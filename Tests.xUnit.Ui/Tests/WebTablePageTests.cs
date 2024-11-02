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
    public void ClickAddButton_ShouldReturnRegistrationForm()
    {
        _webTablePage.ClickAddButton();
        var registrationFormIsDisplayed = _webTablePage.RegistrationForm.IsDisplayed();
        
        Assert.True(registrationFormIsDisplayed);
    }
    
    [Fact]
    public void FillInRegistrationForm_ShouldReturnSavedData()
    {
        _webTablePage.ClickAddButton();
        _webTablePage
            .EnterFistName("Liuda")
            .EnterLastName("Test")
            .EnterEmail("test@test.com")
            .EnterAge("25")
            .EnterSalary("12345")
            .EnterDepartment("QA")
            .ClickSubmitButton();
        
        var rows = _webTablePage.Table?.FindRows().GetAll();
        var newRowCells = rows?[3].FindCells().GetAll();

        Assert.NotNull(rows);
        Assert.NotNull(newRowCells);
        Assert.Equal(4, rows?.Count);
        Assert.Equal("Liuda", newRowCells?[0].GetText());
        Assert.Equal("Test", newRowCells?[1].GetText());
        Assert.Equal("test@test.com", newRowCells?[3].GetText());
        Assert.Equal("25", newRowCells?[2].GetText());
        Assert.Equal("12345", newRowCells?[4].GetText());
        Assert.Equal("QA", newRowCells?[5].GetText());
    }
    
    [Fact]
    public void DeleteElementFromTheTable_ShouldDecreaseRowCount()
    {
        _webTablePage.DeleteFirstRecordButton?.Click();
        
        var rows = _webTablePage.Table?.FindRows().GetAll();
        
        Assert.Equal(2, rows?.Count);
    }

    public Task InitializeAsync()
    {
        _webTablePage.OpenInBrowser(Chrome, "--start-maximized");
        _webTablePage.NavigateToPage();

        return Task.CompletedTask;
    }
    
    [Fact]
    public void SortTableDataByAge()
    {
        _webTablePage.AgeHeader?.Click();
        
        var columns = _webTablePage.Table?.FindColumns().GetAll();
        var firstNameColumnByCell = columns?[0].FindCells().GetAll();
        var ageColumnByCell = columns?[2].FindCells().GetAll();

        Assert.NotNull(firstNameColumnByCell);
        Assert.NotNull(ageColumnByCell);
        Assert.Equal("Alden", firstNameColumnByCell?[0].GetText());
        Assert.Equal("Liuda", firstNameColumnByCell?[2].GetText());
        Assert.Equal("45", ageColumnByCell?[0].GetText());
        Assert.Equal("25", ageColumnByCell?[2].GetText());
    }

    public Task DisposeAsync()
    {
        _webTablePage.Close();
        return Task.CompletedTask;
    }
}