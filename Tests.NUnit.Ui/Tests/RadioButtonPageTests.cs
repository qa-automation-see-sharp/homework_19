using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class RadioButtonPageTests
{
    private RadioButtonPage _radioButtonPage;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _radioButtonPage = new RadioButtonPage();
        _radioButtonPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized");
        _radioButtonPage.NavigateToPage();
    }
    
    [Test, Order(1)]
    [Description("This test checks if the user has landed to the page with the correct title")]
    public void OpenRadioButtonPage_TitleIsCorrect()
    {
        var title = _radioButtonPage.Title?.GetText();

        Assert.That(title, Is.EqualTo("Radio Button"));
    }

    [Test, Order(2)]
    [Description("This test checks if the Yes Radio button is clicked and the correct message is displayed")]
    public void ClickYesRadioButton_DisplayMessage()
    {
        _radioButtonPage.ClickYesRadioButton();
        var displayedMessage = _radioButtonPage.YouHaveSelectedYesMessage();
        
        Assert.That(displayedMessage, Is.True);
    }

    [Test, Order(3)]
    [Description("This test checks if the Impressive Radio button is clicked and the correct message is displayed")]
    public void ClickImpressedRadioButton_DisplayMessage()
    {
        _radioButtonPage.ClickImpressiveRadioButton();
        var displayedMessage = _radioButtonPage.YouHaveSelectedImpressiveMessage();
        
        Assert.That(displayedMessage, Is.True);
    }

    [Test, Order(4)]
    [Description("This test checks that the No Radio button is disabled")]
    public void CheckNoRadioButtonIsDisabled_ReturnTrue()
    {
        var isDisabledButton = _radioButtonPage.CheckNoRadioButton();
        
        Assert.That(isDisabledButton, Is.True);
    }
    
    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _radioButtonPage.Close();
    }
}