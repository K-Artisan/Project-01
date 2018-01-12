using System;
using System.Collections.Generic;
using System.Linq;
using Applications.Domains.Commons.Factories;
using Applications.Domains.Commons.Models;
using Applications.Domains.Commons.Repositories;
using Util;
using Util.Domains;
using Util.Files;
using Util.Images;

namespace Applications.Domains.Commons.Services {
    /// <summary>
    /// 图标管理器
    /// </summary>
    public class IconManager : DomainServiceBase, IIconManager {
        /// <summary>
        /// 初始化图标管理器
        /// </summary>
        /// <param name="fileUpload">文件上传操作</param>
        /// <param name="iconRepository">图标仓储</param>
        /// <param name="fileManager">文件管理器</param>
        public IconManager( IFileUpload fileUpload, IIconRepository iconRepository, IFileManager fileManager ) {
            FileUpload = fileUpload;
            FileUpload.UploadPathStrategy = new DefaultUploadPathStrategy();
            IconRepository = iconRepository;
            FileManager = fileManager;
        }

        /// <summary>
        /// 文件上传操作
        /// </summary>
        public IFileUpload FileUpload { get; set; }

        /// <summary>
        /// 图标仓储
        /// </summary>
        public IIconRepository IconRepository { get; set; }

        /// <summary>
        /// 文件管理器
        /// </summary>
        public IFileManager FileManager { get; set; }

        /// <summary>
        /// 上传图标
        /// </summary>
        /// <param name="categoryId">图标分类编号</param>
        /// <param name="uploadIconPath">上传图标的路径</param>
        /// <param name="cssPath">图标Css的路径</param>
        public Icon Upload( Guid categoryId, string uploadIconPath, string cssPath ) {
            ValidateUpload( categoryId, uploadIconPath, cssPath );
            var image = UploadImage( uploadIconPath );
            var icon = ToIcon( categoryId, image );
            AddToRepository( icon );
            AppendToFile( cssPath, icon );
            return icon;
        }

        /// <summary>
        /// 验证上传
        /// </summary>
        private void ValidateUpload( Guid categoryId, string uploadIconPath, string cssPath ) {
            if ( categoryId == Guid.Empty )
                throw new Warning( CommonResource.IconCategoryIsEmpty );
            if ( uploadIconPath.IsEmpty() )
                throw new ArgumentException( CommonResource.UploadIconPathIsEmpty );
            if ( cssPath.IsEmpty() )
                throw new ArgumentException( CommonResource.IconCssIsEmpty );
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        private ImageInfo UploadImage( string uploadIconPath ) {
            return FileUpload.UploadImage( uploadIconPath );
        }

        /// <summary>
        /// 转换为图标
        /// </summary>
        private Icon ToIcon( Guid categoryId, ImageInfo image ) {
            var result = IconFactory.Create( image );
            result.CategoryId = categoryId;
            return result;
        }

        /// <summary>
        /// 添加到仓储
        /// </summary>
        private void AddToRepository( Icon icon ) {
            icon.Init();
            icon.Validate();
            IconRepository.Add( icon );
        }

        /// <summary>
        /// 添加到CSS文件末尾
        /// </summary>
        private void AppendToFile( string cssPath, Icon icon ) {
            FileManager.FilePath = Sys.GetPhysicalPath( cssPath );
            FileManager.Append( icon.Css );
            FileManager.Save();
        }

        /// <summary>
        /// 删除图标
        /// </summary>
        /// <param name="ids">图标编号集合</param>
        /// <param name="cssPath">图标Css的路径</param>
        public List<Icon> Delete( List<Guid> ids, string cssPath ) {
            ids.CheckNull( "ids" );
            var result = new List<Icon>();
            if ( ids.Count == 0 )
                return result;
            result = IconRepository.Find( ids );
            RemoveFromRepository( result );
            DeleteFiles( result );
            RemoveCss( result, cssPath );
            return result;
        }

        /// <summary>
        /// 从仓储移除图标集合
        /// </summary>
        private void RemoveFromRepository( IEnumerable<Icon> icons ) {
            IconRepository.Remove( icons );
        }

        /// <summary>
        /// 删除文件集合
        /// </summary>
        private void DeleteFiles( IEnumerable<Icon> icons ) {
            FileManager.DeleteFiles( icons.Select( t => Sys.GetPhysicalPath( t.Path ) ) );
        }

        /// <summary>
        /// 从Css文件中移除Css代码
        /// </summary>
        private void RemoveCss( IEnumerable<Icon> icons, string cssPath ) {
            FileManager.FilePath = Sys.GetPhysicalPath( cssPath );
            FileManager.Remove( icons.Select( t => t.Css ) );
            FileManager.Save();
        }
    }
}
