using Microsoft.Playwright;
using ProjectLoggerUtil;
using ProjectUtilityReporting;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ParaBank_Playwright_DotNet.Pages
{

    internal class RegisterPage
    {
        IPage page = default!;

        private readonly string registerLinkLoc = "//a[normalize-space()='Register']" ?? string.Empty;
        private readonly string firstNameLoc = "//input[@id='customer.firstName']" ?? string.Empty;
        private readonly string lastNameLoc = "//input[@id='customer.lastName']" ?? string.Empty;
        private readonly string addressLoc = "//input[@id='customer.address.street']" ?? string.Empty;
        private readonly string cityLoc = "//input[@id='customer.address.city']" ?? string.Empty;
        private readonly string stateLoc = "//input[@id='customer.address.state']" ?? string.Empty;
        private readonly string zipCodeLoc = "//input[@id='customer.address.zipCode']" ?? string.Empty;
        private readonly string phoneLoc = "//input[@id='customer.phoneNumber']" ?? string.Empty;
        private readonly string ssnLoc = "//input[@id='customer.ssn']" ?? string.Empty;
        private readonly string usernameLoc = "//input[@id='customer.username']" ?? string.Empty;
        private readonly string passwordLoc = "//input[@id='customer.password']" ?? string.Empty;
        private readonly string cPasswordLoc = "//input[@id='repeatedPassword']" ?? string.Empty;
        private readonly string registerButtonLoc = "//input[@value='Register']" ?? string.Empty;
 
        public RegisterPage(IPage page)
        {
            this.page = page;
        }

        public async Task ClickOnRegisterLink()
        {
            ExtentReporting.LogInfo("Click on the registration link.");
            LoggerUtil.Info("Click on the registration link.");

            await page.Locator(registerLinkLoc).ClickAsync();

        }

        public async Task EnterFirstName(string firstName)
        {
            ExtentReporting.LogInfo($"Enter the first name: {firstName}");
            LoggerUtil.Info($"Enter the first name: {firstName}");

            await page.Locator(firstNameLoc).FillAsync(firstName);
        }

        public async Task EnterLastName(string lastName)
        {
            ExtentReporting.LogInfo($"Enter the last name: {lastName}");
            LoggerUtil.Info($"Enter the last name: {lastName}");

            await page.Locator(lastNameLoc).FillAsync(lastName);
        }

        public async Task EnterAddress(string address)
        {
            ExtentReporting.LogInfo($"Enter the address: {address}");
            LoggerUtil.Info($"Enter the address: {address}");

            await page.Locator(addressLoc).FillAsync(address);
        }

        public async Task EnterCity(string city)
        {
            ExtentReporting.LogInfo($"Enter the city: {city}");
            LoggerUtil.Info($"Enter the city: {city}");

            await page.Locator(cityLoc).FillAsync(city);
        }

        public async Task EnterState(string state)
        {
            ExtentReporting.LogInfo($"Enter the state: {state}");
            LoggerUtil.Info($"Enter the state: {state}");

            await page.Locator(stateLoc).FillAsync(state);
        }

        public async Task EnterZipCode(string zipCode)
        {
            ExtentReporting.LogInfo($"Enter the zip code: {zipCode}");
            LoggerUtil.Info($"Enter the zip code: {zipCode}");

            await page.Locator(zipCodeLoc).FillAsync(zipCode);
        }

        public async Task EnterPhone(string phone)
        {
            ExtentReporting.LogInfo($"Enter the phone number: {phone}");
            LoggerUtil.Info($"Enter the phone number: {phone}");

            await page.Locator(phoneLoc).FillAsync(phone);
        }

        public async Task EnterSSN(string ssn)
        {
            ExtentReporting.LogInfo($"Enter the SSN: {ssn}");
            LoggerUtil.Info($"Enter the SSN: {ssn}");

            await page.Locator(ssnLoc).FillAsync(ssn);
        }

        public async Task EnterUserName(string username)
        {
            ExtentReporting.LogInfo($"Enter the username: {username}");
            LoggerUtil.Info($"Enter the username: {username}");

            await page.Locator(usernameLoc).FillAsync(username);
        }

        public async Task EnterPassword(string password)
        {
            ExtentReporting.LogInfo($"Enter the password: {password}");
            LoggerUtil.Info($"Enter the password: {password}");

            await page.Locator(passwordLoc).FillAsync(password);
        }

        public async Task EnterConfirmPassword(string ConfirmPassword)
        {
            ExtentReporting.LogInfo($"Enter the confirm password: {ConfirmPassword}");
            LoggerUtil.Info($"Enter the confirm password: {ConfirmPassword}");

            await page.Locator(cPasswordLoc).FillAsync(ConfirmPassword);
        }

        public async Task ClickOnRegisterButton()
        {
            ExtentReporting.LogInfo($"Click on the registration button.");
            LoggerUtil.Info($"Click on the registration button");

            await page.Locator(registerButtonLoc).ClickAsync();
        }
    }

}
