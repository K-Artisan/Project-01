using Applications.Tests.Integration.Configs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.ApplicationServices;

namespace Applications.Tests.Integration {
    /// <summary>
    /// 全局设置
    /// </summary>
    [TestClass]
    public class Global {
        /// <summary>
        /// 全局测试初始化
        /// </summary>
        /// <param name="context">测试上下文</param>
        [AssemblyInitialize]
        public static void TestInit( TestContext context ) {
            Ioc.RegisterTest( new ApplicationConfig() );
        }
    }
}
