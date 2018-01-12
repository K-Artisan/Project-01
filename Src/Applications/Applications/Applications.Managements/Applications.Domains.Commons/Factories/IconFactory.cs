using Applications.Domains.Commons.Models;
using Util.Images;

namespace Applications.Domains.Commons.Factories {
    /// <summary>
    /// 图标工厂
    /// </summary>
    public static class IconFactory {
        /// <summary>
        /// 图片信息转换为图标
        /// </summary>
        public static Icon Create( ImageInfo image ) {
            var result = new Icon {
                Path = image.FilePath, Name = image.FileName, Width = image.Size.Width, Height = image.Size.Height, Size = image.Length.GetSize()
            };
            result.GenerateCss( image.FilePath );
            return result;
        }
    }
}
