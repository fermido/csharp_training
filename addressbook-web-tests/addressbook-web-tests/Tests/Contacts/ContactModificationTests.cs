using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            app.Contacts.EditContact(2);
            ContactData newData = new ContactData("First Name11", "Last Name11");
            
            app.Contacts
                .FillContactForm(newData)
                .SubmitNewContactData();
            app.Auth.LogOut();
        }
    }
}
