using Applications.Domains.Commons.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Images;

namespace Applications.Tests.Commons.Factories {
    /// <summary>
    /// 图标工厂测试
    /// </summary>
    [TestClass]
    public class IconFactoryTest {
        /// <summary>
        /// 创建图标
        /// </summary>
        [TestMethod]
        public void TestCreate() {
            const string path = "/a/b.jpg";
            ImageInfo image = ImageInfo.Create( path, 1, 2, 3,"c.jpg" );
            var icon = IconFactory.Create( image );
            Assert.AreEqual( path, icon.Path );
            Assert.AreEqual( "c.jpg", icon.Name );
            Assert.AreEqual( 1, icon.Size );
            Assert.AreEqual( 2, icon.Width );
            Assert.AreEqual( 3, icon.Height );
            Assert.AreEqual( 3, icon.Height );
            Assert.AreEqual( "icon-b", icon.ClassName );
        }
    }
}
