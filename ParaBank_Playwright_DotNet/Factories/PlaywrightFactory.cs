using Microsoft.Playwright;
using ParaBank_Playwright_DotNet.Utils;
using System;


namespace ParaBank_Playwright_DotNet.Factories
{
    public class PlaywrightFactory
    {

        public IPlaywright playwright = default!;
        public IBrowser browser = default!;
        public IBrowserContext context = default!;
        public IPage page = default!;
        private Config config = default!;
      

        public async Task<IPage> InitBrowser(string browserName)
        {
            config = new Config();
            bool? headless = config?.BrowserSettings?.Headless ?? false;
            int? slomotion = config?.BrowserSettings?.Slowmotion ?? 0;
            int? timeout = config?.BrowserSettings?.Timeout ?? 30;
            string URL = config?.BrowserSettings?.URL ?? "Unknown";


            playwright = await Playwright.CreateAsync();

            switch (browserName.ToLower())
            {
                case "chrome":
                    browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = headless,
                        Channel = browserName,
                        Timeout = timeout
                        
                    });
                    break;

                case "edge":
                    browser = await playwright.Chromium.LaunchAsync(new()
                    {
                        Headless = false,
                        Channel = "msedge"

                    });
                    break;

                case "firefox":
                    browser = await playwright.Firefox.LaunchAsync(new()
                    {
                        Headless = false
                    });
                    break;

                case "safari":
                    browser = await playwright.Webkit.LaunchAsync(new()
                    {
                        Headless = false
                    });
                    break;

                case "chromium":
                    browser = await playwright.Chromium.LaunchAsync(new()
                    {
                        Headless = false
                    });
                    break;

                default:
                    Console.WriteLine("Incorrect Browser Name.");
                    break;
            }

            context = await browser.NewContextAsync();
            page = await browser.NewPageAsync();

            await page.GotoAsync(URL);

            return page;

        }

    }
}
