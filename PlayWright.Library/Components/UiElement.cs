using Microsoft.Playwright;
using PlayWright.Library.Components.Context;

namespace PlayWright.Library.Components
{
    public class UiElement(SearchContext searchContext, By by) : UiContext(searchContext, by)
    {
        public IFrameLocator ContentFrame => Locator.ContentFrame;

        /* protected async Task ActWithHighlight(Func<Task> action)
         {
             // Get current color
             var originalColor = await Locator.EvaluateAsync<string>("el => el.style.backgroundColor");

             //  Set color to yellow
             await Locator.EvaluateAsync($"el => el.style.backgroundColor = 'yellow'");

             // Act
             await action.Invoke();

             // Restore original color
             await Locator.EvaluateAsync($"(el, color) => el.style.backgroundColor = color", originalColor);
         }*/

        public ILocator And(ILocator locator)
        {
            return Locator.And(locator);
        }

        public virtual async Task<string> AriaSnapshotAsync(LocatorAriaSnapshotOptions? options = null)
        {
            return await Locator.AriaSnapshotAsync(options);
        }

        public virtual async Task BlurAsync(LocatorBlurOptions? options = null)
        {
            await Locator.BlurAsync(options);
        }

        public virtual async Task<LocatorBoundingBoxResult?> BoundingBoxAsync(LocatorBoundingBoxOptions? options = null)
        {
            return await Locator.BoundingBoxAsync(options);
        }

        public virtual async Task CheckAsync(LocatorCheckOptions? options = null)
        {
            await Locator.CheckAsync(options);
        }

        public virtual async Task ClearAsync(LocatorClearOptions? options = null)
        {
            await Locator.ClearAsync(options);
        }

        public virtual async Task ClickAsync(LocatorClickOptions? options = null)
        {
            await Locator.ClickAsync(options);
        }

        public virtual async Task DblClickAsync(LocatorDblClickOptions? options = null)
        {
            await Locator.DblClickAsync(options);
        }

        public virtual async Task DispatchEventAsync(string type, object? eventInit = null, LocatorDispatchEventOptions? options = null)
        {
            await Locator.DispatchEventAsync(type, eventInit, options);
        }

        public virtual async Task DragToAsync(ILocator target, LocatorDragToOptions? options = null)
        {
            await Locator.DragToAsync(target, options);
        }

        public virtual async Task<IElementHandle> ElementHandleAsync(LocatorElementHandleOptions? options = null)
        {
            return await Locator.ElementHandleAsync(options);
        }

        public virtual async Task FillAsync(string value, LocatorFillOptions? options = null)
        {
            await Locator.FillAsync(value, options);
        }

        public virtual ILocator Filter(LocatorFilterOptions? options = null)
        {
            return Locator.Filter(options);
        }

        public virtual async Task FocusAsync(LocatorFocusOptions? options = null)
        {
            await Locator.FocusAsync(options);
        }

        public virtual IFrameLocator FrameLocator(string selector)
        {
            return Locator.FrameLocator(selector);
        }

        public virtual async Task<string?> GetAttributeAsync(string name, LocatorGetAttributeOptions? options = null)
        {
            return await Locator.GetAttributeAsync(name, options);
        }

        public virtual async Task HighlightAsync()
        {
            await Locator.HighlightAsync();
        }

        public virtual async Task HoverAsync(LocatorHoverOptions? options = null)
        {
            await Locator.HoverAsync(options);
        }

        public virtual async Task<string> InnerHTMLAsync(LocatorInnerHTMLOptions? options = null)
        {
            return await Locator.InnerHTMLAsync(options);
        }

        public virtual async Task<string> InnerTextAsync(LocatorInnerTextOptions? options = null)
        {
            return await Locator.InnerTextAsync(options);
        }

        public virtual async Task<string> InputValueAsync(LocatorInputValueOptions? options = null)
        {
            return await Locator.InputValueAsync(options);
        }

        public virtual async Task<bool> IsCheckedAsync(LocatorIsCheckedOptions? options = null)
        {
            return await Locator.IsCheckedAsync(options);
        }

        public virtual async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = null)
        {
            return await Locator.IsDisabledAsync(options);
        }

        public virtual async Task<bool> IsEditableAsync(LocatorIsEditableOptions? options = null)
        {
            return await Locator.IsEditableAsync(options);
        }

        public virtual async Task<bool> IsEnabledAsync(LocatorIsEnabledOptions? options = null)
        {
            return await Locator.IsEnabledAsync(options);
        }

