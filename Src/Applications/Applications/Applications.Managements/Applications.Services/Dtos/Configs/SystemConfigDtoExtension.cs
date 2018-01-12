using Applications.Domains.Configs.Models;
using Util;

namespace Applications.Services.Dtos.Configs {
    /// <summary>
    /// 系统配置数据传输对象扩展
    /// </summary>
    public static class SystemConfigDtoExtension {
        /// <summary>
        /// 转换为系统配置实体
        /// </summary>
        /// <param name="dto">系统配置数据传输对象</param>
        public static SystemConfig ToEntity( this SystemConfigDto dto ) {
            return new SystemConfig( dto.Id.ToGuid() ) {
                CategoryId = dto.CategoryId,
                Code = dto.Code,
                Value = dto.Value,
                Description = dto.Description,
                CreateTime = dto.CreateTime,
                Version = dto.Version,
            };
        }

        /// <summary>
        /// 转换为系统配置数据传输对象
        /// </summary>
        /// <param name="entity">系统配置实体</param>
        public static SystemConfigDto ToDto( this SystemConfig entity ) {
            return new SystemConfigDto {
                Id = entity.Id.ToString(),
                CategoryId = entity.CategoryId,
                CategoryName = entity.GetCategory().Name,
                Code = entity.Code,
                Value = entity.Value,
                Description = entity.Description,
                CreateTime = entity.CreateTime,
                Version = entity.Version,
            };
        }
    }
}
