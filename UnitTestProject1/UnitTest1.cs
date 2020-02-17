using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using httpsample;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static Program runner = new Program();

        [TestMethod]
        public void TestMethod1()
        {
            Boolean test_case = runner.ProcessRequest();
            Assert.AreEqual(true, test_case);

        }
    }
}
