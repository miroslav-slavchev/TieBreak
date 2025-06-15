using PlayWright.Library.Components.Context;

namespace SwagLabs.Application.UiElements
{
    public class InventoryItemButton(SearchContext searchContext, By? by = null) 
        : Button(searchContext, by ?? Locate.By("css=button.btn_inventory,button.cart_button"))
    {
        public async Task<bool> IsAddToCartButtonAsync()
        {
            var buttonText = await TextContentAsync();
            return buttonText.ToLower().Trim() == "add to cart";
        }

        public async Task<bool> IsRemoveButtonAsync()
        {
            var buttonText = await TextContentAsync();
            return buttonText.ToLower().Trim() == "remove";
        }

    }
}
