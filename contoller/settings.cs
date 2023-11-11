namespace AdminTool.Controller
{

    public class Settings
    {
        public static void LoadConfiguration()
        {
            string configPath = @"c:\temp\setting.txt";

            Dictionary<string, string> defaultConfig = new Dictionary<string, string>();

            defaultConfig.Add("is_active", "false");


            if (!File.Exists(configPath))
            {
                using (StreamWriter sw = File.CreateText(configPath))
                {
                    foreach (var config in defaultConfig)
                    {
                        sw.WriteLine($"{config.Key}={config.Value}");
                        Console.WriteLine("Writing");
                    }
                }
            }
        }

        public void Dialog()
        {
            throw new NotImplementedException();
        }


    }

}