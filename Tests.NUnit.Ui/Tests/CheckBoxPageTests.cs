using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.PageObjects;

namespace Tests.NUnit.Ui.Tests;

[TestFixture]
public class CheckBoxPageTests
{
     [OneTimeSetUp]
    public void SetUp()
    {
        _checkBoxPage = new CheckBoxPage();
        _checkBoxPage.OpenInBrowser(BrowserNames.Chrome, "--start-maximized");
        _checkBoxPage.NavigateToPage();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        _checkBoxPage.Close();
    }

    private CheckBoxPage _checkBoxPage;
    

    [Test, Order(1)]
    [Description("This test checks if the user has landed to the page with the correct title")]
    public void GetCheckBoxPageTitleTest_TitleIsCorrect()
    {
        var title = _checkBoxPage.CheckBoxPageTitle.GetText();
        
        Assert.That(title, Is.EqualTo("Check Box"));
    }

    [Test, Order(2)]
    [Description("This test checks if the expand menu can be opened")]
    public void ExpandMenuTest()
    {
        var isExpandButtonEnabled = _checkBoxPage.CheckExpandButton();
        _checkBoxPage.ExpandMenu();
        var isExpandedMenuDisplayed = _checkBoxPage.CheckExpandedMenuByCommandsCheckBox();
        
        Assert.Multiple(() =>
        {
            Assert.That(isExpandButtonEnabled, Is.True);
            Assert.That(isExpandedMenuDisplayed, Is.True);
        });
    }

    [Test, Order(3)]
    [Description("This test checks if the home checkbox is marked after clicking it")]
    public void MarkHomeCheckBoxTest()
    {
        _checkBoxPage.MarkHomeCheckbox();
        var isHomeCheckBoxMarked = _checkBoxPage.VerifyTheHomeCheckBoxIsMarked();
        
        Assert.That(isHomeCheckBoxMarked, Is.True);
    }

    [Test, Order(4)]
    [Description("This test checks if the other checkboxes are marked and the description is present")]

    public void CheckMarkedElementsAndDescriptionTest()
    {
        var isDocumentsCheckBoxMarked = _checkBoxPage.VerifyTheDocumentsCheckBoxIsMarked();
        var isTheDescriptionOfSelectedItemsIsPresent = _checkBoxPage.CheckTheDescriptionOfSelectedItems();
        var isTheTextOfTheDescriptionDisplayed = _checkBoxPage.CheckTheTextOfTheDescription();
        
        Assert.Multiple(() =>
        {
            Assert.That(isDocumentsCheckBoxMarked, Is.True);
            Assert.That(isTheDescriptionOfSelectedItemsIsPresent, Is.True);
            Assert.That(isTheTextOfTheDescriptionDisplayed, Is.True);
            
        });
    }
    
    [Test, Order(5)]
    [Description("This test checks if the checkboxes are unmarked and the menu is collapsed")]
    public void UnmarkCheckboxAndCloseTheMenuTest()
    {
        _checkBoxPage.UnMarkHomeCheckbox();
        
        var isCollapseButtonEnabled = _checkBoxPage.CheckCollapseButton();
        _checkBoxPage.CollapseMenu();
        var isCollapsedMenuDisplayed = _checkBoxPage.CheckCollapsedMenuByTheHomeFolderIcon();


        Assert.Multiple(() =>
        {
            Assert.That(isCollapseButtonEnabled, Is.True);
            Assert.That(isCollapsedMenuDisplayed, Is.True);
        });
    }
}