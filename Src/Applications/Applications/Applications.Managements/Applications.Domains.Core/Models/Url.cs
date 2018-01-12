using System.ComponentModel.DataAnnotations;
using Util.Domains;

namespace Applications.Domains.Core.Models {
    /// <summary>
    /// Url
    /// </summary>
    public class Url : ValueObjectBase<Url> {
        /// <summary>
        /// 初始化Url
        /// </summary>
        /// <param name="url">Url</param>
        public Url( string url ) {
            Value = url;
        }

        /// <summary>
        /// Url值
        /// </summary>
        [Url]
        public string Value { get; private set; }
    }
}
