using Microsoft.Playwright;
using PlayWright.Library;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.PageObjects.Cart;
using SwagLabs.Application.PageObjects.Checkout;
using SwagLabs.Application.PageObjects.InventoryItems;

namespace SwagLabs.Application.PageObjects
{
    public class App(BrowserPageSession session)
    {
        public BrowserPageSession PageSession { get; set; } = session;
        public IPage Page => PageSession.Page;
        private ILocator Body => PageSession.Page.Locator("css=body");
        private SearchContext BodyContext => new(PageSession, null, Body);

        public LoginPage LoginPage => new(BodyContext, Locate.By("css=div.login_container"));
        public Header Header => new(BodyContext);
        public ShoppingCartPage ShoppingCartPage => new(BodyContext);
        public InventoryItemsPage InventoryPage => new(BodyContext);
        public SingleInventoryItemPage OpenedInventoryPage => new(BodyContext);
        public CheckOutPage CheckoutPage => new(BodyContext);
    }
}
