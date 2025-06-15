namespace SwagLabs.Tests.InventoryItems
{
    public class InventoryItems_StandardUser_Tests : StandardUserTest
    {
        [Test]
        public async Task AddToCartItem_Validate_CartCounter()
        {
            //Arrange
            var cartCountBefore = await App.Header.CartButton.CountAsync();
            var notAddedItems = await App.InventoryPage.InventoryItems.WhereAsync(async item => await item.IsAddedToCartAsync() == false);
            var addedItems = await App.InventoryPage.InventoryItems.WhereAsync(async item => await item.IsAddedToCartAsync());

            var itemToAdd = notAddedItems.First();

            //Act
            await itemToAdd.AddToCartAsync();
            var cartCountAfter = await App.Header.CartButton.CountAsync();
            bool isRemoveButton = await itemToAdd.Button.IsRemoveButtonAsync();
            
            //Assert
            isRemoveButton.Should().BeTrue("Button should change to 'Remove' after adding an item to the cart.");
            cartCountBefore.Should().Be(addedItems.Count, "Cart count before should match the number of items already in the cart.");
            cartCountAfter.Should().Be(cartCountBefore + 1, "Cart count should increase by 1 after adding an item to the cart.");

        }

        [Test]
        public async Task RemoveFromCartItem_Validate_CartCounter()
        {
            //Arrange
            var notAddedItems = await App.InventoryPage.InventoryItems.WhereAsync(async item => await item.IsAddedToCartAsync() == false);
            await notAddedItems.First().AddToCartAsync(); //Ensure at least one item is added to the cart
            var cartCountBefore = await App.Header.CartButton.CountAsync();
            
            var addedItems = await App.InventoryPage.InventoryItems.WhereAsync(async item => await item.IsAddedToCartAsync());
            var itemToRemove = addedItems.First();
          
            //Act
            await itemToRemove.RemoveFromCartAsync();
            var cartCountAfter = await App.Header.CartButton.CountAsync();
            bool isAddToCartButton = await itemToRemove.Button.IsAddToCartButtonAsync();
            
            //Assert
            isAddToCartButton.Should().BeTrue("Button should change to 'Add to Cart' after removing an item from the cart.");
            cartCountBefore.Should().Be(addedItems.Count, "Cart count before should match the number of items already in the cart.");
            cartCountAfter.Should().Be(cartCountBefore - 1, "Cart count should decrease by 1 after removing an item from the cart.");
        }

        [Test]
        public async Task SortPrice_HighToLow_Validate_SortedItems()
        {
            //Act
            await App.Header.SelectProductSort.SelectPriceHighToLowAsync();

            var productPrices = await App.InventoryPage.InventoryItems.SelectAsync(async item => await item.Price.GetPriceDataAsync());

            //Assert
            bool isSortedDescending = productPrices.SequenceEqual(productPrices.OrderByDescending(x => x.Value));
            isSortedDescending.Should().BeTrue("items should be sorted from high to low price");
        }

        [Test]
        public async Task SortPrice_ZtoA_Validate_SortedItems()
        {
            //Act
            await App.Header.SelectProductSort.SelectNameDescAsync();
            var productNames = await App.InventoryPage.InventoryItems.SelectAsync(async item => await item.Title.TextContentAsync());

            //Assert
            bool isSortedDescending = productNames.SequenceEqual(productNames.OrderByDescending(x => x, StringComparer.OrdinalIgnoreCase));

            // Optional assertion if using FluentAssertions:
            isSortedDescending.Should().BeTrue("items should be sorted from Z to A");
        }
    }
}
