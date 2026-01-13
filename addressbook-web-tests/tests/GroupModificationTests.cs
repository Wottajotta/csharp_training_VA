using NUnit.Framework;
using System.Collections.Generic;
using WebAddressbookTests.tests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            // Подготовка данных - предусловия
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;


            if (app.Groups.GetGroupList().Count == 0)
            {
                app.Groups.Create(new GroupData("abc"));
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(0, newData);

            Assert.That(oldGroups.Count, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(newGroups, Is.EqualTo(oldGroups));

            foreach (GroupData group in newGroups)
            {
                if(group.Id == oldData.Id)
                {
                    Assert.That(newData.Name, Is.EqualTo(group.Name));
                }
            }
        }
    }
}
