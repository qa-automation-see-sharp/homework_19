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
        _radioButtonPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _radioButtonPage.NavigateToPage();
    }

    [Test]
    public void OpenRadioBoxPage_TitleIsCorrect()
    {
        var title = _radioButtonPage.Title?.GetText();

        Assert.That(title, Is.EqualTo("Radio Button"));
    }

    [Test]
    public void CheckYesRadioOutput()
    {
        _radioButtonPage.YesRadio?.Click();

        var output = _radioButtonPage.Output?.GetText();

        Assert.Multiple(() =>
        {
            Assert.That(output, Is.EqualTo("You have selected Yes"));
        });
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _radioButtonPage.Close();
    }
}