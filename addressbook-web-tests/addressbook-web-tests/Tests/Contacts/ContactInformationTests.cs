using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : TestBase
    {

        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(1);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(1);

            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address1, fromForm.Address1);
            Assert.AreEqual(fromTable.AllMails, fromForm.AllMails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);

            app.Auth.LogOut();
        }
    }
}
