namespace PlayWright.Library.Components.Context
{
    public partial class UiContext
    {
        protected static TUiContext Construct<TUiContext>(By? by, SearchContext childSearchContext) where TUiContext : UiContext
        {
            var type = typeof(TUiContext);
            // Try (SearchContext, By) constructor first
            var ctor = type.GetConstructor([typeof(SearchContext), typeof(By)]);

            if (ctor != null)
                return (TUiContext)ctor.Invoke([childSearchContext, by]);

            // Try (SearchContext) constructor as fallback
            ctor = type.GetConstructor([typeof(SearchContext)]);

            if (ctor != null)
                return (TUiContext)ctor.Invoke([childSearchContext]);

            // Throw if neither constructor is found
            throw new InvalidOperationException($"{type.Name} must define a public constructor with either (SearchContext, By) or (SearchContext).");
        }
    }
}
