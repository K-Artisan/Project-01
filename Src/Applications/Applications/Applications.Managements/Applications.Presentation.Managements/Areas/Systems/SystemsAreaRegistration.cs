using System.Web.Mvc;

namespace Presentation.Areas.Systems {
    /// <summary>
    /// 系统模块
    /// </summary>
    public class SystemsAreaRegistration : AreaRegistration {
        /// <summary>
        /// 区域名称
        /// </summary>
        public override string AreaName {
            get {
                return "Systems";
            }
        }

        /// <summary>
        /// 注册路由
        /// </summary>
        public override void RegisterArea( AreaRegistrationContext context ) {
            context.MapRoute(
                "Systems_default",
                "Systems/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
