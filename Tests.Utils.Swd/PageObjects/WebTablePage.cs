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

    [FindBy(Id = "delete-record-1")]
    public Button Delete { get; set; }

    [FindBy(CssSelector = ".ReactTable .rt-thead .rt-th:nth-child(3)")]
    public Element AgeColumnHeader { get; set; }

    [FindBy(Id = "addNewRecordButton")]
    public Button? Add { get; set; }

    [FindBy(Id = "submit")]
    public Button? Submit { get; set; }

    [FindBy(Id = "registration-form-modal")]
    public Element RegistrationForm {get; set; }

    [FindBy(Id = "firstName")]
    private Input FirstNameInput {get; set; }

    [FindBy(Id = "lastName")]
    private Input LastNameInput {get; set; }

    [FindBy(Id = "userEmail")]
    private Input EmailInput {get; set; }

    [FindBy(Id = "age")]
    private Input AgeInput {get; set; }

    [FindBy(Id = "salary")]
    private Input SalaryInput {get; set; }

    [FindBy(Id = "department")]
    private Input DepartmentInput {get; set; }

    public string firstName = "Firstname";
    public string lastName = "Lastname";
    public string email = "email@email.com";
    public string age = "0";
    public string salary = "0";
    public string department = "Department";

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

    public void FillOutRegistrationForm()
    {
        FirstNameInput.SendKeys(firstName);
        LastNameInput.SendKeys(lastName);
        EmailInput.SendKeys(email);
        AgeInput.SendKeys(age);
        SalaryInput.SendKeys(salary);
        DepartmentInput.SendKeys(department);
    }

    public static List<int> ConvertToIntegerList(IList<Element> list)
    {
        var intList = new List<int>();

        for (var i = 0; i < list.Count; i++)
        {
            var cellText = list[i].GetText();

            if (int.TryParse(cellText, out int cellInt))
            {
                intList.Add(cellInt);
            }
        }

        return intList;
    }

    public bool IsSortedAscending(List<int> list)
    {
        return list.SequenceEqual(list.OrderBy(x => x));
    }

    public bool IsSortedDescending(List<int> list)
    {
        return list.SequenceEqual(list.OrderByDescending(x => x));
    }   
}