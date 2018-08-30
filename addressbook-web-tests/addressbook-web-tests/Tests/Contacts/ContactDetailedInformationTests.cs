using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactDetailedInformationTests : TestBase
    {

        [Test]
        public void TestContactDetailedInformation()
        {
            string fromContactDetails = app.Contacts.GetContactInformationfromContactDetails(2);
            app.Navigation.OpenHomePage();
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(2);

            Assert.AreEqual(fromContactDetails, fromForm.AllData);
            
            app.Auth.LogOut();
        }
    }
}
