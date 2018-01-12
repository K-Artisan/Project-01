using System;
using System.Collections.Generic;
using Applications.Services.Dtos.Security;
using Applications.Tests.Security.Models.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace Applications.Tests.Integration.Dtos.Security {
    /// <summary>
    /// 资源数据传输对象测试
    /// </summary>
    [TestClass]
    public class ResourceDtoTest {
        /// <summary>
        /// 创建资源数据传输对象
        /// </summary>
        public static ResourceDto Create() {
            return ResourceTest.Create().ToDto(); 
        }
        
        /// <summary>
        /// 创建资源数据传输对象2
        /// </summary>
        /// <param name="id">资源编号</param>
        public static ResourceDto Create2( Guid id ) {
            return ResourceTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建资源数据传输对象列表
        /// </summary>
        public static List<ResourceDto> CreateList() {
            return new List<ResourceDto>() {
                Create(),
                Create2( ResourceTest.Id2 )
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        [TestMethod]
        public void TestToDto() {
            var dto = Create();
            Assert.AreEqual( ResourceTest.Id.ToString(),dto.Id,"Id" );
            Assert.AreEqual( ResourceTest.ApplicationId,dto.ApplicationId,"ApplicationId" );
            Assert.AreEqual( ResourceTest.ParentId.ToStr(),dto.ParentId,"ParentId" );
            Assert.AreEqual( ResourceTest.Path,dto.Path,"Path" );
            Assert.AreEqual( ResourceTest.Level,dto.Level,"Level" );
            Assert.AreEqual( ResourceTest.Uri,dto.Uri,"Uri" );
            Assert.AreEqual( ResourceTest.Name,dto.Name,"Name" );
            Assert.AreEqual( ResourceTest.Type,dto.Type,"Type" );
            Assert.AreEqual( ResourceTest.SmallIcon, dto.SmallIcon, "SmallIcon" );
            Assert.AreEqual( ResourceTest.LargeIcon, dto.LargeIcon, "LargeIcon" );
            Assert.AreEqual( ResourceTest.Extend,dto.Extend,"Extend" );
            Assert.AreEqual( ResourceTest.Note,dto.Note,"Note" );
            Assert.AreEqual( ResourceTest.PinYin,dto.PinYin,"PinYin" );
            Assert.AreEqual( ResourceTest.Enabled,dto.Enabled,"Enabled" );
            Assert.AreEqual( ResourceTest.SortId,dto.SortId,"SortId" );
            Assert.AreEqual( ResourceTest.CreateTime,dto.CreateTime,"CreateTime" );
            Assert.AreEqual( ResourceTest.Version,dto.Version,"Version" );
        }
        
        /// <summary>
        /// 转换为实体
        /// </summary>
        [TestMethod]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.AreEqual( ResourceTest.Id,entity.Id,"Id" );
            Assert.AreEqual( ResourceTest.ApplicationId,entity.ApplicationId,"ApplicationId" );
            Assert.AreEqual( ResourceTest.ParentId,entity.ParentId,"ParentId" );
            Assert.AreEqual( ResourceTest.Path,entity.Path,"Path" );
            Assert.AreEqual( ResourceTest.Level,entity.Level,"Level" );
            Assert.AreEqual( ResourceTest.Uri,entity.Uri,"Uri" );
            Assert.AreEqual( ResourceTest.Name,entity.Name,"Name" );
            Assert.AreEqual( ResourceTest.Type,entity.Type,"Type" );
            Assert.AreEqual( ResourceTest.SmallIcon, entity.SmallIcon, "SmallIcon" );
            Assert.AreEqual( ResourceTest.LargeIcon, entity.LargeIcon, "LargeIcon" );
            Assert.AreEqual( ResourceTest.Note,entity.Note,"Note" );
            Assert.AreEqual( ResourceTest.PinYin,entity.PinYin,"PinYin" );
            Assert.AreEqual( ResourceTest.Enabled,entity.Enabled,"Enabled" );
            Assert.AreEqual( ResourceTest.SortId,entity.SortId,"SortId" );
            Assert.AreEqual( ResourceTest.CreateTime,entity.CreateTime,"CreateTime" );
            Assert.AreEqual( ResourceTest.Version,entity.Version,"Version" );
        }
    }
}
