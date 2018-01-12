using System;
using Util;

namespace Applications.Domains.Core {
    /// <summary>
    /// 应用程序上下文
    /// </summary>
    public interface IApplicationContext : IDependency{
        /// <summary>
        /// 应用程序编号
        /// </summary>
        Guid ApplicationId { get; }

        /// <summary>
        /// 应用程序编码
        /// </summary>
        string ApplicationCode { get; }

        /// <summary>
        /// 应用程序名称
        /// </summary>
        string Application { get; }

        /// <summary>
        /// 租户编号
        /// </summary>
        Guid TenantId { get; }

        /// <summary>
        /// 租户编码
        /// </summary>
        string TenantCode { get; }

        /// <summary>
        /// 租户名称
        /// </summary>
        string Tenant { get; }

        /// <summary>
        /// 用户编号
        /// </summary>
        Guid UserId { get; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// 角色
        /// </summary>
        string Role { get; }

        /// <summary>
        /// 皮肤
        /// </summary>
        string Skin { get; }

        /// <summary>
        /// 菜单样式
        /// </summary>
        string MenuStyle { get;}
    }
}
