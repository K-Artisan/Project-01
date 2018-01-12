using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Applications.Domains.Security.Models {
    /// <summary>
    /// 空资源
    /// </summary>
    [NotMapped]
    public class NullResource : Resource {
        /// <summary>
        /// 初始化资源
        /// </summary>
        public NullResource()
            : base( Guid.Empty, "", 0 ) {
        }

        /// <summary>
        /// 是否空对象
        /// </summary>
        public override bool IsNull() {
            return true;
        }
    }
}
