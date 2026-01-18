using NUnit.Framework;
using System.Collections.Generic;
using WebAddressbookTests.tests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RecordInformationTest : AuthTestBase
    {
        [Test]
        public void TestRecordInformation()
        {
            RecordData fromTable = app.Record.GetRecordInformationFromTable(0);
            RecordData fromForm = app.Record.GetRecordInformationFromForm(0);


            // verifications
            Assert.That(fromTable, Is.EqualTo(fromForm));
            Assert.That(fromTable.Address, Is.EqualTo(fromForm.Address));
            Assert.That(fromTable.AllPhones, Is.EqualTo(fromForm.AllPhones));
        }

        [Test]
        public void TestRecordInformation2()
        {
            RecordData fromForm = app.Record.GetRecordInformationFromForm(0);
            RecordData fromPage = app.Record.GetRecordInformationFromPage(0);

            Assert.That(fromPage, Is.EqualTo(fromForm));
        }

    }

}
