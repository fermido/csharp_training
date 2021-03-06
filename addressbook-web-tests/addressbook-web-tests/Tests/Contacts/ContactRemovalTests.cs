﻿using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
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
            app.Navigation.OpenHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
            app.Auth.LogOut();
        }

        [Test]
        public void ContactRemovalTestLoadingFromDB()
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

            List<ContactData> oldContacts = ContactData.GetDataFromDb();
            ContactData elementRemove = oldContacts[0];

            app.Contacts.Remove(elementRemove);
            
            List<ContactData> newContacts = ContactData.GetDataFromDb();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
