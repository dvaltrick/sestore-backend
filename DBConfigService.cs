using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using softstoreapi.Models;

namespace softstoreapi
{
    public static class DBConfigService
    {
        public static DBConfig Carregar()
        {
            var data = File.ReadAllText("dbconfig.json");

            var config = JsonConvert.DeserializeObject<DBConfig>(data);

            return config;
        }
    }
}
