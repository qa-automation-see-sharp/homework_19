using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class ButtonsPageTests
{
    private ButtonsPage _buttonsPage;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _buttonsPage = new ButtonsPage();
        _buttonsPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized");
        _buttonsPage.NavigateToPage();
    }
    
    [Test, Order(1)]
    [Description("This test checks if the user has landed to the page with the correct title")]
    public void OpenButtonsPage_TitleIsCorrect()
    {
        var title = _buttonsPage.ButtonsTitle?.GetText();

        Assert.That(title, Is.EqualTo("Buttons"));
    }

    [Test, Order(2)]
    [Description("This test checks double click on the button and the message output")]
    public void DoubleClickButton_ReturnsMessage()
    {
        _buttonsPage.DoubleClick();
        var doubleClickMessage = _buttonsPage.DoubleClickMessage?.GetText();
        
        Assert.That(doubleClickMessage, Is.EqualTo("You have done a double click"));
    }
    
    [Test, Order(3)]
    [Description("This test checks right click on the button and the message output")]
    public void RightClickButton_ReturnsMessage()
    {
        _buttonsPage.RightClick();
        var rightClickMessage = _buttonsPage.RightClickMessage?.GetText();
        
        Assert.That(rightClickMessage, Is.EqualTo("You have done a right click"));
        
    }
    
    [Test, Order(4)]
    [Description("This test checks the click on the button and the message output")]
    public void ClickButton_ReturnsMessage()
    {
        _buttonsPage.ClickMe();
        var clickMessage = _buttonsPage.ClickMeMessage?.GetText();
        
        Assert.That(clickMessage, Is.EqualTo("You have done a dynamic click"));
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _buttonsPage.Close();
    }
}