using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

namespace Tests.Utils.Swd.PageObjects;

public class RadioButtonPage : BasePage
{
    public string Url => "https://demoqa.com/radio-button";

    [FindBy(XPath = "//label[@class='custom-control-label' and @for='yesRadio']")]
    public Element? RadioButtonYesLabel { get; set; }

    [FindBy(XPath = "//label[@class='custom-control-label' and @for='impressiveRadio']")]
    public Element? RadioButtonImpressiveLabel { get; set; }

    [FindBy(Id = "yesRadio")]
    public RadioButton? RadioButtonYes { get; set; }

    [FindBy(Id = "impressiveRadio")]
    public RadioButton? RadioButtonImpressive { get; set; }
    
    [FindBy(Id = "noRadio")]
    public RadioButton? RadioButtonNo { get; set; }

    [FindBy(ClassName = "mt-3")]
    public Element? Output { get; set; }
    private string _outputSelection = "You have selected";

    [FindBy(ClassName = "text-success")]
    public Element? SuccessMessage { get; set; }
    private string _outputYes = "Yes";
    private string _outputImpressive = "Impressive";

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

    public bool OutputTextContainsYes()
    {
        return Output!.GetText().Contains(_outputSelection) &&
               SuccessMessage!.GetText().Contains(_outputYes);
    }

    public bool OutputTextContainsImpressive()
    {
        return Output!.GetText().Contains(_outputSelection) &&
               SuccessMessage!.GetText().Contains(_outputImpressive);
    }
}