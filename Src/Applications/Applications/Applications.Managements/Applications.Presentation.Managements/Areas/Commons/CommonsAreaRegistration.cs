using System.Web.Mvc;

namespace Presentation.Areas.Commons {
    /// <summary>
    /// 公共模块
    /// </summary>
    public class CommonsAreaRegistration : AreaRegistration {
        /// <summary>
        /// 区域名称
        /// </summary>
        public override string AreaName {
            get {
                return "Commons";
            }
        }

        /// <summary>
        /// 注册路由
        /// </summary>
        public override void RegisterArea( AreaRegistrationContext context ) {
            context.MapRoute(
                "Commons_default",
                "Commons/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
