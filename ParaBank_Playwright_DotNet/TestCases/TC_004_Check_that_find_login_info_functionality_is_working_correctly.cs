using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework.Internal;
using ParaBank_Playwright_DotNet.Pages;
using ProjectLoggerUtil;
using ProjectUtilityExcel;
using ProjectUtilityPaths;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace ParaBank_Playwright_DotNet.TestCases
{
    internal class TC_004_Check_that_find_login_info_functionality_is_working_correctly:BaseTest
    {

        private readonly string excelpath = Paths.DataXLSXPath("ParaBankTestData.xlsx");

        [Test]
        public async Task TS_001_user_wants_to_find_login_info()
        {

            try
            {
                string sheetName = "ForgotLoginInfoData";
                LoggerUtil.Info($"ExcelPath: {excelpath}");
                LoggerUtil.Info($"Excel Sheet Name: {sheetName}");

                ExcelReaderUtil.PopulateInCollection(excelpath, sheetName);

                var rowNumber = Convert.ToInt32(ExcelReaderUtil.ReadData(1, "ConfigRow"));
                string firstName = ExcelReaderUtil.ReadData(rowNumber, "FirstName") ?? string.Empty;
                string lastName = ExcelReaderUtil.ReadData(rowNumber, "LastName") ?? string.Empty;
                string address = ExcelReaderUtil.ReadData(rowNumber, "Address") ?? string.Empty;
                string city = ExcelReaderUtil.ReadData(rowNumber, "City") ?? string.Empty;
                string state = ExcelReaderUtil.ReadData(rowNumber, "State") ?? string.Empty;
                string zip = ExcelReaderUtil.ReadData(rowNumber, "ZipCode") ?? string.Empty;
                string ssn = ExcelReaderUtil.ReadData(rowNumber, "SSN") ?? string.Empty;
                string username = ExcelReaderUtil.ReadData(rowNumber, "Username") ?? string.Empty;
                string password = ExcelReaderUtil.ReadData(rowNumber, "Password") ?? string.Empty;

                ForgotLoginInfoPage forgot = new ForgotLoginInfoPage(page);

                await forgot.ClickOnForgotLink();
                await forgot.EnterFirstName(firstName);
                await forgot.EnterLastName(lastName);
                await forgot.EnterAddress(address);
                await forgot.EnterCity(city);
                await forgot.EnterState(state);
                await forgot.EnterZipCode(zip);
                await forgot.EnterSSN(ssn);
                await forgot.ClickOnFindButton();


                //username = "parasoft";
                //password = "demo";


                bool acutalResult = await forgot.IsLoginInfoVisible(username, password);

                Assert.That(acutalResult, Is.True);
            }
            catch (Exception e)
            {
                ExtentReporting.LogFail(e.Message);
                LoggerUtil.Info(e.Message);

                Assert.Fail();
            }

        }

    }
}
