using PlayWright.Library.Components;
using PlayWright.Library.Components.Context;
using SwagLabs.Application.UiElements;

namespace SwagLabs.Application.PageObjects
{
    public class LoginPage(SearchContext searchContext, By by) : PageObject(searchContext, by)
    {
        public UiElement UsernameInput => UiElement(Locate.By("css=input[data-test=username]"));
        public UiElement PasswordInput => UiElement(Locate.By("css=input[data-test=password]"));
        public Button LoginButton => UiElement<Button>(Locate.By("css=input#login-button"));

        public async Task LogInAsync(string username, string password)
        {
            await UsernameInput.FillAsync(username);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
        }
    }
}