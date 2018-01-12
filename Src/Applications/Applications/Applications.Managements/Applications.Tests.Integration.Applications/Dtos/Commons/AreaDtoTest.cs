using System;
using System.Collections.Generic;
using Applications.Services.Dtos.Commons;
using Applications.Tests.Commons.Models.Areas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace Applications.Tests.Integration.Dtos.Commons {
    /// <summary>
    /// 地区数据传输对象测试
    /// </summary>
    [TestClass]
    public class AreaDtoTest {
        /// <summary>
        /// 创建地区数据传输对象
        /// </summary>
        public static AreaDto Create() {
            return AreaTest.Create().ToDto(); 
        }
        
        /// <summary>
        /// 创建地区数据传输对象2
        /// </summary>
        /// <param name="id">地区编号</param>
        public static AreaDto Create2( Guid id ) {
            return AreaTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建地区数据传输对象列表
        /// </summary>
        public static List<AreaDto> CreateList() {
            return new List<AreaDto>() {
                Create(),
                Create2( AreaTest.Id2 )
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        [TestMethod]
        public void TestToDto() {
            var dto = Create();
            Assert.AreEqual( AreaTest.Id.ToString(),dto.Id,"Id" );
            Assert.AreEqual( AreaTest.ParentId,dto.ParentId.ToGuid(),"ParentId" );
            Assert.AreEqual( AreaTest.Code,dto.Code,"Code" );
            Assert.AreEqual( AreaTest.Text,dto.Text,"Text" );
            Assert.AreEqual( AreaTest.Path,dto.Path,"Path" );
            Assert.AreEqual( AreaTest.Level,dto.Level,"Level" );
            Assert.AreEqual( AreaTest.SortId,dto.SortId,"SortId" );
            Assert.AreEqual( AreaTest.PinYin,dto.PinYin,"PinYin" );
            Assert.AreEqual( AreaTest.FullPinYin,dto.FullPinYin,"FullPinYin" );
            Assert.AreEqual( AreaTest.Enabled,dto.Enabled,"Enabled" );
            Assert.AreEqual( AreaTest.CreateTime,dto.CreateTime,"CreateTime" );
            Assert.AreEqual( AreaTest.Version,dto.Version,"Version" );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [TestMethod]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.AreEqual( AreaTest.Id,entity.Id,"Id" );
            Assert.AreEqual( AreaTest.ParentId,entity.ParentId,"ParentId" );
            Assert.AreEqual( AreaTest.Code,entity.Code,"Code" );
            Assert.AreEqual( AreaTest.Text,entity.Text,"Text" );
            Assert.AreEqual( AreaTest.Path,entity.Path,"Path" );
            Assert.AreEqual( AreaTest.Level,entity.Level,"Level" );
            Assert.AreEqual( AreaTest.SortId,entity.SortId,"SortId" );
            Assert.AreEqual( AreaTest.PinYin,entity.PinYin,"PinYin" );
            Assert.AreEqual( AreaTest.FullPinYin,entity.FullPinYin,"FullPinYin" );
            Assert.AreEqual( AreaTest.Enabled,entity.Enabled,"Enabled" );
            Assert.AreEqual( AreaTest.CreateTime,entity.CreateTime,"CreateTime" );
            Assert.AreEqual( AreaTest.Version,entity.Version,"Version" );
        }
    }
}
