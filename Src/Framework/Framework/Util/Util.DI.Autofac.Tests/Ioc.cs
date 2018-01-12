namespace Util.DI.Autofac.Tests {
    /// <summary>
    /// Autofac依赖注入
    /// </summary>
    public static class Ioc {
        /// <summary>
        /// 初始化容器
        /// </summary>
        static Ioc() {
            Container.Init(null, new Module1(), new Module2(), new Module3(), new Module4() );
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        public static T Create<T>() {
            return Container.Create<T>();
        }
    }
}
