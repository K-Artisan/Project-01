using Applications.Domains.Commons.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Commons.Models.Dics {
    /// <summary>
    /// 字典测试
    /// </summary>
    [TestClass]
    public partial class DicTest {
        /// <summary>
        /// 字典
        /// </summary>
        private Dic _dic;

        /// <summary>
        /// 初始化测试
        /// </summary>
        [TestInitialize]
        public void Init() {
            _dic = Create();
        }
    }
}
