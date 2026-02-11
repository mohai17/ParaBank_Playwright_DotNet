using Microsoft.Playwright;
using NUnit.Framework.Interfaces;
using ParaBank_Playwright_DotNet.Factories;
using ProjectUtilityJSON;
using ProjectUtilityReporting;
using ProjectUtilityScreenShot;
using System.Security.Policy;


namespace ParaBank_Playwright_DotNet.TestCases;

public class BaseTest
{
    private PlaywrightFactory factory = default!;
    public IPage page = default!;
    private JSONUtil config = default!;

    [SetUp]

    public async Task Setup()
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        config = new JSONUtil();
        string browserName = config?.LoadConfig()?.BrowserSettings?.BrowserName ?? string.Empty;
        Console.WriteLine(browserName);


        string projectName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name ?? string.Empty;
        var fullName = TestContext.CurrentContext.Test.ClassName;
        var className = fullName?.Split('.').Last();
        var methodName = TestContext.CurrentContext.Test.MethodName;

        ExtentReporting.CreateTest($"{projectName}_Report.html", $"{className ?? "Unknown"}-{methodName ?? "Unknown"}");

        ExtentReporting.LogInfo("Browser Setup is started.");

        factory = new PlaywrightFactory();
        page = await factory.InitBrowser(browserName);

        var url = config?.LoadConfig()?.BrowserSettings?.URL ?? string.Empty;
       
        ExtentReporting.LogInfo("Browser Setup is finished.");

        ExtentReporting.LogInfo($"Goto the url: {url}");

    }

    [TearDown]
    
    public async Task TearDown()
    {
        await EndTest();
        ExtentReporting.EndReporting();

        page?.CloseAsync();
        factory.context?.CloseAsync();
        factory.browser?.CloseAsync();
        factory.playwright?.Dispose();
    }

    private async Task EndTest()
    {
        var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        var message = TestContext.CurrentContext.Result.Message;

        switch (testStatus)
        {
            case TestStatus.Failed:
                ExtentReporting.LogFail($"Test has failed: {message}");
                break;
            case TestStatus.Skipped:
                ExtentReporting.LogInfo($"Test has skipped: {message}");
                break;
            case TestStatus.Passed:
                ExtentReporting.LogPass("Test passed successfully");
                break;
        }

        ExtentReporting.LogScreenshot("Ending Test", await ScreenshotHelper.TakeScreenshotAsync(page, "Element"));

    }


}
