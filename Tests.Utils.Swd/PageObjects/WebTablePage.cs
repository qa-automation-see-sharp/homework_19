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
    
    [FindBy(Id = "addNewRecordButton")]
    public Button? AddButton { get; set; }
    
    [FindBy(XPath = "//div[@role='dialog']/div[@role='document']//div[@class='modal-header']")]
    public Element? RegistrationForm { get; set; }
    
    [FindBy(XPath = "//body/div[@role='dialog']/div[@role='document']//span[.='x']")]
    public Button? CloseRegistrationFormButton { get; set; }
    
    [FindBy(XPath = "/html//input[@id='firstName']")]
    public Element? FirstNameInput { get; set; }
    
    [FindBy(XPath = "/html//input[@id='lastName']")]
    public Element? LastNameInput { get; set; }
    
    [FindBy(XPath = "/html//input[@id='userEmail']")]
    public Element? EmailInput { get; set; }
    
    [FindBy(XPath = "/html//input[@id='age']")]
    public Element? AgeInput { get; set; }
    
    [FindBy(XPath = "/html//input[@id='salary']")]
    public Element? SalaryInput { get; set; }
    
    [FindBy(XPath = "/html//input[@id='department']")]
    public Element? DepartmentInput { get; set; }
    
    [FindBy(XPath = "/html//button[@id='submit']")]
    public Button? SubmitButton { get; set; }
    
    [FindBy(Id = "delete-record-1")]
    public Button? DeleteFirstRecordButton { get; set; }
    
    [FindBy(LinkText = "Age")]
    public Element? AgeHeader { get; set; }

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

    public Element? ClickAddButton()
    {
        AddButton.Click();
        return RegistrationForm;
    }

    public WebTablePage EnterFistName(string firstName)
    {
        FirstNameInput?.SendKeys(firstName);
        return this;
    }
    
    public WebTablePage EnterLastName(string lastName)
    {
        LastNameInput?.SendKeys(lastName);
        return this;
    }
    
    public WebTablePage EnterEmail(string email)
    {
        EmailInput?.SendKeys(email);
        return this;
    }
    
    public WebTablePage EnterAge(string age)
    {
        AgeInput?.SendKeys(age);
        return this;
    }
    
    public WebTablePage EnterSalary(string salary)
    {
        SalaryInput?.SendKeys(salary);
        return this;
    }
    
    public WebTablePage EnterDepartment(string department)
    {
        DepartmentInput?.SendKeys(department);
        return this;
    }

    public WebTablePage ClickSubmitButton()
    {
        SubmitButton?.Click();
        return this;
    }

}