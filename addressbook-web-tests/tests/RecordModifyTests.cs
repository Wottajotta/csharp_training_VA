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
    public class RecordModifyTests : AuthTestBase
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
        public void ModifyRecordTest(RecordData record)
        {
            if (app.Record.GetRecordList().Count == 0)
            {
                app.Record.Create(record);
            }

            List<RecordData> oldrecords = app.Record.GetRecordList();
            RecordData oldData = oldrecords[0];

            app.Record.Modify(0, record);

            oldData.Firstname = record.Firstname;
            oldData.Lastname = record.Lastname;

            List<RecordData> newrecords = app.Record.GetRecordList();

            oldrecords.Sort();
            newrecords.Sort();

            Assert.That(newrecords, Is.EqualTo(oldrecords));
        }
    }
}
