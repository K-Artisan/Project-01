using Applications.Domains.Commons.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Commons.Models.Areas {
    /// <summary>
    /// 地区测试
    /// </summary>
    [TestClass]
    public partial class AreaTest {
        /// <summary>
        /// 地区
        /// </summary>
        private Area _area;

        /// <summary>
        /// 初始化测试
        /// </summary>
        [TestInitialize]
        public void Init() {
            _area = Create();
        }
    }
}
