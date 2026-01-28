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
    public class RecordModifyTests : RecordTestBase
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
        public void ModifyRecordTest(RecordData newData)
        {
            if (app.Record.GetRecordList().Count == 0)
            {
                app.Record.Create(newData);
            }

            List<RecordData> oldRecords = RecordData.GetAll();

            RecordData toBeModified = oldRecords[0];
            RecordData modifiedData = new RecordData(newData.Firstname, newData.Lastname);
            modifiedData.Id = toBeModified.Id;

            app.Record.Modify(toBeModified.Id, modifiedData);

            List<RecordData> newRecords = RecordData.GetAll();

            toBeModified.Firstname = modifiedData.Firstname;
            toBeModified.Lastname = modifiedData.Lastname;

            oldRecords.Sort();
            newRecords.Sort();

            Assert.That(newRecords, Is.EqualTo(oldRecords));
        }

    }
}
