using Applications.Domains.Configs.Models;
using Util.Datas.Ef;

namespace Applications.Datas.Ef.Mappings.Configs {
    /// <summary>
    /// 系统配置映射
    /// </summary>
    public class SystemConfigMap : AggregateMapBase<SystemConfig> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "SystemConfigs", "Configs" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties() {
            //映射基类属性
            base.MapProperties();
            //配置编号
            Property(t => t.Id)
                .HasColumnName("ConfigId");
            //配置分类编号
            Property(t => t.CategoryId)
                .HasColumnName("CategoryId");
            //编码
            Property(t => t.Code)
                .HasColumnName("Code");
            //值
            Property(t => t.Value)
                .HasColumnName("Value");
            //描述
            Property(t => t.Description)
                .HasColumnName("Description");
            //创建时间
            Property(t => t.CreateTime)
                .HasColumnName("CreateTime");
        }
        
        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected override void MapAssociations() {            
            //系统配置分类
            HasOptional(t => t.SystemConfigCategory)
                .WithMany()
                .HasForeignKey(d => d.CategoryId);
        }
    }
}

