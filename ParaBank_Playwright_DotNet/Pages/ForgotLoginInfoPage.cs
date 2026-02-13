using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Playwright;
using ProjectLoggerUtil;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.Pages
{
    internal class ForgotLoginInfoPage
    {

        IPage page = default!;

        private readonly string forgotLinkLoc = "//a[normalize-space()='Forgot login info?']";
        private readonly string firstNameLoc = "//input[@id='firstName']";
        private readonly string lastNameLoc = "//input[@id='lastName']";
        private readonly string addressLoc = "//input[@id='address.street']";
        private readonly string cityLoc = "//input[@id='address.city']";
        private readonly string stateLoc = "//input[@id='address.state']";
        private readonly string zipCodeLoc = "//input[@id='address.zipCode']";
        private readonly string ssnLoc = "//input[@id='ssn']";
        private readonly string findButtonLoc = "//input[@value='Find My Login Info']";
        private readonly string userNameLoc = "(//b[normalize-space()='Username']/following-sibling::text())[1]";
        private readonly string passwordLoc = "(//b[normalize-space()='Username']/following-sibling::text())[3]";

        public ForgotLoginInfoPage(IPage page)
        {
            this.page = page;
        }

        public async Task ClickOnForgotLink()
        {
            ExtentReporting.LogInfo("Click on forgot login info link");
            LoggerUtil.Info("Click on forgot login info link");

            await page.Locator(forgotLinkLoc).ClickAsync();
        }

        public async Task EnterFirstName(string firstname)
        {
            ExtentReporting.LogInfo($"Enter first name: {firstname}");
            LoggerUtil.Info($"Enter first name: {firstname}");

            await page.Locator(firstNameLoc).FillAsync(firstname);
        }

        public async Task EnterLastName(string lastname)
        {
            ExtentReporting.LogInfo($"Enter last name: {lastname}");
            LoggerUtil.Info($"Enter last name: {lastname}");

            await page.Locator(lastNameLoc).FillAsync(lastname);
        }

        public async Task EnterAddress(string address)
        {
            ExtentReporting.LogInfo($"Enter address: {address}");
            LoggerUtil.Info($"Enter address: {address}");

            await page.Locator(addressLoc).FillAsync(address);
        }

        public async Task EnterCity(string city)
        {
            ExtentReporting.LogInfo($"Enter city name: {city}");
            LoggerUtil.Info($"Enter city name: {city}");

            await page.Locator(cityLoc).FillAsync(city);
        }

        public async Task EnterState(string state)
        {

            ExtentReporting.LogInfo($"Enter state name: {state}");
            LoggerUtil.Info($"Enter state name: {state}");

            await page.Locator(stateLoc).FillAsync(state);

        }

        public async Task EnterZipCode(string zipCode)
        {
            ExtentReporting.LogInfo($"Enter the zip code: {zipCode}");
            LoggerUtil.Info($"Enter the zip code: {zipCode}");

            await page.Locator(zipCodeLoc).FillAsync(zipCode);
        }

        public async Task EnterSSN(string ssn)
        {
            ExtentReporting.LogInfo($"Enter the SSN: {ssn}");
            LoggerUtil.Info($"Enter the SSN: {ssn}");

            await page.Locator(ssnLoc).FillAsync(ssn);
        }

        public async Task ClickOnFindButton()
        {
            ExtentReporting.LogInfo("Click on 'Find My Login Info' button");
            LoggerUtil.Info("Click on 'Find My Login Info' button");

            await page.Locator(findButtonLoc).ClickAsync();
        }

        public async Task<bool> IsLoginInfoVisible(string username, string password)
        {
            ExtentReporting.LogInfo("Checking, Login info is visible or not");
            LoggerUtil.Info("Checking, Login info is visible or not");

            var user = await page.Locator(userNameLoc).InnerTextAsync();
            var pass = await page.Locator(passwordLoc).InnerTextAsync();

            Console.WriteLine($"Username: {user}");
            Console.WriteLine($"Password: {pass}");


            if (user.Equals(username) && pass.Equals(password))
            {
                return true;
            }

            return false;
        }
    }
}
