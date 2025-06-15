namespace SwagLabs.Tests
{
    public class ShoppingCartTests : StandardUserTest
    {
        [Test]
        public async Task AddItem_ValidateItIsPresentInCart()
        {
            // Arrange
            var itemToAdd = (await App.InventoryPage.InventoryItems.FirstAsync(async item => await item.IsAddedToCartAsync() == false))!;

            //Act
            await itemToAdd.AddToCartAsync();
            var addedItems = await App.InventoryPage.InventoryItems.WhereAsync(async item => await item.IsAddedToCartAsync());
            var addedItemsData = addedItems.Select(item => item.GetDataAsync()).ToList();

            await App.Header.CartButton.ClickAsync();
            var cartItems = await App.ShoppingCartPage.CartItems.ToListAsync();

            //Assert
            var cartItemsdata = cartItems.Select(item => item.GetDataAsync()).ToList();
            foreach (var item in addedItemsData)
            {
                addedItemsData.Should().ContainEquivalentOf(item);
            }
        }

        [Test]
        public async Task RemoveItemFromCart_ValidateNoLongerPresent()
        {
            // Arrange
            var itemToAdd = (await App.InventoryPage.InventoryItems.FirstAsync(async item => await item.IsAddedToCartAsync() == false))!;
            var itemData = await itemToAdd.GetDataAsync();
            await itemToAdd.AddToCartAsync();

            await App.Header.CartButton.ClickAsync();

            //Act
            var cartItem = await App.ShoppingCartPage.CartItems.FirstAsync(async i => (await i.Title.TextContentAsync()) == itemData.Title);
            await cartItem!.RemoveFromCartAsync();
            var cartItemAfterRemove = await App.ShoppingCartPage.CartItems.FirstOrDefaultAsync(async i => (await i.Title.TextContentAsync()) == itemData.Title);
           
            await App.ShoppingCartPage.ContinueShoppingButton.ClickAsync();
            var itemAfterRemove = await App.InventoryPage.InventoryItems.FirstOrDefaultAsync(async item => (await item.Title.TextContentAsync()) == itemData.Title);

            //Assert
            cartItemAfterRemove.Should().BeNull();
            itemAfterRemove.Should().NotBeNull();
        }

        [Test]
        public async Task CheckoutOverview_ValidateCalculations()
        {
            // Arrange
            var itemToAdd = (await App.InventoryPage.InventoryItems.FirstAsync(async item => await item.IsAddedToCartAsync() == false))!;
            await itemToAdd.AddToCartAsync();
            await App.Header.CartButton.ClickAsync();
            await App.ShoppingCartPage.CheckoutButton.ClickAsync();

            //Act
            await App.CheckoutPage.StepOnePage.CheckOutInformation
                .FillAsync(firstName: "John", lastName: "Doe", postalCode: "12345");
            await App.CheckoutPage.StepOnePage.ContinueButton.ClickAsync();
            var itemsData = await App.CheckoutPage.CheckoutStepTwoPage.CartItems.SelectAsync(async item => await item.GetDataAsync());
            var itemsTotalPrice = itemsData.Sum(item => item.Price!.Value * item.Quantity);
            var summaryInfo = await App.CheckoutPage.CheckoutStepTwoPage.SummaryInfo.SummaryInfoDataAsync();

            // Assert
            summaryInfo.ItemTotal.Value.Should().Be(itemsTotalPrice);
            summaryInfo.Total.Value.Should().Be(summaryInfo.ItemTotal.Value + summaryInfo.Tax.Value);
        }

        [Test]
        public async Task CheckoutComplete_ValidateMessage()
        {
            // Arrange
            var itemToAdd = (await App.InventoryPage.InventoryItems.FirstAsync(async item => await item.IsAddedToCartAsync() == false))!;
            await itemToAdd.AddToCartAsync();
            await App.Header.CartButton.ClickAsync();
            await App.ShoppingCartPage.CheckoutButton.ClickAsync();
            await App.CheckoutPage.StepOnePage.CheckOutInformation
               .FillAsync(firstName: "John", lastName: "Doe", postalCode: "12345");
            await App.CheckoutPage.StepOnePage.ContinueButton.ClickAsync();

            //Act
            await App.CheckoutPage.CheckoutStepTwoPage.FinishButton.ClickAsync();
            var completeMessage = await App.CheckoutPage.CheckOutCompletePage.CompleteHeader.TextContentAsync();

            // Assert

            completeMessage.Should().Be("Thank you for your order!");
        }

        [Test]
        public async Task CheckoutComplete_BackHome_ValidateNoAddedItems()
        {
            // Arrange
            var itemToAdd = (await App.InventoryPage.InventoryItems.FirstAsync(async item => await item.IsAddedToCartAsync() == false))!;
            await itemToAdd.AddToCartAsync();
            await App.Header.CartButton.ClickAsync();
            await App.ShoppingCartPage.CheckoutButton.ClickAsync();
            await App.CheckoutPage.StepOnePage.CheckOutInformation
               .FillAsync(firstName: "John", lastName: "Doe", postalCode: "12345");
            await App.CheckoutPage.StepOnePage.ContinueButton.ClickAsync();
            await App.CheckoutPage.CheckoutStepTwoPage.FinishButton.ClickAsync();

            //Act
            await App.CheckoutPage.CheckOutCompletePage.BackHomeButton.ClickAsync();
            var addedItems = await App.InventoryPage.InventoryItems.WhereAsync(async item => await item.IsAddedToCartAsync());

            // Assert
            addedItems.Should().BeEmpty();
        }
    }
}
