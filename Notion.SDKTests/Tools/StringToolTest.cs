using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notion.SDKTests.Tools
{
    [TestClass]
    public class StringToolTest
    {
        [TestMethod]
        public void StringToGuidTest()
        {
            var str = "7a89c7f51e734f41b43a1e08b1b8256d";
            var except = new Guid("7a89c7f5-1e73-4f41-b43a-1e08b1b8256d");
            var actual = new Guid(str);
            Assert.AreEqual(except, actual);
        }
    }
}
