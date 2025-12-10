using NUnit.Framework;


namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        // Инициализация приложения и вход в систему перед запуском тестов (Синглтон)
        [OneTimeSetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
            app.Navigator.GoToStartPage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
