using System;
using Util;

namespace Applications.Domains.Security.Models {
    /// <summary>
    /// 模块
    /// </summary>
    public class Module : Resource{
        /// <summary>
        /// 初始化模块
        /// </summary>
        public Module()
            : this( Guid.Empty, "", 0 ) {
        }

        /// <summary>
        /// 初始化模块
        /// </summary>
        /// <param name="id">模块标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        public Module( Guid id, string path, int level )
            : base( id, path,level ) {
        }

        /// <summary>
        /// 获取Url
        /// </summary>
        public string GetUrl() {
            if ( Uri.IsEmpty() )
                return string.Empty;
            Uri = Uri.Replace( "\\", "/" ).TrimStart( '~' );
            return Uri.StartsWith( "/" ) ? Uri : string.Empty;
        }
    }
}
