using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RecordModifyTests : TestBase
    {
        [Test]
        public void ModifyRecordTest()
        {
            // Тестовые данные
            RecordData newData = new RecordData("Ivan", "Ivanov", "456 Elm St, Othertown", "555-5678", "ivan@test.ru", "30", "June", "2005");
            // Тестовые шаги
            app.Record.Modify(newData);
        }
    }
}
