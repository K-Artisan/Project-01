using System;
using System.Collections.Generic;
using Applications.Domains.Commons.Models;
using Util;

namespace Applications.Tests.Commons.Models.Dics {
    /// <summary>
    /// 字典测试数据
    /// </summary>
    public partial class DicTest {

        #region 测试数据1

        /// <summary>
        /// 字典编号
        /// </summary>
        public static readonly Guid Id = "cd7efd9a-7bda-4dbf-bc9f-d74c889c1255".ToGuid();
        /// <summary>
        /// 父编号
        /// </summary>
        public static readonly Guid? ParentId = "7ac370f7-efe5-40e1-b92c-ed00277078c1".ToGuid();
        /// <summary>
        /// 编码
        /// </summary>
        public static readonly string Code = "Code";
        /// <summary>
        /// 文本
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
        /// 启用
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime CreateTime = Conv.ToDate( "2015/2/6 12:09:56" );
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version = File.StringToBytes( "1" );

        #endregion

        #region 测试数据2

        /// <summary>
        /// 字典编号
        /// </summary>
        public static readonly Guid Id2 = "67fd65d7-02cf-41f9-b8a4-34f461485e89".ToGuid();
        /// <summary>
        /// 父编号
        /// </summary>
        public static readonly Guid? ParentId2 = "c594687c-75d8-4b28-a294-4a9bf80374df".ToGuid();
        /// <summary>
        /// 编码
        /// </summary>
        public static readonly string Code2 = "Code2";
        /// <summary>
        /// 文本
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
        /// 启用
        /// </summary>
        public static readonly bool Enabled2 = true;
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime CreateTime2 = Conv.ToDate( "2015/2/7 12:09:56" );
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version2 = File.StringToBytes( "2" );

        #endregion

        #region Create(创建实体)

        /// <summary>
        /// 创建字典实体
        /// </summary>
        public static Dic Create() {
            return new Dic( Id,Path,Level ) {
                ParentId = ParentId,
                Code = Code,
                Text = Text,
                SortId = SortId,
                PinYin = PinYin,
                Enabled = Enabled,
                CreateTime = CreateTime,
                Version = Version,
            };
        }

        /// <summary>
        /// 创建字典实体2
        /// </summary>
        /// <param name="id">字典编号</param>
        public static Dic Create2( Guid id ) {
            return new Dic( id, Path2, Level2 ) {
                ParentId = ParentId2,
                Code = Code2,
                Text = Text2,
                SortId = SortId2,
                PinYin = PinYin2,
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
        public static List<Dic> CreateList() {
            return new List<Dic>() {
                Create(),
                Create2( Id2 )
            };
        }

        #endregion
    }
}
