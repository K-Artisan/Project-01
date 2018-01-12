namespace Applications.Datas.Ef.MySql.Mappings.Systems {
    /// <summary>
    /// 应用程序映射
    /// </summary>
    public class ApplicationMap :  Ef.Mappings.Systems.ApplicationMap {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "[Systems.Applications]" );
        }
        
        /// <summary>
        /// 是否支持行版本
        /// </summary>
        protected override bool IsSupportRowVersion {
            get { return false; }
        }
    }
}