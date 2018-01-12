namespace Applications.Datas.Ef.MySql.Mappings.Commons {
    /// <summary>
    /// 图标分类映射
    /// </summary>
    public class IconCategoryMap :  Ef.Mappings.Commons.IconCategoryMap {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "[Commons.IconCategories]" );
        }
        
        /// <summary>
        /// 是否支持行版本
        /// </summary>
        protected override bool IsSupportRowVersion {
            get { return false; }
        }
    }
}