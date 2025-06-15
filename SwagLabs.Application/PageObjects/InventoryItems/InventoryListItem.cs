using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.Extensions;
using System.Text.RegularExpressions;

namespace SwagLabs.Application.PageObjects.InventoryItems
{
    public class InventoryListItem(SearchContext searchContext, By by) : InventoryItemWithImage(searchContext, by)
    {
        protected override By LocateTitle => Locate.By("css=a[id*=_title_link]");

        public async Task<int> IdAsync()
        {
            var testData = await Title.DataTestAttributeAsync();
            var match = Regex.Match(testData, @"item-(\d+)-");
            if (match.Success)
            {
                var id = match.Groups[1].Value;
                return int.Parse(id);
            }
            throw new InvalidOperationException("Failed to extract item id.");
        }
    }
}
