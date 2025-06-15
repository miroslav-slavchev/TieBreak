using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.Models;

namespace SwagLabs.Application.UiElements
{
    public class PriceBar(SearchContext searchContext, By by) : UiElement(searchContext, by)
    {
        public async Task<PriceModel> GetPriceDataAsync()
        {
            var priceText = await TextContentAsync();
            if (string.IsNullOrWhiteSpace(priceText))
            {
                throw new InvalidOperationException("Price text is empty or null.");
            }
            return new PriceModel(priceText);
        }
    }
}
