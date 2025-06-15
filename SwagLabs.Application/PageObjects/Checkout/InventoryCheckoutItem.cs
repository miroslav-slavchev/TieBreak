using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.Models;
using SwagLabs.Application.PageObjects.InventoryItems;
using SwagLabs.Application.UiElements;

namespace SwagLabs.Application.PageObjects.Checkout
{
    public class InventoryCheckoutItem(SearchContext searchContext, By by) : InventoryItem(searchContext, by)
    {
        protected override By LocateTitle => Locate.By("css=a[id*='_title_link']");

        public UiElement QuantityElement => UiElement<UiElement>(Locate.By("css=div.cart_quantity"));

        public async Task<int> GetQuantityAsync()
        {
            var quantityText = await QuantityElement.TextContentAsync();
            if (int.TryParse(quantityText, out int quantity))
            {
                return quantity;
            }
            throw new InvalidOperationException("Failed to parse quantity from the cart item.");
        }

        public async Task<InventoryCheckoutItemModel> GetDataAsync()
        {
            var title = await Title.TextContentAsync();
            var description = await Description.TextContentAsync();
            var price = await Price.GetPriceDataAsync();
            var quantity = await GetQuantityAsync();

            return new InventoryCheckoutItemModel()
            {
                Title = title,
                Description = description,
                Price = new(price.Text),
                Quantity = quantity
            };
        }
    }
}
