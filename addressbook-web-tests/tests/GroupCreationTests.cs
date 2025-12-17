using NUnit.Framework;
using System.Collections.Generic;
using System.Security.Cryptography;
using WebAddressbookTests.tests;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateGroupsTest : AuthTestBase
    {

        [Test]
        public void CreateGroupTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "des";
            group.Footer = "fff";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(newGroups, Is.EqualTo(oldGroups));
        }

        [Test]
        public void CreateEmptyGroupTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(newGroups, Is.EqualTo(oldGroups));
        }

        [Test]
        public void BadNameCreateGroupTest()
        {
            GroupData group = new GroupData("`a`a`````");
            group.Header = "des";
            group.Footer = "fff";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(newGroups, Is.EqualTo(oldGroups));
        }
    }
}
