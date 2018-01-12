using System;
using System.Collections.Generic;
using Applications.Services.Dtos.Commons;
using Applications.Tests.Commons.Models.Icons;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Integration.Dtos.Commons {
    /// <summary>
    /// 图标数据传输对象测试
    /// </summary>
    [TestClass]
    public class IconDtoTest {
        /// <summary>
        /// 创建图标数据传输对象
        /// </summary>
        public static IconDto Create() {
            return IconTest.Create().ToDto(); 
        }
        
        /// <summary>
        /// 创建图标数据传输对象2
        /// </summary>
        /// <param name="id">图标编号</param>
        public static IconDto Create2( Guid id ) {
            return IconTest.Create2( id ).ToDto(); 
        }
        
        /// <summary>
        /// 创建图标数据传输对象列表
        /// </summary>
        public static List<IconDto> CreateList() {
            return new List<IconDto>() {
                Create(),
                Create2( IconTest.Id2 )
            };
        }
        
        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        [TestMethod]
        public void TestToDto() {
            var dto = Create();
            Assert.AreEqual( IconTest.Id.ToString(),dto.Id,"Id" );
            Assert.AreEqual( IconTest.CategoryId,dto.CategoryId,"CategoryId" );
            Assert.AreEqual( IconTest.TenantId,dto.TenantId,"TenantId" );
            Assert.AreEqual( IconTest.Name,dto.Name,"Name" );
            Assert.AreEqual( IconTest.Path,dto.Path,"Path" );
            Assert.AreEqual( IconTest.ClassName,dto.ClassName,"ClassName" );
            Assert.AreEqual( IconTest.Size + " B",dto.Size,"Size" );
            Assert.AreEqual( IconTest.Width,dto.Width,"Width" );
            Assert.AreEqual( IconTest.Height,dto.Height,"Height" );
            Assert.AreEqual( IconTest.Css,dto.Css,"Css" );
            Assert.AreEqual( IconTest.CreateTime,dto.CreateTime,"CreateTime" );
            Assert.AreEqual( IconTest.Version,dto.Version,"Version" );
        }
    }
}
