using System.ComponentModel.DataAnnotations.Schema;

namespace Applications.Domains.Core.Models {
    /// <summary>
    /// 空地址
    /// </summary>
    [NotMapped]
    public class NullAddress : Address{
        /// <summary>
        /// 是否空对象
        /// </summary>
        public override bool IsNull() {
            return true;
        }
    }
}
