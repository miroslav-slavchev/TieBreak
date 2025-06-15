using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.PageObjects.Cart;
using SwagLabs.Application.UiElements;

namespace SwagLabs.Application.PageObjects.Checkout
{
    public class CheckoutStepTwoPage(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        public PageObjectList<InventoryCheckoutItem> CartItems => InnerPageObjects<InventoryCheckoutItem>(Locate.By("css=div.cart_item"));

        public Button FinishButton => UiElement<Button>(Locate.By("css=#finish"));

        public Button CancelButton => UiElement<Button>(Locate.By("css=#cancel"));

        public SummaryInfo SummaryInfo => InnerPageObject<SummaryInfo>(Locate.By("css=div.summary_info"));
    }
}
