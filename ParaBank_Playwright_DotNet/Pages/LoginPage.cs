using Microsoft.Playwright;


namespace ParaBank_Playwright_DotNet.Pages
{
    public class LoginPage
    {
        public IPage page = default!;

        private readonly string usernameLoc = "//input[@name='username']";
        private readonly string passwordLoc = "//input[@name='password']";
        private readonly string loginButtonLoc = "//input[@value='Log In']";
        private readonly string accountOverviewHeader = "(//h1[@class='title'])[1]";

        public LoginPage(IPage page)
        {
            this.page = page;
        }

        public async Task EnterUsername(string username)
        {
            await page.Locator(usernameLoc).FillAsync(username);
        }

        public async Task EnterPassword(string password)
        {
            await page.Locator(passwordLoc).FillAsync(password);
        }

        public async Task ClickOnLoginButton()
        {
            await page.Locator(loginButtonLoc).ClickAsync();
        }

        public async Task<bool> IsAccountOverviewHeaderDisplayed()
        {
            string text = await page.Locator(accountOverviewHeader).InnerTextAsync() ?? string.Empty;
            text.Trim();
            return text.Equals("Accounts Overview");

        }

    }
}
