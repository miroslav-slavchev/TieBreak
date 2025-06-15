using PlayWright.Library.Components.Context;

namespace SwagLabs.Application.PageObjects.Checkout
{
    public class CheckOutPage(SearchContext searchContext, By? by = null) : BaseSwagLabsPage(searchContext, by)
    {
        public CheckOutStepOnePage StepOnePage => new(SearchContext, By);
        public CheckoutStepTwoPage CheckoutStepTwoPage => new(SearchContext, By);
        public CheckOutCompletePage CheckOutCompletePage => new(SearchContext, By);
    }
}
