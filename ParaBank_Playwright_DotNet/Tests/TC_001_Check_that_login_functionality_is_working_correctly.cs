using ParaBank_Playwright_DotNet.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.Tests
{
    internal class TC_001_Check_that_login_functionality_is_working_correctly:BaseTest
    {
        [Test]

        public async Task TS_001_user_wants_to_login_with_valid_username_and_password()
        {

            LoginPage login = new LoginPage(page);

            await login.EnterUsername("xxx");
            await login.EnterPassword("xxxxxxxxx");
            await login.ClickOnLoginButton();
            bool actualResult = await login.IsAccountOverviewHeaderDisplayed();

            Assert.That(actualResult, Is.True);

        }
    }
}
