using Applications.Domains.Security.Models;
using Util.Datas.Ef;

namespace Applications.Datas.Ef.Mappings.Systems {
    /// <summary>
    /// 应用程序映射
    /// </summary>
    public class ApplicationMap : AggregateMapBase<Application> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable() {
            ToTable( "Applications", "Systems" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties() {
            //映射基类属性
            base.MapProperties();
            //应用程序编号
            Property( t => t.Id )
                .HasColumnName( "ApplicationId" );
            //应用程序编码
            Property( t => t.Code )
                .HasColumnName( "Code" );
            //应用程序名称
            Property( t => t.Name )
                .HasColumnName( "Name" );
            //备注
            Property( t => t.Note )
                .HasColumnName( "Note" );
            //启用
            Property( t => t.Enabled )
                .HasColumnName( "Enabled" );
            //创建时间
            Property( t => t.CreateTime )
                .HasColumnName( "CreateTime" );
        }

        /// <summary>
        /// 映射导航属性
        /// </summary>
        protected override void MapAssociations() {
        }
    }
}