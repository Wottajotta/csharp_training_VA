using NUnit.Framework;
using System.Collections.Generic;
using WebAddressbookTests.tests;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateGroupsTest : AuthTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i <5; i++)
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
        public void CreateGroupTest(GroupData group)
        {

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.That(oldGroups.Count+1, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(newGroups, Is.EqualTo(oldGroups));
        }
    }
}
