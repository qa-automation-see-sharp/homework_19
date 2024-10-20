using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class WebTablePageTests
{
    private readonly WebTablePage _webTablePage = new();

    [SetUp]
    public void SetUp()
    {
        _webTablePage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _webTablePage.NavigateToPage();
    }

    [Test]
    public void FirstWebTableTest()
    {
        var title = _webTablePage.Title?.GetText();
        var rows = _webTablePage.Table?.FindRows().GetAll();
        var rowCells = rows?[2].FindCells().GetAll();
        var columns = _webTablePage.Table?.FindColumns().GetAll();
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
    [Test]
    public void WebTables_SortByAge()
    {
        _webTablePage.SortByAge();
        var columns = _webTablePage.Table?.FindColumns().GetAll();
        var columnCellsName = columns?[0].FindCells().GetAll();
        var columnCellsAge = columns?[2].FindCells().GetAll();

        Assert.Multiple(() =>
        {
            Assert.That(columnCellsName?[0].GetText(), Is.EqualTo("Kierra"));
            Assert.That(columnCellsName?[1].GetText(), Is.EqualTo("Cierra"));
            Assert.That(columnCellsName?[2].GetText(), Is.EqualTo("Alden"));
            Assert.That(columnCellsAge?[0].GetText(), Is.EqualTo("29"));
            Assert.That(columnCellsAge?[1].GetText(), Is.EqualTo("39"));
            Assert.That(columnCellsAge?[2].GetText(), Is.EqualTo("45"));
        });
    }

    [Test]
    public void WebTables_AddAndDeleteRecord()
    {
        _webTablePage.Add();

        _webTablePage.AddFirstName("Olesia");
        _webTablePage.AddLastName("Zaremba");
        _webTablePage.AddEmail("zaremba_olesia@email.com");
        _webTablePage.InputAge(25);
        _webTablePage.AddSalary(1500000);
        _webTablePage.AddDepartment("Product Development");

        _webTablePage.Submit();

        var rows = _webTablePage.Table?.FindRows().GetAll();
        Assert.That(rows?.Count, Is.EqualTo(4));

        var rowCellsAdd = rows?[3].FindCells().GetAll();

        Assert.Multiple(() =>
        {
            Assert.That(rows?.Count, Is.EqualTo(4));
            Assert.That(rowCellsAdd?[0].GetText(), Is.EqualTo("Olesia"));
            Assert.That(rowCellsAdd?[1].GetText(), Is.EqualTo("Zaremba"));
            Assert.That(rowCellsAdd?[2].GetText(), Is.EqualTo("25"));
            Assert.That(rowCellsAdd?[3].GetText(), Is.EqualTo("zaremba_olesia@email.com"));
            Assert.That(rowCellsAdd?[4].GetText(), Is.EqualTo("1500000"));
            Assert.That(rowCellsAdd?[5].GetText(), Is.EqualTo("Product Development"));
        });

        _webTablePage.DeleteRow(4);

        rows = _webTablePage.Table?.FindRows().GetAll();

        Assert.That(rows?.Count, Is.EqualTo(3));
    }

    [TearDown]
    public void TearDown()
    {
        _webTablePage.Close();
    }
}