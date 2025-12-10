using NUnit.Framework;
using WebAddressbookTests.tests;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateGroupsTest : AuthTestBase
    {

        [Test]
        public void CreateGroupTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "des";
            group.Footer = "fff";

            app.Groups.Create(group);
        }

        [Test]
        public void CreateEmptyGroupTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);  
        }
    }
}
