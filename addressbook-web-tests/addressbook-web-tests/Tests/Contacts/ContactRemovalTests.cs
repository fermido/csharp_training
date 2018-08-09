using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts
                .SelectGroup(1)
                .InitContactRemoval()
                .ConfirmContactRemoval();
            
            app.Auth.LogOut();
        }
    }
}
