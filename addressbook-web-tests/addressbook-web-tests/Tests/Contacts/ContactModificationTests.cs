using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
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
            app.Navigation.OpenHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
            app.Auth.LogOut();
        }
    }
}
