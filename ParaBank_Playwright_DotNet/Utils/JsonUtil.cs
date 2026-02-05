using System;
using System.IO;
using System.Text.Json;

namespace ParaBank_Playwright_DotNet.Utils
{
    public class BrowserSettings
    {
        public string? BrowserName { get; set; }
        public bool Headless { get; set; }
        public int Slowmotion { get; set; }
        public int Timeout { get; set; }
        public string? URL { get; set; }
    }

    public class Config
    {
        public BrowserSettings? BrowserSettings { get; set; }
    }

    internal class JSONUtil
    {
        private readonly string _configPath =
            "C:\\Users\\mohai\\source\\repos\\ParaBank_Playwright_DotNet\\ParaBank_Playwright_DotNet\\Resources\\Config\\BrowserConfig.json";

        public Config LoadConfig()
        {
            try
            {
                string jsonFile = File.ReadAllText(_configPath);

                Config? jsonData = JsonSerializer.Deserialize<Config>(jsonFile);

                return jsonData ?? new Config();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading config: {ex.Message}");
                return new Config();
            }
        }
    }
}