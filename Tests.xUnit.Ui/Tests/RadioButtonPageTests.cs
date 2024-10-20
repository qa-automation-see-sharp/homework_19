using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.xUnit.Ui.Tests;
public class RadioButtonPageTests : IDisposable
{
    private RadioButtonPage _radioButtonPage;

    public RadioButtonPageTests()
    {
        _radioButtonPage = new RadioButtonPage();
        _radioButtonPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _radioButtonPage.NavigateToPage();
    }

    [Fact]
    public void OpenRadioBoxPage_TitleIsCorrect()
    {
        var title = _radioButtonPage.Title?.GetText();
        Assert.Equal("Radio Button", title);
    }

    [Fact]
    public void CheckYesRadioOutput()
    {
        _radioButtonPage.YesRadio?.Click();
        var output = _radioButtonPage.Output?.GetText();

        Assert.Equal("You have selected Yes", output);
    }

    public void Dispose()
    {
        _radioButtonPage.Close();
    }
}
