using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace UITesting.POM.Google
{
    public class SearchBlock
    {
        public readonly IPage Page;

        public Task<IElementHandle> Element
        {
            get => this.Page.QuerySelectorAsync(this.Selector);
            private set { }
        }

        public readonly string Selector;

        public SearchBlock(IPage page, string selector)
        {
            this.Page = page;
            this.Selector = selector;
        }

        public async Task<SearchBlock> SetSearchText(string searchText)
        {
            await Page.TypeAsync("", searchText);
            return this;
        }

        public async Task<SearchResultPage> GoogleSearch()
        {
            await Page.ClickAsync("");
            return new SearchResultPage(Page);
        }

        public async Task<SearchResultPage> IamLucky()
        {
            await Page.ClickAsync("");
            return new SearchResultPage(Page);
        }
    }
}
