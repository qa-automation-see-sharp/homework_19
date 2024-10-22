using Tests.Utils.Swd.PageObjects;
using static Tests.Utils.Swd.BaseWebElements.Browser.BrowserNames;

namespace Tests.xUnit.Ui.Tests;

public class CheckBoxPageTests : IAsyncLifetime
{
    private readonly CheckBoxPage _checkBoxPage = new();

    [Fact]
    public void GetPageUrl_ShouldReturnCheckBoxUrl()
    {
        //Arrange
        var expectedUrl = _checkBoxPage.Url;

        //Act
        var url = _checkBoxPage.GetPageUrl();  

        //Assert
        Assert.Equivalent(url, expectedUrl);        
    }

    [Fact]
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
            Assert.True(foldersExpanded);
            Assert.False(foldersCollapsed);
        });        
    }

    [Fact]
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
            Assert.True(isCheckedHome);
            Assert.True(isCheckedDesktop);
            Assert.True(isCheckedDocuments);
            Assert.True(isCheckedDownloads);
            Assert.True(outputContainsText);
        });        
    }
    
    public Task InitializeAsync()
    {
        _checkBoxPage.OpenInBrowser(Chrome, "--start-maximized");
        _checkBoxPage.NavigateToPage();

        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        _checkBoxPage.Close();
        return Task.CompletedTask;
    }
}