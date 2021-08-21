using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UITesting.POM.Google
{
    public class MainPage
    {
        public readonly IPage Page;

        public MainPage(IPage page)
        {
            Page = page;
        }
    }
}
