using System.Linq;
using System.Web.Mvc;
using Applications.Services.Contracts.Security;
using Presentation.Base;
using Util;
using Util.Webs.EasyUi.Results;
using Util.Webs.EasyUi.Trees;

namespace Presentation.Controllers {
    /// <summary>
    /// 主界面控制器
    /// </summary>
    public class HomeController : PermissionControllerBase {
        /// <summary>
        /// 初始化主界面控制器
        /// </summary>
        /// <param name="securityService">系统服务</param>
        public HomeController( ISystemService securityService ) {
            SecurityService = securityService;
        }

        /// <summary>
        /// 安全服务
        /// </summary>
        public ISystemService SecurityService { get; set; }

        /// <summary>
        /// 获取主界面
        /// </summary>
        public virtual ActionResult Index() {
            return View();
        }

        public ActionResult GetTree() {
            var node = new TreeNode { Id = "1", Text = "系统管理" };
            var node1 = new TreeNode { Id = "2", ParentId = "1", Text = "应用程序管理", Attributes = new { url = "/systems/application" } };
            var node10 = new TreeNode { Id = "20", ParentId = "1", Text = "应用程序管理2", Attributes = new { url = "/systems/application2/Index?a=1" } };
            var node11 = new TreeNode { Id = "21", ParentId = "1", Text = "应用程序管理3", Attributes = new { url = "/systems/application3" } };
            var node3 = new TreeNode { Id = "4", ParentId = "1", Text = "字典管理", Attributes = new { url = "/commons/dic" } };
            var node4 = new TreeNode { Id = "5", ParentId = "1", Text = "地区管理", Attributes = new { url = "/commons/area" } };
            var node123 = new TreeNode { Id = "123", ParentId = "1", Text = "系统配置管理", Attributes = new { url = "/configs/systemconfig" } };
            var node7 = new TreeNode { Id = "8", ParentId = "1", Text = "资源管理", Attributes = new { url = "/systems/resource" } };
            var node8 = new TreeNode { Id = "9", ParentId = "1", Text = "图标管理", Attributes = new { url = "/commons/icon" } };
            return Content(new TreeResult( new[] { node, node1, node10, node11, node123,  node3, node4, node7, node8 } ).ToString());
        }
    }
}
