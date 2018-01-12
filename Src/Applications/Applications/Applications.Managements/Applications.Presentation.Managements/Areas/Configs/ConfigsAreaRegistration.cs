using System.Web.Mvc;

namespace Presentation.Areas.Configs {
    /// <summary>
    /// 配置模块
    /// </summary>
    public class ConfigsAreaRegistration : AreaRegistration {
        /// <summary>
        /// 区域名称
        /// </summary>
        public override string AreaName {
            get {
                return "Configs";
            }
        }

        /// <summary>
        /// 注册路由
        /// </summary>
        public override void RegisterArea( AreaRegistrationContext context ) {
            context.MapRoute(
                "Configs_default",
                "Configs/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
