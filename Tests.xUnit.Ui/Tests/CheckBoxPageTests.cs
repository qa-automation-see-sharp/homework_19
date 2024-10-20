using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.xUnit.Ui.Tests;
public class CheckBoxTests : IDisposable
{
    protected CheckBoxPage _checkBoxPage;

    public CheckBoxTests()
    {
        _checkBoxPage = new CheckBoxPage();
        _checkBoxPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _checkBoxPage.NavigateToPage();
    }

    [Fact]
    public void NavigateToCheckBox_CheckThePageIsCorrect()
    {
        var pageTitle = _checkBoxPage.VerifyCheckBoxTitle();
        var homeBox = _checkBoxPage.CheckHomeBoxTitle();

        Assert.True(pageTitle);
        Assert.True(homeBox);
    }

    [Fact]
    public void NavigateToCheckBox_WhenIUnrollHome_ElementShouldBeDisplayed()
    {
        _checkBoxPage.ExpandAllButton?.Click();
        var unrolledFolders = _checkBoxPage.CheckUnrolledFolders();

        _checkBoxPage.CollapseAllButton?.Click();
        var foldersCollapsed = !_checkBoxPage.CheckUnrolledFolders();

        Assert.True(unrolledFolders);
        Assert.True(foldersCollapsed);
    }

    [Fact]
    public void CheckBox_WhenChecked_ShouldDisplayCheckedIcon()
    {
        _checkBoxPage.ExpandAllButton?.Click();

        _checkBoxPage.CheckHomeBox();
        var resultText = _checkBoxPage.ResultText();
        bool areAllChecked = _checkBoxPage.CheckAllBoxesAreChecked();

        var expectedSelections = new[]
        {
            "home", "desktop", "notes", "commands", "documents", "workspace",
            "react", "angular", "veu", "office", "public", "private",
            "classified", "general", "downloads", "wordFile", "excelFile"
        };

        var normalizedResultText = resultText.Replace("\n", " ").Trim();

        Assert.True(areAllChecked);
        Assert.Contains("You have selected :", resultText);

        foreach (var selection in expectedSelections)
        {
            Assert.Contains(selection, resultText);
        }
    }

    [Fact]
    public void CheckBox_WhenChecked_ShowsSelectedObjectLabel()
    {
        _checkBoxPage.RefreshPage();

        _checkBoxPage.ExpandAllButton?.Click();
        _checkBoxPage.CheckNotesBox();

        var resultText = _checkBoxPage.ResultText();

        Assert.Contains("notes", resultText);
    }

    public void Dispose()
    {
        _checkBoxPage.Close();
    }
}
