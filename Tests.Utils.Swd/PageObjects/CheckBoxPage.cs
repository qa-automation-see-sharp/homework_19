using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

namespace Tests.Utils.Swd.PageObjects;

public class CheckBoxPage : BasePage
{
    public string Url => "https://demoqa.com/checkbox";

    [FindBy(XPath = "//h1[contains(text(),\"Check Box\")]")]
    public Element? CheckBoxTitle { get; set; }

    [FindBy(XPath = "//span[@class='rct-title' and text()='Home']")]
    public Element? HomeBoxTitle { get; set; }

    [FindBy(XPath = "//button[@aria-label='Expand all' and @title='Expand all']")]
    public Button? ExpandAllButton { get; set; }

    [FindBy(XPath = "//button[@aria-label='Collapse all' and @title='Collapse all']")]
    public Button? CollapseAllButton { get; set; }

    [FindBy(XPath = "//span[@class='rct-title' and text()='Desktop']")]
    public Element? DesktopFolder { get; set; }

    [FindBy(XPath = "//span[@class='rct-title' and text()='Documents']")]
    public Element? DocumentsFolder { get; set; }

    [FindBy(XPath = "//span[@class='rct-title' and text()='Downloads']")]
    public Element? DownloadsFolder { get; set; }

    [FindBy(XPath = "//label[@for='tree-node-home']")]
    public CheckBox? HomeCheckBox { get; set; }

    [FindBy(XPath = "//label[@for='tree-node-notes']")]
    public CheckBox? NotesCheckBox { get; set; }

    [FindBy(XPath = "//label[@for='tree-node-desktop']")]
    public CheckBox? DesktopCheckBox { get; set; }

    [FindBy(XPath = "//label[@for='tree-node-documents']")]
    public CheckBox? DocumentsCheckBox { get; set; }

    [FindBy(XPath = "//label[@for='tree-node-downloads']")]
    public CheckBox? DownloadsCheckBox { get; set; }

    [FindBy(XPath = "//*[@id='result']")]
    public Element? Result { get; set; }

    public CheckBoxPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }

    public CheckBoxPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public bool VerifyCheckBoxTitle()
    {
        return CheckBoxTitle.IsDisplayed() && CheckBoxTitle.IsEnabled();
    }

    public bool CheckHomeBoxTitle()
    {
        return HomeBoxTitle.IsDisplayed() && HomeBoxTitle.IsEnabled();
    }

    public string ResultText()
    {
        return Result.GetText();
    }

    public bool CheckUnrolledFolders()
    {
        try
        {
            var elements = new List<Element?>
        {
            DesktopFolder,
            DocumentsFolder,
            DownloadsFolder
        }.Where(e => e != null).ToList();

            return elements.Any() && elements.All(IsElementVisible);

        }
        catch (NullReferenceException e)
        {
            return false;
        }
    }
    private bool IsElementVisible(Element? element)
    {
        return element != null && element.IsDisplayed() && element.IsEnabled();
    }

    public CheckBoxPage CheckHomeBox()
    {
        var homeBox = HomeCheckBox;
        homeBox.Click();

        return this;
    }

    public CheckBoxPage CheckNotesBox()
    {
        var notesBox = NotesCheckBox;
        notesBox.Click();

        return this;
    }

    public bool CheckAllBoxesAreChecked()
    {
        var checkBoxes = new List<CheckBox>
        {
            HomeCheckBox,
            DesktopCheckBox,
            DocumentsCheckBox,
            DownloadsCheckBox
        };

        return checkBoxes.All(IsCheckboxChecked);
    }

    private bool IsCheckboxChecked(CheckBox checkbox)
    {
        return checkbox != null && checkbox.IsDisplayed() && checkbox.IsEnabled();
    }
}