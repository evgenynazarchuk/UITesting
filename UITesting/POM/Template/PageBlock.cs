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

        public readonly PageBlock<PageObjectType> ParentPageBlock;

        public readonly PageObjectType PageObject;

        public readonly string BlockSelector;

        public PageBlock(PageObjectType pageObject, string blockSelector)
        {
            this.Page = pageObject.Page;
            this.PageObject = pageObject;
            this.ParentPageBlock = this;
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
            if (this.ParentPageBlock == this)
            {
                var blockHandle = await this.Page.QuerySelectorAsync(this.BlockSelector);

                if (blockHandle is not null)
                {
                    return blockHandle;
                }
                else
                {
                    throw new ApplicationException();
                }
            }
            else
            {
                IElementHandle parentHandle = await ParentPageBlock.GetBlockHandleAsync();
                var blockHandle = await parentHandle.QuerySelectorAsync(this.BlockSelector);

                if (blockHandle is not null)
                {
                    return blockHandle;
                }
                else
                {
                    throw new ApplicationException();
                }
            }
        }

        public virtual async Task ClickAsync()
        {
            this.PageObject.Wait();
            IElementHandle blockHandle = await this.GetBlockHandleAsync();
            await blockHandle.ClickAsync();
        }

        public virtual async Task TypeAsync(string text)
        {
            this.PageObject.Wait();
            IElementHandle blockHandle = await this.GetBlockHandleAsync();
            await blockHandle.TypeAsync(text);
        }

        public virtual async Task ClickAsync(string elementSelector)
        {
            this.PageObject.Wait();
            IElementHandle blockHandle = await this.GetBlockHandleAsync();
            var elementHandle = await blockHandle.QuerySelectorAsync(elementSelector);

            if (elementHandle is not null)
            {
                IElementHandle blockElementHandle = elementHandle;
                await blockElementHandle.ClickAsync();
            }
            else
            {
                throw new ApplicationException();
            }
        }

        public virtual async Task TypeAsync(string elementSelector, string text)
        {
            this.PageObject.Wait();
            IElementHandle blockHandle = await this.GetBlockHandleAsync();
            var elementHandle = await blockHandle.QuerySelectorAsync(elementSelector);

            if (elementHandle is not null)
            {
                IElementHandle blockElementHandle = elementHandle;
                await blockElementHandle.TypeAsync(text);
            }
            else
            {
                throw new ApplicationException();
            }
        }
    }
}
