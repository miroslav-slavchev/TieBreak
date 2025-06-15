using Microsoft.Playwright;
using PlayWright.Library;
using SwagLabs.Application.PageObjects;
using SwagLabs.Tests.Infrastructure.Config;

namespace SwagLabs.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        private IPlaywright _playwright;

        public AppSettings AppSettings { get; } = TestConfiguration.LoadAppSettings();
        public App App { get; private set; }

        [OneTimeSetUp]
        public async Task InitPlaywright()
        {
            _playwright = await Playwright.CreateAsync();
        }

        [SetUp]
        public async Task SetUp()
        {
            var browser = await _playwright.Chromium.LaunchAsync(new() { Headless = false });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();

            var session = new BrowserPageSession(_playwright, page);
            App = new App(session);

            await LogInAsync(); 
        }

        [TearDown]
        public async Task TearDown()
        {
            if (App?.PageSession?.Context != null)
            {
                await App.PageSession.Context.CloseAsync();
            }
        }

        [OneTimeTearDown]
        public async Task TearDownPlaywright()
        {
           await Task.Run(()=> _playwright?.Dispose());
        }

        protected abstract UserConfig User { get; }

        protected virtual bool UseCookieLogin => false;

        private async Task LogInAsync()
        {
            if (UseCookieLogin)
            {
                string url = $"{AppSettings.App.Url}{AppSettings.App.HomePagePath}";
                await CookieLogIn();
                await App.Page.GotoAsync($"{url}");
            }
            else
            {
                string url = AppSettings.App.Url;
                await App.Page.GotoAsync(url);
                await UiLogIn();
            }
        }

        private async Task UiLogIn()
        {
            await App.LoginPage.LogInAsync(User.Username, User.Password);
        }

        private async Task CookieLogIn()
        {
            var expires = DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds(); // Expires in 1 hour

            await App.PageSession.Context.AddCookiesAsync(
            [
                new Cookie
                {
                    Name = "session-username",
                    Value = "standard_user",
                    Domain = "www.saucedemo.com",
                    Path = "/",
                    Expires = expires,
                    HttpOnly = false,
                    Secure = false
                }
            ]);
        }

        [OneTimeTearDown]
        public async Task Stop()
        {
            await App.PageSession.Browser.CloseAsync();
        }
    }

    public class StandardUserTest : BaseTest
    {
        protected override UserConfig User => AppSettings.Users.StandardUser;
        protected override bool UseCookieLogin => true;
    }
}
