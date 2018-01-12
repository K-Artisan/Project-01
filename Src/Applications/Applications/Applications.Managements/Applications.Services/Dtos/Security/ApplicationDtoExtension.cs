﻿using Applications.Domains.Security.Models;
using Util;

namespace Applications.Services.Dtos.Security {
    /// <summary>
    /// 应用程序数据传输对象扩展
    /// </summary>
    public static class ApplicationDtoExtension {
        /// <summary>
        /// 转换为应用程序实体
        /// </summary>
        /// <param name="dto">应用程序数据传输对象</param>
        public static Application ToEntity( this ApplicationDto dto ) {
            return new Application( dto.Id.ToGuid() ) {
                Code = dto.Code,
                Name = dto.Name,
                Note = dto.Note,
                Enabled = dto.Enabled,
                CreateTime = dto.CreateTime,
                Version = dto.Version,
            };
        }

        /// <summary>
        /// 转换为应用程序数据传输对象
        /// </summary>
        /// <param name="entity">应用程序实体</param>
        public static ApplicationDto ToDto( this Application entity ) {
            return new ApplicationDto {
                Id = entity.Id.ToString(),
                Code = entity.Code,
                Name = entity.Name,
                Note = entity.Note,
                Enabled = entity.Enabled,
                CreateTime = entity.CreateTime,
                Version = entity.Version,
            };
        }
    }
}
