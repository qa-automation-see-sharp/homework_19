using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.xUnit.Ui.Tests;

public class TextBoxPageTests : IAsyncLifetime
{
    private readonly TextBoxPage _textBoxPage = new();

    [Fact]
    public void FillOutAndSubmitForm()
    {
        //Arrange            
        var fullName = "Full Name";
        var email = "email@mail.com";
        var currentAddress = "Current Address";
        var permanentAddress = "Permanent Address";

        //Act
        _textBoxPage.EnterFullName(fullName);
        _textBoxPage.EnterEmail(email);
        _textBoxPage.EnterCurrentAddress(currentAddress);
        _textBoxPage.EnterPermanentAddress(permanentAddress);
        _textBoxPage.ScrollDownUsingKeys();
        _textBoxPage.Submit.Click();

        var assertedFullName = _textBoxPage.Output.GetText().Contains(fullName);
        var assertedEmail = _textBoxPage.Output.GetText().Contains(email);
        var assertedCurrentAddress = _textBoxPage.Output.GetText().Contains(currentAddress);
        var assertedPermanentAddress = _textBoxPage.Output.GetText().Contains(permanentAddress);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.True(assertedFullName);
            Assert.True(assertedEmail);
            Assert.True(assertedPermanentAddress);
            Assert.True(assertedCurrentAddress);
        });
    }

    public Task InitializeAsync()
    {
        _textBoxPage.OpenInBrowser(Chrome, "--start-maximized");
        _textBoxPage.NavigateToPage();

        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        _textBoxPage.Close();
        return Task.CompletedTask;
    }
}