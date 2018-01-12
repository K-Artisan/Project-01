using System;

namespace Applications.Domains.Security.Models {
    /// <summary>
    /// 操作
    /// </summary>
    public class Operation : Resource {
        /// <summary>
        /// 初始化操作
        /// </summary>
        public Operation()
            : this( Guid.Empty, "", 0 ) {
        }

        /// <summary>
        /// 初始化操作
        /// </summary>
        /// <param name="id">操作标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        public Operation( Guid id, string path, int level )
            : base( id, path, level ) {
        }
    }
}
