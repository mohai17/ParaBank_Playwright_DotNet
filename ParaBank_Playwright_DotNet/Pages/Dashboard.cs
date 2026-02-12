using Microsoft.Playwright;
using ProjectLoggerUtil;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.Pages
{
    internal class Dashboard
    {

        IPage page = default!;

        private readonly string accountOverviewHeader = "(//h1[@class='title'])[1]";
        private readonly string registerSucceedWelcomeMsg = "//h1[@class='title']";
        private readonly string logoutLinkLoc = "//a[normalize-space()='Log Out']";

        public Dashboard(IPage page)
        {
            this.page = page;
        }

        public async Task<bool> IsAccountOverviewHeaderDisplayed()
        {
            ExtentReporting.LogInfo("Checking, Account Overview Header is displaying or not");
            LoggerUtil.Info("Checking, Account Overview Header is displaying or not");

            string text = await page.Locator(accountOverviewHeader).InnerTextAsync() ?? string.Empty;
            text.Trim();
            return text.Equals("Accounts Overview");

        }

        public async Task<bool> IsRegisterSucceedWelcomeMsgDisplayed()
        {
            ExtentReporting.LogInfo("Checking, Welcome Message after registration is displaying or not");
            LoggerUtil.Info("Checking, Welcome Message after registration is displaying or not");

            string text = await page.Locator(registerSucceedWelcomeMsg).InnerTextAsync() ?? string.Empty;
            text.Trim();
            return text.Contains("Welcome");
        }

        public async Task ClickOnLogoutLink()
        {
            ExtentReporting.LogInfo("Click on the logout link");
            LoggerUtil.Info("Click on the logout link");

            try
            {
                await page.Locator(logoutLinkLoc).ClickAsync();
            }
            catch (Exception e)
            { 
                LoggerUtil.Error(e.Message);
                ExtentReporting.LogFail(e.Message);
               
            }
        }
    }
}
