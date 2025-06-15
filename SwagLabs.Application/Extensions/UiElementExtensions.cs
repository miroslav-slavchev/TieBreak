using PlayWright.Library.Components;

namespace SwagLabs.Application.Extensions
{
    public static class UiElementExtensions
    {
        public static async Task<string> DataTestAttributeAsync(this UiElement element)
        {
            var dataTestAttribute = await element.GetAttributeAsync("data-test");
            return dataTestAttribute;
        }
    }
}
