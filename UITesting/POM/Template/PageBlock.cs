using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UITesting.POM.Template
{
    public class PageBlock<PageObjectType>
        where PageObjectType : PageObject
    {
        public readonly IPage Page;

        public readonly PageBlock<PageObjectType>? ParentPageBlock;

        public readonly PageObjectType PageObject;

        public readonly string BlockSelector;

        public PageBlock(PageObjectType pageObject, string blockSelector)
        {
            this.Page = pageObject.Page;
            this.PageObject = pageObject;
            this.ParentPageBlock = null;
            this.BlockSelector = blockSelector;
        }

        public PageBlock(PageBlock<PageObjectType> parentPageBlock, string blockSelector)
        {
            this.Page = parentPageBlock.Page;
            this.PageObject = parentPageBlock.PageObject;
            this.ParentPageBlock = parentPageBlock;
            this.BlockSelector = blockSelector;
        }

        public async Task<IElementHandle> GetBlockHandleAsync()
        {
            IElementHandle? blockHandle;

            await this.WaitAsync();

            if (this.ParentPageBlock is null)
            {
                blockHandle = await this.Page.QuerySelectorAsync(this.BlockSelector);
            }
            else
            {
                IElementHandle parentHandle = await ParentPageBlock.GetBlockHandleAsync();
                blockHandle = await parentHandle.QuerySelectorAsync(this.BlockSelector);
            }

            if (blockHandle is null)
            {
                throw new ApplicationException($"Block not found");
            }

            return blockHandle;
        }

        public virtual async Task ClickAsync()
        {
            await this.WaitAsync();

            IElementHandle blockHandle = await this.GetBlockHandleAsync();
            await blockHandle.ClickAsync();
        }

        public virtual async Task TypeAsync(string text)
        {
            await this.WaitAsync();

            IElementHandle blockHandle = await this.GetBlockHandleAsync();
            await blockHandle.TypeAsync(text);
        }

        protected virtual async Task ClickAsync(string elementSelector)
        {
            await this.WaitAsync();

            IElementHandle blockHandle = await this.GetBlockHandleAsync();
            IElementHandle? elementHandle = await blockHandle.QuerySelectorAsync(elementSelector);

            if (elementHandle is not null)
            {
                await elementHandle.ClickAsync();
            }
            else
            {
                throw new ApplicationException("Element not found");
            }
        }

        protected virtual async Task TypeAsync(string elementSelector, string text)
        {
            await this.WaitAsync();

            IElementHandle blockHandle = await this.GetBlockHandleAsync();
            IElementHandle? elementHandle = await blockHandle.QuerySelectorAsync(elementSelector);

            if (elementHandle is not null)
            {
                await elementHandle.TypeAsync(text);
            }
            else
            {
                throw new ApplicationException("Element not found");
            }
        }

        protected async Task<PageBlock<PageObjectType>> WaitAsync()
        {
            if (this.PageObject is null)
            {
                await WaitPageLoadAsync();
            }
            else
            {
                await this.PageObject.WaitPageLoadAsync();
            }

            return this;
        }

        protected virtual async Task<PageBlock<PageObjectType>> WaitPageLoadAsync()
        {
            await Task.CompletedTask;
            return this;
        }
    }
}
