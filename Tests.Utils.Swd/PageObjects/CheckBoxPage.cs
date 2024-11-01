using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;

namespace Tests.Utils.Swd.PageObjects;

public class CheckBoxPage : BasePage
{
    public string Url => "https://demoqa.com/checkbox";
    
    [FindBy(XPath = "//h1[contains(text(),\"Check Box\")]")]
    public Element? CheckBoxPageTitle { get; set; }

    [FindBy(CssSelector = "button[title='Expand all']")]
    public Element? ExpandButton { get; set; }
    
    [FindBy(XPath = "//div[@id='tree-node']/ol/li/span/label/span[@class='rct-checkbox']")]
    public CheckBox HomeCheckBox { get; set; }
    
    [FindBy(CssSelector = "button[title='Collapse all']")]
    public Element? CollapseButton { get; set; }
       
    [FindBy(CssSelector = "[for='tree-node-home'] .rct-icon-check")]
    public CheckBox HomeCheckBoxMarked { get; set; }
        
    [FindBy(CssSelector = ".rct-icon.rct-icon-parent-close > path")]
    public Element? HomeFolderIconInACollapsedMenu { get; set; }
        
    [FindBy(XPath = "//div[@id='tree-node']/ol/li/ol/li[1]/span[@class='rct-text']/label/span[@class='rct-checkbox']")]
    public CheckBox DesktopCheckBox { get; set; }
    
    [FindBy(XPath = "//div[@id='tree-node']/ol/li/ol/li[1]/ol/li[2]/span[@class='rct-text']/label/span[@class='rct-checkbox']")] 
    public CheckBox CommandsCheckBox { get; set; }

    [FindBy(XPath = "//div[@id='tree-node']/ol/li/ol/li[2]/ol/li[1]/ol/li[1]/span[@class='rct-text']")]
    public CheckBox ReactCheckBox { get; set; }
    
    [FindBy(XPath = "//div[@id='tree-node']/ol/li/ol/li[2]/span[@class='rct-text']/label/span[@class='rct-checkbox']")]
    public CheckBox DocumentsCheckBox { get; set; }
   
    [FindBy(CssSelector = "[for='tree-node-documents'] [d='M19 3H5c-1\\.11 0-2 \\.9-2 2v14c0 1\\.1\\.89 2 2 2h14c1\\.11 0 2-\\.9 2-2V5c0-1\\.1-\\.89-2-2-2zm-9 14l-5-5 1\\.41-1\\.41L10 14\\.17l7\\.59-7\\.59L19 8l-9 9z']")]
    public CheckBox DocumentsCheckBoxMarked { get; set; }

    [FindBy(XPath = "//div[@id='tree-node']/ol/li/ol/li[3]/span[@class='rct-text']/label/span[@class='rct-checkbox']")]
    public CheckBox DownloadsCheckBox { get; set; }
        
    [FindBy (XPath = "//div[@id='result']/span[.='You have selected :']")]
    public Element? DescriptionOfSelectedItems { get; set; }
        

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

    public CheckBoxPage ExpandMenu()
    {
        ExpandButton.Click();
        return this;
    }

    public void CollapseMenu()
    {
        CollapseButton.Click();
    }

    public bool CheckExpandButton()
    {
        var element = ExpandButton;
        return element.IsDisplayed() && element.IsEnabled();
    }

    public bool CheckExpandedMenuByCommandsCheckBox()
    {
        var element = CommandsCheckBox;
        return element.IsDisplayed();
    }

    public bool CheckCollapseButton()
    {
        var element = CollapseButton;
        return element.IsDisplayed() && element.IsEnabled();
    }

    public bool CheckCollapsedMenuByTheHomeFolderIcon()
    {
        var element = HomeFolderIconInACollapsedMenu;
        return element.IsDisplayed();
    }

    public void MarkHomeCheckbox()
    {
        HomeCheckBox.Check();
        //Thread.Sleep(3000); 
    }

    public bool CheckTheDescriptionOfSelectedItems()
    {
        var element = DescriptionOfSelectedItems;
        return element.IsDisplayed();
    }

    public bool CheckTheTextOfTheDescription()
    {
        var element = DescriptionOfSelectedItems;
        return element.GetText().Equals("You have selected :");
    }

    public bool VerifyTheHomeCheckBoxIsMarked()
    {
        var element = HomeCheckBoxMarked;
        return element.IsDisplayed();
    }

    public bool VerifyTheDocumentsCheckBoxIsMarked()
    {
        var element = DocumentsCheckBoxMarked;
        return element.IsDisplayed();
    }

    public void UnMarkHomeCheckbox()
    {
        HomeCheckBox.UnCheck();
       // Thread.Sleep(5000); 
    }
}