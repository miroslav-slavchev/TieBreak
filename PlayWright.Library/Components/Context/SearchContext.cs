using Microsoft.Playwright;

namespace PlayWright.Library.Components.Context
{
    /// <summary>
    /// Represents a search context for locating elements within a browser session.
    /// </summary>
    /// <param name="browserSession"> The browser session in which the search context operates.</param>
    /// <param name="parent">The parent locator in which the target one will be searched.</param>
    /// <param name="root">Represents the root element (usually that's the body.</param>
    public class SearchContext(BrowserPageSession browserSession, ILocator? parent = null, ILocator? root = null)
    {
        public BrowserPageSession BrowserSession { get; } = browserSession;

        // These should be null only for the Root Element and in some exceptions
        public ILocator? ParentLocator { get; } = parent;
        public ILocator? RootLocator { get; } = root;

        public SearchContext GetChildSearchContext(ILocator targetLocator) => new(browserSession: BrowserSession, parent: targetLocator, root: RootLocator);
    }
}
