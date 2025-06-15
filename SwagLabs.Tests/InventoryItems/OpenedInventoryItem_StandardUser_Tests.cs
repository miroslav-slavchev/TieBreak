namespace SwagLabs.Tests.InventoryItems
{
    public class OpenedInventoryItem_StandardUser_Tests : StandardUserTest
    {
        [Test]
        public async Task OpenItem_ValidateItemPage()
        {
            //Arrange
            var invetoryItem = await App.InventoryPage.InventoryItems.FirstAsync();
            var itemData = await invetoryItem.GetDataAsync();
            var itemId = await invetoryItem.IdAsync();

            //Act
            await invetoryItem.Title.ClickAsync();
            var openedItemData = await App.OpenedInventoryPage.InventoryItem.GetDataAsync();

            //Assert
            openedItemData.Should().BeEquivalentTo(itemData);
            App.PageSession.Page.Url.Should().EndWith($"id={itemId}");
        }
    }
}
