using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.DI.Autofac.Tests {
    /// <summary>
    /// Autofac依赖注入框架测试
    /// </summary>
    [TestClass]
    public class IocTest {
        /// <summary>
        /// 创建对象
        /// </summary>
        [TestMethod]
        public void TestCreate() {
            IOperation operation = Ioc.Create<IOperation>();
            Assert.AreEqual( 10, operation.GetNumber() );

            IOperation2 operation2 = Ioc.Create<IOperation2>();
            Assert.AreEqual( 10, operation2.GetNumber() );
        }

        /// <summary>
        /// 测试对象生命周期,将Context对象设为每个调用只创建一个，两个操作的值才会相等
        /// </summary>
        [TestMethod]
        public void TestCreate_Life() {
            IOperation3 operation3 = Ioc.Create<IOperation3>();
            IOperation4 operation4 = Ioc.Create<IOperation4>();
            Assert.AreEqual( operation3.Value(), operation4.Value() ); 
        }

        /// <summary>
        /// 性能测试
        /// </summary>
        [TestMethod]
        [Ignore]
        public void TestCreate_Performance() {
            for( int i = 0; i < 100000; i++ ) {
                IService service = Ioc.Create<IService>();
            }
        }
    }
}
