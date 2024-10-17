using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;
using static Tests.Utils.Swd.Helpers.TableXPathHelper;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Table;

public class Table : BaseElement
{
    [FindBy(XPath = "//div[@class='rt-resizable-header-content']")]
    public Elements<Element> Heads { get; set; }

    [FindBy(XPath = "//div/div[contains(@class,'rt-tr -odd') or contains(@class,'rt-tr -even')]")]
    public Elements<Row> Rows { get; set; }

    [FindBy(XPath = "//div[@class='rt-resizable-header-content']")]
    public Elements<Column> Columns { get; set; }

    public Elements<Row> FindRows()
    {
        Rows.FindElements();
        var rows = Rows.GetAll();
        for (var i = 0; i < rows.Count; i++)
        {
            rows[i].RowNumber = i + 1;
            rows[i].Locator = By.XPath(GetRowXPath(i + 1));
        }

        return Rows;
    }

    public Elements<Column> FindColumns()
    {
        Columns.FindElements();
        var columnsCount = Columns.GetAll().Count;
        var columns = Columns.GetAll();
        for (var i = 0; i < columnsCount; i++)
        {
            columns[i].ColumnNumber = i + 1;
            columns[i].Locator = By.XPath(GetColumnXPath(i + 1));
        }

        return Columns;
    }
}