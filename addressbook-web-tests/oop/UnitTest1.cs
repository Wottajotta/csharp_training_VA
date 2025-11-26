using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace addressbook_web_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(5);
            Square s2 = new Square(10);
            Square s3 = s1;


            Assert.AreEqual(s1.Size, 5);
            Assert.AreEqual(s2.Size, 10);
            Assert.AreEqual(s3.Size, 5);

            s3.Size = 15;
            Assert.AreEqual(s3.Size, 15);

            s2.Colored = true;
            Assert.AreEqual(s2.Colored, true);

        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle c1 = new Circle(2);
            Circle c2 = new Circle(4);
            Circle c3 = c1;


            Assert.AreEqual(c1.Radius, 2);
            Assert.AreEqual(c2.Radius, 4);
            Assert.AreEqual(c3.Radius, 2);

            c3.Radius = 15;
            Assert.AreEqual(c3.Radius, 15);

            c2.Colored = true;

        }
    }
}
