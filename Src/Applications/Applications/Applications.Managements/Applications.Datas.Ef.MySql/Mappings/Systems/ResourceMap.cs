namespace Applications.Datas.Ef.MySql.Mappings.Systems {
    /// <summary>
    /// 资源映射
    /// </summary>
    public class ResourceMap :  Ef.Mappings.Systems.ResourceMap {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "[Systems.Resources]" );
        }
        
        /// <summary>
        /// 是否支持行版本
        /// </summary>
        protected override bool IsSupportRowVersion {
            get { return false; }
        }
    }
}