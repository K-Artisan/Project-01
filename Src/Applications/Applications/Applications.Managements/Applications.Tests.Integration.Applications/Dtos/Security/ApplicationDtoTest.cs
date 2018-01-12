using System.Collections.Generic;
using Applications.Services.Dtos.Security;
using Applications.Tests.Security.Models.Applications;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Applications.Tests.Integration.Dtos.Security {
    /// <summary>
    /// 应用程序数据传输对象测试
    /// </summary>
    [TestClass]
    public class ApplicationDtoTest {
        /// <summary>
        /// 创建应用程序数据传输对象
        /// </summary>
        public static ApplicationDto Create() {
            return ApplicationTest.Create().ToDto();
        }

        /// <summary>
        /// 创建应用程序数据传输对象2
        /// </summary>
        /// <param name="id">应用程序编号</param>
        public static ApplicationDto Create2( System.Guid id ) {
            return ApplicationTest.Create2( id ).ToDto();
        }

        /// <summary>
        /// 创建应用程序数据传输对象列表
        /// </summary>
        public static List<ApplicationDto> CreateList() {
            return new List<ApplicationDto>() {
                Create(),
                Create2( ApplicationTest.Id2 )
            };
        }

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        [TestMethod]
        public void TestToDto() {
            var dto = Create();
            Assert.AreEqual( ApplicationTest.Id.ToString(), dto.Id, "Id" );
            Assert.AreEqual( ApplicationTest.Code, dto.Code, "Code" );
            Assert.AreEqual( ApplicationTest.Name, dto.Name, "Name" );
            Assert.AreEqual( ApplicationTest.Note, dto.Note, "Note" );
            Assert.AreEqual( ApplicationTest.Enabled, dto.Enabled, "Enabled" );
            Assert.AreEqual( ApplicationTest.CreateTime, dto.CreateTime, "CreateTime" );
            Assert.AreEqual( ApplicationTest.Version, dto.Version, "Version" );
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        [TestMethod]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.AreEqual( ApplicationTest.Id, entity.Id, "Id" );
            Assert.AreEqual( ApplicationTest.Code, entity.Code, "Code" );
            Assert.AreEqual( ApplicationTest.Name, entity.Name, "Name" );
            Assert.AreEqual( ApplicationTest.Note, entity.Note, "Note" );
            Assert.AreEqual( ApplicationTest.Enabled, entity.Enabled, "Enabled" );
            Assert.AreEqual( ApplicationTest.CreateTime, entity.CreateTime, "CreateTime" );
            Assert.AreEqual( ApplicationTest.Version, entity.Version, "Version" );
        }
    }
}
