using NUnit.Framework;
using System.Collections.Generic;
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

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups
                    .SelectGroup(groupnumber)
                    .InitGroupRemoval()
                    .ReturnToGroupsPage();

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            app.Auth.LogOut();
        }
    }
}
