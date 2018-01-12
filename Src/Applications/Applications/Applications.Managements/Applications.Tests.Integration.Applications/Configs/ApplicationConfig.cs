using Autofac;
using Util.ApplicationServices;
using Util.Datas.Sql.Queries;
using Util.Datas.SqlServer.Queries;
using Util.Exports;
using Util.Files;
using Util.Offices.Npoi;

namespace Applications.Tests.Integration.Configs {
    /// <summary>
    /// 应用程序Ioc配置
    /// </summary>
    public class ApplicationConfig : Util.DI.Autofac.ConfigBase {
        /// <summary>
        /// 加载配置
        /// </summary>
        protected override void Load( ContainerBuilder builder ) {
            LoadBase( builder );
        }

        /// <summary>
        /// 加载基础设施
        /// </summary>
        private void LoadBase( ContainerBuilder builder ) {
            builder.RegisterType<TenantUploadPathStrategy>().As<IUploadPathStrategy>().InstancePerLifetimeScope();
            builder.RegisterType<ExportFactory>().As<IExportFactory>();
            builder.RegisterType<SqlServerQuery2012>().As<ISqlQuery>();
        }
    }
}
