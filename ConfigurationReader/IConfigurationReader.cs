using System;
using System.Collections.Generic;
using System.Text;

namespace Reader
{
    public interface IConfigurationReader
    {
        T GetValue<T>(string key);
    }
}
