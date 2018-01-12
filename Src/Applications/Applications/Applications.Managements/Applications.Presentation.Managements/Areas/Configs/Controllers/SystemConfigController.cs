using System.Web.Mvc;
using Applications.Domains.Configs.Queries;
using Applications.Services.Contracts.Configs;
using Applications.Services.Dtos.Configs;
using Presentation.Base;
using Util;
using Util.Webs;

namespace Presentation.Areas.Configs.Controllers {
    /// <summary>
    /// 系统配置控制器
    /// </summary>
    public partial class SystemConfigController : GridControllerBase<SystemConfigDto, SystemConfigQuery> {
        /// <summary>
        /// 初始化系统配置控制器
        /// </summary>
        /// <param name="categoryService">系统配置分类服务</param>
        /// <param name="configService">系统配置服务</param>
        public SystemConfigController( ISystemConfigCategoryService categoryService, ISystemConfigService configService )
            : base( configService ) {
            CategoryService = categoryService;
            ConfigService = configService;
        }

        /// <summary>
        /// 系统配置分类服务
        /// </summary>
        public ISystemConfigCategoryService CategoryService { get; set; }

        /// <summary>
        /// 系统配置服务
        /// </summary>
        public ISystemConfigService ConfigService { get; private set; }

        /// <summary>
        /// 获取主界面
        /// </summary>
        public override ActionResult Index() {
            return View( ConfigService.Create() );
        }

        /// <summary>
        /// 获取配置面板
        /// </summary>
        /// <param name="categoryId">分类编号</param>
        [AjaxOnly]
        public PartialViewResult ConfigPanel( string categoryId ) {
            return PartialView( "Parts/Config", CreateConfigDto( categoryId ) );
        }

        /// <summary>
        /// 创建配置dto
        /// </summary>
        private SystemConfigDto CreateConfigDto( string categoryId ) {
            var icon = new SystemConfigDto { CategoryId = categoryId.ToGuidOrNull() };
            icon.CategoryName = CategoryService.Get( icon.CategoryId ).Name;
            return icon;
        }
    }
}