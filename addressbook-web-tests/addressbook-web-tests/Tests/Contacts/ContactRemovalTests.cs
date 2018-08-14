using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("First Name", "Last Name");
            contact.MiddleName = "MiddleName";
            contact.NickName = "NickName";
            contact.Title = "Title";

            if (!app.Contacts.IsContactExisted())
            {
                app.Contacts.CreateNewContact(contact);
                app.Navigation.OpenHomePage();
            }
            
            app.Contacts
                .SelectGroup(1)
                .InitContactRemoval()
                .ConfirmContactRemoval();
            
            app.Auth.LogOut();
        }
    }
}
