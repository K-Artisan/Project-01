using System;
using Applications.Domains.Security.Enums;
using Applications.Domains.Security.Models;

namespace Applications.Domains.Security.Factories {
    /// <summary>
    /// 资源工厂
    /// </summary>
    public static class ResourceFactory {
        /// <summary>
        /// 创建资源
        /// </summary>
        /// <param name="id">资源标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        /// <param name="applicationId">应用程序编号</param>
        /// <param name="parentId">父编号</param>
        /// <param name="uri">资源标识</param>
        /// <param name="name">资源名称</param>
        /// <param name="type">资源类型</param>
        /// <param name="smallIcon">小图标</param>
        /// <param name="largeIcon">大图标</param>
        /// <param name="note">备注</param>
        /// <param name="pinYin">拼音简码</param>
        /// <param name="extend">扩展</param>
        /// <param name="enabled">启用</param>
        /// <param name="sortId">排序号</param>
        /// <param name="createTime">创建时间</param>
        /// <param name="version">版本号</param>
        public static Resource Create( Guid id, string path, int level, Guid applicationId,
            Guid? parentId, string uri, string name, ResourceType type, string smallIcon, 
            string largeIcon, string note, string pinYin, dynamic extend,
            bool enabled, int sortId, DateTime? createTime, byte[] version ) {
            Resource result;
            switch( type ) {
                case ResourceType.Module:
                    result = new Module( id, path, level );
                    break;
                default :
                    throw new NotImplementedException();
            }
            result.ApplicationId = applicationId;
            result.ParentId = parentId;
            result.Uri = uri;
            result.Name = name;
            result.Type = type;
            result.SmallIcon = smallIcon;
            result.LargeIcon = largeIcon;
            result.Note = note;
            result.PinYin = pinYin;
            result.Extend = Util.Json.ToJson( extend );
            result.Enabled = enabled;
            result.SortId = sortId;
            result.CreateTime = createTime;
            result.Version = version;
            return result;
        }
    }
}
