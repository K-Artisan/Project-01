using Applications.Datas.Ef;
using Applications.Datas.Ef.MySql;
using Autofac;
using Util.ApplicationServices;
using Util.Datas.Sql.Queries;
using Util.Datas.SqlServer.Queries;
using Util.Exports;
using Util.Files;
using Util.Offices.Npoi;

namespace Applications.Services.Configs {
    /// <summary>
    /// 应用程序Ioc配置
    /// </summary>
    public class IocConfig : Util.DI.Autofac.ConfigBase {
        /// <summary>
        /// 加载配置
        /// </summary>
        protected override void Load( ContainerBuilder builder ) {
            builder.RegisterType<TenantUploadPathStrategy>().As<IUploadPathStrategy>().SingleInstance();
            builder.RegisterType<ExportFactory>().As<IExportFactory>().SingleInstance();
            builder.RegisterType<SqlServerQuery2012>().As<ISqlQuery>().InstancePerLifetimeScope();
            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>().InstancePerLifetimeScope();
            //builder.RegisterType<MySqlApplicationUnitOfWork>().As<IApplicationUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
