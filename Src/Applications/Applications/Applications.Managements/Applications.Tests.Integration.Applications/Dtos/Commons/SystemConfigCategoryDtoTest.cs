using System;
using System.Collections.Generic;
using Applications.Services.Dtos.Configs;
using Applications.Tests.Commons.Models.SystemConfigs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Integration.Dtos.Commons {
    /// <summary>
    /// 系统配置分类数据传输对象测试
    /// </summary>
    [TestClass]
    public class SystemConfigCategoryDtoTest {
        /// <summary>
        /// 创建系统配置分类数据传输对象
        /// </summary>
        public static SystemConfigCategoryDto Create() {
            return SystemConfigCategoryTest.Create().ToDto(); 
        }
        
        /// <summary>
        /// 创建系统配置分类数据传输对象2
        /// </summary>
        /// <param name="id">系统配置分类编号</param>
        public static SystemConfigCategoryDto Create2( Guid id ) {
            return SystemConfigCategoryTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建系统配置分类数据传输对象列表
        /// </summary>
        public static List<SystemConfigCategoryDto> CreateList() {
            return new List<SystemConfigCategoryDto>() {
                Create(),
                Create2( SystemConfigCategoryTest.Id2 )
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        [TestMethod]
        public void TestToDto() {
            var dto = Create();
            Assert.AreEqual( SystemConfigCategoryTest.Id.ToString(),dto.Id,"Id" );
            Assert.AreEqual( SystemConfigCategoryTest.Name,dto.Name,"Name" );
            Assert.AreEqual( SystemConfigCategoryTest.CreateTime,dto.CreateTime,"CreateTime" );
            Assert.AreEqual( SystemConfigCategoryTest.SortId,dto.SortId,"SortId" );
            Assert.AreEqual( SystemConfigCategoryTest.Version,dto.Version,"Version" );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [TestMethod]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.AreEqual( SystemConfigCategoryTest.Id,entity.Id,"Id" );
            Assert.AreEqual( SystemConfigCategoryTest.Name,entity.Name,"Name" );
            Assert.AreEqual( SystemConfigCategoryTest.CreateTime,entity.CreateTime,"CreateTime" );
            Assert.AreEqual( SystemConfigCategoryTest.SortId,entity.SortId,"SortId" );
            Assert.AreEqual( SystemConfigCategoryTest.Version,entity.Version,"Version" );
        }
    }
}
