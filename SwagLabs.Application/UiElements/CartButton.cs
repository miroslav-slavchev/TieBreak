using Microsoft.Playwright;
using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;

namespace SwagLabs.Application.UiElements
{
    public class CartButton(SearchContext searchContext, By? by = null) : UiElement(searchContext, by ?? Locate.By("css=#shopping_cart_container"))
    {
        private ILocator Badge => Locator.Locator("css=span.shopping_cart_badge");

        public async Task<bool> ShoppingCartBadgePresentAsync() => await Badge.CountAsync() > 0;

        public async Task<int> CountAsync()
        {
            if (await ShoppingCartBadgePresentAsync())
            {
                string? text = await Badge.TextContentAsync();
                if (string.IsNullOrEmpty(text))
                {
                    return 0;
                }
                return int.Parse(text);
            }
            return 0;
        }
    }
}
