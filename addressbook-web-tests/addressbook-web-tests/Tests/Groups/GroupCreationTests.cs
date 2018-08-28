using NUnit.Framework;
using System.Collections.Generic;
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
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.CreateNewGroup(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);                      
            app.Auth.LogOut();
        }
    }
}
