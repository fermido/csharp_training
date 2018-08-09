using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {
            app.Contacts.InitNewContactCreation();
            ContactData contact = new ContactData("First Name", "Last Name");
            contact.MiddleName = "MiddleName";
            contact.NickName = "NickName";
            contact.Title = "Title";
            
            app.Contacts
                .FillContactForm(contact)
                .SubmitNewContactCreation();
            app.Auth.LogOut();
        }
    }
}
