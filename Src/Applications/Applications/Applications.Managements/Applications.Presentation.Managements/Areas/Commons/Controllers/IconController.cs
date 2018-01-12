using System.Web.Mvc;
using Applications.Domains.Commons.Queries;
using Applications.Services.Contracts.Commons;
using Applications.Services.Dtos.Commons;
using Presentation.Base;
using Util;
using Util.Webs;
using Util.Webs.EasyUi.Forms;

namespace Presentation.Areas.Commons.Controllers {
    /// <summary>
    /// 图标控制器 - 图标管理
    /// </summary>
    public partial class IconController : FormControllerBase<IconDto, IconQuery> {
        /// <summary>
        /// 初始化图标控制器
        /// </summary>
        /// <param name="categoryService">图标分类服务</param>
        /// <param name="iconService">图标服务</param>
        public IconController( IIconCategoryService categoryService, IIconService iconService )
            : base( iconService ) {
            CategoryService = categoryService;
            IconService = iconService;
        }

        /// <summary>
        /// 图标分类服务
        /// </summary>
        public IIconCategoryService CategoryService { get; set; }

        /// <summary>
        /// 图标服务
        /// </summary>
        public IIconService IconService { get; set; }

        /// <summary>
        /// 获取主界面
        /// </summary>
        public override ActionResult Index() {
            return View( IconService.Create() );
        }

        /// <summary>
        /// 获取图标面板
        /// </summary>
        /// <param name="categoryId">图标分类编号</param>
        [AjaxOnly]
        public PartialViewResult IconPanel( string categoryId ) {
            return PartialView( "Parts/Icon", CreateIconDto( categoryId ) );
        }

        /// <summary>
        /// 创建图标dto
        /// </summary>
        private IconDto CreateIconDto( string categoryId ) {
            var icon = new IconDto { CategoryId = categoryId.ToGuidOrNull() };
            icon.CategoryName = CategoryService.Get( icon.CategoryId ).Name;
            return icon;
        }

        /// <summary>
        /// 获取批量上传窗口
        /// </summary>
        /// <param name="categoryId">图标分类编号</param>
        [AjaxOnly]
        public PartialViewResult BatchAdd( string categoryId ) {
            return PartialView( "Parts/Icon.Form", CreateIconDto( categoryId ) );
        }

        /// <summary>
        /// 上传图标
        /// </summary>
        /// <param name="categoryId">图标分类编号</param>
        [HttpPost]
        [FormExceptionHandler]
        public ActionResult Upload( string categoryId ) {
            IconService.Upload( categoryId );
            return Ok();
        }

        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id">实体编号</param>
        public override PartialViewResult Detail( string id ) {
            return PartialView( "Parts/Icon.Detail", IconService.Get( id ) );
        }
    }
}