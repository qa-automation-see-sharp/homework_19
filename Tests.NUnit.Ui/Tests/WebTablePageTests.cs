using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class WebTablePageTests
{
    private readonly WebTablePage _webTablePage = new();

    [SetUp]
    public void SetUp()
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
    public void AddElementToTable()
    {
        //Arrange
        var initialRows = _webTablePage.Table?.FindRows().GetAll();
        var addDisplayed = _webTablePage.Add!.IsDisplayed();
        var addEnabled = _webTablePage.Add.IsEnabled();

        //Act
        _webTablePage.Add.Click();
        _webTablePage.FillOutRegistrationForm();
        var submitDisplayed = _webTablePage.Submit!.IsDisplayed();
        var submitEnabled = _webTablePage.Submit.IsEnabled();
        _webTablePage.Submit.Click();
        var rows = _webTablePage.Table?.FindRows().GetAll();
        var rowCells = rows?[3].FindCells().GetAll();
        var isNewRowAdded = rows!.Count - initialRows!.Count == 1;

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(addDisplayed, Is.True);
            Assert.That(addEnabled, Is.True);
            Assert.That(submitDisplayed, Is.True);
            Assert.That(submitEnabled, Is.True);
            Assert.That(isNewRowAdded, Is.True);
            Assert.That(rowCells?[0].GetText(), Is.EqualTo(_webTablePage.firstName));
            Assert.That(rowCells?[1].GetText(), Is.EqualTo(_webTablePage.lastName));
            Assert.That(rowCells?[2].GetText(), Is.EqualTo(_webTablePage.age));
            Assert.That(rowCells?[3].GetText(), Is.EqualTo(_webTablePage.email));
            Assert.That(rowCells?[4].GetText(), Is.EqualTo(_webTablePage.salary));
            Assert.That(rowCells?[5].GetText(), Is.EqualTo(_webTablePage.department));            
        });
    }

    [Test]
    public void DeleteElementFromTable()
    {
        //Arrange
        var initialRows = _webTablePage.Table?.FindRows().GetAll();
        var deleteDisplayed = _webTablePage.Delete.IsDisplayed();
        var deleteEnabled = _webTablePage.Delete.IsEnabled();

        //Act
        _webTablePage.Delete.Click();
        var rows = _webTablePage.Table?.FindRows().GetAll();
        var isNewRowDeleted = initialRows!.Count - rows!.Count == 1;

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(deleteDisplayed, Is.True);
            Assert.That(deleteEnabled, Is.True);            
            Assert.That(isNewRowDeleted, Is.True);                        
        });
    }

    [Test]
    public void SortingTableByAge()
    {
        //Arrange
        _webTablePage.AgeColumnHeader.Click();
        var columnsAscending = _webTablePage.Table?.FindColumns().GetAll();
        var columnCellsAscending = columnsAscending?[2].FindCells().GetAll();

        //Act
        var intListAscending = WebTablePage.ConvertToIntegerList(columnCellsAscending!);
        var isAscending = _webTablePage.IsSortedAscending(intListAscending);

        _webTablePage.AgeColumnHeader.Click();
        var columnsDescending = _webTablePage.Table?.FindColumns().GetAll();
        var columnCellsDescending = columnsDescending?[2].FindCells().GetAll();
        var intListDescending = WebTablePage.ConvertToIntegerList(columnCellsDescending!);
        var isDescending = _webTablePage.IsSortedDescending(intListDescending);

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(isAscending, Is.True);
            Assert.That(isDescending, Is.True);                                   
        });
    }

    [TearDown]
    public void TearDown()
    {
        _webTablePage.Close();
    }
}