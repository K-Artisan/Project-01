namespace Applications.Datas.Ef.MySql.Mappings.Commons {
    /// <summary>
    /// 映射
    /// </summary>
    public class AreaMap :  Ef.Mappings.Commons.AreaMap {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "[Commons.Areas]" );
        }
        
        /// <summary>
        /// 是否支持行版本
        /// </summary>
        protected override bool IsSupportRowVersion {
            get { return false; }
        }
    }
}