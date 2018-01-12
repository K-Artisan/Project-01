using Applications.Domains.Core.Models;
using Util.Datas.Ef;

namespace Applications.Datas.Ef.Mappings {
    /// <summary>
    /// 地址映射
    /// </summary>
    public class AddressMap : ValueObjectMapBase<Address> {
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties() {
            //省份编号
            Property( t => t.ProvinceId )
                .HasColumnName( "ProvinceId" );
            //省份
            Property( t => t.Province )
                .HasColumnName( "Province" );
            //城市编号
            Property( t => t.CityId )
                .HasColumnName( "CityId" );
            //城市
            Property( t => t.City )
                .HasColumnName( "City" );
            //区县编号
            Property( t => t.CountyId )
                .HasColumnName( "CountyId" );
            //区县
            Property( t => t.County )
                .HasColumnName( "County" );
            //街道
            Property( t => t.Street )
                .HasColumnName( "Street" );
            //邮政编码
            Property( t => t.Zip )
                .HasColumnName( "Zip" );
        }
    }
}
