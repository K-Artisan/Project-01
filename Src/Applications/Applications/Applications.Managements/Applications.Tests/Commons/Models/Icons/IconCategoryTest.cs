using Applications.Domains.Commons.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Commons.Models.Icons {
    /// <summary>
    /// 图标分类测试
    /// </summary>
    [TestClass]
    public partial class IconCategoryTest {
        /// <summary>
        /// 图标分类
        /// </summary>
        private IconCategory _iconCategory;

        /// <summary>
        /// 初始化测试
        /// </summary>
        [TestInitialize]
        public void Init() {
            _iconCategory = Create();
        }
    }
}
