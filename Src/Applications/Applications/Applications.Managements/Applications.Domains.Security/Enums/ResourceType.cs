using System.ComponentModel;
using Util;

namespace Applications.Domains.Security.Enums {
    /// <summary>
    /// 资源类型
    /// </summary>
    public enum ResourceType {
        /// <summary>
        /// 模块(菜单)
        /// </summary>
        [Description( "模块(菜单)" )]
        Module = 1
    }

    /// <summary>
    /// 资源类型枚举扩展
    /// </summary>
    public static class ResourceTypeExtensions {
        /// <summary>
        /// 获取描述
        /// </summary>
        public static string Description( this ResourceType? type ) {
            return type == null ? string.Empty : type.Value.Description();
        }

        /// <summary>
        /// 获取值
        /// </summary>
        public static int? Value( this ResourceType? type ) {
            if ( type == null )
                return null;
            return type.Value.Value();
        }
    }
}
