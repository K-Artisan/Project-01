using System;
using Util;
using Util.Security;

namespace Applications.Domains.Core {
    /// <summary>
    /// 应用程序上下文
    /// </summary>
    public class ApplicationContext : IApplicationContext{
        /// <summary>
        /// 初始化应用程序上下文
        /// </summary>
        public ApplicationContext() {
            _identity = SecurityContext.Identity;
        }

        /// <summary>
        /// 标识
        /// </summary>
        private readonly Identity _identity;

        /// <summary>
        /// 应用程序编号
        /// </summary>
        public Guid ApplicationId {
            get { return _identity.ApplicationId.ToGuid(); } 
        }

        /// <summary>
        /// 应用程序编码
        /// </summary>
        public string ApplicationCode {
            get { return _identity.ApplicationCode; }
        }

        /// <summary>
        /// 应用程序名称
        /// </summary>
        public string Application {
            get { return _identity.Application; }
        }

        /// <summary>
        /// 租户编号
        /// </summary>
        public Guid TenantId {
            get { return _identity.TenantId.ToGuid(); }
        }

        /// <summary>
        /// 租户编码
        /// </summary>
        public string TenantCode {
            get { return _identity.TenantCode; }
        }

        /// <summary>
        /// 租户名称
        /// </summary>
        public string Tenant {
            get { return _identity.Tenant; }
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        public Guid UserId {
            get { return _identity.UserId.ToGuid(); }
        }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string FullName {
            get { return _identity.FullName; }
        }

        /// <summary>
        /// 角色
        /// </summary>
        public string Role {
            get { return _identity.Role; }
        }

        /// <summary>
        /// 皮肤
        /// </summary>
        public string Skin {
            get { return _identity.Skin; }
        }

        /// <summary>
        /// 菜单样式
        /// </summary>
        public string MenuStyle {
            get { return _identity.MenuStyle; }
        }
    }
}
