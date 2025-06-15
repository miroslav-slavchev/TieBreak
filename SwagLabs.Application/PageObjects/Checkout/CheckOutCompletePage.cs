using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.UiElements;

namespace SwagLabs.Application.PageObjects.Checkout
{
    public class CheckOutCompletePage(SearchContext searchContext, By? by = null) : BaseSwagLabsPage(searchContext, by)
    {
        public UiElement CompleteHeader => UiElement(Locate.By("css=h2.complete-header"));

        public UiElement CompleteText => UiElement(Locate.By("css=p.complete-text"));

        public Button BackHomeButton => UiElement<Button>(Locate.By("css=#back-to-products"));
    }
}