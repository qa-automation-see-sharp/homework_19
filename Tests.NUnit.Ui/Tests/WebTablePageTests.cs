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
        _webTablePage
            .EnterFistName("Liuda")
            .EnterLastName("Test")
            .EnterEmail("test@test.com")
            .EnterAge("25")
            .EnterSalary("$12345")
            .EnterDepartment("QA")
            .ClickSubmitButton();
        
        Assert.Multiple(() =>
        {
        });
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _webTablePage.Close();
    }
}