        public virtual async Task<bool> IsHiddenAsync(LocatorIsHiddenOptions? options = null)
        {
            return await Locator.IsHiddenAsync(options);
        }

        public virtual async Task<bool> IsVisibleAsync(LocatorIsVisibleOptions? options = null)
        {
            return await Locator.IsVisibleAsync(options);
        }

        public virtual async Task PressAsync(string key, LocatorPressOptions? options = null)
        {
            await Locator.PressAsync(key, options);
        }

        public virtual async Task PressSequentiallyAsync(string text, LocatorPressSequentiallyOptions? options = null)
        {
            await Locator.PressSequentiallyAsync(text, options);
        }

        public virtual async Task<byte[]> ScreenshotAsync(LocatorScreenshotOptions? options = null)
        {
            return await Locator.ScreenshotAsync(options);
        }

        public virtual async Task ScrollIntoViewIfNeededAsync(LocatorScrollIntoViewIfNeededOptions? options = null)
        {
            await Locator.ScrollIntoViewIfNeededAsync(options);
        }

        public virtual async Task<IReadOnlyList<string>> SelectOptionAsync(string values, LocatorSelectOptionOptions? options = null)
        {
            return await Locator.SelectOptionAsync(values, options);
        }

        public virtual async Task<IReadOnlyList<string>> SelectOptionAsync(IElementHandle values, LocatorSelectOptionOptions? options = null)
        {
            return await Locator.SelectOptionAsync(values, options);
        }

        public virtual async Task<IReadOnlyList<string>> SelectOptionAsync(IEnumerable<string> values, LocatorSelectOptionOptions? options = null)
        {
            return await Locator.SelectOptionAsync(values, options);
        }

        public virtual async Task<IReadOnlyList<string>> SelectOptionAsync(SelectOptionValue values, LocatorSelectOptionOptions? options = null)
        {
            return await Locator.SelectOptionAsync(values, options);
        }

        public virtual async Task<IReadOnlyList<string>> SelectOptionAsync(IEnumerable<IElementHandle> values, LocatorSelectOptionOptions? options = null)
        {
            return await Locator.SelectOptionAsync(values, options);
        }

        public virtual async Task<IReadOnlyList<string>> SelectOptionAsync(IEnumerable<SelectOptionValue> values, LocatorSelectOptionOptions? options = null)
        {
            return await Locator.SelectOptionAsync(values, options);
        }

        public virtual async Task SelectTextAsync(LocatorSelectTextOptions? options = null)
        {
            await Locator.SelectTextAsync(options);
        }

        public virtual async Task SetCheckedAsync(bool checkedState, LocatorSetCheckedOptions? options = null)
        {
            await Locator.SetCheckedAsync(checkedState, options);
        }

        public virtual async Task SetInputFilesAsync(string files, LocatorSetInputFilesOptions? options = null)
        {
            await Locator.SetInputFilesAsync(files, options);
        }

        public virtual async Task SetInputFilesAsync(IEnumerable<string> files, LocatorSetInputFilesOptions? options = null)
        {
            await Locator.SetInputFilesAsync(files, options);
        }

        public virtual async Task SetInputFilesAsync(FilePayload files, LocatorSetInputFilesOptions? options = null)
        {
            await Locator.SetInputFilesAsync(files, options);
        }

        public virtual async Task SetInputFilesAsync(IEnumerable<FilePayload> files, LocatorSetInputFilesOptions? options = null)
        {
            await Locator.SetInputFilesAsync(files, options);
        }

        public virtual async Task TapAsync(LocatorTapOptions? options = null)
        {
            await Locator.TapAsync(options);
        }

        public virtual async Task<string> TextContentAsync(LocatorTextContentOptions? options = null)
        {
            return (await Locator.TextContentAsync(options))!;
        }

        public virtual async Task UncheckAsync(LocatorUncheckOptions? options = null)
        {
            await Locator.UncheckAsync(options);
        }

        public virtual async Task WaitForAsync(LocatorWaitForOptions? options = null)
        {
            await Locator.WaitForAsync(options);
        }

        public virtual async Task WaitForAttributeValueAsync(string attributeName, string expectedValue, int timeout = 3000, int pollingIntervalMs = 100)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            while (stopwatch.ElapsedMilliseconds < timeout)
            {
                var attr = await Locator.GetAttributeAsync(attributeName);
                if (attr == expectedValue)
                    return;

                await Task.Delay(pollingIntervalMs);
            }

            throw new TimeoutException($"Attribute '{attributeName}' did not reach value '{expectedValue}' within {timeout}ms.");
        }
    }
}
