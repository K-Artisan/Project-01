namespace Applications.Datas.Ef.MySql.Mappings.Commons {
    /// <summary>
    /// 字典映射
    /// </summary>
    public class DicMap :  Ef.Mappings.Commons.DicMap {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "[Commons.Dics]" );
        }
        
        /// <summary>
        /// 是否支持行版本
        /// </summary>
        protected override bool IsSupportRowVersion {
            get { return false; }
        }
    }
}