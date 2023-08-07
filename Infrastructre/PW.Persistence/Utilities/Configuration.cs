using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.Persistence.Utilities
{
    public static class Configuration
    {
        private static ConfigurationManager ConfigurationManager
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/PW.Web"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager;
            }
        }
        public static string ConnectionString
        {

            get
            {
                return ConfigurationManager.GetConnectionString("PWDbConnection");
            }

        }
    }
}
