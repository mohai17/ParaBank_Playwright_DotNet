using ParaBank_Playwright_DotNet.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.TestCases;

internal class TC_001_Check_that_register_functionality_is_working_correctly:BaseTest
{

    [Test]

    public async Task TS_001_user_wants_to_register_with_all_valid_data()
    {

        RegisterPage reg = new RegisterPage(page);

        await reg.ClickOnRegisterLink();
        await reg.EnterFirstName("aaa");
        await reg.EnterLastName("aaa");
        await reg.EnterAddress("aaa");
        await reg.EnterCity("aaa");
        await reg.EnterState("aaa");
        await reg.EnterZipCode("aaa");
        await reg.EnterPhone("1234");
        await reg.EnterSSN("aaa");
        await reg.EnterUserName("aaa");
        await reg.EnterPassword("aaaaaa");
        await reg.EnterConfirmPassword("aaaaaa");
        await reg.ClickOnRegisterButton();

        bool actualResult = await new Dashboard(page).IsRegisterSucceedWelcomeMsgDisplayed();

        Assert.That(actualResult, Is.True);
    }

}
