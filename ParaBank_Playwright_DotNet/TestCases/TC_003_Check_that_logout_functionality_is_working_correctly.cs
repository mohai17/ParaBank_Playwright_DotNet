using ParaBank_Playwright_DotNet.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.TestCases
{
    internal class TC_003_Check_that_logout_functionality_is_working_correctly:BaseTest
    {
        [Test]
        public async Task TS_001_user_wants_to_logout()
        {
            LoginPage login = new LoginPage(page);

            await login.EnterUsername("aaa");
            await login.EnterPassword("aaaaaa");
            await login.ClickOnLoginButton();

            Dashboard dash = new Dashboard(page);

            await dash.ClickOnLogoutLink();

            bool actualResult = await login.IsCustomerLoginVisible();

            Assert.That(actualResult, Is.True);
        }

    }
}
