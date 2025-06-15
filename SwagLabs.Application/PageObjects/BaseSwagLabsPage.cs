using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;

namespace SwagLabs.Application.PageObjects
{
    public abstract class BaseSwagLabsPage(SearchContext searchContext, By? by = null) 
        : PageObject(searchContext, by ?? Locate.By("css=#root"))
    {
    }
}
