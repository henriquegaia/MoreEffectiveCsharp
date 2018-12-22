using Microsoft.VisualStudio.TestTools.UnitTesting;
using MECSharp_28_NeverWriteAsyncVoidMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECSharp_28_NeverWriteAsyncVoidMethods.Tests
{
    [TestClass()]
    public class Pg144_2_UseAppDomainTests
    {
        [TestMethod()]
        public void HandleFileAsyncTest()
        {
            Task<int> task = Pg144_2_UseAppDomain
                .HandleFileAsync(throwExp: false);
            task.Wait();
            int result = task.Result;
            Assert.AreEqual(task.IsCompleted, true);
            Assert.AreEqual(16921, result);
        }
    }
}