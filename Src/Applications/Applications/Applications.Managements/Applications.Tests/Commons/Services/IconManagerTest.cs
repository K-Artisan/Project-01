using System;
using System.Collections.Generic;
using System.Linq;
using Applications.Domains.Commons;
using Applications.Domains.Commons.Models;
using Applications.Domains.Commons.Repositories;
using Applications.Domains.Commons.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Util;
using Util.Files;
using Util.Images;

namespace Applications.Tests.Commons.Services {
    /// <summary>
    /// 图标管理器测试
    /// </summary>
    [TestClass]
    public class IconManagerTest {
        /// <summary>
        /// 图标管理器
        /// </summary>
        private IconManager _manager;
        /// <summary>
        /// 模拟文件上传操作
        /// </summary>
        private IFileUpload _mockUpload;
        /// <summary>
        /// 模拟图标仓储
        /// </summary>
        private IIconRepository _mockIconRepository;
        /// <summary>
        /// 模拟文件管理器
        /// </summary>
        private IFileManager _mockFileManager;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _mockUpload = Substitute.For<IFileUpload>();
            _mockIconRepository = Substitute.For<IIconRepository>();
            _mockFileManager = Substitute.For<IFileManager>();
            _manager = new IconManager( _mockUpload, _mockIconRepository, _mockFileManager );
        }

        /// <summary>
        /// 上传图标时验证分类编号不能为空
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( Warning ) )]
        public void TestUpload_Validate_CategoryIdIsEmpty() {
            try {
                _manager.Upload( Guid.Empty, "", "" );
            }
            catch ( Warning ex ) {
                Assert.AreEqual( CommonResource.IconCategoryIsEmpty, ex.Message );
                throw;
            }
        }

        /// <summary>
        /// 上传图标时验证图标存放路径不能为空
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( ArgumentException ) )]
        public void TestUpload_Validate_ImagePathIsEmpty() {
            try {
                _manager.Upload( Guid.NewGuid(), "", "a" );
            }
            catch ( ArgumentException ex ) {
                Assert.AreEqual( CommonResource.UploadIconPathIsEmpty, ex.Message );
                throw;
            }
        }

        /// <summary>
        /// 上传图标时验证Css路径不能为空
        /// </summary>
        [TestMethod]
        [ExpectedException( typeof( ArgumentException ) )]
        public void TestUpload_Validate_CssPathIsEmpty() {
            try {
                _manager.Upload( Guid.NewGuid(), "a", "" );
            }
            catch ( ArgumentException ex ) {
                Assert.AreEqual( CommonResource.IconCssIsEmpty, ex.Message );
                throw;
            }
        }

        /// <summary>
        /// 上传图标
        /// </summary>
        [TestMethod]
        public void TestUpload() {
            //设置参数
            const string iconUploadPath = "/a/b";
            const string cssPath = "/a/b/icon.css";
            const string imagePath = "/a/b/c.jpg";
            var css = Icon.CreateCss( imagePath );
            //设置上传文件操作
            _mockUpload.UploadImage( iconUploadPath ).Returns( ImageInfo.Create( imagePath, 0, 0, 0 ) );

            //添加图标
            _manager.Upload( Guid.NewGuid(), iconUploadPath, cssPath );

            //验证
            _mockUpload.Received().UploadImage( iconUploadPath );
            _mockIconRepository.Received().Add( Arg.Is<Icon>( icon => icon.Name == "c" ) );
            _mockFileManager.Received().FilePath = Sys.GetPhysicalPath( cssPath );
            _mockFileManager.Received().Append( Arg.Is( css ) );
            _mockFileManager.Received().Save();
        }

        /// <summary>
        /// 删除图标
        /// </summary>
        [TestMethod]
        public void TestDelete() {
            //设置参数
            const string cssPath = "/a/b/icon.css";
            var id1 = Guid.NewGuid();
            var id2 = Guid.NewGuid();
            var ids = new List<Guid> { id1, id2 };
            const string path1 = "/a/b.jpg";
            const string path2 = "/a/c.jpg";
            var paths = new List<string> { Sys.GetPhysicalPath( path1 ), Sys.GetPhysicalPath( path2 ) };
            const string css1 = "a";
            const string css2 = "b";
            var cssList = new List<string> { css1, css2 };
            var icons = new List<Icon> { new Icon( id1, "", css1 ) { Path = path1 }, new Icon( id2, "", css2 ) { Path = path2 } };
            //设置仓储操作
            _mockIconRepository.Find( ids ).Returns( icons );

            //删除图标
            _manager.Delete( ids,cssPath );

            //验证
            _mockIconRepository.Received().Remove( Arg.Is( icons ) );
            _mockFileManager.Received().DeleteFiles( Arg.Is<IEnumerable<string>>( t => t.All( paths.Contains ) ) );
            _mockFileManager.Received().FilePath = Sys.GetPhysicalPath( cssPath );
            _mockFileManager.Received().Remove( Arg.Is<IEnumerable<string>>( t => t.All( cssList.Contains ) ) );
            _mockFileManager.Received().Save();
        }
    }
}
