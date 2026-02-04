using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.Pages
{
    public class LoginPage
    {
        public IPage page = default!;

        private readonly string usernameLoc = "//input[@name='username']";
        private readonly string passwordLoc = "//input[@name='password']";
        private readonly string loginButtonLoc = "//input[@value='Log In']";

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

    }
}
