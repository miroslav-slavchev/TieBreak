using Microsoft.Playwright;

namespace PlayWright.Library
{
    public class BrowserPageSession(IPlaywright playwright, IPage page)
    {
        public IPlaywright Playwright { get; } = playwright;
        public IBrowser Browser => Context.Browser!;
        public IBrowserContext Context => Page.Context;
        public IPage Page { get; } = page;
    }
}
