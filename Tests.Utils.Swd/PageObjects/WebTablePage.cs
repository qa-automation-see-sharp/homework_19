using OpenQA.Selenium;
using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Browser;
using Tests.Utils.Swd.BaseWebElements.Elements;
using Tests.Utils.Swd.BaseWebElements.Elements.Table;
using Tests.Utils.Swd.BaseWebElements.Page.Abstractions;

namespace Tests.Utils.Swd.PageObjects;

public class WebTablePage : BasePage
{
    private string Url => "https://demoqa.com/webtables";
    
    [FindBy(XPath = "//h1[contains(text(),\"Web Tables\")]")]
    public Element? Title { get; set; }

    [FindBy(XPath = "//div[@class='rt-tbody']")]
    public Table? Table { get; set; }

    [FindBy(XPath = "//div[@class='rt-resizable-header-content' and text()='Age']")]
    public Table? Age { get; set; }

    [FindBy(XPath = "//button[@id='addNewRecordButton']")]

    public Button? AddButton { get; set; }

    private string DeleteButtonXPath(int rowNumber) => $"//span[@id='delete-record-{rowNumber}']";

    [FindBy(XPath = "//div[contains(@class, 'modal-content')]//input[@id='firstName']")]
    public Element? FirstName { get; set; }

    [FindBy(XPath = "//div[contains(@class, 'modal-content')]//input[@id='lastName']")]
    public Element? LastName { get; set; }

    [FindBy(XPath = "//div[contains(@class, 'modal-content')]//input[@id='age']")]
    public Element? AddAge { get; set; }

    [FindBy(XPath = "//div[contains(@class, 'modal-content')]//input[@id='userEmail']")]
    public Element? Email { get; set; }

    [FindBy(XPath = "//div[contains(@class, 'modal-content')]//input[@id='salary']")]
    public Element? Salary { get; set; }

    [FindBy(XPath = "//div[contains(@class, 'modal-content')]//input[@id='department']")]
    public Element? Department { get; set; }

    [FindBy(XPath = "//div[contains(@class, 'modal-content')]//button[@id='submit']")]
    public Element? SubmitButton { get; set; }


    public WebTablePage OpenInBrowser(BrowserNames name, params string[] args)
    {
        OpenWith(name, args);
        return this;
    }

    public WebTablePage NavigateToPage()
    {
        NavigateTo(Url);
        return this;
    }

    public WebTablePage SortByAge()
    {
        Age.Click();
        return this;
    }

    public WebTablePage Add()
    {
        AddButton.Click();
        return this;
    }
    public WebTablePage AddFirstName(string name)
    {
        FirstName?.SendKeys(name);
        return this;
    }
    public WebTablePage AddLastName(string name)
    {
        LastName?.SendKeys(name);
        return this;
    }
    
    public WebTablePage AddEmail(string email)
    {
        Email?.SendKeys(email);
        return this;
    }

    public WebTablePage InputAge(int age)
    {
        AddAge?.SendKeys(Convert.ToString(age));
        return this;
    }

    public WebTablePage AddSalary(int salary)
    {
        Salary?.SendKeys(Convert.ToString(salary));
        return this;
    }

    public WebTablePage AddDepartment(string department)
    {
        Department?.SendKeys(department);
        return this;
    }
    
    public WebTablePage Submit()
    {
        SubmitButton?.Click();
        return this;
    }

    public WebTablePage DeleteRow(int row)
    {
        var deleteButton = WebDriverFactory.Driver.FindElement(By.XPath(DeleteButtonXPath(row)));
        deleteButton.Click();

        return this;
    }
}