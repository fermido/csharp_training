using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.InitNewContactCreation();
            ContactData contact = new ContactData("First Name", "Last Name");
            contact.MiddleName = "MiddleName";
            contact.NickName = "NickName";
            contact.Title = "Title";

            app.Contacts
                .FillContactForm(contact)
                .SubmitNewContactCreation();
            app.Navigation.OpenHomePage();
            
            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
            app.Auth.LogOut();
        }
    }
}
