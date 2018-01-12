using Applications.Domains.Security.Factories;
using Applications.Domains.Security.Models;
using Util;

namespace Applications.Services.Dtos.Security {
    /// <summary>
    /// 资源数据传输对象扩展
    /// </summary>
    public static class ResourceDtoExtension {
        /// <summary>
        /// 转换为资源实体
        /// </summary>
        /// <param name="dto">资源数据传输对象</param>
        public static Resource ToEntity( this ResourceDto dto ) {
            return ResourceFactory.Create(
                id: dto.Id.ToGuid(),
                path: dto.Path,
                level: dto.Level.SafeValue(),
                applicationId: dto.ApplicationId.SafeValue(),
                parentId: dto.ParentId.ToGuidOrNull(),
                uri: dto.Uri,
                name: dto.Name,
                type: dto.Type.SafeValue(),
                smallIcon: dto.SmallIcon,
                largeIcon: dto.LargeIcon,
                extend: dto.Extend,
                note: dto.Note,
                pinYin: dto.PinYin,
                enabled: dto.Enabled,
                sortId: dto.SortId.SafeValue(),
                createTime: dto.CreateTime,
                version: dto.Version
            );
        }

        /// <summary>
        /// 转换为资源数据传输对象
        /// </summary>
        /// <param name="entity">资源实体</param>
        public static ResourceDto ToDto( this Resource entity ) {
            return new ResourceDto {
                Id = entity.Id.ToString(),
                ApplicationId = entity.ApplicationId,
                ParentId = entity.ParentId.ToStr(),
                Path = entity.Path,
                Level = entity.Level,
                Uri = entity.Uri,
                Name = entity.Name,
                Type = entity.Type,
                SmallIcon = entity.SmallIcon,
                LargeIcon = entity.LargeIcon,
                Extend = entity.Extend,
                Note = entity.Note,
                PinYin = entity.PinYin,
                Enabled = entity.Enabled,
                SortId = entity.SortId,
                CreateTime = entity.CreateTime,
                Version = entity.Version,
            };
        }
    }
}
