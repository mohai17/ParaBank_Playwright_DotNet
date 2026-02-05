using Microsoft.Playwright;
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
            await page.Locator(registerLinkLoc).ClickAsync();

        }

        public async Task EnterFirstName(string firstName)
        {
            await page.Locator(firstNameLoc).FillAsync(firstName);
        }

        public async Task EnterLastName(string lastName)
        {
            await page.Locator(lastNameLoc).FillAsync(lastName);
        }

        public async Task EnterAddress(string address)
        {
            await page.Locator(addressLoc).FillAsync(address);
        }

        public async Task EnterCity(string city)
        {
            await page.Locator(cityLoc).FillAsync(city);
        }

        public async Task EnterState(string state)
        {
            await page.Locator(stateLoc).FillAsync(state);
        }

        public async Task EnterZipCode(string zipCode)
        {
            await page.Locator(zipCodeLoc).FillAsync(zipCode);
        }

        public async Task EnterPhone(string phone)
        {
            await page.Locator(phoneLoc).FillAsync(phone);
        }

        public async Task EnterSSN(string ssn)
        {
            await page.Locator(ssnLoc).FillAsync(ssn);
        }

        public async Task EnterUserName(string username)
        {
            await page.Locator(usernameLoc).FillAsync(username);
        }

        public async Task EnterPassword(string password)
        {
            await page.Locator(passwordLoc).FillAsync(password);
        }

        public async Task EnterConfirmPassword(string ConfirmPassword)
        {
            await page.Locator(cPasswordLoc).FillAsync(ConfirmPassword);
        }

        public async Task ClickOnRegisterButton()
        {
            await page.Locator(registerButtonLoc).ClickAsync();
        }
    }

}
