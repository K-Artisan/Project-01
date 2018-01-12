namespace Applications.Datas.Ef.MySql.Mappings.Configs {
    /// <summary>
    /// 系统配置分类映射
    /// </summary>
    public class SystemConfigCategoryMap :  Ef.Mappings.Configs.SystemConfigCategoryMap {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "[Configs.SystemConfigCategories]" );
        }
        
        /// <summary>
        /// 是否支持行版本
        /// </summary>
        protected override bool IsSupportRowVersion {
            get { return false; }
        }
    }
}