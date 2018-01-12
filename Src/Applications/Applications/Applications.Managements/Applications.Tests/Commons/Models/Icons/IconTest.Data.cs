using System;
using System.Collections.Generic;
using Applications.Domains.Commons.Models;
using Util;

namespace Applications.Tests.Commons.Models.Icons {
    /// <summary>
    /// 图标测试数据
    /// </summary>
    public partial class IconTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 图标编号
        /// </summary>
        public static readonly Guid Id = "e861a973-e442-48a4-9c52-7ae12eaa694d".ToGuid();
        /// <summary>
        /// 图标分类编号
        /// </summary>
        public static readonly Guid? CategoryId = "fbadae0f-1568-4bb6-9a3a-857adb124463".ToGuid();
        /// <summary>
        /// 租户编号
        /// </summary>
        public static readonly Guid? TenantId = "74b0446e-156e-417a-a0e9-82d922b5e9f8".ToGuid();
        /// <summary>
        /// 图标名称
        /// </summary>
        public static readonly string Name = "Name";
        /// <summary>
        /// 图标路径
        /// </summary>
        public static readonly string Path = "Path";
        /// <summary>
        /// 类名
        /// </summary>
        public static readonly string ClassName = "ClassName";
        /// <summary>
        /// 图标大小
        /// </summary>
        public static readonly int Size = 1;
        /// <summary>
        /// 宽度
        /// </summary>
        public static readonly int Width = 1;
        /// <summary>
        /// 高度
        /// </summary>
        public static readonly int Height = 1;
        /// <summary>
        /// Css代码
        /// </summary>
        public static readonly string Css = "Css";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime CreateTime = Conv.ToDate( "2015/3/26 17:10:28" );
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version = File.StringToBytes( "1" );
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 图标编号
        /// </summary>
        public static readonly Guid Id2 = "b450d81f-1e77-4689-8f3b-3efcb9e1f122".ToGuid();
        /// <summary>
        /// 图标分类编号
        /// </summary>
        public static readonly Guid? CategoryId2 = "a5b796aa-892a-4d3f-b051-03681d612e64".ToGuid();
        /// <summary>
        /// 租户编号
        /// </summary>
        public static readonly Guid? TenantId2 = "b494f00f-06c9-4006-9d32-d1d5977779bf".ToGuid();
        /// <summary>
        /// 图标名称
        /// </summary>
        public static readonly string Name2 = "Name2";
        /// <summary>
        /// 图标路径
        /// </summary>
        public static readonly string Path2 = "Path2";
        /// <summary>
        /// 类名
        /// </summary>
        public static readonly string ClassName2 = "ClassName2";
        /// <summary>
        /// 图标大小
        /// </summary>
        public static readonly int Size2 = 2;
        /// <summary>
        /// 宽度
        /// </summary>
        public static readonly int Width2 = 2;
        /// <summary>
        /// 高度
        /// </summary>
        public static readonly int Height2 = 2;
        /// <summary>
        /// Css代码
        /// </summary>
        public static readonly string Css2 = "Css2";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime CreateTime2 = Conv.ToDate( "2015/3/27 17:10:28" );
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version2 = File.StringToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建图标实体
        /// </summary>
        public static Icon Create() {
            return new Icon( Id, ClassName,Css ) {
                CategoryId = CategoryId,
                TenantId = TenantId,
                Name = Name,
                Path = Path,
                Size = Size,
                Width = Width,
                Height = Height,
                CreateTime = CreateTime,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建图标实体2
        /// </summary>
        /// <param name="id">图标编号</param>
        public static Icon Create2( Guid id ) {
            return new Icon( id, ClassName2, Css2 ) {
                CategoryId = CategoryId2,
                TenantId = TenantId2,
                Name = Name2,
                Path = Path2,
                Size = Size2,
                Width = Width2,
                Height = Height2,
                CreateTime = CreateTime2,
                Version = Version2,
            };
        }
        
        #endregion
        
        #region CreateList(创建列表)

        /// <summary>
        /// 创建列表
        /// </summary>
        public static List<Icon> CreateList() {
            return new List<Icon>() {
                Create(),
                Create2( Id2 )
            };
        }

        #endregion
    }
}
