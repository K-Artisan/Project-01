using System;
using System.Collections.Generic;
using Applications.Domains.Configs.Models;
using Util;

namespace Applications.Tests.Commons.Models.SystemConfigs {
    /// <summary>
    /// 系统配置测试数据
    /// </summary>
    public partial class SystemConfigTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 配置编号
        /// </summary>
        public static readonly Guid Id = "393b556a-59d8-47e7-aece-bf796afe74c9".ToGuid();
        /// <summary>
        /// 配置分类编号
        /// </summary>
        public static readonly Guid? CategoryId = "4a3eb4e5-7692-419b-bd59-3d9a2c8cce24".ToGuid();
        /// <summary>
        /// 编码
        /// </summary>
        public static readonly string Code = "Code";
        /// <summary>
        /// 值
        /// </summary>
        public static readonly string Value = "Value";
        /// <summary>
        /// 描述
        /// </summary>
        public static readonly string Description = "Description";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime CreateTime = Conv.ToDate( "2015/4/18 8:26:14" );
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version = File.StringToBytes( "1" );
        
        #endregion
        
        #region 测试数据2
        
        /// <summary>
        /// 配置编号
        /// </summary>
        public static readonly Guid Id2 = "20e6d4e1-6f37-4179-9427-2c9304f3faac".ToGuid();
        /// <summary>
        /// 配置分类编号
        /// </summary>
        public static readonly Guid? CategoryId2 = "2480c971-4fab-477b-80c0-37f80350c0f5".ToGuid();
        /// <summary>
        /// 编码
        /// </summary>
        public static readonly string Code2 = "Code2";
        /// <summary>
        /// 值
        /// </summary>
        public static readonly string Value2 = "Value2";
        /// <summary>
        /// 描述
        /// </summary>
        public static readonly string Description2 = "Description2";
        /// <summary>
        /// 创建时间
        /// </summary>
        public static readonly DateTime CreateTime2 = Conv.ToDate( "2015/4/19 8:26:14" );
        /// <summary>
        /// 版本号
        /// </summary>
        public static readonly Byte[] Version2 = File.StringToBytes( "2" );
        
        #endregion
        
        #region Create(创建实体)
        
        /// <summary>
        /// 创建系统配置实体
        /// </summary>
        public static SystemConfig Create() {
            return new SystemConfig( Id ) {
                CategoryId = CategoryId,
                Code = Code,
                Value = Value,
                Description = Description,
                CreateTime = CreateTime,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建系统配置实体2
        /// </summary>
        /// <param name="id">系统配置编号</param>
        public static SystemConfig Create2( Guid id ) {
            return new SystemConfig( id ) {
                CategoryId = CategoryId2,
                Code = Code2,
                Value = Value2,
                Description = Description2,
                CreateTime = CreateTime2,
                Version = Version2,
            };
        }
        
        #endregion
        
        #region CreateList(创建列表)

        /// <summary>
        /// 创建列表
        /// </summary>
        public static List<SystemConfig> CreateList() {
            return new List<SystemConfig>() {
                Create(),
                Create2( Id2 )
            };
        }

        #endregion
    }
}
