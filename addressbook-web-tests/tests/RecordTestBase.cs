using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests.tests;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RecordTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareRecordsUI_DB()
        {
            if (PERFORM_LING_UI_CHECKS)
            {
                List<RecordData> fromUi = app.Record.GetRecordList();
                List<RecordData> fromDb = RecordData.GetAll();

                fromUi.Sort();
                fromDb.Sort();

                Assert.That(fromDb, Is.EqualTo(fromUi));
            }
        }
    }
}
