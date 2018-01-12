using System;
using Applications.Services.Dtos.Commons;
using Util.Domains.Repositories;

namespace Presentation.Areas.Commons.Models {
    /// <summary>
    /// 图标集合视图实体
    /// </summary>
    public class IconListViewModel {
        /// <summary>
        /// 初始化图标集合视图实体
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="categoryId">分类编号</param>
        /// <param name="icons">图标分页集合</param>
        public IconListViewModel( int? width, int? height, Guid? categoryId, PagerList<IconDto> icons ) {
            Width = width;
            Height = height;
            CategoryId = categoryId;
            Icons = icons;
        }

        /// <summary>
        /// 宽度
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// 图标分页集合
        /// </summary>
        public PagerList<IconDto> Icons { get; set; }
    }
}