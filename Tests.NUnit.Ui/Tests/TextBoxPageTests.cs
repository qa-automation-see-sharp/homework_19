using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class TextBoxPageTests
{
    private readonly TextBoxPage _textBoxPage = new();

    [SetUp]
    public void SetUp()
    {
        _textBoxPage.OpenInBrowser(Chrome, "--start-maximized");
        _textBoxPage.NavigateToPage();
    }

    [Test]
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
            Assert.That(assertedFullName, Is.True);
            Assert.That(assertedEmail, Is.True);
            Assert.That(assertedPermanentAddress, Is.True);
            Assert.That(assertedCurrentAddress, Is.True);
        });
    }

    [TearDown]
    public void TearDown()
    {
        _textBoxPage.Close();
    }
}