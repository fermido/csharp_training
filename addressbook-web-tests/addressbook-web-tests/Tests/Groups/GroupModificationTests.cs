using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Navigation.GoToGroupsPage();
            GroupData newData = new GroupData("a1");
            newData.Header = "b1";
            newData.Footer = "c1";

            if (!app.Groups.IsGroupExisted())
            {
                app.Groups.CreateNewGroup(newData);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups
                .SelectGroup(0)
                .InitGroupModification()
                .FillGroupForm(newData)
                .SubmitGroupModificationForm()
                .ReturnToGroupsPage();
            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void GroupModificationTestLoadinFromDB()
        {
            app.Navigation.GoToGroupsPage();
            GroupData newData = new GroupData("a1");
            newData.Header = "b1";
            newData.Footer = "c1";

            if (!app.Groups.IsGroupExisted())
            {
                app.Groups.CreateNewGroup(newData);
            }

            List<GroupData> oldGroups = GroupData.GetDataFromDb();
            GroupData oldData = oldGroups[0];

            app.Groups
                .SelectGroup(oldData.Id)
                .InitGroupModification()
                .FillGroupForm(newData)
                .SubmitGroupModificationForm()
                .ReturnToGroupsPage();

            List<GroupData> newGroups = GroupData.GetDataFromDb(); 
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}
