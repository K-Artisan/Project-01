using System;
using Applications.Domains.Commons.Models;

namespace Applications.Services.Dtos.Commons {
    /// <summary>
    /// 图标数据传输对象扩展
    /// </summary>
    public static class IconDtoExtension {
        /// <summary>
        /// 转换为图标实体
        /// </summary>
        /// <param name="dto">图标数据传输对象</param>
        public static Icon ToEntity( this IconDto dto ) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 转换为图标数据传输对象
        /// </summary>
        /// <param name="entity">图标实体</param>
        public static IconDto ToDto( this Icon entity ) {
            return new IconDto {
                Id = entity.Id.ToString(),
                CategoryId = entity.CategoryId,
                CategoryName = entity.GetCategory().Name,
                TenantId = entity.TenantId,
                Icon = entity.Path,
                Name = entity.Name,
                Path = entity.Path,
                ClassName = entity.ClassName,
                Size = entity.GetSize().ToString(),
                Width = entity.Width,
                Height = entity.Height,
                Css = entity.Css,
                CreateTime = entity.CreateTime,
                Version = entity.Version,
            };
        }
    }
}
