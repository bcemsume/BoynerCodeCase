using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Reader;
using Service;
using System.Threading.Tasks;

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
        public void ReaderTest()
        {
            var reader = new ConfigurationReader("", "", 1);

            reader.Get();
        }
    }
}
