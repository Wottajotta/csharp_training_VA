using NUnit.Framework;
using System.Collections.Generic;
using WebAddressbookTests.tests;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {

            if (app.Groups.GetGroupList().Count == 0)
            {
                app.Groups.Create(new GroupData("abc"));
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(0);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(newGroups, Is.EqualTo(oldGroups));
            Assert.That(newGroups.Count, Is.EqualTo(oldGroups.Count));
            
        }
    }
}
