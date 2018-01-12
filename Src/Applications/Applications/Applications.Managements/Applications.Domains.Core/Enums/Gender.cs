using System.ComponentModel;
using Util;

namespace Applications.Domains.Core.Enums {
    /// <summary>
    /// 性别
    /// </summary>
    public enum Gender {
        /// <summary>
        /// 女
        /// </summary>        
        [Description( "女士" )]
        Female = 0,
        /// <summary>
        /// 男
        /// </summary>
        [Description( "先生" )]
        Male = 1
    }

    /// <summary>
    /// 性别枚举扩展
    /// </summary>
    public static class GenderExtensions {
        /// <summary>
        /// 获取描述
        /// </summary>
        public static string Description( this Gender? gender ) {
            return gender == null ? string.Empty : gender.Value.Description();
        }

        /// <summary>
        /// 获取值
        /// </summary>
        public static int? Value( this Gender? gender ) {
            if ( gender == null )
                return null;
            return gender.Value.Value();
        }
    }
}
