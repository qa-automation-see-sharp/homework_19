using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.Tests;

//TODO: Create set of tests for Links page
[TestFixture]
public class LinksPageTests
{
    private LinksPage _linksPage;
    
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _linksPage = new LinksPage();
        _linksPage.OpenInBrowser(BrowserNames.Chrome);
        _linksPage.NavigateToPage();
    }
    
    [Test]
    public void ClickOnLinkThatOpensNewWindow()
    {
        _linksPage.ClickOnLinkThatOpensNewWindow();
    }
}