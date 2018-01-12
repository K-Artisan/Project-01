using System;
using Applications.Domains.Core.Contracts;
using Util.ApplicationServices;
using Util.Security;
using Util.Security.Webs;

namespace Applications.Services.Security {
    /// <summary>
    /// 管理系统授权模块
    /// </summary>
    public class AuthorizeModule : AuthorizeModuleBase {
        /// <summary>
        /// 获取用户标识
        /// </summary>
        /// <param name="userId">用户编号</param>
        protected override Identity GetIdentity( Guid userId ) {
            var identity = new Identity();
            Init( identity );
            return identity;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init( Identity identity ) {
            var siteManager = Ioc.Create<ISiteManager>();
            identity.Skin = siteManager.GetSkin();
        }

        /// <summary>
        /// 获取
        /// </summary>
        protected override ISecurityManager GetSecurityService() {
            return null;
        }
    }
}
