using Microsoft.Playwright;
using NUnit.Framework.Internal;
using ProjectLoggerUtil;
using ProjectUtilityReporting;


namespace ParaBank_Playwright_DotNet.Pages
{
    public class LoginPage
    {
        public IPage page = default!;

        private readonly string usernameLoc = "//input[@name='username']";
        private readonly string passwordLoc = "//input[@name='password']";
        private readonly string loginButtonLoc = "//input[@value='Log In']";
        private readonly string customerLoginHeaderLoc = "//h2[normalize-space()='Customer Login']";

        public LoginPage(IPage page)
        {
            this.page = page;
        }

        public async Task EnterUsername(string username)
        {
            ExtentReporting.LogInfo($"Enter the username: {username}");
            LoggerUtil.Info($"Enter the username: {username}");

            await page.Locator(usernameLoc).FillAsync(username);
        }

        public async Task EnterPassword(string password)
        {
            ExtentReporting.LogInfo($"Enter the password: {password}");
            LoggerUtil.Info($"Enter the password: {password}");

            await page.Locator(passwordLoc).FillAsync(password);
        }

        public async Task ClickOnLoginButton()
        {
            ExtentReporting.LogInfo("Click on the login button.");
            LoggerUtil.Info("Click on the login button");

            await page.Locator(loginButtonLoc).ClickAsync();
        }

        public async Task<bool> IsCustomerLoginVisible()
        {
            ExtentReporting.LogInfo("Checking, Customer Login Header is visible or not.");
            LoggerUtil.Info("Checking, Customer Login Header is visible or not.");

            return await page.Locator(customerLoginHeaderLoc).IsVisibleAsync();
        }



    }
}
