using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;

namespace SwagLabs.Application.UiElements
{
    public class Anchor(SearchContext searchContext, By? by = null) : UiElement(searchContext, by ?? Locate.By("css=a"))
    {
    }
}
