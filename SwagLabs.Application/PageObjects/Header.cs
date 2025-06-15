using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.UiElements;

namespace SwagLabs.Application.PageObjects
{
    public class Header(SearchContext searchContext, By? by = null)
        : PageObject(searchContext, by ?? Locate.By("css=#header_container"))
    {
        public CartButton CartButton => UiElement<CartButton>();

        public SelectProductSort SelectProductSort => UiElement<SelectProductSort>(Locate.By("css=select[data-test=product-sort-container]"));
    }
}
