using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.UiElements;

namespace SwagLabs.Application.PageObjects.Cart
{
    public class ShoppingCartPage(SearchContext searchContext, By? by = null) : BaseSwagLabsPage(searchContext, by)
    {
        public Button CheckoutButton => UiElement<Button>(Locate.By("css=#checkout"));
        public Button ContinueShoppingButton => UiElement<Button>(Locate.By("css=#continue-shopping"));

        public PageObjectList<InventoryCartItem> CartItems => InnerPageObjects<InventoryCartItem>(Locate.By("css=div.cart_item"));
    }
}
