using System.Drawing;
using OpenQA.Selenium;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.Helpers;
using static Tests.Utils.Swd.Helpers.WaitHelper;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

public abstract class BaseElement
{
    public By? Locator { get; init; }
    public BaseElement? Parent { get; init; }

    public IWebElement? WrappedIWebElement { get; set; }

    protected BaseElement()
    {
        InitializationHelper.InitializeElements(this, Parent);
    }

    //Potential hidden recursion
    protected IWebElement FindElement()
    {
        var by = Locator;
        if (Parent is null)
        {
            var element = WaitAndHandleExceptionOrResult(
                () => WebDriverFactory.Driver.FindElement(by),
                e => e is null);
            return element;
        }
        else
        {
            var parentElement = Parent.FindElement();
            var element = WaitAndHandleExceptionOrResult(
                () => parentElement.FindElement(by),
                e => e is null);
            return element;
        }
    }

    //Potential hidden recursion
    protected IEnumerable<T> FindElements<T>() where T : BaseElement, new()
    {
        var by = Locator;
        if (Parent is null)
        {
            var elements = WaitAndHandleExceptionOrResult(() => WebDriverFactory.Driver.FindElements(by)
                    .Select(e => new T { WrappedIWebElement = e, Locator = by }).ToList(),
                elements => elements.Count == 0);
            return elements;
        }
        else
        {
            var parentElement = Parent.FindElement();
            var elements = WaitAndHandleExceptionOrResult(() => parentElement.FindElements(by)
                    .Select(e => new T { WrappedIWebElement = e, Locator = by }).ToList(),
                elements => elements.Count == 0);
            return elements;
        }
    }
    
    public string GetTagName()
    {
        var element = FindElement();
        var tagName = WaitAndHandleExceptions(() => element.TagName);
        return tagName;
    }

    public string GetText()
    {
        var element = FindElement();
        var text = WaitAndHandleExceptions(() => element.Text);
        return text;
    }

    public bool IsEnabled()
    {
        var element = FindElement();
        var enabled = WaitAndHandleExceptions(() => element.Enabled);
        return enabled;
    }

    public bool IsSelected()
    {
        var element = FindElement();
        var selected = WaitAndHandleExceptions(() => element.Selected);
        return selected;
    }

    public bool IsDisplayed()
    {
        var element = FindElement();
        var displayed = WaitAndHandleExceptions(() => element.Displayed);
        return displayed;
    }

    public Point GetLocation()
    {
        var element = FindElement();
        var location = WaitAndHandleExceptions(() => element.Location);
        return location;
    }

    public Size GetSize()
    {
        var element = FindElement();
        var size = WaitAndHandleExceptions(() => element.Size);
        return size;
    }

    public void Clear()
    {
        var element = FindElement();
        WaitAndHandleExceptions(() => element.Clear());
    }

    public void SendKeys(string text)
    {
        var element = FindElement();
        WaitAndHandleExceptions(() => element.SendKeys(text));
    }

    public void Submit()
    {
        var element = FindElement();
        WaitAndHandleExceptions(() => element.Submit());
    }

    public void Click()
    {
        var element = FindElement();
        WaitAndHandleExceptions(() => element.Click());
    }

    public string GetAttribute(string attributeName)
    {
        var element = FindElement();
        var attribute = WaitAndHandleExceptions(() => element.GetAttribute(attributeName));
        return attribute;
    }

    public string GetDomAttribute(string attributeName)
    {
        var element = FindElement();
        var attribute = WaitAndHandleExceptions(() => element.GetAttribute(attributeName));
        return attribute;
    }

    public string GetDomProperty(string propertyName)
    {
        var element = FindElement();
        var property = WaitAndHandleExceptions(() => element.GetDomProperty(propertyName));
        return property;
    }

    public string GetCssValue(string propertyName)
    {
        var element = FindElement();
        var cssValue = WaitAndHandleExceptions(() => element.GetCssValue(propertyName));
        return cssValue;
    }

    public ISearchContext GetShadowRoot()
    {
        var element = FindElement();
        var shadowRoot = WaitAndHandleExceptions(() => element.GetShadowRoot());
        return shadowRoot;
    }
}