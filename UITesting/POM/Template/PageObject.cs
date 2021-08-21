using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UITesting.POM.Template
{
    public class PageObject
    {
        public readonly IPage Page;

        public PageObject(IPage page)
        {
            Page = page;
        }

        public virtual PageObject Wait()
        {
            return this;
        }

        public virtual PageObject WaitAngular()
        {
            return this;
        }

        public virtual PageObject WaitAnimation()
        {
            return this;
        }

        public virtual PageObject WaitJQuery()
        {
            return this;
        }

        public virtual PageObject TakeScreenshot()
        {
            return this;
        }
    }
}
