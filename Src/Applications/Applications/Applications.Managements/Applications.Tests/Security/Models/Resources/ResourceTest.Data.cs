using System;
using System.Collections.Generic;
using Applications.Domains.Security.Enums;
using Applications.Domains.Security.Models;
using Util;

namespace Applications.Tests.Security.Models.Resources {
    /// <summary>
    /// 资源测试数据
    /// </summary>
    public partial class ResourceTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 资源编号
        /// </summary>
        public static readonly Guid Id = "de51c001-329f-4ab5-a2e0-578ffa48c814".ToGuid();
        /// <summary>
        /// 应用程序编号
        /// </summary>
        public static readonly Guid ApplicationId = "2bb4f9ad-1271-41be-aa00-f4ea9b0729a6".ToGuid();
        /// <summary>
        /// 父编号
        /// </summary>
        public static readonly Guid? ParentId = "04e129a8-9de7-4d9c-acd6-1648fc342016".ToGuid();
        /// <summary>
        /// 路径
        /// </summary>
        public static readonly string Path = "Path";
        /// <summary>
        /// 级数
        /// </summary>
        public static readonly int Level = 1;
        /// <summary>
        /// 资源标识
        /// </summary>
        public static readonly string Uri = "Uri";
        /// <summary>
        /// 资源名称
        /// </summary>
        public static readonly string Name = "Name";
        /// <summary>
        /// 资源类型
        /// </summary>
        public static readonly ResourceType? Type = ResourceType.Module;
        /// <summary>
        /// 小图标
        /// </summary>
        public static readonly string SmallIcon = "SmallIcon";
        /// <summary>
        /// 大图标
        /// </summary>
        public static readonly string LargeIcon = "LargeIcon";
        /// <summary>
        /// 扩展
        /// </summary>
        public static readonly string Extend = "Extend";
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Note = "Note";
        /// <summary>
        /// 拼音简码
        /// </summary>
        public static readonly string PinYin = "PinYin";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 排序号
        /// </summary>
        public static readonly int? SortId = 1;
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime CreateTime = Conv.ToDate( "2015/3/19 13:54:44" );
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version = File.StringToBytes( "1" );
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 资源编号
        /// </summary>
        public static readonly Guid Id2 = "d2f3f447-8589-47f1-8236-9834f6b55848".ToGuid();
        /// <summary>
        /// 应用程序编号
        /// </summary>
        public static readonly Guid ApplicationId2 = "5b6b66c5-04eb-4ffe-90ee-3fbbaaec6695".ToGuid();
        /// <summary>
        /// 父编号
        /// </summary>
        public static readonly Guid? ParentId2 = "d3dfc889-cad2-4f4e-8508-6a7a8f917842".ToGuid();
        /// <summary>
        /// 路径
        /// </summary>
        public static readonly string Path2 = "Path2";
        /// <summary>
        /// 级数
        /// </summary>
        public static readonly int Level2 = 2;
        /// <summary>
        /// 资源标识
        /// </summary>
        public static readonly string Uri2 = "Uri2";
        /// <summary>
        /// 资源名称
        /// </summary>
        public static readonly string Name2 = "Name2";
        /// <summary>
        /// 资源类型
        /// </summary>
        public static readonly ResourceType Type2 = ResourceType.Module;
        /// <summary>
        /// 小图标
        /// </summary>
        public static readonly string SmallIcon2 = "SmallIcon2";
        /// <summary>
        /// 大图标
        /// </summary>
        public static readonly string LargeIcon2 = "LargeIcon2";
        /// <summary>
        /// 扩展
        /// </summary>
        public static readonly string Extend2 = "Extend2";
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Note2 = "Note2";
        /// <summary>
        /// 拼音简码
        /// </summary>
        public static readonly string PinYin2 = "PinYin2";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled2 = true;
        /// <summary>
        /// 排序号
        /// </summary>
        public static readonly int? SortId2 = 2;
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime CreateTime2 = Conv.ToDate( "2015/3/20 13:54:44" );
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version2 = File.StringToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建资源实体
        /// </summary>
        public static Resource Create() {
            return new Resource( Id, Path, Level ) {
                ApplicationId = ApplicationId,
                ParentId = ParentId,
                Uri = Uri,
                Name = Name,
                Type = Type,
                SmallIcon = SmallIcon,
                LargeIcon = LargeIcon,
                Extend = Extend,
                Note = Note,
                PinYin = PinYin,
                Enabled = Enabled,
                SortId = SortId,
                CreateTime = CreateTime,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建资源实体2
        /// </summary>
        /// <param name="id">资源编号</param>
        public static Resource Create2( Guid id ) {
            return new Resource( id, Path2, Level2 ) {
                ApplicationId = ApplicationId2,
                ParentId = ParentId2,
                Uri = Uri2,
                Name = Name2,
                Type = Type2,
                SmallIcon = SmallIcon2,
                LargeIcon = LargeIcon2,
                Extend = Extend2,
                Note = Note2,
                PinYin = PinYin2,
                Enabled = Enabled2,
                SortId = SortId2,
                CreateTime = CreateTime2,
                Version = Version2,
            };
        }
        
        #endregion
        
        #region CreateList(创建列表)

        /// <summary>
        /// 创建列表
        /// </summary>
        public static List<Resource> CreateList() {
            return new List<Resource> {
                Create(),
                Create2( Id2 )
            };
        }

        #endregion
    }
}
