using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Address1 = GenerateRandomString(100),
                    MiddleName = GenerateRandomString(100),
                    NickName = GenerateRandomString(100),
                    Title = GenerateRandomString(100)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.InitNewContactCreation();
            
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
