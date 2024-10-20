using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Browser;

namespace Tests.Utils.Swd.PageObjects;

public class RadioButtonPage : BasePage
{
    public string Url => "https://demoqa.com/radio-button";

    [FindBy(XPath = "//h1[contains(text(),\"Radio Button\")]")]
    public Element? Title { get; set; }

    [FindBy(XPath = "//label[@class='custom-control-label' and @for='yesRadio']")]
    public Button? YesRadio { get; set; }

    [FindBy(XPath = "//p[@class='mt-3']")]
    public Element? Output { get; set; }

    public RadioButtonPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }
    
    public RadioButtonPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }
}