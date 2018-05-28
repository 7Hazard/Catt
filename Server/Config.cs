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
        static Config config = JsonConvert.DeserializeObject<Config>(ReadConfig());

        static string ReadConfig()
        {
            try
            {
                return File.ReadAllText("config.json");
            }
            catch (Exception)
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
        Config()
        {
            host = "localhost";
            port = 6969;
        }

        public string host;
        public int port;
    }
}
