using Applications.Domains.Core.Models;
using Util;

namespace Applications.Domains.Core.Infos {
    /// <summary>
    /// 地址信息扩展
    /// </summary>
    public static class AddressInfoExtension {
        /// <summary>
        /// 转换为地址
        /// </summary>
        public static Address ToAddress( this AddressInfo info ) {
            return new Address( info.ProvinceId.ToGuidOrNull(), info.CityId.ToGuidOrNull(), info.CountyId.ToGuidOrNull(), info.Province, info.City, info.County, info.Street, info.Zip );
        }

        /// <summary>
        /// 转换为地址信息
        /// </summary>
        /// <param name="address">地址</param>
        public static AddressInfo ToInfo( this Address address ) {
            return new AddressInfo {
                ProvinceId = address.ProvinceId.ToStr(),
                CityId = address.CityId.ToStr(),
                CountyId = address.CountyId.ToStr(),
                Province = address.Province,
                City = address.City,
                County = address.County,
                Street = address.Street,
                Zip = address.Zip,
                Description = address.Description
            };
        }
    }
}
