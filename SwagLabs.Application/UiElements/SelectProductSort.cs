using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;

namespace SwagLabs.Application.UiElements
{
    public static class SelectProductSortOptions
    {
        public const string NameAtoZ = "Name (A to Z)";
        public const string NameZtoA = "Name (Z to A)";
        public const string PriceLowToHigh = "Price (low to high)";
        public const string PriceHighToLow = "Price (high to low)";
    }

    public class SelectProductSort(SearchContext searchContext, By by) : UiElement(searchContext, by)
    {
        public async Task SelectOptionByTextAsync(string option)
        {
            var current = await SelectedOptionAsync();
            if (current == option)
            {
                return; // Already selected
            }
            else
            {
                await base.SelectOptionAsync(option);
            }
        }
        public async Task<string> SelectedOptionAsync()
        {
            var selected = await Locator.EvaluateAsync<string>("el => el.options[el.selectedIndex].text");
            return selected;
        }

        public async Task SelectNameAscAsync() => await SelectOptionByTextAsync(SelectProductSortOptions.NameAtoZ);

        public async Task SelectNameDescAsync() => await SelectOptionByTextAsync(SelectProductSortOptions.NameZtoA);

        public async Task SelectPriceLowToHighAsync() => await SelectOptionByTextAsync(SelectProductSortOptions.PriceLowToHigh);

        public async Task SelectPriceHighToLowAsync() => await SelectOptionByTextAsync(SelectProductSortOptions.PriceHighToLow);

    }
}
