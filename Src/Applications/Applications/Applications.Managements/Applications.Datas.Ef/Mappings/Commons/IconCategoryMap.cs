using Applications.Domains.Commons.Models;
using Util.Datas.Ef;

namespace Applications.Datas.Ef.Mappings.Commons {
    /// <summary>
    /// 图标分类映射
    /// </summary>
    public class IconCategoryMap : AggregateMapBase<IconCategory> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "IconCategories", "Commons" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties() {
            //映射基类属性
            base.MapProperties();
            //图标分类编号
            Property(t => t.Id)
                .HasColumnName("CategoryId");
            //租户编号
            Property(t => t.TenantId)
                .HasColumnName("TenantId");
            //分类名称
            Property(t => t.Name)
                .HasColumnName("Name");
            //创建时间
            Property(t => t.CreateTime)
                .HasColumnName("CreateTime");
            //排序号
            Property( t => t.SortId )
                .HasColumnName( "SortId" );
        }
        
        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected override void MapAssociations() {            
        }
    }
}

