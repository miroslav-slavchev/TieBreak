using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.UiElements;

namespace SwagLabs.Application.PageObjects.Checkout
{
    public class CheckOutStepOnePage(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        public CheckOutInformation CheckOutInformation => InnerPageObject<CheckOutInformation>(Locate.By("css=div.checkout_info"));

        public Button CancelButton => UiElement<Button>(Locate.By("css=#cancel"));
        public Button ContinueButton => UiElement<Button>(Locate.By("css=#continue"));
    }
}
