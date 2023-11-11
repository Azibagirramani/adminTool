//  Console application for database management


using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AdminTool.Controller
{

    public class AdminTool
    {

        public static bool LocalManager()
        {
            return false;
        }

        public static Dictionary<string, string> LoadConfiguration()
        {
            string configPath = @"c:\temp\setting.txt";

            Dictionary<string, string> defaultConfig = new Dictionary<string, string>();


            if (!File.Exists(configPath))
            {
                defaultConfig.Add("is_active", "false");
                defaultConfig.Add("auth_type", "local");
                defaultConfig.Add("is_new", "true");
                Console.WriteLine("Settings up local configs");
                using (StreamWriter sw = new StreamWriter(configPath, true))
                {
                    foreach (var config in defaultConfig)
                    {
                        sw.WriteLine($"{config.Key}={config.Value}");
                    }
                }
            }


            Dictionary<string, string> configFileContent = new Dictionary<string, string>();
            foreach (string line in File.ReadLines(configPath))
            {

                string[] parts = line.Split('=');
                if (parts.Length == 2)
                {
                    configFileContent[parts[0]] = parts[1];
                }
            }


            return configFileContent;
        }
        public static void Main()
        {
            Dictionary<string, string> content = LoadConfiguration();
            string configPath = @"c:\temp\setting.txt";
            if (Convert.ToBoolean(content.GetValueOrDefault("is_new")))
            {

                if (content.GetValueOrDefault("username") != "")
                {
                    Console.WriteLine("Please type in your username");
                    var username = Console.ReadLine();
                    /// write to file
                    using (StreamWriter sw = new StreamWriter(configPath, true))
                    {
                        sw.WriteLine($"username={username}");
                    }


                    string[] readText = File.ReadAllLines(configPath);

                    // 2. Empty the file
                    File.WriteAllText(configPath, string.Empty);

                    // 3. Fill up again, but without the deleted line
                    using (StreamWriter writer = new StreamWriter(configPath))
                    {
                        foreach (string s in readText)
                        {
                            if (!s.Equals("is_new:true"))
                            {
                                writer.WriteLine(s);
                            }
                        }
                    }

                }
            }



        }

    }

}