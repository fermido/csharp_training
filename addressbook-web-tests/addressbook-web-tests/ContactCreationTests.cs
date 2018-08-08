using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));

            contactHelper.InitNewContactCreation();
            ContactData contact = new ContactData("First Name", "Last Name");
            contact.MiddleName = "MiddleName";
            contact.NickName = "NickName";
            contact.Title = "Title";
            contact.Company = "Company";
            contact.Address1 = "Address1";
            contact.Address2 = "Address2";
            contact.Home = "home";
            contact.Mobile = "Mobile";
            contact.Work = "Work";
            contact.Fax = "Fax";
            contact.Email1 = "Email1";
            contact.Email2 = "Email2";
            contact.Email3 = "Email3";
            contact.Homepage = "HomePage";
            contact.Bday = "1";
            contact.Bmonth = "January";
            contact.Byear = "1986";
            contact.Aday = "1";
            contact.Amonth = "February";
            contact.Ayear = "2000";
            contact.Phone = "phone";
            contact.Notes = "notes";
            contactHelper.FillContactForm(contact);
            
            contactHelper.SubmitNewContactCreation();
            loginHelper.LogOut();
        }
    }
}
