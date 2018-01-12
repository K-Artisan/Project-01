using Applications.Domains.Security.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Security.Models.Resources {
    /// <summary>
    /// 资源测试
    /// </summary>
    [TestClass]
    public partial class ResourceTest {
        /// <summary>
        /// 资源
        /// </summary>
        private Resource _resource;

        /// <summary>
        /// 初始化测试
        /// </summary>
        [TestInitialize]
        public void Init() {
            _resource = Create();
        }
    }
}
