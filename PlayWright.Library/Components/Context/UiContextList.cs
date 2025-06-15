using Microsoft.Playwright;

namespace PlayWright.Library.Components.Context
{
    /// <summary>
    /// Represents a lazily-evaluated, asynchronous enumerable list of UI components derived from <see cref="UiContext"/>.
    /// </summary>
    /// <typeparam name="TUiComponent">The type of UI component, derived from <see cref="UiContext"/>.</typeparam>
    /// <param name="searchContext">The search context used to scope the element lookup.</param>
    /// <param name="by">The selector and related options used to find the elements.</param>
    /// <param name="precondition">
    /// Optional asynchronous delegate that must return true before enumeration begins.
    /// Used to wait for conditions like data readiness or UI signals.
    /// </param>
    /// <param name="skipDefaultWait">
    /// If <c>true</c>, skips the default Playwright <c>waitForSelector</c> call before enumeration.
    /// </param>
    public class UiContextList<TUiComponent>(
        SearchContext searchContext,
        By by,
        Func<Task<bool>>? precondition = null,
        bool skipDefaultWait = false
        ) : UiContext(searchContext, by), IAsyncEnumerable<TUiComponent> where TUiComponent : UiContext
    {
        private List<TUiComponent>? _cachedList;
        private readonly Func<Task<bool>>? _precondition = precondition;
        private readonly bool _skipDefaultWait = skipDefaultWait;

        public async IAsyncEnumerator<TUiComponent> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            await EnsureElementsAttachedAsync();

            int count = await Locator.CountAsync();
            for (int i = 0; i < count; i++)
            {
                By nthBy = new(By.Selector, By.Options, By.WaitOptions, By.SearchIn, i);
                yield return Construct<TUiComponent>(nthBy, SearchContext);
            }
        }

        private async Task EnsureElementsAttachedAsync()
        {
            if (_precondition != null)
            {
                var success = await _precondition();
                if (!success)
                    throw new TimeoutException("Custom precondition failed.");
                return;
            }

            if (_skipDefaultWait)
                return;

            try
            {
                var waitOptions = new PageWaitForSelectorOptions
                {
                    State = WaitForSelectorState.Attached,
                    Strict = false,
                    Timeout = 4000
                };
                await Page.WaitForSelectorAsync(By.Selector, waitOptions);

            }
            catch
            {
                // Expect 0 items list
            }
        }

        public async Task<List<TUiComponent>> ToListAsync(bool useCache = false)
        {
            if (useCache && _cachedList != null)
                return _cachedList;

            var list = new List<TUiComponent>();
            await foreach (var element in this)
                list.Add(element);

            if (useCache)
                _cachedList = list;

            return list;
        }

        public void ClearCache() => _cachedList = null;

        public async Task<TUiComponent> FirstAsync() => (await ToListAsync()).First();
        public async Task<TUiComponent?> FirstOrDefaultAsync() => (await ToListAsync()).FirstOrDefault();
        public async Task<TUiComponent?> FirstAsync(Func<TUiComponent, bool> predicate) => (await ToListAsync()).First(predicate);
        public async Task<TUiComponent?> FirstAsync(Func<TUiComponent, Task<bool>> predicate)
        {
            await foreach (var item in this)
            {
                if (await predicate(item))
                    return item;
            }
            throw new Exception("Cannot find item");
        }

        public async Task<TUiComponent?> FirstOrDefaultAsync(Func<TUiComponent, bool> predicate) => (await ToListAsync()).FirstOrDefault(predicate);

        public async Task<TUiComponent?> FirstOrDefaultAsync(Func<TUiComponent, Task<bool>> predicate)
        {
            await foreach (var item in this)
            {
                if (await predicate(item))
                    return item;
            }
            return null;
        }

        public async Task<bool> ContainsAsync(Func<TUiComponent, Task<bool>> predicate) => (await FirstOrDefaultAsync(predicate)) is not null;

        public async Task<List<TResult>> SelectAsync<TResult>(Func<TUiComponent, Task<TResult>> asyncSelector)
        {
            ArgumentNullException.ThrowIfNull(asyncSelector);
            var results = new List<TResult>();
            await foreach (var item in this)
                results.Add(await asyncSelector(item));
            return results;
        }

        public async Task<List<TUiComponent>> WhereAsync(Func<TUiComponent, Task<bool>> predicate)
        {
            var results = new List<TUiComponent>();
            await foreach (var item in this)
            {
                if (await predicate(item))
                    results.Add(item);
            }
            return results;
        }

        public async Task ForEachAsync(Func<TUiComponent, Task> action)
        {
            ArgumentNullException.ThrowIfNull(action);
            await foreach (var item in this)
                await action(item);
        }

        public async Task<TUiComponent?> SingleOrDefaultAsync(Func<TUiComponent, Task<bool>> predicate)
        {
            TUiComponent? match = null;
            await foreach (var item in this)
            {
                if (await predicate(item))
                {
                    if (match != null)
                        throw new InvalidOperationException("Multiple elements match the condition.");
                    match = item;
                }
            }
            return match;
        }

        public async Task<Dictionary<TKey, List<TUiComponent>>> GroupByAsync<TKey>(Func<TUiComponent, Task<TKey>> keySelector) where TKey : notnull
        {
            var groups = new Dictionary<TKey, List<TUiComponent>>();
            await foreach (var item in this)
            {
                var key = await keySelector(item);
                if (!groups.ContainsKey(key))
                    groups[key] = new List<TUiComponent>();
                groups[key].Add(item);
            }
            return groups;
        }

        public TUiComponent FirstWithText(string text)
        {
            var options = By.Options ?? new();
            options.HasText = text;
            By by = new(By.Selector, options, By.WaitOptions, By.SearchIn);
            return Construct<TUiComponent>(by, SearchContext);
        }

        public async Task<TUiComponent> LastAsync()
        {
            var list = await ToListAsync();
            if (list.Count == 0)
                throw new InvalidOperationException("No elements found.");
            return list.Last();
        }

        public async Task<TUiComponent> NthAsync(int index)
        {
            var list = await ToListAsync();
            if (index < 0 || index >= list.Count)
                throw new ArgumentOutOfRangeException($"Index {index} is out of range.");
            return list[index];
        }

        public async Task<int> CountAsync() => await Locator.CountAsync();
    }
}
