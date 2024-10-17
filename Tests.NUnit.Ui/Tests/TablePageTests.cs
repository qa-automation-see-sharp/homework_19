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
        var rows = _tablePage.Table?.FindRows().GetAll();
        var rowCells = rows?[2].FindCells().GetAll();
        var columns = _tablePage.Table?.FindColumns().GetAll();
        var columnCells = columns?[0].FindCells().GetAll();

        Assert.Multiple(() =>
        {
            Assert.That(title, Is.EqualTo("Web Tables"));
            Assert.That(rows?.Count, Is.EqualTo(3));
            Assert.That(rowCells?[0].GetText(), Is.EqualTo("Kierra"));
            Assert.That(columns?.Count, Is.EqualTo(7));
            Assert.That(columnCells?[0].GetText(), Is.EqualTo("Cierra"));
            Assert.That(columnCells?[1].GetText(), Is.EqualTo("Alden"));
            Assert.That(columnCells?[2].GetText(), Is.EqualTo("Kierra"));
        });
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _tablePage.Close();
    }
}