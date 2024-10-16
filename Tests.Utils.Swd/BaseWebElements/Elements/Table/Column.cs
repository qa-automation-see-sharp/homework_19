using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Table;

public class Column : BaseElement
{
    [FindBy(XPath = "//div[contains(@class,'rt-tbody')]/div/div[contains(@class,'rt-tr -odd') or contains(@class,'rt-tr -even')]/div[1]")]
    public Elements<Element> Cells { get; set; }

    public Column()
    {
    }

    public Column(string xpath)
    {
        Locator = By.XPath(xpath);
    }
}