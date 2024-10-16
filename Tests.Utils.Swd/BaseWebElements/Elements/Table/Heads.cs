using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Table;

public class Heads : BaseElement
{
    [FindBy(XPath = "//div[@class ='rt-thead -header']/div/div/div[@class='rt-resizable-header-content']")]
    public Elements<Element> Cells { get; set; }
    
    public Heads()
    {
    }
    
    public Heads(string xpath)
    {
        Locator = By.XPath(xpath);
    }
}