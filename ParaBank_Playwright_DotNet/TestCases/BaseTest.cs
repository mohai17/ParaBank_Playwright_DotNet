using Microsoft.Playwright;
using ParaBank_Playwright_DotNet.Factories;
using ParaBank_Playwright_DotNet.Utils;


namespace ParaBank_Playwright_DotNet.TestCases;

public class BaseTest
{
    private PlaywrightFactory factory = default!;
    public IPage page = default!;
    private JSONUtil config = default!;

    [SetUp]

    public async Task Setup()
    {
        config = new JSONUtil();
        string browserName = config?.LoadConfig()?.BrowserSettings?.BrowserName ?? string.Empty;
        Console.WriteLine(browserName);

        factory = new PlaywrightFactory();
        page = await factory.InitBrowser(browserName);

        
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
