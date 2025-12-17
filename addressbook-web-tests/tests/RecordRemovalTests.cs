using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests.tests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RecordRemovalTests : AuthTestBase
    {
        [Test]
        public void RecordRemovalTest()
        {
            List<RecordData> oldrecords = app.Record.GetRecordList();

            app.Record.Remove();

            List<RecordData> newrecords = app.Record.GetRecordList();
            oldrecords.RemoveAt(0);
            oldrecords.Sort();
            newrecords.Sort();
            Assert.That(newrecords, Is.EqualTo(oldrecords));
        }
    }
}
