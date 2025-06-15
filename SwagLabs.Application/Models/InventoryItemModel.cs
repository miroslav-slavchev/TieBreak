namespace SwagLabs.Application.Models
{
    public class InventoryItemModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public PriceModel? Price { get; set; }
    }

    public class InventoryItemWithImageModel : InventoryItemModel
    {
        public string? ImgSrc { get; set; }

        public string? ButtonText { get; set; }
        public bool? AddedToCart => ButtonText == "Remove";
    }

    public class InventoryCartItemModel : InventoryItemModel
    {
        public int? Quantity { get; set; }

        public string? ButtonText { get; set; }
        public bool? AddedToCart => ButtonText == "Remove";
    }

    public class InventoryCheckoutItemModel : InventoryItemModel
    {
        public int? Quantity { get; set; }
    }
}