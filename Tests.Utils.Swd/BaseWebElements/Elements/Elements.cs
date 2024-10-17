using System.Collections;
using OpenQA.Selenium;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

namespace Tests.Utils.Swd.BaseWebElements.Elements;

public class Elements<T> : BaseElement
    where T : BaseElement, new()
{
    private IList<T> _collection = new List<T>();

    public Elements(By locator, BaseElement parent)
    {
        Locator = locator;
        Parent = parent;
    }

    public int Count => _collection.Count;
    
    public void FindElements()
    {
        _collection = FindElements<T>().ToList();
    }

    public IList<T> GetAll()
    {
        return _collection;
    }

    public T GetElement(int index)
    {
        return _collection.ElementAt(index);
    }

    public T? FirstOrDefault(Func<T, bool> condition)
    {
        return _collection.FirstOrDefault(condition);
    }
}