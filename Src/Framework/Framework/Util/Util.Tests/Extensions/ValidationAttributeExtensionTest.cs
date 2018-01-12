﻿using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Tests.Samples;

namespace Util.Tests.Extensions {
    /// <summary>
    /// 验证特性扩展
    /// </summary>
    [TestClass]
    public class ValidationAttributeExtensionTest {
        /// <summary>
        /// 获取验证特性的错误消息
        /// </summary>
        [TestMethod]
        public void TestGetErrorMessage() {
            var nameAttribute = Lambda.GetAttribute<Test2, string, RequiredAttribute>( t => t.Name );
            Assert.AreEqual( "名称不能为空", nameAttribute.GetErrorMessage() );
            var intAttribute = Lambda.GetAttribute<Test2, int, RequiredAttribute>( t => t.Int );
            Assert.AreEqual( R.IsEmpty, intAttribute.GetErrorMessage() );
        }
    }
}
