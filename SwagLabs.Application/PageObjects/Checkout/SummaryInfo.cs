using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.Models;

namespace SwagLabs.Application.PageObjects.Checkout
{
    public class SummaryInfo(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        public UiElement PayMentInformation => UiElement(Locate.By("css=div[data-test=payment-info-value]"));
        public UiElement ShippingInformation => UiElement(Locate.By("css=div[data-test=shipping-info-value]"));

        public UiElement ItemTotal => UiElement(Locate.By("css=div[data-test=subtotal-label]"));
        public UiElement Tax => UiElement(Locate.By("css=div[data-test=tax-label]"));
        public UiElement Total => UiElement(Locate.By("css=div[data-test=total-label]"));

        public async Task<SummaryInfoModel> SummaryInfoDataAsync()
        {
            string paymentInformation = await PayMentInformation.TextContentAsync();
            string shippingInformation = await ShippingInformation.TextContentAsync();

            string ItemTotalText = await ItemTotal.TextContentAsync();
            string taxText = await Tax.TextContentAsync();
            string totalText = await Total.TextContentAsync();

            SummaryInfoModel summaryInfo = new ()
            {
                PaymentInformation = paymentInformation,
                ShippingInformation = shippingInformation,
                ItemTotal = new(ItemTotalText.Replace("Item total: ","")),
                Tax = new(taxText.Replace("Tax: ", "")),
                Total = new(totalText.Replace("Total: ", ""))
            };

            return summaryInfo;
        }
    }
}