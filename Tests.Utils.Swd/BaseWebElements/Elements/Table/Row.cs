using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Table;

public class Row : BaseElement
{
    [FindBy(XPath = "//div[contains(@class,'rt-tr -odd' ) or contains(@class,'rt-tr -even')]//div[@class='rt-td']")]
    public Elements<Element> Cells { get; set; }

    public Row() { }

    public Row(string xpath)
    {
        Locator = By.XPath(xpath);
    }
    
}