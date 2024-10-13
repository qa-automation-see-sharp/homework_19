using Tests.Utils.Swd.Attribute;
using Tests.Utils.Swd.BaseWebElements.Elements;

namespace Tests.Utils.Swd.PageObjects
{
    public class RegistrationFormsWindow
    {
        [FindBy(Id ="firstName")]
        public Input FirstName{get; set;}

        [FindBy(Id ="lastName")]
        public Input LastName{get; set;}

        [FindBy(Id ="userEmail")]
        public Input Email{get;set;}

        [FindBy(Id ="age")]
        public Input Age {get; set;}

        [FindBy(Id ="salary")]
        public Input Salary {get; set;}

        [FindBy(Id ="department")]
        public Input Department {get; set;}

        [FindBy(Id ="submit")]
        public Button Submit {get; set;}

        [FindBy(ClassName ="close")]
        public Button Close {get; set;}

        public TablePage AddUser(string firstName, string lastName, string email, 
                            byte age, int salary, string department)
        {
            //FirstName.
            return new TablePage();
        }
    }
}