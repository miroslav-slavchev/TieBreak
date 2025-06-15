namespace SwagLabs.Application.Models
{
    public class SummaryInfoModel
    {
        public string? PaymentInformation { get; set; }
        public string? ShippingInformation { get; set; }
        public PriceModel ItemTotal { get; set; }
        public PriceModel Tax { get; set; }
        public PriceModel Total { get; set; }
    }
}
