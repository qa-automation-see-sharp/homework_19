using Tests.Utils.Swd.Helpers;
using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class TablePageTests
{
    private readonly TablePage _tablePage = new();

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _tablePage.OpenInBrowser(Chrome, "--start-maximized");
        _tablePage.NavigateToPage();
    }

    [Test]
    public void OpenWebTablePage_TitleIsCorrect()
    {
        var title = _tablePage.Title?.GetText();

        // Assert.Multiple(() =>
        // {
        //     Assert.That(title, Is.EqualTo("Web Tables"));
        //     Assert.That(row, Is.Not.Null);
        //     Assert.That(cell, Is.Not.Null);
        //     Assert.That(cellKierraText, Is.EqualTo("Kierra"));
        // });
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _tablePage.Close();
    }
}