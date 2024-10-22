using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.xUnit.Ui.Tests;

public class ButtonsPageTests : IAsyncLifetime
{
    private readonly ButtonPage _buttonPage = new();

    [Fact]
    public void DoubleClickButtonTest()
    {
        //Arrange - N/A

        //Act
        var isButtonDisplayed = _buttonPage.DoubleClickButton!.IsDisplayed();
        var isButtonEnabled = _buttonPage.DoubleClickButton.IsEnabled();
        _buttonPage.DoubleClickButton.DoubleClick();
        var isMessageDisplayed = _buttonPage.DoubleClickMessage!.IsDisplayed();
        var messageContainsText = _buttonPage.DoubleClickMessage.GetText().Contains(_buttonPage.outputDoubleClick);

        //Assert
         Assert.Multiple(() => 
        {
            Assert.True(isButtonDisplayed);
            Assert.True(isButtonEnabled);
            Assert.True(isMessageDisplayed);
            Assert.True(messageContainsText);            
        });        
    }

    [Fact]
    public void RightClickButtonTest()
    {
        //Arrange - N/A

        //Act
        var isButtonDisplayed = _buttonPage.RightClickButton!.IsDisplayed();
        var isButtonEnabled = _buttonPage.RightClickButton.IsEnabled();
        _buttonPage.RightClickButton.RightClick();
        var isMessageDisplayed = _buttonPage.RightClickMessage!.IsDisplayed();
        var messageContainsText = _buttonPage.RightClickMessage.GetText().Contains(_buttonPage.outputRightClick);

        //Assert
         Assert.Multiple(() => 
        {
            Assert.True(isButtonDisplayed);
            Assert.True(isButtonEnabled);
            Assert.True(isMessageDisplayed);
            Assert.True(messageContainsText);            
        });        
    }

    [Fact]
    public void LeftClickButtonTest()
    {
        //Arrange - N/A

        //Act
        var isButtonDisplayed = _buttonPage.LeftClickButton!.IsDisplayed();
        var isButtonEnabled = _buttonPage.LeftClickButton.IsEnabled();
        _buttonPage.LeftClickButton.Click();
        var isMessageDisplayed = _buttonPage.LeftClickMessage!.IsDisplayed();
        var messageContainsText = _buttonPage.LeftClickMessage.GetText().Contains(_buttonPage.outputLeftClick);

        //Assert
         Assert.Multiple(() => 
        {
            Assert.True(isButtonDisplayed);
            Assert.True(isButtonEnabled);
            Assert.True(isMessageDisplayed);
            Assert.True(messageContainsText);            
        });        
    }

    public Task InitializeAsync()
    {
        _buttonPage.OpenInBrowser(Chrome, "--start-maximized");
        _buttonPage.NavigateToPage();

        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        _buttonPage.Close();
        return Task.CompletedTask;
    }
}