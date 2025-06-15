using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;

namespace SwagLabs.Application.PageObjects.Checkout
{
    public class CheckOutInformation(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        public UiElement FirstNameInput => UiElement(Locate.By("css=input#first-name"));
        public UiElement LastNameInput => UiElement(Locate.By("css=input#last-name"));
        public UiElement PostalCodeInput => UiElement(Locate.By("css=input#postal-code"));

        public async Task FillAsync(string firstName, string lastName, string postalCode)
        {
            await FirstNameInput.FillAsync(firstName);
            await LastNameInput.FillAsync(lastName);
            await PostalCodeInput.FillAsync(postalCode);
        }
    }
}