using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParaBank_Playwright_DotNet.Pages
{
    
    internal class AccountDetails
    {

        IPage page = default!;

        public AccountDetails(IPage page)
        {
            this.page = page;
        }



    }
}
