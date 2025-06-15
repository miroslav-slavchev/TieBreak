using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.UiElements;

namespace SwagLabs.Application.PageObjects.InventoryItems
{
    public abstract class InventoryItem(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        protected abstract By LocateTitle { get; }
        public UiElement Title => UiElement<UiElement>(LocateTitle);

        public UiElement Description => UiElement(Locate.By("css=div[data-test=inventory-item-desc]"));
        public PriceBar Price => UiElement<PriceBar>(Locate.By("css=div[data-test=inventory-item-price]"));
    }

    public abstract class InventoryItemWithButton(SearchContext searchContext, By by) : InventoryItem(searchContext, by)
    {
        public InventoryItemButton Button => UiElement<InventoryItemButton>();

        public async Task AddToCartAsync()
        {
            if (await Button.IsAddToCartButtonAsync())
            {
                await Button.ClickAsync();
            }
            // else - button should be "Remove" button, no action needed
        }

        public async Task RemoveFromCartAsync()
        {
            if (await Button.IsRemoveButtonAsync())
            {
                await Button.ClickAsync();
            }
            // else - button should be "Add to Cart" button, no action needed
        }

        public async Task<bool> IsAddedToCartAsync()
        {
            return await Button.IsRemoveButtonAsync();
        }
    }
}
