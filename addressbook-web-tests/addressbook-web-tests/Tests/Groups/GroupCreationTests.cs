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
            app.Navigation.GoToGroupsPage();
            GroupData group = new GroupData("a");
            group.Header = "b";
            group.Footer = "c";

            app.Groups
                .InitGroupCreation()
                .FillGroupForm(group)
                .SubmitGroupForm()
                .ReturnToGroupsPage();

            app.Auth.LogOut();
        }
    }
}
