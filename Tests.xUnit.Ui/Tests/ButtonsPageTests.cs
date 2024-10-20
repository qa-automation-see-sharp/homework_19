using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.xUnit.Ui.Tests;
public class ButtonsPageTests : IDisposable
{
    private ButtonsPage _buttonsPage;

    public ButtonsPageTests()
    {
        _buttonsPage = new ButtonsPage();
        _buttonsPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _buttonsPage.NavigateToPage();
    }

    [Fact]
    public void OpenButtonsPage_TitleIsCorrect()
    {
        var title = _buttonsPage.Title?.GetText();
        Assert.Equal("Buttons", title);
    }

    [Fact]
    public void CheckLabelsAreDisplayed()
    {
        _buttonsPage.DoubleClickButton?.DoubleClick();
        _buttonsPage.RightClickButton?.RightClick();
        _buttonsPage.DynamicClickButton?.Click();

        Assert.True(_buttonsPage.WaitForElementText(_buttonsPage.DoubleClickMessage, "You have done a double click"));
        Assert.True(_buttonsPage.WaitForElementText(_buttonsPage.RightClickMessage, "You have done a right click"));
        Assert.True(_buttonsPage.WaitForElementText(_buttonsPage.DynamicClickMessage, "You have done a dynamic click"));
    }

    public void Dispose()
    {
        _buttonsPage.Close();
    }
}
