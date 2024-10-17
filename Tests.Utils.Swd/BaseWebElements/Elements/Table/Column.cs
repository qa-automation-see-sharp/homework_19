using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;
using Tests.Utils.Swd.Helpers;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Table;

public class Column : BaseElement
{
    public int ColumnNumber { get; set; }

    public Elements<Element> Cells { get; set; }

    public Elements<Element> FindCells()
    {
        Cells = new Elements<Element>(Locator, this);
        Cells.FindElements();
        var cells = Cells.GetAll();
        for (var i = 0; i < cells.Count; i++)
        {
            cells[i].Locator = By.XPath(TableXPathHelper.GetCellFromTheColumnXPath(i + 1, ColumnNumber));
        }

        return Cells;
    }
}