using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;

namespace Tests.Utils.Swd.PageObjects;

public class ButtonsPage : BasePage
{
    public string Url => "https://demoqa.com/buttons";

    [FindBy(XPath = "//h1[contains(text(),\"Buttons\")]")]
    public Element? Title { get; set; }

    [FindBy(Id = "doubleClickBtn")]
    public Button? DoubleClickButton { get; set; }
    [FindBy(Id = "rightClickBtn")]
    public Button? RightClickButton { get; set; }
    [FindBy(XPath ="//button[text() = 'Click Me']")]
    public Button? DynamicClickButton { get; set; }
    [FindBy(Id = "doubleClickMessage")]
    public Element? DoubleClickMessage { get; set; }
    [FindBy(Id = "rightClickMessage")]
    public Element? RightClickMessage { get; set; }
    [FindBy(Id = "dynamicClickMessage")]
    public Element? DynamicClickMessage { get; set; }

    public ButtonsPage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }
    
    public ButtonsPage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }
    public bool WaitForElementText(Element element, string expectedText, int maxWaitTimeInSeconds = 10)
    {
        DateTime endTime = DateTime.Now.AddSeconds(maxWaitTimeInSeconds);
        while (DateTime.Now < endTime)
        {
            if (element != null && element.GetText() == expectedText)
            {
                return true;
            }
            Thread.Sleep(500);
        }
        return false;
    }
}