using Tests.Utils.Swd.Helpers;
using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

//TODO: finish the test as described in homework   
[TestFixture]
public class WebTablePageTests
{
    private readonly WebTablePage _webTablePage = new();
    private readonly RegistrationFormsWindow _registrationFormsWindow = new();

    [SetUp]
    public void OneTimeSetUp()
    {
        _webTablePage.OpenInBrowser(Chrome, "--start-maximized");
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
    public void AddUserToTable()
    {
        var initialRows = _webTablePage.Table?.FindRows().GetAll();

        _webTablePage.ClickAddButton().AddUser("Natali", "Black", "natali.black@gmail.com", 18, 2000, "Telecom");
        var rows = _webTablePage.Table?.FindRows().GetAll();
        var rowCells = rows?[rows.Count-1].FindCells().GetAll();
        var isNewRowAdded = rows!.Count - initialRows!.Count == 1;

        Assert.Multiple(() =>
        {
            Assert.That(isNewRowAdded, Is.True);
            Assert.That(rowCells?[0].GetText(), Is.EqualTo("Natali"));
            Assert.That(rowCells?[1].GetText(), Is.EqualTo("Black"));
            Assert.That(rowCells?[2].GetText(), Is.EqualTo("18"));
            Assert.That(rowCells?[3].GetText(), Is.EqualTo("natali.black@gmail.com"));
            Assert.That(rowCells?[4].GetText(), Is.EqualTo("2000"));
            Assert.That(rowCells?[5].GetText(), Is.EqualTo("Telecom"));            
        });
    }

    [Test]
    public void DeleteUserFromTable()
    {
        var initialRows = _webTablePage.Table?.FindRows().GetAll();

        _webTablePage.Delete.Click();
        var rows = _webTablePage.Table?.FindRows().GetAll();
        var isNewRowDeleted = initialRows!.Count - rows!.Count == 1;

        Assert.Multiple(() =>
        {           
            Assert.That(isNewRowDeleted, Is.True);                        
        });
    }

    [Test]
    public void SortingTableByAge()
    {
        var columnsAscending = _webTablePage.Table?.FindColumns().GetAll();

        var orderedList = columnsAscending?[2].FindCells().GetAll();
        List<string> expectedData = WebTablePage.DataSorting(orderedList).OrderBy(x => x).ToList();
        _webTablePage.AgeColumnHeader.Click();
        var columnCellsAscending = columnsAscending?[2].FindCells().GetAll();
        List<string> dataAfterSorting = WebTablePage.DataSorting(columnCellsAscending);

        Assert.Multiple(() =>
        {
            Assert.That(expectedData[0].Equals(dataAfterSorting[0]));
            Assert.That(expectedData[1].Equals(dataAfterSorting[1]));                               
        });
    }

    [TearDown]
    public void TearDown()
    {
        _webTablePage.Close();
    }
}