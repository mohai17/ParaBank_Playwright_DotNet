using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.Pages
{
    internal class BasePage
    {

        IPage page = default!;
        public BasePage(IPage page)
        {
            this.page = page;
        }
        public async Task WaitForElement(string Loc)
        {
            await page.Locator(Loc).WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible
            });
        }

    }
}
