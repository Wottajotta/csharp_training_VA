using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RecordRemovalTests : TestBase
    {
        [Test]
        public void RecordRemovalTest()
        {
            app.Record.Remove();
        }
    }
}
