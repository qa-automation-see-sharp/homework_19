using OpenQA.Selenium.Support.UI;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.Helpers;
using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

//TODO: finish the test as described in homework   
[TestFixture]
public class WebTablePageTests
{
    private readonly WebTablePage _webTablePage = new();

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _webTablePage.OpenInBrowser(Chrome, "--start-maximized");
        _webTablePage.NavigateToPage();
    }

    [Test, Order(1)]
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

    [Test, Order(2)]
    public void ClickAddButton_ReturnRegistrationForm()
    {
        _webTablePage.ClickAddButton();
        var registrationFormIsDisplayed = _webTablePage.RegistrationForm.IsDisplayed();
        
        Assert.That(registrationFormIsDisplayed, Is.True);
    }

    [Test, Order(3)]
    public void FillInRegistrationForm_ReturnSavedData()
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

        Assert.Multiple(() =>
        {
            Assert.That(rows?.Count, Is.EqualTo(4));
            Assert.That(newRowCells?[0].GetText(), Is.EqualTo("Liuda"));
            Assert.That(newRowCells?[1].GetText(), Is.EqualTo("Test"));
            Assert.That(newRowCells?[3].GetText(), Is.EqualTo("test@test.com"));
            Assert.That(newRowCells?[2].GetText(), Is.EqualTo("25"));
            Assert.That(newRowCells?[4].GetText(), Is.EqualTo("12345"));
            Assert.That(newRowCells?[5].GetText(), Is.EqualTo("QA"));
        });
    }
    
    [Test, Order(4)]
    public void DeleteElementFromTheTable_ShouldDecreaseRowCount()
    {
        _webTablePage.DeleteFirstRecordButton?.Click();
        
        var rows = _webTablePage.Table?.FindRows().GetAll();
        
        Assert.That(rows?.Count, Is.EqualTo(3));
    }
    
    [Test, Order(5)]
    public void SortTableDataByAge()
    {
        var columns = _webTablePage.Table?.FindColumns().GetAll();
        var cellsBeforeSorting = columns?[2].FindCells().GetAll();
        
        List<string> dataBeforeSorting = WebTablePage.DataBeforeSorting(cellsBeforeSorting);
        
        _webTablePage.AgeHeader?.Click();
        Thread.Sleep(2000);

        var columns2 = _webTablePage.Table?.FindColumns().GetAll();
        var cellsAfterSorting = columns2?[2].FindCells().GetAll();
        
        List<string> dataAfterSorting = WebTablePage.DataAfterSorting(cellsAfterSorting);
        
        List<string> expectedData = WebTablePage.DataBeforeSorting(cellsBeforeSorting).OrderBy(x => x).ToList();

        var isSortedAscending = _webTablePage.IsSorted(expectedData);
        
        Assert.That(isSortedAscending, Is.True);
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _webTablePage.Close();
    }
}