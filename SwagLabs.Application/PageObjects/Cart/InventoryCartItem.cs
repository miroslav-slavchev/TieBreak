using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.Models;
using SwagLabs.Application.PageObjects.InventoryItems;

namespace SwagLabs.Application.PageObjects.Cart
{
    public class InventoryCartItem(SearchContext searchContext, By by) : InventoryItemWithButton(searchContext, by)
    {
        protected override By LocateTitle => Locate.By("css=a[id*=_title_link]");

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

        public async Task <InventoryCartItemModel> GetDataAsync()
        {
            var title = await Title.TextContentAsync();
            var description = await Description.TextContentAsync();
            var price = await Price.GetPriceDataAsync();
            var quantity = await GetQuantityAsync();
            var buttonText = await Button.TextContentAsync();

            return new InventoryCartItemModel
            {
                Title = title,
                Description = description,
                Price = new(price.Text),
                Quantity = quantity,
                ButtonText = buttonText
            };
        }
    }
}
