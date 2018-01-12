using System;
using System.Collections.Generic;
using Applications.Services.Dtos.Configs;
using Applications.Tests.Commons.Models.SystemConfigs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Integration.Dtos.Commons {
    /// <summary>
    /// 系统配置数据传输对象测试
    /// </summary>
    [TestClass]
    public class SystemConfigDtoTest {
        /// <summary>
        /// 创建系统配置数据传输对象
        /// </summary>
        public static SystemConfigDto Create() {
            return SystemConfigTest.Create().ToDto(); 
        }
        
        /// <summary>
        /// 创建系统配置数据传输对象2
        /// </summary>
        /// <param name="id">系统配置编号</param>
        public static SystemConfigDto Create2( Guid id ) {
            return SystemConfigTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建系统配置数据传输对象列表
        /// </summary>
        public static List<SystemConfigDto> CreateList() {
            return new List<SystemConfigDto>() {
                Create(),
                Create2( SystemConfigTest.Id2 )
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        [TestMethod]
        public void TestToDto() {
            var dto = Create();
            Assert.AreEqual( SystemConfigTest.Id.ToString(),dto.Id,"Id" );
            Assert.AreEqual( SystemConfigTest.CategoryId,dto.CategoryId,"CategoryId" );
            Assert.AreEqual( SystemConfigTest.Code,dto.Code,"Code" );
            Assert.AreEqual( SystemConfigTest.Value,dto.Value,"Value" );
            Assert.AreEqual( SystemConfigTest.Description,dto.Description,"Description" );
            Assert.AreEqual( SystemConfigTest.CreateTime,dto.CreateTime,"CreateTime" );
            Assert.AreEqual( SystemConfigTest.Version,dto.Version,"Version" );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [TestMethod]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.AreEqual( SystemConfigTest.Id,entity.Id,"Id" );
            Assert.AreEqual( SystemConfigTest.CategoryId,entity.CategoryId,"CategoryId" );
            Assert.AreEqual( SystemConfigTest.Code,entity.Code,"Code" );
            Assert.AreEqual( SystemConfigTest.Value,entity.Value,"Value" );
            Assert.AreEqual( SystemConfigTest.Description,entity.Description,"Description" );
            Assert.AreEqual( SystemConfigTest.CreateTime,entity.CreateTime,"CreateTime" );
            Assert.AreEqual( SystemConfigTest.Version,entity.Version,"Version" );
        }
    }
}
