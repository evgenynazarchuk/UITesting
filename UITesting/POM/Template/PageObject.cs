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

        public virtual async Task<PageObject> WaitPageLoadAsync()
        {
            await Task.CompletedTask;
            return this;
        }

        public virtual async Task<PageObject> WaitAngular()
        {
            await Task.CompletedTask;
            return this;
        }

        public virtual async Task<PageObject> WaitAnimation()
        {
            await Task.CompletedTask;
            return this;
        }

        public virtual async Task<PageObject> WaitJQuery()
        {
            await Task.CompletedTask;
            return this;
        }

        public virtual async Task<PageObject> TakeScreenshot()
        {
            await Task.CompletedTask;
            return this;
        }
    }
}
