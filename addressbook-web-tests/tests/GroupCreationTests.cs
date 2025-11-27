using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateGroupsTest : TestBase
    {

        [Test]
        public void CreateGroupTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "des";
            group.Footer = "fff";

            app.Groups.Create(group);
            app.Auth.Logout();
        }

        [Test]
        public void CreateEmptyGroupTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);  
            app.Auth.Logout();
        }
    }
}
