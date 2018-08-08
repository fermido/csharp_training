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
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin","secret"));
            navigationHelper.GoToGroupsPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("a");
            group.Header = "b";
            group.Footer = "c";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupForm();
            navigationHelper.ReturnToGroupsPage();
            loginHelper.LogOut();
        }
    }
}
