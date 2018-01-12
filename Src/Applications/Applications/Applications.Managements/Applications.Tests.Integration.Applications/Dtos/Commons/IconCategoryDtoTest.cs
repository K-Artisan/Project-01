using System;
using System.Collections.Generic;
using Applications.Services.Dtos.Commons;
using Applications.Tests.Commons.Models.Icons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Integration.Dtos.Commons {
    /// <summary>
    /// 图标分类数据传输对象测试
    /// </summary>
    [TestClass]
    public class IconCategoryDtoTest {
        /// <summary>
        /// 创建图标分类数据传输对象
        /// </summary>
        public static IconCategoryDto Create() {
            return IconCategoryTest.Create().ToDto(); 
        }
        
        /// <summary>
        /// 创建图标分类数据传输对象2
        /// </summary>
        /// <param name="id">图标分类编号</param>
        public static IconCategoryDto Create2( Guid id ) {
            return IconCategoryTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建图标分类数据传输对象列表
        /// </summary>
        public static List<IconCategoryDto> CreateList() {
            return new List<IconCategoryDto>() {
                Create(),
                Create2( IconCategoryTest.Id2 )
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        [TestMethod]
        public void TestToDto() {
            var dto = Create();
            Assert.AreEqual( IconCategoryTest.Id.ToString(),dto.Id,"Id" );
            Assert.AreEqual( IconCategoryTest.TenantId,dto.TenantId,"TenantId" );
            Assert.AreEqual( IconCategoryTest.Name,dto.Name,"Name" );
            Assert.AreEqual( IconCategoryTest.CreateTime,dto.CreateTime,"CreateTime" );
            Assert.AreEqual( IconCategoryTest.Version,dto.Version,"Version" );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [TestMethod]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.AreEqual( IconCategoryTest.Id,entity.Id,"Id" );
            Assert.AreEqual( IconCategoryTest.TenantId,entity.TenantId,"TenantId" );
            Assert.AreEqual( IconCategoryTest.Name,entity.Name,"Name" );
            Assert.AreEqual( IconCategoryTest.CreateTime,entity.CreateTime,"CreateTime" );
            Assert.AreEqual( IconCategoryTest.Version,entity.Version,"Version" );
        }
    }
}
