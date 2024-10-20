using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class CheckBoxTests
{
    protected CheckBoxPage _checkBoxPage;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _checkBoxPage = new CheckBoxPage();
        _checkBoxPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized", "--headless");
        _checkBoxPage.NavigateToPage();
    }

    [Test]
    public void NavigateToCheckBox_CheckThePageIsCorrect()
    {
        var pageTitle = _checkBoxPage.VerifyCheckBoxTitle();
        var homeBox = _checkBoxPage.CheckHomeBoxTitle();

        Assert.Multiple(() =>
        {
            Assert.That(pageTitle, Is.True);
            Assert.That(homeBox, Is.True);
        });
    }

    [Test]
    public void NavigateToCheckBox_WhenIUnrollHome_ElementShouldBeDisplayed()
    {
        _checkBoxPage.ExpandAllButton?.Click();
        var unrolledFolders = _checkBoxPage.CheckUnrolledFolders();

        _checkBoxPage.CollapseAllButton?.Click();
        var foldersCollapsed = !_checkBoxPage.CheckUnrolledFolders();

        Assert.Multiple(() =>
        {
            Assert.That(unrolledFolders, Is.True);
            Assert.That(foldersCollapsed, Is.True);
        });
    }

    [Test]
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

        Assert.Multiple(() =>
        {
            Assert.That(areAllChecked, Is.True);
            Assert.That(resultText, Does.Contain("You have selected :"), "The result text does not start with the expected prefix.");

            foreach (var selection in expectedSelections)
            {
                Assert.That(resultText, Does.Contain(selection), $"The result text does not contain '{selection}'.");
            }
        });
    }

    [Test]
    public void CheckBox_WhenChecked_ShowsSelectedObjectLabel()
    {
        _checkBoxPage.RefreshPage();

        _checkBoxPage.ExpandAllButton?.Click();
        _checkBoxPage.CheckNotesBox();

        var resultText = _checkBoxPage.ResultText();

        Assert.That(resultText, Does.Contain("notes"));
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _checkBoxPage.Close();
    }
}