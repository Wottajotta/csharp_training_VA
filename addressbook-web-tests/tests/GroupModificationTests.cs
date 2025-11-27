using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            // Подготовка данных - предусловия
            GroupData newData = new GroupData("zzz");
            newData.Header = "sss";
            newData.Footer = "ccc";

            app.Groups.Modify(1, newData);
        }
    }
}
