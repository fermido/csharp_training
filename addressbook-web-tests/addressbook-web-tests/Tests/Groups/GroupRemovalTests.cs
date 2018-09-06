using NUnit.Framework;
using System.Collections.Generic;
using WebAddressbookTests;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            var groupnumber = 0;

            app.Navigation.GoToGroupsPage();
            GroupData group = new GroupData("a");
            group.Header = "b";
            group.Footer = "c";

            if (!app.Groups.IsGroupExisted())
            {
                app.Groups.CreateNewGroup(group);
                app.Groups.ReturnToGroupsPage();
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups
                    .SelectGroup(groupnumber)
                    .InitGroupRemoval()
                    .ReturnToGroupsPage();

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void GroupRemovalTestLoadingFromDB()
        {
            app.Navigation.GoToGroupsPage();
            GroupData group = new GroupData("a");
            group.Header = "b";
            group.Footer = "c";

            if (!app.Groups.IsGroupExisted())
            {
                app.Groups.CreateNewGroup(group);
                app.Groups.ReturnToGroupsPage();
            }

            List<GroupData> oldGroups = GroupData.GetDataFromDb();
            GroupData elementRemove = oldGroups[0];

            app.Groups.Remove(elementRemove);
             
            List<GroupData> newGroups = GroupData.GetDataFromDb();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
