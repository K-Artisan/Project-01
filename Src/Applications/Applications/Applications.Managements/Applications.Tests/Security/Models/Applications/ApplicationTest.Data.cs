using System;
using System.Collections.Generic;
using Applications.Domains.Security.Models;
using Util;

namespace Applications.Tests.Security.Models.Applications {
    /// <summary>
    /// 应用程序测试数据
    /// </summary>
    public partial class ApplicationTest {

        #region 测试数据1

        /// <summary>
        /// 应用程序编号
        /// </summary>
        public static readonly System.Guid Id = "7ed5e1b0-3962-4aa3-9ca0-7940c670e102".ToGuid();
        /// <summary>
        /// 应用程序编码
        /// </summary>
        public static readonly string Code = "Code";
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public static readonly string Name = "Name";
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Note = "Note";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled = true;
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly System.DateTime CreateTime = Conv.ToDate( "2015/1/18 14:54:25" );
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly System.Byte[] Version = File.StringToBytes( "1" );

        #endregion

        #region 测试数据2

        /// <summary>
        /// 应用程序编号
        /// </summary>
        public static readonly System.Guid Id2 = "15a9d848-a804-4cab-b58e-c1a1ab67a9f6".ToGuid();
        /// <summary>
        /// 应用程序编码
        /// </summary>
        public static readonly string Code2 = "Code2";
        /// <summary>
        /// 应用程序名称
        /// </summary>
        public static readonly string Name2 = "Name2";
        /// <summary>
        /// 备注
        /// </summary>
        public static readonly string Note2 = "Note2";
        /// <summary>
        /// 启用
        /// </summary>
        public static readonly bool Enabled2 = true;
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly System.DateTime CreateTime2 = Conv.ToDate( "2015/1/19 14:54:25" );
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly System.Byte[] Version2 = File.StringToBytes( "2" );

        #endregion

        #region Create(创建实体)

        /// <summary>
        /// 创建应用程序实体
        /// </summary>
        public static Application Create() {
            return new Application( Id ) {
                Code = Code,
                Name = Name,
                Note = Note,
                Enabled = Enabled,
                CreateTime = CreateTime,
                Version = Version,
            };
        }

        /// <summary>
        /// 创建应用程序实体2
        /// </summary>
        /// <param name="applicationId">应用程序编号</param>
        public static Application Create2( Guid applicationId ) {
            return new Application( applicationId ) {
                Code = Code2,
                Name = Name2,
                Note = Note2,
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
        public static List<Application> CreateList() {
            return new List<Application>() {
                Create(),
                Create2( Id2 )
            };
        }

        #endregion
    }
}
