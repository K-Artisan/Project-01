using Applications.Domains.Security.Models;
using Util.Datas.Ef;

namespace Applications.Datas.Ef.Mappings.Systems {
    /// <summary>
    /// 资源映射
    /// </summary>
    public class ResourceMap : AggregateMapBase<Resource> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "Resources", "Systems" );
            Map<Module>( t => t.Requires( "Discriminator" ).HasValue( "Module" ) );
            Map<Operation>( t => t.Requires( "Discriminator" ).HasValue( "Operation" ) );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties() {
            //映射基类属性
            base.MapProperties();
            //资源编号
            Property( t => t.Id )
                .HasColumnName( "ResourceId" );
            //应用程序编号
            Property( t => t.ApplicationId )
                .HasColumnName( "ApplicationId" );
            //父编号
            Property( t => t.ParentId )
                .HasColumnName( "ParentId" );
            //路径
            Property( t => t.Path )
                .HasColumnName( "Path" );
            //级数
            Property( t => t.Level )
                .HasColumnName( "Level" );
            //资源标识
            Property( t => t.Uri )
                .HasColumnName( "Uri" );
            //资源名称
            Property( t => t.Name )
                .HasColumnName( "Name" );
            //资源类型
            Property( t => t.Type )
                .HasColumnName( "Type" );
            //小图标
            Property( t => t.SmallIcon )
                .HasColumnName( "SmallIcon" );
            //大图标
            Property( t => t.LargeIcon )
                .HasColumnName( "LargeIcon" );
            //扩展
            Property( t => t.Extend )
                .HasColumnName( "Extend" );
            //备注
            Property( t => t.Note )
                .HasColumnName( "Note" );
            //拼音简码
            Property( t => t.PinYin )
                .HasColumnName( "PinYin" );
            //启用
            Property( t => t.Enabled )
                .HasColumnName( "Enabled" );
            //排序号
            Property( t => t.SortId )
                .HasColumnName( "SortId" );
            //创建时间
            Property( t => t.CreateTime )
                .HasColumnName( "CreateTime" );
        }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected override void MapAssociations() {
            //应用程序
            HasRequired( t => t.Application )
                .WithMany()
                .HasForeignKey( d => d.ApplicationId );
        }
    }
}

