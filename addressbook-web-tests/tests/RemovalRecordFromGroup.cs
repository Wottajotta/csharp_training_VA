using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests.tests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovalRecordFromGroup : AuthTestBase
    {
        [Test]
        public void TestRemovalRecordToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<RecordData> oldlist = group.GetRecord();
            RecordData record = RecordData.GetAll()
                .Except(oldlist).First();

            app.Record.RemoveRecordFromGroup(record, group);

            List<RecordData> newlist = group.GetRecord();
            oldlist.Add(record);
            newlist.Sort();
            oldlist.Sort();

            Assert.That(oldlist, Is.EqualTo(newlist));
        }
    }
}
