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
            var groupnumber = "[1]";

            app.Navigation.GoToGroupsPage();
            GroupData group = new GroupData("a");
            group.Header = "b";
            group.Footer = "c";

            if (!app.Groups.IsGroupExisted())
            {
                app.Groups.CreateNewGroup(group);
                app.Groups.ReturnToGroupsPage();
                groupnumber = "";
            }
                
            app.Groups
                    .SelectGroup(groupnumber)
                    .InitGroupRemoval()
                    .ReturnToGroupsPage();
            
            app.Auth.LogOut();
        }
    }
}
