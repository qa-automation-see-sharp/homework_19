using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.xUnit.Ui.Tests;

//TODO: finish the test as described in homework   
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