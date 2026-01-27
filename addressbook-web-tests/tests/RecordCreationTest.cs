using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using WebAddressbookTests.tests;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateRecordTests : RecordTestBase
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
        public static IEnumerable<RecordData> RecordDataFromXmlFile()
        {
            return (List<RecordData>)
                new XmlSerializer(typeof(List<RecordData>))
                .Deserialize(new StreamReader(@"record.xml"));
        }

        public static IEnumerable<RecordData> RecordDataFromJsonFile()
        {
            return (JsonConvert.DeserializeObject<List<RecordData>>(
                 File.ReadAllText(@"record.json")));
        }


        [Test, TestCaseSource("RecordDataFromJsonFile")]
        public void CreateNewRecord(RecordData record)
        {

            List<RecordData> oldrecords = RecordData.GetAll();

            // Тестовые шаги
            app.Record.Create(record);

            List<RecordData> newrecords = RecordData.GetAll();
            oldrecords.Add(record);
            oldrecords.Sort();
            newrecords.Sort();
            Assert.That(newrecords, Is.EqualTo(oldrecords));
        }   
    }
}
