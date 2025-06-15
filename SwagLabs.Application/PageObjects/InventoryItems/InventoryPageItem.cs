using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;

namespace SwagLabs.Application.PageObjects.InventoryItems
{
    public class InventoryPageItem(SearchContext searchContext, By by) : InventoryItemWithImage(searchContext, by)
    {
        protected override By LocateTitle => Locate.By("css=div.inventory_details_name");
    }
}
