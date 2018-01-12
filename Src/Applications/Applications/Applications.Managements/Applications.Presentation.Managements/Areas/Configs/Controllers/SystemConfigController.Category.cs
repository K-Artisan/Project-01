using System.Linq;
using System.Web.Mvc;
using Applications.Services.Dtos.Configs;
using Util;
using Util.Webs;
using Util.Webs.EasyUi.Forms;
using Util.Webs.EasyUi.Trees;

namespace Presentation.Areas.Configs.Controllers {
    /// <summary>
    /// 系统配置控制器 - 分类
    /// </summary>
    public partial class SystemConfigController {
        /// <summary>
        /// 获取分类
        /// </summary>
        [AjaxOnly]
        public ActionResult GetCategories() {
            var dtos = CategoryService.GetAll();
            return ToTreeResult( dtos.Select( t => new TreeNode { Id = t.Id, Text = t.Name } ), "系统配置分类" );
        }

        /// <summary>
        /// 获取新增分类表单
        /// </summary>
        [AjaxOnly]
        public PartialViewResult AddCategory() {
            return PartialView( "Parts/Categories.Form", CategoryService.Create() );
        }

        /// <summary>
        /// 获取更新分类表单
        /// </summary>
        [AjaxOnly]
        public PartialViewResult EditCategory( string id ) {
            return PartialView( "Parts/Categories.Form", CategoryService.Get( id ) );
        }

        /// <summary>
        /// 保存分类
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormExceptionHandler]
        [AjaxOnly]
        public ActionResult SaveCategory( SystemConfigCategoryDto dto ) {
            CategoryService.Save( dto );
            return Ok( R.SaveSuccess );
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormExceptionHandler]
        [AjaxOnly]
        public virtual ActionResult DeleteCategories( string ids ) {
            CategoryService.Delete( ids );
            return Ok( R.DeleteSuccess );
        }
    }
}