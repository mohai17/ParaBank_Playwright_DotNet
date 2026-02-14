using ParaBank_Playwright_DotNet.Pages;
using ProjectLoggerUtil;
using ProjectUtilityExcel;
using ProjectUtilityPaths;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.TestCases
{
    internal class TC_005_Check_that_open_new_account_functionality_is_working_correctly:BaseTest
    {

        private readonly string excelPath = Paths.DataXLSXPath("ParaBankTestData.xlsx");

        [Test]
        public async Task TS_001_user_wants_to_open_a_new_account()
        {
            try
            {
                LoggerUtil.Info($"ExcelPath:{excelPath}");
                ExcelReaderUtil.PopulateInCollection(excelPath, "RegisterData");

                int rowNumber = 1;
                string username = ExcelReaderUtil.ReadData(rowNumber, "Username") ?? string.Empty;
                string password = ExcelReaderUtil.ReadData(rowNumber, "Password") ?? string.Empty;

                username = "parasoft";
                password = "demo";

                LoginPage login = new LoginPage(page);
                await login.EnterUsername(username);
                await login.EnterPassword(password);
                await login.ClickOnLoginButton();

                OpenNewAccountPage openAcc = new OpenNewAccountPage(page);

                await openAcc.ClickOnOpenNewAccountLink();
                await openAcc.SelectAccountType("SAVINGS");
                await openAcc.SelectFromAccId(0);
                await openAcc.ClickOnOpenAccountButton();

                bool actualResult = await openAcc.IsNewAccountNumberVisible();

                Assert.That(actualResult, Is.True);
            }
            catch (Exception e)
            {

                ExtentReporting.LogInfo(e.Message);
                LoggerUtil.Error(e.Message);
                Assert.Fail();

            }
        }

    }
}
