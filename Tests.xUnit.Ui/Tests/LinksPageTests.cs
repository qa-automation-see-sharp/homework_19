using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.xUnit.Ui.Tests;

//TODO: Create set of tests for Links page
public class LinksPageTests : IAsyncLifetime
{
    private LinksPage _linksPage;

    public Task InitializeAsync()
    {
        _linksPage = new LinksPage();
        _linksPage.OpenInBrowser(BrowserNames.Chrome);
        _linksPage.NavigateToPage();

        return Task.CompletedTask;
    }

    [Fact]
    public void OneTimeSetUp()
    {
        _linksPage = new LinksPage();
        _linksPage.OpenInBrowser(BrowserNames.Chrome);
        _linksPage.NavigateToPage();
    }

    [Fact]
    public void ClickOnLinkThatOpensNewWindow()
    {
        _linksPage.ClickOnLinkThatOpensNewWindow();
    }


    public Task DisposeAsync()
    {
        _linksPage.Close();

        return Task.CompletedTask;
    }
}