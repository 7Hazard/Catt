using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Server
{
    public class Config
    {
        // Statics
        static Config config = JsonConvert.DeserializeObject<Config>(ReadConfig()); // Deserialize config on start

        static string ReadConfig()
        {
            try // to read config.json if exists
            {
                return File.ReadAllText("config.json");
            }
            catch // else returns empty object
            {
                return "{}";
            }
        }

        public static string Host
        {
            get
            {
                return config.host;
            }
        }

        public static int Port
        {
            get
            {
                return config.port;
            }
        }

        // Members
        Config() // Default config values
        {
            host = "0.0.0.0";
            port = 6969;
        }

        public string host;
        public int port;
    }
}
