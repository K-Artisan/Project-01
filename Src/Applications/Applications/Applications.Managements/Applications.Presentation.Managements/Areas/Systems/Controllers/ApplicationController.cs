using System.Linq;
using System.Web.Mvc;
using Applications.Domains.Security.Queries;
using Applications.Services.Contracts.Security;
using Applications.Services.Dtos.Security;
using Presentation.Base;
using Util;
using Util.Webs;
using Util.Webs.EasyUi.Forms;
using Util.Webs.EasyUi.Forms.Comboxs;

namespace Presentation.Areas.Systems.Controllers {
    /// <summary>
    /// 应用程序控制器
    /// </summary>
    public class ApplicationController : GridControllerBase<ApplicationDto, ApplicationQuery> {
        /// <summary>
        /// 初始化应用程序控制器
        /// </summary>
        /// <param name="service">应用程序服务</param>
        public ApplicationController( IApplicationService service )
            : base( service ) {
                Service = service;
        }

        /// <summary>
        /// 应用程序服务
        /// </summary>
        public new IApplicationService Service { get; set; }

        /// <summary>
        /// 应用程序控件
        /// </summary>
        [AjaxOnly]
        public ActionResult ApplicationsControl() {
            var applications = Service.GetAll();
            return ToComboxResult( applications.Select( t => new ComboxItem( t.Name, t.Id ) ) );
        }

        /// <summary>
        /// 导出
        /// </summary>
        public void Export() {
            Service.Export();
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">Id列表</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormExceptionHandler]
        [AjaxOnly]
        public ActionResult Enable( string ids ) {
            Service.Enable( ids.ToGuidList() );
            return Ok( "启用成功" );
        }

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="ids">Id列表</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormExceptionHandler]
        [AjaxOnly]
        public ActionResult Disable( string ids ) {
            Service.Disable( ids.ToGuidList() );
            return Ok( "禁用成功" );
        }
    }
}
