using Applications.Domains.Configs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Commons.Models.SystemConfigs {
    /// <summary>
    /// 系统配置分类测试
    /// </summary>
    [TestClass]
    public partial class SystemConfigCategoryTest {
        /// <summary>
        /// 系统配置分类
        /// </summary>
        private SystemConfigCategory _systemConfigCategory;

        /// <summary>
        /// 初始化测试
        /// </summary>
        [TestInitialize]
        public void Init() {
            _systemConfigCategory = Create();
        }
    }
}
