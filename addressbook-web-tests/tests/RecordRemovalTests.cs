using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests.tests;

namespace WebAddressbookTests
{
    [TestFixture]
    public class RecordRemovalTests : AuthTestBase
    {
        [Test]
        public void RecordRemovalTest()
        {
            app.Record.Remove();
        }
    }
}
