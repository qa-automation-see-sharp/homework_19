using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class RadioButtonPageTests
{
    private readonly RadioButtonPage _radioButtonPage = new();

    [SetUp]
    public void SetUp()
    {
        _radioButtonPage.OpenInBrowser(Chrome, "--start-maximized");
        _radioButtonPage.NavigateToPage();
    }

    [Test]
    public void RadioButtonYes()
    {
        //Arrange - N/A

        //Act        
        _radioButtonPage.RadioButtonYesLabel!.Click();
        var isButtonSelected = _radioButtonPage.RadioButtonYes!.IsSelected();       
        var isButtonEnabled = _radioButtonPage.RadioButtonYes.IsEnabled();
        var isOutputDisplayed = _radioButtonPage.Output!.IsDisplayed();
        var outputContainsYes = _radioButtonPage.OutputTextContainsYes();

        //Assert
         Assert.Multiple(() => 
        {
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(isButtonSelected, Is.True);
            Assert.That(isOutputDisplayed, Is.True);
            Assert.That(outputContainsYes, Is.True);
        });        
    }

    [Test]
    public void RadioButtonImpressive()
    {
        //Arrange - N/A

        //Act
        _radioButtonPage.RadioButtonImpressiveLabel!.Click();
        var isButtonSelected = _radioButtonPage.RadioButtonImpressive!.IsSelected();
        var isButtonEnabled = _radioButtonPage.RadioButtonImpressive.IsEnabled();        
        var isOutputDisplayed = _radioButtonPage.Output!.IsDisplayed();
        var outputContainsImpressive = _radioButtonPage.OutputTextContainsImpressive();

        //Assert
         Assert.Multiple(() => 
        {
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(isButtonSelected, Is.True);
            Assert.That(isOutputDisplayed, Is.True);
            Assert.That(outputContainsImpressive, Is.True);
        });        
    }

    [Test]
    public void RadioButtonNo()
    {
        //Arrange - N/A

        //Act
        var isButtonEnabled = _radioButtonPage.RadioButtonNo!.IsEnabled();   

        //Assert
         Assert.Multiple(() => 
        {
            Assert.That(isButtonEnabled, Is.False);
        });        
    }

    [TearDown]
    public void TearDown()
    {
        _radioButtonPage.Close();
    }
}