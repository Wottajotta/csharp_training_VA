using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateGroupTest : TestBase
    {

        [Test]
        public void CreateGroupsTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupPage();
            InitNewGroup();
            GroupData group = new GroupData("aaa");
            group.Header = "des";
            group.Footer = "fff";
            FillGroup(group);
            SumbitGroupCreation();
            ReturnToGroupPage();
            Logout();
        }
    }
}
