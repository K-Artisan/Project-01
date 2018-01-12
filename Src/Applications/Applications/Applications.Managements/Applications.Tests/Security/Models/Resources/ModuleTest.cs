using Applications.Domains.Security.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Security.Models.Resources {
    /// <summary>
    /// 模块测试
    /// </summary>
    [TestClass]
    public class ModuleTest {
        /// <summary>
        /// 模块
        /// </summary>
        private Module _module;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _module = new Module();
        }

        /// <summary>
        /// 获取Url
        /// </summary>
        [TestMethod]
        public void TestGetUrl() {
            Assert.AreEqual( "", _module.GetUrl(), "null" );
            _module.Uri = "a";
            Assert.AreEqual( "",_module.GetUrl() );
            _module.Uri = "/a";
            Assert.AreEqual( "/a", _module.GetUrl() );
            _module.Uri = @"\a\b";
            Assert.AreEqual( "/a/b", _module.GetUrl() );
            _module.Uri = @"~\a\b";
            Assert.AreEqual( "/a/b", _module.GetUrl() );
        }
    }
}
