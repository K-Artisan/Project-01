using System;
using System.Collections.Generic;
using Applications.Domains.Configs.Models;
using Util;

namespace Applications.Tests.Commons.Models.SystemConfigs {
    /// <summary>
    /// 系统配置分类测试数据
    /// </summary>
    public partial class SystemConfigCategoryTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 配置分类编号
        /// </summary>
        public static readonly Guid Id = "816a66d3-defd-4cba-82da-25bb9be430b3".ToGuid();
        /// <summary>
        /// 分类名称
        /// </summary>
        public static readonly string Name = "Name";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime CreateTime = Conv.ToDate( "2015/4/18 8:26:14" );
        /// <summary>
        /// 排序号
        /// </summary>
        public static readonly int SortId = 1;
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version = File.StringToBytes( "1" );
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 配置分类编号
        /// </summary>
        public static readonly Guid Id2 = "59824cf0-7a8f-440f-a315-66930fcc332f".ToGuid();
        /// <summary>
        /// 分类名称
        /// </summary>
        public static readonly string Name2 = "Name2";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime CreateTime2 = Conv.ToDate( "2015/4/19 8:26:14" );
        /// <summary>
        /// 排序号
        /// </summary>
        public static readonly int SortId2 = 2;
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version2 = File.StringToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建系统配置分类实体
        /// </summary>
        public static SystemConfigCategory Create() {
            return new SystemConfigCategory( Id ) {
                Name = Name,
                CreateTime = CreateTime,
                SortId = SortId,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建系统配置分类实体2
        /// </summary>
        /// <param name="id">系统配置分类编号</param>
        public static SystemConfigCategory Create2( Guid id ) {
            return new SystemConfigCategory( id ) {
                Name = Name2,
                CreateTime = CreateTime2,
                SortId = SortId2,
                Version = Version2,
            };
        }
        
        #endregion
        
        #region CreateList(创建列表)

        /// <summary>
        /// 创建列表
        /// </summary>
        public static List<SystemConfigCategory> CreateList() {
            return new List<SystemConfigCategory>() {
                Create(),
                Create2( Id2 )
            };
        }

        #endregion
    }
}
