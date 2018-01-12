using Applications.Domains.Commons.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Commons.Models.Icons {
    /// <summary>
    /// 图标测试
    /// </summary>
    [TestClass]
    public partial class IconTest {
        /// <summary>
        /// 图标
        /// </summary>
        private Icon _icon;

        /// <summary>
        /// 初始化测试
        /// </summary>
        [TestInitialize]
        public void Init() {
            _icon = Create();
        }

        /// <summary>
        /// 生成CSS
        /// </summary>
        [TestMethod]
        public void TestGenerateCss() {
            _icon.GenerateCss( "/a/b-123456.jpg" );
            Assert.AreEqual( "icon-b-123456", _icon.ClassName );
            const string css = ".icon-b-123456{background:url(images/b-123456.jpg) no-repeat center center;}";
            Assert.AreEqual( css, _icon.Css );
        }
    }
}
