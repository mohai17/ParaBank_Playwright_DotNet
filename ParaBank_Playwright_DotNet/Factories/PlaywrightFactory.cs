using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.Factories
{
    public class PlaywrightFactory
    {

        public IPlaywright playwright = default!;
        public IBrowser browser = default!;
        public IBrowserContext context = default!;
        public IPage page = default!;

        public async Task<IPage> InitBrowser(string browserName)
        {
            Console.WriteLine("Browser name: " + browserName);

            playwright = await Playwright.CreateAsync();

            switch (browserName.ToLower())
            {
                case "chrome":
                    browser = await playwright.Chromium.LaunchAsync(new()
                    {
                        Headless = false,
                        Channel = "chrome"

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

            await page.GotoAsync("https://parabank.parasoft.com/parabank/index.htm");

            return page;

        }

    }
}
