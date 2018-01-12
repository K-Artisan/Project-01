using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Applications.Datas.Ef;
using Applications.Datas.Ef.MySql;
using Applications.Services.Configs;
using Util;
using Util.ApplicationServices;
using Util.Datas.Ef;
using Util.Logs;
using Util.Logs.Log4;

namespace Presentation {
    /// <summary>
    /// 应用程序全局设置
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication {
        /// <summary>
        /// 启动应用程序
        /// </summary>
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes( RouteTable.Routes );
            BundleConfig.RegisterBundles( BundleTable.Bundles );
            Ioc.RegisterMvc( typeof( MvcApplication ).Assembly,new IocConfig() );
            //EfUnitOfWork.Init( new ApplicationUnitOfWork(), new MySqlApplicationUnitOfWork() );
        }

        /// <summary>
        /// 应用程序错误处理
        /// </summary>
        protected void Application_Error( object sender, EventArgs e ) {
            var lastError = Server.GetLastError();
            WriteLog( lastError );
            //Response.Redirect( @"~/error" );
            //Server.ClearError();
        }

        /// <summary>
        /// 记录异常日志
        /// </summary>
        /// <param name="exception">异常</param>
        private void WriteLog( Exception exception ) {
            ILog log = Log.GetContextLog( this.GetType() );
            log.Application = "管理系统";
            log.Caption.Add( "管理后台Global全局异常捕获" );
            log.Exception = exception;
            Warning.WriteLog( log, exception );
        }
    }
}