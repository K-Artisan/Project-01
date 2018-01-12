namespace Applications.Datas.Ef.MySql.Mappings.Configs {
    /// <summary>
    /// 系统配置映射
    /// </summary>
    public class SystemConfigMap :  Ef.Mappings.Configs.SystemConfigMap {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "[Configs.SystemConfigs]" );
        }
        
        /// <summary>
        /// 是否支持行版本
        /// </summary>
        protected override bool IsSupportRowVersion {
            get { return false; }
        }
    }
}