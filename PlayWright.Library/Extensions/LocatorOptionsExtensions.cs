using Microsoft.Playwright;

namespace PlayWright.Library.Extensions
{
    public static class LocatorOptionsExtensions
    {
        public static LocatorLocatorOptions ConvertToLocatorOptions(this PageLocatorOptions pageOptions)
        {
            if (pageOptions == null) return null;

            return new LocatorLocatorOptions
            {
                Has = pageOptions.Has,
                HasNot = pageOptions.HasNot,
                HasTextString = pageOptions.HasTextString,
                HasNotTextString = pageOptions.HasNotTextString
            };
        }

        public static PageLocatorOptions ConvertToPageOptions(this LocatorLocatorOptions locatorOptions)
        {
            if (locatorOptions == null) return null;

            return new PageLocatorOptions
            {
                Has = locatorOptions.Has,
                HasNot = locatorOptions.HasNot,
                HasTextString = locatorOptions.HasTextString,
                HasNotTextString = locatorOptions.HasNotTextString
            };
        }
    }
}