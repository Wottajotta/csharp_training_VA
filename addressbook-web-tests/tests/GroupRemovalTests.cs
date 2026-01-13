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

            Assert.That(oldGroups.Count - 1, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = app.Groups.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(newGroups, Is.EqualTo(oldGroups));
            Assert.That(newGroups.Count, Is.EqualTo(oldGroups.Count));

            // Проверяем группу по Id
            foreach (GroupData group in newGroups)
            {
                Assert.That(group.Id, !Is.EqualTo(toBeRemoved.Id));
            }
            
        }
    }
}
