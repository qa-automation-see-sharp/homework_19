using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Elements.Table;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

namespace Tests.Utils.Swd.PageObjects;

public class WebTablePage : BasePage
{
    private string Url => "https://demoqa.com/webtables";
    
    [FindBy(XPath = "//h1[contains(text(),\"Web Tables\")]")]
    public Element? Title { get; set; }

    [FindBy(XPath = "//div[@class='rt-tbody']")]
    public Table? Table { get; set; }

    [FindBy(Id = "addNewRecordButton")]
    public Button? Add { get; set; }

    [FindBy(CssSelector = ".ReactTable .rt-thead .rt-th:nth-child(3)")]
    public Element AgeColumnHeader { get; set; }

    [FindBy(XPath ="//*[starts-with(@id,'delete-record')]")]
    public Element Delete {get; set;}
    

    public WebTablePage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }

    public WebTablePage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public bool IsSortedAscending(List<int> list)
    {
        return list.SequenceEqual(list.OrderBy(x => x));
    }

    public bool IsSortedDescending(List<int> list)
    {
        return list.SequenceEqual(list.OrderByDescending(x => x));
    }   

    public RegistrationFormsWindow ClickAddButton()
    {
        Add.Click();
        return new RegistrationFormsWindow();
    }

    public static List<string> DataSorting(IList<Element> list)
    {
        var dataSorting = new List<string>();

        foreach (var element in list)
        {
            dataSorting.Add(element.GetText());
        }
        return dataSorting;
    }
}