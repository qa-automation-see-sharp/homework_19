using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

namespace Tests.Utils.Swd.PageObjects;

public class RadioButtonPage : BasePage
{
    public string Url => "https://demoqa.com/radio-button";
    
    [FindBy(XPath = "//h1[contains(text(),\"Radio Button\")]")]
    public Element? Title { get; set; }
    
    [FindBy(CssSelector = "[for='yesRadio']")]
    private Button? YesRadioButton { get; set; }
    
    [FindBy(CssSelector = "[class='mt-3']")]
    private Element? YouHaveSelectedOption { get; set; }
    
    [FindBy(CssSelector = "[for='impressiveRadio']")]
    private Button? ImpressiveRadioButton { get; set; }
    
    [FindBy(CssSelector = "[for='noRadio']")]
    private Button? NoRadioButton { get; set; }
    
    
    public RadioButtonPage OpenInBrowser (BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }
    
    public RadioButtonPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public void ClickYesRadioButton()
    {
        YesRadioButton.Click();
    }

    public bool YouHaveSelectedYesMessage()
    {
        return YouHaveSelectedOption.GetText().Contains("You have selected Yes");
    }

    public bool CheckNoRadioButton()
    {
        NoRadioButton.Click();
        return NoRadioButton.IsEnabled();
    }

    public void ClickImpressiveRadioButton()
    {
        ImpressiveRadioButton.Click();
    }
    
    public bool YouHaveSelectedImpressiveMessage()
    {
        return YouHaveSelectedOption.GetText().Contains("You have selected Impressive");
    }
}