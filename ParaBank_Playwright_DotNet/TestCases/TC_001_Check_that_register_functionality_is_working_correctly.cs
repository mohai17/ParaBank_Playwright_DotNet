using ParaBank_Playwright_DotNet.Pages;
using ProjectLoggerUtil;
using ProjectUtilityExcel;
using ProjectUtilityPaths;
using ProjectUtilityReporting;


namespace ParaBank_Playwright_DotNet.TestCases;

internal class TC_001_Check_that_register_functionality_is_working_correctly:BaseTest
{
    private readonly string excelpath = Paths.DataXLSXPath("ParaBankTestData.xlsx");

    [Test]

    public async Task TS_001_user_wants_to_register_with_all_valid_data()
    {
        try
        {
            ExcelReaderUtil.PopulateInCollection(excelpath, "RegisterData");
            var rowNumber = 3;
            var firstName = ExcelReaderUtil.ReadData(rowNumber, "FirstName") ?? string.Empty;
            var lastName = ExcelReaderUtil.ReadData(rowNumber, "LastName") ?? string.Empty;
            var address = ExcelReaderUtil.ReadData(rowNumber, "Address") ?? string.Empty;
            var city = ExcelReaderUtil.ReadData(rowNumber, "City") ?? string.Empty;
            var state = ExcelReaderUtil.ReadData(rowNumber, "State") ?? string.Empty;
            var zipCode = ExcelReaderUtil.ReadData(rowNumber, "ZipCode") ?? string.Empty;
            var phone = ExcelReaderUtil.ReadData(rowNumber, "Phone") ?? string.Empty;
            var ssn = ExcelReaderUtil.ReadData(rowNumber, "SSN") ?? string.Empty;
            var username = ExcelReaderUtil.ReadData(rowNumber, "Username") ?? string.Empty;
            var password = ExcelReaderUtil.ReadData(rowNumber, "Password") ?? string.Empty;
            var cpassword = ExcelReaderUtil.ReadData(rowNumber, "ConfirmPassword") ?? string.Empty;


            RegisterPage reg = new RegisterPage(page);

            await reg.ClickOnRegisterLink();
            await reg.EnterFirstName(firstName);
            await reg.EnterLastName(lastName);
            await reg.EnterAddress(address);
            await reg.EnterCity(city);
            await reg.EnterState(state);
            await reg.EnterZipCode(zipCode);
            await reg.EnterPhone(phone);
            await reg.EnterSSN(ssn);
            await reg.EnterUserName(username);
            await reg.EnterPassword(password);
            await reg.EnterConfirmPassword(cpassword);
            await reg.ClickOnRegisterButton();

            bool actualResult = await new Dashboard(page).IsRegisterSucceedWelcomeMsgDisplayed();

            Assert.That(actualResult, Is.True);
        }
        catch (Exception e)
        {

            LoggerUtil.Error(e.Message);
         
        }
    }

}
