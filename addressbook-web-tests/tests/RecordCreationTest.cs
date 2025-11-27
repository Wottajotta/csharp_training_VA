using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateRecordTests : TestBase
    {

        [Test]
        public void CreateNewRecord()
        {
            // Тестовые данные
            RecordData record = new RecordData("Ruslan", "Ruslanov", "123 Main St, Anytown", "555-1234", "rus@test.ru", "20", "May", "1990");
            record.Middlename = "Ruslanovich";
            record.Nickname = "ruslan123";
            record.Title = "Mr.";
            record.Company = "Ruslan Inc.";

            // Тестовые шаги
            app.Record
                .AddNewRecord()
                .FillRecordForm(record)
                .SubmitRecordCreation();
            app.Navigator.GoToHomePage();
            app.Auth.Logout();
        }   
    }
}
