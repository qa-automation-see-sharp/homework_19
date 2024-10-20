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
        _buttonsPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _buttonsPage.NavigateToPage();
    }

    [Test]
    public void OpenButtonsPage_TitleIsCorrect()
    {
        var title = _buttonsPage.Title?.GetText();

        Assert.That(title, Is.EqualTo("Buttons"));
    }

    [Test]
    public void CheckLabelsAreDisplayed()
    {
        _buttonsPage.DoubleClickButton?.DoubleClick();
        _buttonsPage.RightClickButton?.RightClick();
        _buttonsPage.DynamicClickButton?.Click();

        Assert.Multiple(() =>
        {
            Assert.That(_buttonsPage.WaitForElementText(_buttonsPage.DoubleClickMessage, "You have done a double click"), Is.True);
            Assert.That(_buttonsPage.WaitForElementText(_buttonsPage.RightClickMessage, "You have done a right click"), Is.True);
            Assert.That(_buttonsPage.WaitForElementText(_buttonsPage.DynamicClickMessage, "You have done a dynamic click"), Is.True);
        });
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _buttonsPage.Close();
    }
}