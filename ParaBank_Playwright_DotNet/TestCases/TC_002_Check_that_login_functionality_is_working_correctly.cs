using ParaBank_Playwright_DotNet.Pages;
using ProjectLoggerUtil;
using ProjectUtilityExcel;
using ProjectUtilityPaths;


namespace ParaBank_Playwright_DotNet.TestCases;

internal class TC_002_Check_that_login_functionality_is_working_correctly:BaseTest
{

    private readonly string excelpath = Paths.DataXLSXPath("ParaBankTestData.xlsx");

    [Test]

    public async Task TS_001_user_wants_to_login_with_valid_username_and_password()
    {

        try
        {
            ExcelReaderUtil.PopulateInCollection(excelpath, "RegisterData");
            var rowNumber = 3;
            string username = ExcelReaderUtil.ReadData(rowNumber, "Username") ?? string.Empty;
            string password = ExcelReaderUtil.ReadData(rowNumber, "Password") ?? string.Empty;

            LoginPage login = new LoginPage(page);

            await login.EnterUsername(username);
            await login.EnterPassword(password);
            await login.ClickOnLoginButton();

            Dashboard dash = new Dashboard(page);

            bool actualResult = await dash.IsAccountOverviewHeaderDisplayed();

            Assert.That(actualResult, Is.True);
        }
        catch (Exception e)
        {

            LoggerUtil.Error(e.Message);
         
        }

    }
}
