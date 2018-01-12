using System;
using System.Collections.Generic;
using Applications.Services.Dtos.Commons;
using Applications.Tests.Commons.Models.Dics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace Applications.Tests.Integration.Dtos.Commons {
    /// <summary>
    /// 字典数据传输对象测试
    /// </summary>
    [TestClass]
    public class DicDtoTest {
        /// <summary>
        /// 创建字典数据传输对象
        /// </summary>
        public static DicDto Create() {
            return DicTest.Create().ToDto();
        }

        /// <summary>
        /// 创建字典数据传输对象2
        /// </summary>
        /// <param name="id">字典编号</param>
        public static DicDto Create2( Guid id ) {
            return DicTest.Create2( id ).ToDto();
        }

        /// <summary>
        /// 创建字典数据传输对象列表
        /// </summary>
        public static List<DicDto> CreateList() {
            return new List<DicDto>() {
                Create(),
                Create2( DicTest.Id2 )
            };
        }

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        [TestMethod]
        public void TestToDto() {
            var dto = Create();
            Assert.AreEqual( DicTest.Id.ToString(), dto.Id, "Id" );
            Assert.AreEqual( DicTest.ParentId, dto.ParentId.ToGuid(), "ParentId" );
            Assert.AreEqual( DicTest.Code, dto.Code, "Code" );
            Assert.AreEqual( DicTest.Text, dto.Text, "Text" );
            Assert.AreEqual( DicTest.Path, dto.Path, "Path" );
            Assert.AreEqual( DicTest.Level, dto.Level, "Level" );
            Assert.AreEqual( DicTest.SortId, dto.SortId, "SortId" );
            Assert.AreEqual( DicTest.PinYin, dto.PinYin, "PinYin" );
            Assert.AreEqual( DicTest.Enabled, dto.Enabled, "Enabled" );
            Assert.AreEqual( DicTest.CreateTime, dto.CreateTime, "CreateTime" );
            Assert.AreEqual( DicTest.Version, dto.Version, "Version" );
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        [TestMethod]
        public void TestToEntity() {
            var entity = Create().ToEntity();
            Assert.AreEqual( DicTest.Id, entity.Id, "Id" );
            Assert.AreEqual( DicTest.ParentId, entity.ParentId, "ParentId" );
            Assert.AreEqual( DicTest.Code, entity.Code, "Code" );
            Assert.AreEqual( DicTest.Text, entity.Text, "Text" );
            Assert.AreEqual( DicTest.Path, entity.Path, "Path" );
            Assert.AreEqual( DicTest.Level, entity.Level, "Level" );
            Assert.AreEqual( DicTest.SortId, entity.SortId, "SortId" );
            Assert.AreEqual( DicTest.PinYin, entity.PinYin, "PinYin" );
            Assert.AreEqual( DicTest.Enabled, entity.Enabled, "Enabled" );
            Assert.AreEqual( DicTest.CreateTime, entity.CreateTime, "CreateTime" );
            Assert.AreEqual( DicTest.Version, entity.Version, "Version" );
        }
    }
}
