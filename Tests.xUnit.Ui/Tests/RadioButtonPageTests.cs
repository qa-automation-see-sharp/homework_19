using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.xUnit.Ui.Tests;

public class RadioButtonPageTests : IAsyncLifetime
{
    private readonly RadioButtonPage _radioButtonPage = new();

    [Fact]
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
            Assert.True(isButtonEnabled);
            Assert.True(isButtonSelected);
            Assert.True(isOutputDisplayed);
            Assert.True(outputContainsYes);
        });        
    }

    [Fact]
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
            Assert.True(isButtonEnabled);
            Assert.True(isButtonSelected);
            Assert.True(isOutputDisplayed);
            Assert.True(outputContainsImpressive);
        });        
    }

    [Fact]
    public void RadioButtonNo()
    {
        //Arrange - N/A

        //Act
        var isButtonEnabled = _radioButtonPage.RadioButtonNo!.IsEnabled();   

        //Assert
         Assert.Multiple(() => 
        {
            Assert.False(isButtonEnabled);
        });        
    }

    public Task InitializeAsync()
    {
        _radioButtonPage.OpenInBrowser(Chrome, "--start-maximized");
        _radioButtonPage.NavigateToPage();

        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        _radioButtonPage.Close();
        return Task.CompletedTask;
    }
}