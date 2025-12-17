using NUnit.Framework;
using System.Collections.Generic;
using WebAddressbookTests.tests;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateRecordTests : AuthTestBase
    {

        [Test]
        public void CreateNewRecord()
        {
            // Тестовые данные
            RecordData record = new RecordData("Anton", "Ruslanov", "123 Main St, Anytown", "555-1234", "rus@test.ru", "20", "May", "1990");
            record.Middlename = "Ruslanovich";
            record.Nickname = "ruslan123";
            record.Title = "Mr.";
            record.Company = "Ruslan Inc.";

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
