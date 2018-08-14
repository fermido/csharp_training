using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            app.Groups
                .SelectGroup("[1]")
                .InitGroupModification()
                .FillGroupForm(newData)
                .SubmitGroupModificationForm()
                .ReturnToGroupsPage();

            app.Auth.LogOut();
        }
}
}
