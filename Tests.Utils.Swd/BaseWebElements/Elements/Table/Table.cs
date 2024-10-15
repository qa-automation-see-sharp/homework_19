using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements.Abstractions;

namespace Tests.Utils.Swd.BaseWebElements.Elements.Table;

public class Table : BaseElement
{
    [FindBy(XPath = "//div[@class ='rt-thead -header']/div/div/div[@class='rt-resizable-header-content']" )]
    public Elements<Element> Heads { get; set; }

    [FindBy(XPath = "//div[@class='rt-tr-group']/div[contains(@class,'rt-tr -odd') or contains(@class,'rt-tr -even')]")]
    public Elements<Row> Rows { get; set; }
    
    public Element? GetCellFromRows(string text)
    {
        var getCorrectRow = Rows.FirstOrDefault(r => r.WrappedIWebElement!.Text.Contains(text));
        var cell = getCorrectRow?.GetCellFromRows(text);
        return cell;
    }
    
    public Element GetHead(string text)
    {
        var heads = Heads.GetElements();
        var head = heads.FirstOrDefault(e => e.GetText() == text);
        return head;
    }
}