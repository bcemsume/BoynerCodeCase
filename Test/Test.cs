using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reader;
using Service;
using System.Threading.Tasks;
using SimpleInjector;
using Core.MessageBroker.Abstract;
using Core.MessageBroker.Concrete;
using Core.CacheManager.Abstract;
using Core.CacheManager.Concrete;

namespace Test
{
    [TestClass]
    public class Test
    {
        const string Name = "SiteName";
        const string Type = "String";
        const string Value = "boyner.com.tr";
        const bool IsActive = false;
        const string ApplicationName = "SERVICE-A";

        const string MQTestPublishMessage = "test message";
        const string MQTestPublishQueueName = "test";

        public Test()
        {

        }

        [TestMethod]
        public async Task GetTest()
        {

            var repository = new Mock<IConfigDal>();

            repository.Setup(x => x.GetAsync(z => z.Name.Equals(Name))).Returns(Task.FromResult(new Config
            {
                Value = Value,
                ApplicationName = ApplicationName,
                IsActive = IsActive,
                Name = Name,
                Type = Type
            }));

            var service = new ConfigService(repository.Object);

            var customer = (await service.GetAsync(z => z.Name.Equals(Name)));

            Assert.IsTrue(customer != null);
            Assert.IsTrue(customer.Name == Name);
            Assert.IsTrue(customer.ApplicationName == ApplicationName);
        }

        [TestMethod]
        public async Task AddTest()
        {

            var config = new Config { ApplicationName = ApplicationName, IsActive = IsActive, Name = Name, Type = Type, Value = Value };
            var repository = new Mock<IConfigDal>();


            var service = new ConfigService(repository.Object);

            await service.AddAsync(config);

            repository.Verify(x => x.AddAsync(config));

        }

        [TestMethod]
        public void RediSetKeyTest()
        {
            var container = new Container();
            container.Register<ICacheManager, RedisCacheManager>();

            container.Verify();

            var cacheManager = container.GetInstance<ICacheManager>();

            cacheManager.SetValue(Name, Value);

        }

        [TestMethod]
        public async Task RediSetKeyTestAsync()
        {
            var container = new Container();
            container.Register<ICacheManager, RedisCacheManager>();

            container.Verify();

            var cacheManager = container.GetInstance<ICacheManager>();

            await cacheManager.SetValueAsync(Name, Value);

        }


        [TestMethod]
        public void RedisGetValueTest()
        {
            var container = new Container();
            container.Register<ICacheManager, RedisCacheManager>();

            container.Verify();

            var cacheManager = container.GetInstance<ICacheManager>();

            var value = cacheManager.GetValue(Name);

            Assert.IsTrue(value.ToString() == Value);

        }

        [TestMethod]
        public async Task RedisGetValueTestAsync()
        {
            var container = new Container();
            container.Register<ICacheManager, RedisCacheManager>();

            container.Verify();

            var cacheManager = container.GetInstance<ICacheManager>();

            var value = await cacheManager.GetValueAsync(Name);

            Assert.IsTrue(value.ToString() == Value);

        }

        [TestMethod]
        public void ReaderTest()
        {
            var reader = new ConfigurationReader("", "", 1);

            var result = reader.GetValue<string>("test");
        }

        [TestMethod]
        public void MQPublishTest()
        {
            var container = new Container();
            container.Register<IMessageBroker, RabbitMQMessageBroker>();

            container.Verify();

            var messageBroker = container.GetInstance<IMessageBroker>();

            messageBroker.Publisher(MQTestPublishQueueName, MQTestPublishMessage);

        }

        [TestMethod]
        public void MQConsumerTest()
        {
            var container = new Container();
            container.Register<IMessageBroker, RabbitMQMessageBroker>();

            container.Verify();

            var messageBroker = container.GetInstance<IMessageBroker>();

            messageBroker.Consumer(MQTestPublishQueueName);
        }
    }
}
