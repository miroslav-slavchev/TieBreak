using PlayWright.Library.Components.Context;

namespace PlayWright.Library.Components
{
    public abstract class PageObject(SearchContext searchContext, By by) : UiContext(searchContext, by)
    {
        protected TPageObject InnerPageObject<TPageObject>(By? by = null) where TPageObject : PageObject
        {
            SearchContext childSearchContext = SearchContext.GetChildSearchContext(Locator);
            TPageObject pageObject = Construct<TPageObject>(by, childSearchContext);
            return pageObject;
        }

        protected PageObjectList<TPageObject> InnerPageObjects<TPageObject>(By? by = null, Func<Task<bool>>? precondition = null, bool skipDefaultWait = false) where TPageObject : PageObject
        {
            SearchContext childSearchContext = SearchContext.GetChildSearchContext(Locator);
            if (by == null)
            {
                var tempObject = Construct<TPageObject>(null, childSearchContext);
                by = tempObject.By;
            }
            PageObjectList<TPageObject> pageObjects = new(childSearchContext, by, precondition, skipDefaultWait);
            return pageObjects;
        }

        protected UiElement UiElement(By? by = null) => UiElement<UiElement>(by);

        protected TUiElement UiElement<TUiElement>(By? by = null) where TUiElement : UiElement
        {
            SearchContext childSearchContext = SearchContext.GetChildSearchContext(Locator);
            TUiElement element = Construct<TUiElement>(by, childSearchContext);
            return element;
        }

        protected UiElementList UiElements(By? by = null, Func<Task<bool>>? precondition = null, bool skipDefaultWait = false) => new(SearchContext.GetChildSearchContext(Locator), by, precondition, skipDefaultWait);
        protected UiElementList<TUiElement> UiElements<TUiElement>(By? by = null, Func<Task<bool>>? precondition = null, bool skipDefaultWait = false) where TUiElement : UiElement
        {
            if (by == null)
            {
                var tempElement = Construct<TUiElement>(null, SearchContext);
                by = tempElement.By;
            }
            SearchContext childSearchContext = SearchContext.GetChildSearchContext(Locator);
            UiElementList<TUiElement> elements = new(childSearchContext, by, precondition, skipDefaultWait);
            return elements;
        }

        public UiElement Target => new(SearchContext, By);
    }
}
