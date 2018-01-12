using Applications.Domains.Commons.Models;
using Util;

namespace Applications.Services.Dtos.Commons {
    /// <summary>
    /// 图标分类数据传输对象扩展
    /// </summary>
    public static class IconCategoryDtoExtension {
        /// <summary>
        /// 转换为图标分类实体
        /// </summary>
        /// <param name="dto">图标分类数据传输对象</param>
        public static IconCategory ToEntity( this IconCategoryDto dto ) {
            return new IconCategory( dto.Id.ToGuid() ) {
                TenantId = dto.TenantId,
                Name = dto.Name,
                CreateTime = dto.CreateTime,
                SortId = dto.SortId,
                Version = dto.Version,
            };
        }

        /// <summary>
        /// 转换为图标分类数据传输对象
        /// </summary>
        /// <param name="entity">图标分类实体</param>
        public static IconCategoryDto ToDto( this IconCategory entity ) {
            return new IconCategoryDto {
                Id = entity.Id.ToString(),
                TenantId = entity.TenantId,
                Name = entity.Name,
                CreateTime = entity.CreateTime,
                SortId = entity.SortId,
                Version = entity.Version,
            };
        }
    }
}
