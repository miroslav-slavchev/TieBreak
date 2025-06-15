using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;

namespace SwagLabs.Application.PageObjects.InventoryItems
{
    public class InventoryItemsPage(SearchContext searchContext, By? by = null) : BaseSwagLabsPage(searchContext, by)
    {
        public PageObjectList<InventoryListItem> InventoryItems => InnerPageObjects<InventoryListItem>(Locate.By("css=div.inventory_item"));
    }
}
