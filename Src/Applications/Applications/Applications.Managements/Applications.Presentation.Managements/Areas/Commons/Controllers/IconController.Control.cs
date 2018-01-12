using System;
using System.Web.Mvc;
using Applications.Domains.Commons.Queries;
using Presentation.Areas.Commons.Models;
using Util.Webs;

namespace Presentation.Areas.Commons.Controllers {
    /// <summary>
    /// 图标控制器 - 图标选择控件
    /// </summary>
    public partial class IconController {
        /// <summary>
        /// 选择图标控件
        /// </summary>
        [AjaxOnly]
        public PartialViewResult IconsControl() {
            return PartialView( CategoryService.GetAll() );
        }

        /// <summary>
        /// 获取图标尺寸选项卡
        /// </summary>
        /// <param name="categoryId">图标分类编号</param>
        [AjaxOnly]
        public PartialViewResult GetSizeTabs( Guid? categoryId ) {
            var query = new IconQuery { PageSize = 100, CategoryId = categoryId, Width = 16, Height = 16 };
            return PartialView( "IconsControl/SizeTabs", CreateIconListViewModel( query ) );
        }

        /// <summary>
        /// 创建图标集合视图实体
        /// </summary>
        private IconListViewModel CreateIconListViewModel( IconQuery query ) {
            return new IconListViewModel( query.Width, query.Height, query.CategoryId, IconService.Query( query ) );
        }

        /// <summary>
        /// 获取图标控件选项卡面板
        /// </summary>
        /// <param name="query">图标查询实体</param>
        [AjaxOnly]
        public PartialViewResult GetIconTab( IconQuery query ) {
            SetPage( query );
            return PartialView( "IconsControl/Tab", CreateIconListViewModel( query ) );
        }
    }
}