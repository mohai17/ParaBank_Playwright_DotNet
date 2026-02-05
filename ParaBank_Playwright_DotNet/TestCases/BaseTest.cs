using Microsoft.Playwright;
using ParaBank_Playwright_DotNet.Factories;


namespace ParaBank_Playwright_DotNet.Tests
{
    public class BaseTest
    {
        private PlaywrightFactory factory = default!;
        public IPage page = default!;


        [SetUp]

        public async Task Setup()
        {
            factory = new PlaywrightFactory();
            page = await factory.InitBrowser("Chrome");
        }

        [TearDown]
        
        public async Task TearDown()
        {
            page?.CloseAsync();
            factory.context?.CloseAsync();
            factory.browser?.CloseAsync();
            factory.playwright?.Dispose();
        }

    }
}
