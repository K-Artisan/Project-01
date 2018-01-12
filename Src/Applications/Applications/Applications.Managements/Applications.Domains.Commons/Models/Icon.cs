using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Util.Files;

namespace Applications.Domains.Commons.Models {
    /// <summary>
    /// 图标
    /// </summary>
    public partial class Icon {
        /// <summary>
        /// 图标分类编号
        /// </summary>
        [Display( Name = "图标分类编号" )]
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// 图标分类
        /// </summary>
        public virtual IconCategory IconCategory { get; set; }

        /// <summary>
        /// 获取图标分类
        /// </summary>
        public IconCategory GetCategory() {
            if( IconCategory == null )
                return new IconCategory();
            return IconCategory;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init() {
            base.Init();
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 获取文件大小
        /// </summary>
        public FileSize GetSize() {
            return new FileSize( Size );
        }

        /// <summary>
        /// 生成Css
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public void GenerateCss( string filePath ) {
            ClassName = CreateClassName( filePath );
            Css = CreateCss( filePath );
        }

        /// <summary>
        /// 创建类名
        /// </summary>
        private string CreateClassName( string filePath ) {
            return string.Format( "icon-{0}", System.IO.Path.GetFileNameWithoutExtension( filePath ) );
        }

        /// <summary>
        /// 创建Css
        /// </summary>
        /// <param name="filePath">文件路径</param>
        public static string CreateCss( string filePath ) {
            var result = new StringBuilder();
            result.AppendFormat( ".icon-{0}", System.IO.Path.GetFileNameWithoutExtension( filePath ) );
            result.Append( "{" );
            result.AppendFormat( "background:url(images/{0}) no-repeat center center;", System.IO.Path.GetFileName( filePath ) );
            result.Append( "}" );
            return result.ToString();
        }
    }
}