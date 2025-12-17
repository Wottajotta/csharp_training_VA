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
        [Test]
        public void ModifyRecordTest()
        {
            // Тестовые данные
            RecordData newData = new RecordData("Ivan", "Ivanov", "456 Elm St, Othertown", "555-5678", "ivan@test.ru", "30", "June", "2005");
            // Тестовые шаги
            List<RecordData> oldrecords = app.Record.GetRecordList();

            app.Record.Modify(0, newData);


            List<RecordData> newrecords = app.Record.GetRecordList();

            oldrecords[0].Firstname = newData.Firstname;
            oldrecords[0].Lastname = newData.Lastname;

            // Проверка
            Assert.That(newrecords, Is.EqualTo(oldrecords));
        }
    }
}
