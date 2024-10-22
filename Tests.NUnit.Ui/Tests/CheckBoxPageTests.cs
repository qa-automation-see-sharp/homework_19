using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class CheckBoxPageTests
{
    private readonly CheckBoxPage _checkBoxPage = new();

    [SetUp]
    public void SetUp()
    {
        _checkBoxPage.OpenInBrowser(Chrome, "--start-maximized");
        _checkBoxPage.NavigateToPage();
    }

    [Test]
    public void GetPageUrl_ShouldReturnCheckBoxUrl()
    {
        //Arrange
        var expectedUrl = _checkBoxPage.Url;

        //Act
        var url = _checkBoxPage.GetPageUrl();  

        //Assert
        Assert.That(url, Is.EqualTo(expectedUrl));        
    }

    [Test]
    public void ExpandCheckBoxList_ShouldDisplayFolders()
    {
        //Arrange - N/A
        
        //Act
        _checkBoxPage.ToggleHome!.Click();
        var foldersExpanded = _checkBoxPage.IsDisplayedFolderList();
        _checkBoxPage.ToggleHome.Click();
        var foldersCollapsed = _checkBoxPage.IsDisplayedFolderList();

        //Assert
        Assert.Multiple(() => 
        {
            Assert.That(foldersExpanded, Is.True);
            Assert.That(foldersCollapsed, Is.False);
        });        
    }

    [Test]
    public void CheckBoxesAndOutputText()
    {
        //Arrange - N/A
        _checkBoxPage.ToggleHome!.Click();
        
        //Act        
        _checkBoxPage.UncheckedHome!.Click();
        var isCheckedHome = _checkBoxPage.CheckedHome!.IsDisplayed();
        var isCheckedDesktop = _checkBoxPage.CheckedDesktop!.IsDisplayed();
        var isCheckedDocuments = _checkBoxPage.CheckedDocuments!.IsDisplayed();
        var isCheckedDownloads = _checkBoxPage.CheckedDownloads!.IsDisplayed();
        var outputContainsText = _checkBoxPage.OutputContainsCheckedElements();

        //Assert
        Assert.Multiple(() => 
        {
            Assert.That(isCheckedHome, Is.True);
            Assert.That(isCheckedDesktop, Is.True);
            Assert.That(isCheckedDocuments, Is.True);
            Assert.That(isCheckedDownloads, Is.True);
            Assert.That(outputContainsText, Is.True);
        });        
    }

    [TearDown]
    public void TearDown()
    {
        _checkBoxPage.Close();
    }
}