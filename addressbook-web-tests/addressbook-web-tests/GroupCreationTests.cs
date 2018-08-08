using NUnit.Framework;
using WebAddressbookTests;

namespace WebAdressbookTests 
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("a");
            group.Header = "b";
            group.Footer = "c";
            FillGroupForm(group);
            SubmitGroupForm();
            ReturnToGroupsPage();
            LogOut();
        }
    }
}
