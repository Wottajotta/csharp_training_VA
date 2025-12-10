using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests: TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // Подготовка
            app.Auth.Logout();

            // Действия
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);
            
            // Проверка
            Assert.That(app.Auth.IsLoggedIn());
        }

        [Test]
        public void LoginWithInValidCredentials()
        {
            // Подготовка
            app.Auth.Logout();

            // Действия
            AccountData account = new AccountData("admin", "123456");
            app.Auth.Login(account);

            // Проверка
            Assert.That(!app.Auth.IsLoggedIn());
        }

    }
}
