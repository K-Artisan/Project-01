using System;
using Applications.Domains.Security;
using Applications.Domains.Security.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util;

namespace Applications.Tests.Security.Models.Applications {
    /// <summary>
    /// 应用程序测试
    /// </summary>
    [TestClass]
    public partial class ApplicationTest {
        /// <summary>
        /// 应用程序
        /// </summary>
        private Application _application;

        /// <summary>
        /// 初始化测试
        /// </summary>
        [TestInitialize]
        public void Init() {
            _application = Create();
        }

        /// <summary>
        /// 验证应用程序编码
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Warning))]
        public void TestValidate_CodeIsEmpty() {
            try {
                _application.Code = string.Empty;
                _application.Validate();
            }
            catch ( Warning ex ) {
                Assert.AreEqual( SecurityResource.ApplicationCodeIsEmpty,ex.Message );
                throw;
            }
        }

        /// <summary>
        /// 验证应用程序名称
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( Warning ) )]
        public void TestValidate_NameIsEmpty() {
            try {
                _application.Name = string.Empty;
                _application.Validate();
            }
            catch ( Warning ex ) {
                Assert.AreEqual( SecurityResource.ApplicationNameIsEmpty, ex.Message );
                throw;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        [TestMethod]
        public void TestInit() {
            var entity = new Application( Guid.Empty );
            entity.Init();
            Assert.AreNotEqual( Guid.Empty,entity.Id );
            Assert.AreNotEqual( DateTime.MinValue, entity.CreateTime, "CreateTime" );
        }
    }
}
