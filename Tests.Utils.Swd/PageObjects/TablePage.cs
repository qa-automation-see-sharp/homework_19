using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Elements.Table;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

namespace Tests.Utils.Swd.PageObjects;

public class TablePage : BasePage
{
    private string Url => "https://demoqa.com/webtables";
    
    [FindBy(XPath = "//h1[contains(text(),\"Web Tables\")]")]
    public Element? Title { get; set; }

    [FindBy(XPath = "//div[@class='ReactTable -striped -highlight']")]
    public Table? Table { get; set; }

    [FindBy(Id = "addNewRecordButton")]
    public Button? Add { get; set; }

    public TablePage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }

    public TablePage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public TablePage ClickOnRowWithText(string text)
    {
         Table?.GetCellFromRows(text).Click();
         return this;
    }

    public RegistrationFormsWindow ClickAddButton()
    {
        Add.Click();
        return new RegistrationFormsWindow();
    }

}