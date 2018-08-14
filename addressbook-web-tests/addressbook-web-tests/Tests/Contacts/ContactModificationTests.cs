using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("First Name11", "Last Name11");

            if (!app.Contacts.IsContactExisted())
            {
                app.Contacts.CreateNewContact(newData);
                app.Navigation.OpenHomePage();
            }

            app.Contacts.EditContact(1);
                        
            app.Contacts
                .FillContactForm(newData)
                .SubmitNewContactData();
            app.Auth.LogOut();
        }
    }
}
