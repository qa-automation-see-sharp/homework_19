using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class ButtonsPageTests
{
    private readonly ButtonPage _buttonPage = new();

    [SetUp]
    public void SetUp()
    {
        _buttonPage.OpenInBrowser(Chrome, "--start-maximized");
        _buttonPage.NavigateToPage();
    }

    [Test]
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
            Assert.That(isButtonDisplayed, Is.True);
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(isMessageDisplayed, Is.True);
            Assert.That(messageContainsText, Is.True);            
        });        
    }

    [Test]
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
            Assert.That(isButtonDisplayed, Is.True);
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(isMessageDisplayed, Is.True);
            Assert.That(messageContainsText, Is.True);            
        });        
    }

    [Test]
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
            Assert.That(isButtonDisplayed, Is.True);
            Assert.That(isButtonEnabled, Is.True);
            Assert.That(isMessageDisplayed, Is.True);
            Assert.That(messageContainsText, Is.True);            
        });        
    }

    [TearDown]
    public void TearDown()
    {
        _buttonPage.Close();
    }
}