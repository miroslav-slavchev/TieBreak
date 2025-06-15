using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;

namespace SwagLabs.Application.PageObjects.InventoryItems
{
    public class SingleInventoryItemPage(SearchContext searchContext, By? by = null) : BaseSwagLabsPage(searchContext, by)
    {
        public InventoryPageItem InventoryItem => InnerPageObject<InventoryPageItem>(Locate.By("css=div.inventory_item_container"));
    }
}
