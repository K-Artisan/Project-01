namespace Applications.Domains.Configs.Models {
    /// <summary>
    /// 系统配置
    /// </summary>
    public partial class SystemConfig {
        /// <summary>
        /// 获取系统配置分类
        /// </summary>
        public SystemConfigCategory GetCategory() {
            if ( SystemConfigCategory == null )
                return new SystemConfigCategory();
            return SystemConfigCategory;
        }
    }
}