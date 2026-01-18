using NUnit.Framework;
using System.Collections.Generic;
using WebAddressbookTests.tests;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateRecordTests : AuthTestBase
    {

        public static IEnumerable<RecordData> RandomRecordDataProvider()
        {
            List<RecordData> records = new List<RecordData>();
            for (int i = 0; i < 5; i++)
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
        public void CreateNewRecord(RecordData record)
        {

            List<RecordData> oldrecords = app.Record.GetRecordList();

            // Тестовые шаги
            app.Record.Create(record);

            List<RecordData> newrecords = app.Record.GetRecordList();
            oldrecords.Add(record);
            oldrecords.Sort();
            newrecords.Sort();
            Assert.That(newrecords, Is.EqualTo(oldrecords));
        }   
    }
}
