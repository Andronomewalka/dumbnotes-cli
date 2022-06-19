using Newtonsoft.Json;

namespace BlogAppCli
{
    public class Config
    {
        public Folders Folders { get; set; }
        public List<Script> Scripts { get; set; }   

        private static readonly string configPath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\config.json";

        private Config() 
        {
            Folders = new Folders();
            Scripts = new List<Script>();
        }
       
        public static async Task<Config> ReadConfig()
        {
            try
            {
                string jsonContent = await File.ReadAllTextAsync(configPath);
                Config config = JsonConvert.DeserializeObject<Config>(jsonContent) ?? new Config();
                FillScriptDestinations(config);
                return config;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("no config.json found");
            }
            return new Config();
        }

        private static void FillScriptDestinations(Config config)
        {
            config.Scripts.ForEach(PlaceDestination);


            void PlaceDestination(Script script)
            {
                script.Command = script.Command.Replace("{clientDestination}", config.Folders.Client);
                script.Command = script.Command.Replace("{adminDestination}", config.Folders.Admin);
                script.Command = script.Command.Replace("{apiDestination}", config.Folders.Api);
            }
        }
    }
}
