using NUnit.Framework;
using System.Collections.Generic;
using WebAddressbookTests.tests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 3; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = null,
                    Footer = null
                });
            }
            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupModificationTest(GroupData groups)
        {


            if (app.Groups.GetGroupList().Count == 0)
            {
                app.Groups.Create(groups);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, groups);

            Assert.That(oldGroups.Count, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = groups.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(newGroups, Is.EqualTo(oldGroups));

            foreach (GroupData group in newGroups)
            {
                if(group.Id == oldData.Id)
                {
                    Assert.That(groups.Name, Is.EqualTo(group.Name));
                }
            }
        }
    }
}
