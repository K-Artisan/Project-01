using Applications.Domains.Commons.Models;
using Util.Datas.Ef;

namespace Applications.Datas.Ef.Mappings.Commons {
    /// <summary>
    /// 图标映射
    /// </summary>
    public class IconMap : AggregateMapBase<Icon> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "Icons", "Commons" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties() {
            //映射基类属性
            base.MapProperties();
            //图标编号
            Property(t => t.Id)
                .HasColumnName("IconId");
            //图标分类编号
            Property(t => t.CategoryId)
                .HasColumnName("CategoryId");
            //租户编号
            Property(t => t.TenantId)
                .HasColumnName("TenantId");
            //图标名称
            Property(t => t.Name)
                .HasColumnName("Name");
            //图标路径
            Property(t => t.Path)
                .HasColumnName("Path");
            //类名
            Property(t => t.ClassName)
                .HasColumnName("ClassName");
            //图标大小
            Property(t => t.Size)
                .HasColumnName("Size");
            //宽度
            Property(t => t.Width)
                .HasColumnName("Width");
            //高度
            Property(t => t.Height)
                .HasColumnName("Height");
            //Css代码
            Property(t => t.Css)
                .HasColumnName("Css");
            //创建时间
            Property(t => t.CreateTime)
                .HasColumnName("CreateTime");
        }
        
        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected override void MapAssociations() {            
            //图标分类
            HasOptional(t => t.IconCategory)
                .WithMany()
                .HasForeignKey(d => d.CategoryId);
        }
    }
}

