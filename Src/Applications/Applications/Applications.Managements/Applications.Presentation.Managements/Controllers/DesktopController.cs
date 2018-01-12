using System.Web.Mvc;
using Presentation.Base;

namespace Presentation.Controllers {
    /// <summary>
    /// 桌面控制器
    /// </summary>
    public class DesktopController : PermissionControllerBase {
        /// <summary>
        /// 获取主界面
        /// </summary>
        public virtual ActionResult Index() {
            return View();
        }
    }
}
