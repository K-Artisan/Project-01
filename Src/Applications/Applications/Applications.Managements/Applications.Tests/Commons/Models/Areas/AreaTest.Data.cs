using System;
using System.Collections.Generic;
using Applications.Domains.Commons.Models;
using Util;

namespace Applications.Tests.Commons.Models.Areas {
    /// <summary>
    /// 地区测试数据
    /// </summary>
    public partial class AreaTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 地区编号
        /// </summary>
        public static readonly Guid Id = "9c4a780d-5bd1-44aa-9c21-1a20673b3073".ToGuid();
        /// <summary>
        /// 父编号
        /// </summary>
        public static readonly Guid? ParentId = "f92d88a9-9a65-4e58-b898-a9212db9f20e".ToGuid();
        /// <summary>
        /// 编码
        /// </summary>
        public static readonly string Code = "Code";
        /// <summary>
        /// 地区名称
        /// </summary>
        public static readonly string Text = "Text";
        /// <summary>
        /// 路径
        /// </summary>
        public static readonly string Path = "Path";
        /// <summary>
        /// 级数
        /// </summary>
        public static readonly int Level = 1;
        /// <summary>
        /// 排序号
        /// </summary>
        public static readonly int SortId = 1;
        /// <summary>
        /// 拼音简码
        /// </summary>
        public static readonly string PinYin = "PinYin";
        /// <summary>
        /// 全拼
        /// </summary>
        public static readonly string FullPinYin = "FullPinYin";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime CreateTime = Conv.ToDate( "2015/2/26 21:32:18" );
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version = File.StringToBytes( "1" );
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 地区编号
        /// </summary>
        public static readonly Guid Id2 = "306f0ed8-584f-4a44-bf8c-95fc202ae43f".ToGuid();
        /// <summary>
        /// 父编号
        /// </summary>
        public static readonly Guid? ParentId2 = "e5598fdf-dcba-4a13-9276-c11c510462fd".ToGuid();
        /// <summary>
        /// 编码
        /// </summary>
        public static readonly string Code2 = "Code2";
        /// <summary>
        /// 地区名称
        /// </summary>
        public static readonly string Text2 = "Text2";
        /// <summary>
        /// 路径
        /// </summary>
        public static readonly string Path2 = "Path2";
        /// <summary>
        /// 级数
        /// </summary>
        public static readonly int Level2 = 2;
        /// <summary>
        /// 排序号
        /// </summary>
        public static readonly int SortId2 = 2;
        /// <summary>
        /// 拼音简码
        /// </summary>
        public static readonly string PinYin2 = "PinYin2";
        /// <summary>
        /// 全拼
        /// </summary>
        public static readonly string FullPinYin2 = "FullPinYin2";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled2 = true;
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime CreateTime2 = Conv.ToDate( "2015/2/27 21:32:18" );
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version2 = File.StringToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建地区实体
        /// </summary>
        public static Area Create() {
            return new Area( Id,Path,Level ) {
                ParentId = ParentId,
                Code = Code,
                Text = Text,
                SortId = SortId,
                PinYin = PinYin,
                FullPinYin = FullPinYin,
                Enabled = Enabled,
                CreateTime = CreateTime,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建地区实体2
        /// </summary>
        /// <param name="id">地区编号</param>
        public static Area Create2( Guid id ) {
            return new Area( id,Path2,Level2 ) {
                ParentId = ParentId2,
                Code = Code2,
                Text = Text2,
                SortId = SortId2,
                PinYin = PinYin2,
                FullPinYin = FullPinYin2,
                Enabled = Enabled2,
                CreateTime = CreateTime2,
                Version = Version2,
            };
        }
        
        #endregion
        
        #region CreateList(创建列表)

        /// <summary>
        /// 创建列表
        /// </summary>
        public static List<Area> CreateList() {
            return new List<Area>() {
                Create(),
                Create2( Id2 )
            };
        }

        #endregion
    }
}
