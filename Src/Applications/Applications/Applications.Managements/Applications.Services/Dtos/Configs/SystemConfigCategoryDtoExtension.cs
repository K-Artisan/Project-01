using Applications.Domains.Configs.Models;
using Util;

namespace Applications.Services.Dtos.Configs {
    /// <summary>
    /// 系统配置分类数据传输对象扩展
    /// </summary>
    public static class SystemConfigCategoryDtoExtension {
        /// <summary>
        /// 转换为系统配置分类实体
        /// </summary>
        /// <param name="dto">系统配置分类数据传输对象</param>
        public static SystemConfigCategory ToEntity( this SystemConfigCategoryDto dto ) {
            return new SystemConfigCategory( dto.Id.ToGuid() ) {
                Name = dto.Name,
                CreateTime = dto.CreateTime,
                SortId = dto.SortId.SafeValue(),
                Version = dto.Version,
            };
        }

        /// <summary>
        /// 转换为系统配置分类数据传输对象
        /// </summary>
        /// <param name="entity">系统配置分类实体</param>
        public static SystemConfigCategoryDto ToDto( this SystemConfigCategory entity ) {
            return new SystemConfigCategoryDto {
                Id = entity.Id.ToString(),
                Name = entity.Name,
                CreateTime = entity.CreateTime,
                SortId = entity.SortId,
                Version = entity.Version,
            };
        }
    }
}
