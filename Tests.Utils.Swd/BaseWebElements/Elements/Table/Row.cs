using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Table;

public class Row : BaseElement
{
    [FindBy(XPath = "//div[@class='rt-td']")]
    public Elements<Element> Cells { get; set; }

    public Element GetCellFromRows(string text)
    {
        var cells = Cells.GetElements();
        var cell = cells.FirstOrDefault(e => e.GetText() == text);
        return cell;
    }
}