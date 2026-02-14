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

        private readonly string excelpath = Paths.DataXLSXPath("ParaBankTestData.xlsx");

        [Test]
        public async Task TS_001_user_wants_to_open_a_new_account()
        {
            try
            {
                string sheetName = "OpenNewAccountData";
                LoggerUtil.Info($"ExcelPath: {excelpath}");
                LoggerUtil.Info($"Excel Sheet Name: {sheetName}");

                int rowNumber = Convert.ToInt32(ExcelReaderUtil.ReadData(1,"ConfigRow"));
                string username = ExcelReaderUtil.ReadData(rowNumber, "Username") ?? string.Empty;
                string password = ExcelReaderUtil.ReadData(rowNumber, "Password") ?? string.Empty;
                string accountType = ExcelReaderUtil.ReadData(rowNumber, "AccountType") ?? string.Empty;
                int accountID = Convert.ToInt32(ExcelReaderUtil.ReadData(rowNumber, "AccountID"));

                LoginPage login = new LoginPage(page);
                await login.EnterUsername(username);
                await login.EnterPassword(password);
                await login.ClickOnLoginButton();

                OpenNewAccountPage openAcc = new OpenNewAccountPage(page);

                await openAcc.ClickOnOpenNewAccountLink();
                await openAcc.SelectAccountType(accountType);
                await openAcc.SelectFromAccId(accountID);
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
