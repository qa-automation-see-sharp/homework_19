using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.xUnit.Ui.Tests;

public class WebTablePageTests : IAsyncLifetime
{
    private readonly WebTablePage _webTablePage = new();

    [Fact]
    public void FirstWebTableTest()
    {
        var title = _webTablePage.Title?.GetText();
        var rows = _webTablePage.Table?.FindRows().GetAll();
        var rowCells = rows?[2].FindCells().GetAll();
        var columns = _webTablePage.Table?.FindColumns().GetAll();
        var columnCells = columns?[0].FindCells().GetAll();

        Assert.Multiple(() =>
        {
            Assert.Equivalent(title, "Web Tables");
            Assert.Equivalent(rows?.Count, 3);
            Assert.Equivalent(rowCells?[0].GetText(), "Kierra");
            Assert.Equivalent(columns?.Count,7);
            Assert.Equivalent(columnCells?[0].GetText(),"Cierra");
            Assert.Equivalent(columnCells?[1].GetText(), "Alden");
            Assert.Equivalent(columnCells?[2].GetText(), "Kierra");
        });
    }

    [Fact]
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
            Assert.True(addDisplayed);
            Assert.True(addEnabled);
            Assert.True(submitDisplayed);
            Assert.True(submitEnabled);
            Assert.True(isNewRowAdded);
            Assert.Equivalent(rowCells?[0].GetText(), _webTablePage.firstName);
            Assert.Equivalent(rowCells?[1].GetText(), _webTablePage.lastName);
            Assert.Equivalent(rowCells?[2].GetText(), _webTablePage.age);
            Assert.Equivalent(rowCells?[3].GetText(), _webTablePage.email);
            Assert.Equivalent(rowCells?[4].GetText(), _webTablePage.salary);
            Assert.Equivalent(rowCells?[5].GetText(), _webTablePage.department);            
        });
    }

    [Fact]
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
            Assert.True(deleteDisplayed);
            Assert.True(deleteEnabled);            
            Assert.True(isNewRowDeleted);                        
        });
    }

    [Fact]
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
            Assert.True(isAscending);
            Assert.True(isDescending);                                   
        });
    }

    public Task InitializeAsync()
    {
        _webTablePage.OpenInBrowser(Chrome, "--start-maximized");
        _webTablePage.NavigateToPage();

        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        _webTablePage.Close();
        return Task.CompletedTask;
    }
}