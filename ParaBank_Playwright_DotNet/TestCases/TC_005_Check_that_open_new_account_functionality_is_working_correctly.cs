using ParaBank_Playwright_DotNet.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.TestCases
{
    internal class TC_005_Check_that_open_new_account_functionality_is_working_correctly:BaseTest
    {
        [Test]
        public async Task TS_001_user_wants_to_open_a_new_account()
        {

            LoginPage login = new LoginPage(page);
            await login.EnterUsername("parasoft");
            await login.EnterPassword("demo");
            await login.ClickOnLoginButton();

            OpenNewAccountPage openAcc = new OpenNewAccountPage(page);

            await openAcc.ClickOnOpenNewAccountLink();
            await openAcc.SelectAccountType("SAVINGS");
            await openAcc.SelectFromAccId(0);
            await openAcc.ClickOnOpenAccountButton();
            
            bool actualResult = await openAcc.IsNewAccountNumberVisible();

            Assert.That(actualResult, Is.True);
        }

    }
}
