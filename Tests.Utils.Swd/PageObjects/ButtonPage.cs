using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

namespace Tests.Utils.Swd.PageObjects;

public class ButtonPage : BasePage
{
    public string Url => "https://demoqa.com/buttons";

    [FindBy(Id = "doubleClickBtn")]
    public Button? DoubleClickButton { get; set; }

    [FindBy(Id = "rightClickBtn")]
    public Button? RightClickButton { get; set; }

    [FindBy(XPath = "//button[text()='Click Me']")]
    public Button? LeftClickButton { get; set; }

    [FindBy(Id = "doubleClickMessage")]
    public Button? DoubleClickMessage { get; set; }

    [FindBy(Id = "rightClickMessage")]
    public Button? RightClickMessage { get; set; }

    [FindBy(Id = "dynamicClickMessage")]
    public Button? LeftClickMessage { get; set; }

    public string outputDoubleClick = "You have done a double click";
    public string outputRightClick = "You have done a right click";
    public string outputLeftClick = "You have done a dynamic click";

    public ButtonPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }

    public ButtonPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }    
}