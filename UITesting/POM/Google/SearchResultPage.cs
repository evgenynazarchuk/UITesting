using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UITesting.POM.Google
{
    public class SearchResultPage
    {
        public readonly IPage Page;

        public SearchResultPage(IPage page)
        {
            Page = page;
        }

        public int GetResultCount()
        {
            return 0;
        }
    }
}
