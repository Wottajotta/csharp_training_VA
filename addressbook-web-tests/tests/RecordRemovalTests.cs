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
    public class RecordRemovalTests : RecordTestBase
    {
        public static IEnumerable<RecordData> RandomRecordDataProvider()
        {
            List<RecordData> records = new List<RecordData>();
            for (int i = 0; i < 3; i++)
            {
                records.Add(new RecordData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(10),
                    Nickname = GenerateRandomString(10),
                    Title = GenerateRandomString(5),
                    Company = GenerateRandomString(15),
                    HomePhone = GenerateRandomPhone(),
                    MobilePhone = GenerateRandomPhone(),
                    WorkPhone = GenerateRandomPhone(),
                    Email = GenerateRandomEmail(10)
                });
            }
            return records;
        }


        [Test, TestCaseSource("RandomRecordDataProvider")]
        public void RecordRemovalTest(RecordData record)
        {

            if (app.Record.GetRecordList().Count == 0) {
                app.Record.Create(record);
            }
            List<RecordData> oldrecords = RecordData.GetAll();

            app.Record.Remove();

            List<RecordData> newrecords = RecordData.GetAll();
            oldrecords.RemoveAt(0);
            oldrecords.Sort();
            newrecords.Sort();
            Assert.That(newrecords, Is.EqualTo(oldrecords));
        }
    }
}
