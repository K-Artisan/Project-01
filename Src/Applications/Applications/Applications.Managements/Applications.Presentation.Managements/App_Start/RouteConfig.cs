using System.Web.Mvc;
using System.Web.Routing;

namespace Presentation {
    /// <summary>
    /// 路由配置
    /// </summary>
    public class RouteConfig {
        /// <summary>
        /// 注册路由
        /// </summary>
        public static void RegisterRoutes( RouteCollection routes ) {
            IgnoreRoute( routes );
            RouteDefault( routes );
        }

        /// <summary>
        /// 忽略路由
        /// </summary>
        private static void IgnoreRoute( RouteCollection routes ) {
            routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );
        }

        /// <summary>
        /// 注册默认路由，注意：默认路由必须在自定义路由之后
        /// </summary>
        private static void RouteDefault( RouteCollection routes ) {
            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}