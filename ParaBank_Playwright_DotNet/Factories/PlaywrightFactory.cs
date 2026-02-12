using Microsoft.Playwright;
using ProjectUtilityJSON;


namespace ParaBank_Playwright_DotNet.Factories
{
    public class PlaywrightFactory
    {

        public IPlaywright playwright = default!;
        public IBrowser browser = default!;
        public IBrowserContext context = default!;
        public IPage page = default!;
        private JSONUtil config = default!;
      

        public async Task<IPage> InitBrowser(string browserName)
        {
            config = new JSONUtil();
            bool? headless = config?.LoadConfig()?.BrowserSettings?.Headless ?? default;
            int? slomotion = config?.LoadConfig()?.BrowserSettings?.Slowmotion ?? default;
            int? timeout = config?.LoadConfig()?.BrowserSettings?.Timeout ?? default;
            string URL = config?.LoadConfig()?.BrowserSettings?.URL ?? string.Empty;


            playwright = await Playwright.CreateAsync();

            switch (browserName.ToLower())
            {
                case "chrome":
                    browser = await playwright.Chromium.LaunchAsync(new()
                    {           
                        Channel = "chrome",
                        Headless = headless,
                        SlowMo = slomotion,
                        Timeout = timeout
                        
                    });
                    break;

                case "edge":
                    browser = await playwright.Chromium.LaunchAsync(new()
                    {
           
                        Channel = "msedge",
                        Headless = headless,
                        SlowMo = slomotion,
                        Timeout = timeout

                    });
                    break;

                case "firefox":
                    browser = await playwright.Firefox.LaunchAsync(new()
                    {
                        Headless = headless,
                        SlowMo = slomotion,
                        Timeout = timeout
                    });
                    break;

                case "safari":
                    browser = await playwright.Webkit.LaunchAsync(new()
                    {
                        Headless = headless,
                        SlowMo = slomotion,
                        Timeout = timeout
                    });
                    break;

                case "chromium":
                    browser = await playwright.Chromium.LaunchAsync(new()
                    {
                        Headless = headless,
                        SlowMo = slomotion,
                        Timeout = timeout
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
