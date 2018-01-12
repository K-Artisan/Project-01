using System;
using Applications.Domains.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Core.Models {
    /// <summary>
    /// 地址测试
    /// </summary>
    [TestClass]
    public class AddressTest {
        /// <summary>
        /// 获取地址描述
        /// </summary>
        [TestMethod]
        public void TestDescription() {
            Address address = new Address(null,null,null, "四川省","成都市","金牛区","二环路北二段15号","221000" );
            Assert.AreEqual( "四川省成都市金牛区二环路北二段15号", address.Description );
            Console.WriteLine(address);
        }
    }
}
