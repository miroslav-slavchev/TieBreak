using Microsoft.Playwright;

namespace PlayWright.Library.Components.Context
{
    public abstract partial class UiContext(SearchContext searchContext, By by)
    {
        public string Name => GetType().Name;

        public SearchContext SearchContext { get; } = searchContext;
        public By By { get; protected set; } = by;

        public ILocator Locator => GetLocator();

        public IPage Page => SearchContext.BrowserSession.Page;
    }
}
