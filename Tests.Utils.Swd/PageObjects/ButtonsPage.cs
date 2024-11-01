using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;

namespace Tests.Utils.Swd.PageObjects;

public class ButtonsPage: BasePage
{
    public string Url => "https://demoqa.com/buttons";
    
    [FindBy(XPath = "//h1[contains(text(),\"Buttons\")]")]
    public Element? ButtonsTitle { get; set; }
    
    [FindBy(XPath = "/html//button[@id='doubleClickBtn']")]
    private Button? DoubleClickButton { get; set; }
    
    [FindBy(XPath = "/html//p[@id='doubleClickMessage']")]
    public Element? DoubleClickMessage { get; set; }
    
    [FindBy(XPath = "//button[@id='rightClickBtn']")]
    private Button? RightClickButton { get; set; }
    
    [FindBy(XPath = "/html//p[@id='rightClickMessage']")]
    public Element? RightClickMessage { get; set; }
    
    [FindBy(XPath = "//button[text()='Click Me']")]
    public Element? ClickMeButton { get; set; }
    
    [FindBy(XPath = "/html//p[@id='dynamicClickMessage']")]
    public Element? ClickMeMessage { get; set; }

    public ButtonsPage OpenInBrowser (BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }
    
    public ButtonsPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }
    
    public void DoubleClick()
    {
        DoubleClickButton.DoubleClick();
    }
    
    public void RightClick()
    {
        RightClickButton.RightClick();
    }
    
    public void ClickMe()
    {
        ClickMeButton.Click();
    }
}