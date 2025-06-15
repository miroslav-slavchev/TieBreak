using Microsoft.Playwright;
using PlayWright.Library.Extensions;

namespace PlayWright.Library.Components.Context
{
    public partial class UiContext
    {
        private ILocator GetLocator()
        {
            ILocator locator;
            if (By.SearchIn == SearchIn.Parent && SearchContext.ParentLocator != null)
            {
                locator = SearchContext.ParentLocator.Locator(By.Selector, By.Options);
            }
            else if (By.SearchIn == SearchIn.Root && SearchContext.RootLocator != null)
            {
                locator = SearchContext.RootLocator.Locator(By.Selector, By.Options);
            }
            else if (By.SearchIn == SearchIn.Page)
            {
                locator = SearchContext.BrowserSession.Page.Locator(By.Selector, By.Options?.ConvertToPageOptions());
            }
            else
            {
                locator = GetLocatorByPriority();
            }

            if (By.WaitOptions != null)
            {
                locator.WaitForAsync(By.WaitOptions);
            }

            if (By.Index >= 0)
            {
                return locator.Nth(By.Index);
            }
            else
            {
                return locator;
            }
        }

        private ILocator GetLocatorByPriority()
        {
            if (SearchContext.ParentLocator != null)
            {
                return SearchContext.ParentLocator.Locator(By.Selector, By.Options);
            }
            else if (SearchContext.RootLocator != null)
            {
                return SearchContext.RootLocator.Locator(By.Selector, By.Options);
            }
            else
            {
                return SearchContext.BrowserSession.Page.Locator(By.Selector, By.Options?.ConvertToPageOptions());
            }
        }
    }
}
