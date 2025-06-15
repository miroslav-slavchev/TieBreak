using Microsoft.Playwright;

namespace PlayWright.Library.Components.Context
{
    public enum SearchIn
    {
        Parent,
        Root,
        Page
    }

    /// <summary>
    /// Represents a Locator configuration.
    /// </summary>
    public class By
    {
        public By(string selector, LocatorLocatorOptions? options = null, LocatorWaitForOptions? waitOptions = null, SearchIn searchIn = SearchIn.Parent, int index = -1)
        {
            Selector = selector;
            Options = options;
            WaitOptions = waitOptions;
            SearchIn = searchIn;
            Index = index;
        }

        public string Selector { get; }

        public LocatorLocatorOptions? Options { get; }

        public LocatorWaitForOptions? WaitOptions { get; }

        public SearchIn SearchIn { get; }

        public int Index { get; set; }
    }

    public static class Locate
    {
        public static By By(string selector, LocatorLocatorOptions? options = null, LocatorWaitForOptions? waitOptions = null, SearchIn searchIn = SearchIn.Parent, int index = -1) => new(selector, options, waitOptions, searchIn, index);

        public static ByBuilder BySelector(string selector) => new(selector);
    }

    public class ByBuilder(string selector)
    {
        public string Selector { get; } = selector;

        public LocatorLocatorOptions? Options { get; private set; }

        public LocatorWaitForOptions? WaitOptions { get; private set; }

        public SearchIn SearchIn { get; private set; }

        public int Index { get; private set; }

        public ByBuilder WithOptions(LocatorLocatorOptions? options)
        {
            Options = options;
            return this;
        }

        public ByBuilder WithText(string text)
        {
            Options ??= new LocatorLocatorOptions();
            Options.HasText = text;
            return this;
        }

        public ByBuilder WithWaitOptions(LocatorWaitForOptions? waitOptions)
        {
            WaitOptions = waitOptions;
            return this;
        }

        public ByBuilder WithSearchIn(SearchIn searchIn)
        {
            SearchIn = searchIn;
            return this;
        }

        public ByBuilder WithIndex(int index)
        {
            Index = index;
            return this;
        }

        public By Build()
        {
            if (string.IsNullOrEmpty(Selector))
            {
                throw new ArgumentException("Selector must be provided.");
            }
            return new By(Selector, Options, WaitOptions, SearchIn, Index);
        }
    }
}
