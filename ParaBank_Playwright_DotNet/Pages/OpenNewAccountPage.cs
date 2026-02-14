using Microsoft.Playwright;
using ProjectLoggerUtil;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ParaBank_Playwright_DotNet.Pages
{
    internal class OpenNewAccountPage
    {

        IPage page;

        private readonly string OpenNewAccLinkLoc = "//a[normalize-space()='Open New Account']";
        private readonly string TypeDropDownLoc = "//select[@id='type']";
        private readonly string FromAccIdLoc = "//select[@id='fromAccountId']";
        private readonly string OpenButtonLoc = "//input[@value='Open New Account']";
        private readonly string CongratesMsgLoc = "//p[normalize-space()='Congratulations, your account is now open.']";
        private readonly string NewAccIdLoc = "//a[@id='newAccountId']";

        public OpenNewAccountPage(IPage page)
        {
            this.page = page;
        }

        public async Task ClickOnOpenNewAccountLink()
        {
            ExtentReporting.LogInfo("Click on Open New Account Link");
            LoggerUtil.Info("Click on Open New Account Link");

            await page.Locator(OpenNewAccLinkLoc).ClickAsync();

        }

        public async Task SelectAccountType(string AccType)
        {
            ExtentReporting.LogInfo($"Select the account type: {AccType}");
            LoggerUtil.Info($"Select the account type: {AccType}");

            await page.Locator(TypeDropDownLoc).SelectOptionAsync(new[] 
            {  
                new SelectOptionValue(){ Label = AccType }
            
            });

        }

        public async Task SelectFromAccId(int FromAccIndex)
        {

            ExtentReporting.LogInfo($"Select From Account ID: {FromAccIndex}");
            LoggerUtil.Info($"Select From Account ID: {FromAccIndex}");

            await page.Locator(FromAccIdLoc).SelectOptionAsync(new[] 
            { 
                new SelectOptionValue(){ Index = FromAccIndex }
            });

        }

        public async Task ClickOnOpenAccountButton()
        {
            ExtentReporting.LogInfo("Click on open account button");
            LoggerUtil.Info("Click on open account button");

            await page.Locator(OpenButtonLoc).ClickAsync();
        }

        public async Task<bool> IsCongratsMsgVisible()
        {
            ExtentReporting.LogInfo("Checking, Congrates message is visible or not");
            LoggerUtil.Info("Checking, Congrates message is visible or not");

            return await page.Locator(CongratesMsgLoc).IsVisibleAsync();
        }

        public async Task<bool> IsNewAccountNumberVisible()
        {
            ExtentReporting.LogInfo("Checking, New Account Id is visible or not");
            LoggerUtil.Info("Checking, New Account Id is visible or not");

            string accNum = await page.Locator(NewAccIdLoc).TextContentAsync() ?? string.Empty;
            LoggerUtil.Info($"New Account Id/Number: {accNum}");

            return await page.Locator(NewAccIdLoc).IsVisibleAsync();
        }
    }
}
