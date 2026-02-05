using ParaBank_Playwright_DotNet.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.TestCases;

internal class TC_002_Check_that_login_functionality_is_working_correctly:BaseTest
{
    [Test]

    public async Task TS_001_user_wants_to_login_with_valid_username_and_password()
    {

        LoginPage login = new LoginPage(page);

        await login.EnterUsername("aaa");
        await login.EnterPassword("aaaaaa");
        await login.ClickOnLoginButton();

        Dashboard dash = new Dashboard(page);

        bool actualResult = await dash.IsAccountOverviewHeaderDisplayed();

        Assert.That(actualResult, Is.True);

    }
}
