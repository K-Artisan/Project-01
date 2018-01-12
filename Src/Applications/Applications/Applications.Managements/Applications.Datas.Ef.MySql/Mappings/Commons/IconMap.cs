namespace Applications.Datas.Ef.MySql.Mappings.Commons {
    /// <summary>
    /// 图标映射
    /// </summary>
    public class IconMap :  Ef.Mappings.Commons.IconMap {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "[Commons.Icons]" );
        }
        
        /// <summary>
        /// 是否支持行版本
        /// </summary>
        protected override bool IsSupportRowVersion {
            get { return false; }
        }
    }
}