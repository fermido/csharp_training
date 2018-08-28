using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
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
                .SelectGroup("[1]")
                .InitGroupModification()
                .FillGroupForm(newData)
                .SubmitGroupModificationForm()
                .ReturnToGroupsPage();
            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            app.Auth.LogOut();
        }
}
}
