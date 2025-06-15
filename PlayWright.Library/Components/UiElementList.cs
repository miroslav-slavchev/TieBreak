using PlayWright.Library.Components.Context;

namespace PlayWright.Library.Components
{
    public class UiElementList<TUiElement>(SearchContext searchContext, By by, Func<Task<bool>>? precondition = null, bool skipDefaultWait = false)
        : UiContextList<TUiElement>(searchContext, by, precondition, skipDefaultWait) where TUiElement : UiElement
    { }

    public class UiElementList(SearchContext searchContext, By by, Func<Task<bool>>? precondition = null, bool skipDefaultWait = false)
        : UiElementList<UiElement>(searchContext, by, precondition, skipDefaultWait)
    { }
}
