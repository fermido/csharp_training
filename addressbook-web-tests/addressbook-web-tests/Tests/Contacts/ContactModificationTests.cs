using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
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

        [Test]
        public void ContactModificationTestLoadingFromDB()
        {
            ContactData newData = new ContactData("First Name11", "Last Name11");

            if (!app.Contacts.IsContactExisted())
            {
                app.Contacts.CreateNewContact(newData);
                app.Navigation.OpenHomePage();
            }

            List<ContactData> oldContacts = ContactData.GetDataFromDb();
            ContactData oldData = oldContacts[0];

            app.Contacts
                .EditContact(oldData.Id)
                .FillContactForm(newData)
                .SubmitNewContactData();
            app.Navigation.OpenHomePage();

            List<ContactData> newContacts = ContactData.GetDataFromDb();

            oldContacts[0].FirstName = newData.FirstName;
            oldContacts[0].LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
