using System;
using System.Collections.Generic;
using Applications.Domains.Security.Models;
using Applications.Domains.Security.Repositories;
using Applications.Services.Contracts.Security;
using Applications.Services.Dtos.Security;
using Applications.Tests.Integration.Dtos.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;
using Util.ApplicationServices;
using Util.Datas.SqlServer;

namespace Applications.Tests.Integration.Services.Security {
    /// <summary>
    /// 应用程序服务测试
    /// </summary>
    [TestClass]
    public class ApplicationServiceTest {
        /// <summary>
        /// 随机数生成器
        /// </summary>
        private RandomBuilder _builder;
        /// <summary>
        /// 应用程序服务
        /// </summary>
        private IApplicationService _service;
        /// <summary>
        /// 应用程序仓储
        /// </summary>
        private IApplicationRepository _repository;
        /// <summary>
        /// 应用程序
        /// </summary>
        private ApplicationDto _dto;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _builder = new RandomBuilder();
            _repository = Ioc.Create<IApplicationRepository>();
            _service = Ioc.Create<IApplicationService>();
            _dto = ApplicationDtoTest.Create2( Guid.Empty );
        }

        /// <summary>
        /// 测试
        /// </summary>
        [TestMethod]
        public void Test() {
            _repository.Remove( t => t.Code == _dto.Code );
            var count = _repository.Count();
            _service.Save( _dto );
            Assert.AreEqual( count + 1, _repository.Count() );
        }

        /// <summary>
        /// 添加测试数据
        /// </summary>
        [TestMethod]
        [Ignore]
        public void AddTestDatas() {
            for ( int i = 0; i < 1; i++ ) {
                var entities = new List<Application>();
                for ( int j = 0; j < 10000; j++ ) {
                    var entity = new Application( Guid.NewGuid() );
                    entity.Code = _builder.GenerateString( 10 );
                    entity.Name = _builder.GenerateChinese( 30 );
                    entity.Note = _builder.GenerateChinese( 100 );
                    entity.Enabled = _builder.GenerateBool();
                    entity.CreateTime = _builder.GenerateDate();
                    entities.Add( entity );
                }
                _repository.BulkInsert( entities );
            }
        }
    }
}