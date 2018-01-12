using Applications.Domains.Configs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Commons.Models.SystemConfigs {
    /// <summary>
    /// 系统配置测试
    /// </summary>
    [TestClass]
    public partial class SystemConfigTest {
        /// <summary>
        /// 系统配置
        /// </summary>
        private SystemConfig _systemConfig;

        /// <summary>
        /// 初始化测试
        /// </summary>
        [TestInitialize]
        public void Init() {
            _systemConfig = Create();
        }
    }
}
