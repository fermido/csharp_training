using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
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

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1])
                {
                    Address1 = parts[2],
                    MiddleName = parts[3],
                    NickName = parts[4],
                    Title = parts[5],
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromXmlFile")]
        public void ContactCreationTestFromXml(ContactData contact)
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

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTestFromJson(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.InitNewContactCreation();

            app.Contacts
                .FillContactForm(contact)
                .SubmitNewContactCreation();
            app.Navigation.OpenHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTestFromJsonLoadingFromDB(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            
            app.Contacts
                .InitNewContactCreation()
                .FillContactForm(contact)
                .SubmitNewContactCreation();
            app.Navigation.OpenHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
