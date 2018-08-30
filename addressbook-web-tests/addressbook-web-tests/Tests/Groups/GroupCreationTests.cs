using NUnit.Framework;
using System.Collections.Generic;
using WebAddressbookTests;

namespace WebAdressbookTests 
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
             return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupCreationTest(GroupData group)
        {
            app.Navigation.GoToGroupsPage();
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.CreateNewGroup(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);                      
            app.Auth.LogOut();
        }
    }
}
