using PlayWright.Library.Components.Context;

namespace PlayWright.Library.Components
{
    public class PageObjectList<TPageObject>(SearchContext searchContext, By by, Func<Task<bool>>? precondition = null, bool skipDefaultWait = false)
        : UiContextList<TPageObject>(searchContext, by, precondition, skipDefaultWait) where TPageObject : PageObject
    { }
}
