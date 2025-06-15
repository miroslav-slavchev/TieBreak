using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.Models;

namespace SwagLabs.Application.PageObjects.InventoryItems
{
    public class InventoryItemWithImage(SearchContext searchContext, By by) : InventoryItemWithButton(searchContext, by)
    {
        protected override By LocateTitle => Locate.By("css=div.inventory_item_name");
        
        public UiElement Image => UiElement(Locate.By("css=img"));


        public async Task<InventoryItemWithImageModel> GetDataAsync()
        {
            string? imageSource = await Image.GetAttributeAsync("src");
            string buttonText = await Button.TextContentAsync();
            string title = await Title.TextContentAsync();
            string descriptionText = await Description.TextContentAsync();
            var price = await Price.GetPriceDataAsync();

            var itemData = new InventoryItemWithImageModel()
            {
                ImgSrc = imageSource,
                ButtonText = buttonText,
                Title = title,
                Description = descriptionText,
                Price = new(price.Text)
            };

            return itemData;
        }
    }
}
