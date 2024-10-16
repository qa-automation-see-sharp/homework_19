using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;
using static Tests.Utils.Swd.Helpers.TableXPathHelper;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Table;

public class Table : BaseElement
{
    [FindBy(XPath = "//div[@class ='rt-thead -header']/div/div/div[@class='rt-resizable-header-content']")]
    public Elements<Heads> Heads { get; set; }

    [FindBy(XPath = "//div/div[contains(@class,'rt-tr -odd') or contains(@class,'rt-tr -even')]")]
    public Elements<Row> Rows { get; set; }

    [FindBy(XPath = "//div/div[contains(@class,'rt-tr -odd') or contains(@class,'rt-tr -even')]")]
    public Elements<Column> Columns { get; set; }

    public Table FindAllRows()
    {
        Rows.FindElements();
        var rows = Rows.GetElements();
        for (var i = 0; i < rows.Count; i++)
        {
            rows[i].Locator = By.XPath(GetRowXPath(i + 1));
        }

        return this;
    }
    
    public Table FindAllColumns(int columnsCount)
    {
        Columns.FindElements();
        var columns = Columns.GetElements();
        for (var i = 0; i < columns.Count; i++)
        {
            columns[i].Locator = By.XPath(GetColumnXPath(i + 1));
        }

        return this;
    }
}