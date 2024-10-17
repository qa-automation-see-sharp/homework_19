using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;
using Tests.Utils.Swd.Helpers;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Table;

public class Row : BaseElement
{
    public int RowNumber { get; set; }
    
    public Elements<Element> Cells { get; set; }

    public Elements<Element> FindCells()
    {
        var locatorString = Locator?.Criteria + "/div";
        Cells = new Elements<Element>(By.XPath(locatorString), this);
        Cells.FindElements();
        var cells = Cells.GetAll();
        for (var i = 0; i < cells.Count; i++)
        {
            cells[i].Locator = By.XPath(TableXPathHelper.GetCellFromRowXPath(RowNumber, i + 1));
        }

        return Cells;
    }
}