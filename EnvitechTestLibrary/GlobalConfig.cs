using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace EnvitechTestLibrary
{
    public static class GlobalConfig
    {
        public static string CnnString(string name) //takes the name of a db from app.config and uses it's ConnectionString
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
