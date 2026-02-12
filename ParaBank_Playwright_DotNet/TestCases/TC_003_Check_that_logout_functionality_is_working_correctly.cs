using ParaBank_Playwright_DotNet.Pages;
using ProjectLoggerUtil;
using ProjectUtilityExcel;
using ProjectUtilityPaths;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.TestCases
{
    internal class TC_003_Check_that_logout_functionality_is_working_correctly:BaseTest
    {

        private readonly string excelpath = Paths.DataXLSXPath("ParaBankTestData.xlsx");

        [Test]
        public async Task TS_001_user_wants_to_logout()
        {
            try
            {
                ExcelReaderUtil.PopulateInCollection(excelpath, "RegisterData");
                var rowNumber = 5;
                string username = ExcelReaderUtil.ReadData(rowNumber, "Username") ?? string.Empty;
                string password = ExcelReaderUtil.ReadData(rowNumber, "Password") ?? string.Empty;

                LoginPage login = new LoginPage(page);

                await login.EnterUsername(username);
                await login.EnterPassword(password);
                await login.ClickOnLoginButton();

                Dashboard dash = new Dashboard(page);

           
                await dash.ClickOnLogoutLink();
                

                bool actualResult = await login.IsCustomerLoginVisible();

                Assert.That(actualResult, Is.True);
            }
            catch (Exception e)
            {

                LoggerUtil.Error(e.Message);
            }
        }

    }
}
