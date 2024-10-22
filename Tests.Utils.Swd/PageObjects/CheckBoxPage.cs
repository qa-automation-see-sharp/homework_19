using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

namespace Tests.Utils.Swd.PageObjects;

public class CheckBoxPage : BasePage
{
    public string Url => "https://demoqa.com/checkbox";

    [FindBy(XPath = "//button[@aria-label='Toggle' and @title='Toggle']")]
    public Element? ToggleHome { get; set; }

    [FindBy(XPath = "//span[contains(text(), 'Desktop')]")]
    public Element? FolderDesktop { get; set; }

    [FindBy(XPath = "//span[contains(text(), 'Documents')]")]
    public Element? FolderDocuments { get; set; }

    [FindBy(XPath = "//span[contains(text(), 'Downloads')]")]
    public Element? FolderDownloads { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-home'] .rct-checkbox svg.rct-icon.rct-icon-uncheck")]
    public Element? UncheckedHome { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-desktop'] .rct-checkbox svg.rct-icon.rct-icon-uncheck")]
    public Element? UncheckedDesktop { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-documents'] .rct-checkbox svg.rct-icon.rct-icon-uncheck")]
    public Element? UncheckedDocuments { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-downloads'] .rct-checkbox svg.rct-icon.rct-icon-uncheck")]
    public Element? UncheckedDownloads { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-home'] .rct-checkbox svg.rct-icon.rct-icon-check")]
    public Element? CheckedHome { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-desktop'] .rct-checkbox svg.rct-icon.rct-icon-check")]
    public Element? CheckedDesktop { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-documents'] .rct-checkbox svg.rct-icon.rct-icon-check")]
    public Element? CheckedDocuments { get; set; }

    [FindBy(CssSelector = "label[for='tree-node-downloads'] .rct-checkbox svg.rct-icon.rct-icon-check")]
    public Element? CheckedDownloads { get; set; }

    [FindBy(XPath = "//*[@id='result']")]
    public Element? Output { get; set; }

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
    
    public bool IsDisplayedFolderList()
    {
        bool IsElementDisplayed(By locator)
        {
            var elements = WebDriverFactory.Driver.FindElements(locator);
            return elements.Count > 0 && elements[0].Displayed;
        }

        var folders = new List<bool>()
        {
            IsElementDisplayed(FolderDesktop!.Locator!),
            IsElementDisplayed(FolderDocuments!.Locator!),
            IsElementDisplayed(FolderDownloads!.Locator!)
        };

        return folders.All(x => x);
    }
    
    public bool OutputContainsCheckedElements()
    {
        var outputHome = "home";
        var outputDesktop = FolderDesktop!.GetText().ToLower();
        var outputDocuments = FolderDocuments!.GetText().ToLower();
        var outputDownloads = FolderDownloads!.GetText().ToLower();
        var outputText = "You have selected";
        return Output!.GetText().Contains(outputText) &&
                Output.GetText().Contains(outputDesktop) &&
                Output.GetText().Contains(outputDocuments) &&
                Output.GetText().Contains(outputDownloads) &&
                Output.GetText().Contains(outputHome);
    }
}