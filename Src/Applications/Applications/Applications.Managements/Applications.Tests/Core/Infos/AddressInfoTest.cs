using System;
using Applications.Domains.Core.Infos;
using Applications.Domains.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace Applications.Tests.Core.Infos {
    /// <summary>
    /// 地址信息测试
    /// </summary>
    [TestClass]
    public class AddressInfoTest {
        /// <summary>
        /// 省份编号
        /// </summary>
        public static readonly Guid? ProvinceId = "0067960c-ea2d-4d44-ac96-890d1c62ae1a".ToGuid();
        /// <summary>
        /// 城市编号
        /// </summary>
        public static readonly Guid? CityId = "60ffd3d1-5215-4a9a-bb40-79514e316dcc".ToGuid();
        /// <summary>
        /// 区县编号
        /// </summary>
        public static readonly Guid? CountyId = "420124f2-bfc1-44c0-89fd-043133c6663a".ToGuid();

        /// <summary>
        /// 加载地址
        /// </summary>
        [TestMethod]
        public void TestLoadAddress() {
            Address address = new Address(ProvinceId,CityId,CountyId, "四川省", "成都市", "金牛区", "二环路北二段15号", "221000" );
            AddressInfo result = address.ToInfo();
            Assert.AreEqual( ProvinceId, result.ProvinceId.ToGuid() );
            Assert.AreEqual( CityId, result.CityId.ToGuid() );
            Assert.AreEqual( CountyId, result.CountyId.ToGuid() );
            Assert.AreEqual( "四川省", result.Province );
            Assert.AreEqual( "成都市", result.City );
            Assert.AreEqual( "金牛区", result.County );
            Assert.AreEqual( "二环路北二段15号", result.Street );
            Assert.AreEqual( "221000", result.Zip );
            Console.WriteLine( result );
        }

        /// <summary>
        /// 转换为地址
        /// </summary>
        [TestMethod]
        public void TestToAddress() {
            var address = new AddressInfo {
                ProvinceId = ProvinceId.ToStr(),
                CityId = CityId.ToStr(),
                CountyId = CountyId.ToStr(),
                Province = "四川省",
                City = "成都市",
                County = "金牛区",
                Street = "二环路北二段15号",
                Zip = "221000"
            };
            Address result = address.ToAddress();
            Assert.AreEqual( ProvinceId, result.ProvinceId );
            Assert.AreEqual( CityId, result.CityId );
            Assert.AreEqual( CountyId, result.CountyId );
            Assert.AreEqual( "四川省",result.Province );
            Assert.AreEqual( "成都市", result.City );
            Assert.AreEqual( "金牛区", result.County );
            Assert.AreEqual( "二环路北二段15号", result.Street );
            Assert.AreEqual( "221000", result.Zip );
            Assert.AreEqual( "四川省成都市金牛区二环路北二段15号", result.Description );
            Console.WriteLine( result );
        }
    }
}
