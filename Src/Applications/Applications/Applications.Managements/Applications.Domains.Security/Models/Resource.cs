using Util;

namespace Applications.Domains.Security.Models {
    /// <summary>
    /// 资源
    /// </summary>
    public partial class Resource {
        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init() {
            base.Init();
            PinYin = Str.PinYin( Name );
        }
    }
}