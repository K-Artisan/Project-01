using System;
using System.Collections.Generic;
using Applications.Domains.Commons.Models;
using Util;

namespace Applications.Tests.Commons.Models.Icons {
    /// <summary>
    /// 图标分类测试数据
    /// </summary>
    public partial class IconCategoryTest {
        
        #region 测试数据1
        
        /// <summary>
        /// 图标分类编号
        /// </summary>
        public static readonly Guid Id = "6b9858a2-467e-4ca4-857d-fc21d513de6d".ToGuid();
        /// <summary>
        /// 租户编号
        /// </summary>
        public static readonly Guid? TenantId = "3c603b09-e6b2-4735-ad81-f89142f0f87b".ToGuid();
        /// <summary>
        /// 分类名称
        /// </summary>
        public static readonly string Name = "Name";
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
        /// 图标分类编号
        /// </summary>
        public static readonly Guid Id2 = "d180450c-0c66-4e32-9393-a25c4a3024bf".ToGuid();
        /// <summary>
        /// 租户编号
        /// </summary>
        public static readonly Guid? TenantId2 = "e77798e8-adca-4120-b718-3dac8293157a".ToGuid();
        /// <summary>
        /// 分类名称
        /// </summary>
        public static readonly string Name2 = "Name2";
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
        /// 创建图标分类实体
        /// </summary>
        public static IconCategory Create() {
            return new IconCategory( Id ) {
                TenantId = TenantId,
                Name = Name,
                CreateTime = CreateTime,
                Version = Version,
            };
        }
        
        /// <summary>
        /// 创建图标分类实体2
        /// </summary>
        /// <param name="id">图标分类编号</param>
        public static IconCategory Create2( Guid id ) {
            return new IconCategory( id ) {
                TenantId = TenantId2,
                Name = Name2,
                CreateTime = CreateTime2,
                Version = Version2,
            };
        }
        
        #endregion
        
        #region CreateList(创建列表)

        /// <summary>
        /// 创建列表
        /// </summary>
        public static List<IconCategory> CreateList() {
            return new List<IconCategory>() {
                Create(),
                Create2( Id2 )
            };
        }

        #endregion
    }
}
