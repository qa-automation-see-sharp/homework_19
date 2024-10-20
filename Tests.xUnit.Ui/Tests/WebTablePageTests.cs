using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.xUnit.Ui.Tests;
public class WebTablePageTests : IDisposable
{
    private readonly WebTablePage _webTablePage = new();

    public WebTablePageTests()
    {
        _webTablePage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _webTablePage.NavigateToPage();
    }

    [Fact]
    public void FirstWebTableTest()
    {
        var title = _webTablePage.Title?.GetText();
        var rows = _webTablePage.Table?.FindRows().GetAll();
        var rowCells = rows?[2].FindCells().GetAll();
        var columns = _webTablePage.Table?.FindColumns().GetAll();
        var columnCells = columns?[0].FindCells().GetAll();

        Assert.NotNull(title);
        Assert.Equal("Web Tables", title);
        Assert.NotNull(rows);
        Assert.Equal(3, rows?.Count);
        Assert.Equal("Kierra", rowCells?[0].GetText());
        Assert.NotNull(columns);
        Assert.Equal(7, columns?.Count);
        Assert.Equal("Cierra", columnCells?[0].GetText());
        Assert.Equal("Alden", columnCells?[1].GetText());
        Assert.Equal("Kierra", columnCells?[2].GetText());
    }

    [Fact]
    public void WebTables_SortByAge()
    {
        _webTablePage.SortByAge();
        var columns = _webTablePage.Table?.FindColumns().GetAll();
        var columnCellsName = columns?[0].FindCells().GetAll();
        var columnCellsAge = columns?[2].FindCells().GetAll();

        Assert.NotNull(columnCellsName);
        Assert.NotNull(columnCellsAge);
        Assert.Equal("Kierra", columnCellsName?[0].GetText());
        Assert.Equal("Cierra", columnCellsName?[1].GetText());
        Assert.Equal("Alden", columnCellsName?[2].GetText());
        Assert.Equal("29", columnCellsAge?[0].GetText());
        Assert.Equal("39", columnCellsAge?[1].GetText());
        Assert.Equal("45", columnCellsAge?[2].GetText());
    }

    [Fact]
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
        Assert.Equal(4, rows?.Count);

        var rowCellsAdd = rows?[3].FindCells().GetAll();

        Assert.Multiple(() =>
        {
            Assert.Equal(4, rows?.Count);
            Assert.Equal("Olesia", rowCellsAdd?[0].GetText());
            Assert.Equal("Zaremba", rowCellsAdd?[1].GetText());
            Assert.Equal("25", rowCellsAdd?[2].GetText());
            Assert.Equal("zaremba_olesia@email.com", rowCellsAdd?[3].GetText());
            Assert.Equal("1500000", rowCellsAdd?[4].GetText());
            Assert.Equal("Product Development", rowCellsAdd?[5].GetText());
        });

        _webTablePage.DeleteRow(4);

        rows = _webTablePage.Table?.FindRows().GetAll();

        Assert.Equal(3, rows?.Count);
    }

    public void Dispose()
    {
        _webTablePage.Close();
    }
}
