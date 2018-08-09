using NUnit.Framework;
using WebAddressbookTests;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigation.GoToGroupsPage();
            
            app.Groups
                .SelectGroup(1)
                .InitGroupRemoval()
                .ReturnToGroupsPage();

            app.Auth.LogOut();
        }
    }
}
