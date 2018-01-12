using System.Collections.Generic;
using Applications.Domains.Core.Contracts;
using Applications.Domains.Security.Models;
using Applications.Domains.Security.Repositories;
using Applications.Services.Contracts.Security;
using Util;

namespace Applications.Services.Impl.Security {
    /// <summary>
    /// 系统服务
    /// </summary>
    public class SystemService : ISystemService{
        /// <summary>
        /// 初始化安全服务
        /// </summary>
        /// <param name="siteManager">站点管理器</param>
        /// <param name="resourceRepository">资源仓储</param>
        public SystemService( ISiteManager siteManager, IResourceRepository resourceRepository ) {
            SiteManager = siteManager;
            ResourceRepository = resourceRepository;
        }

        /// <summary>
        /// 站点管理器
        /// </summary>
        protected ISiteManager SiteManager { get; set; }

        /// <summary>
        /// 资源仓储
        /// </summary>
        protected IResourceRepository ResourceRepository { get; set; }

        /// <summary>
        /// 获取皮肤列表
        /// </summary>
        public List<Item> GetSkins() {
            return SiteManager.GetSkins();
        }

        /// <summary>
        /// 获取菜单样式列表
        /// </summary>
        public List<Item> GetMenuStyles() {
            return SiteManager.GetMenuStyles();
        }

        /// <summary>
        /// 获取皮肤描述
        /// </summary>
        /// <param name="skin">皮肤</param>
        public string GetSkinDescription( string skin ) {
            return SiteManager.GetSkinDescription( skin );
        }

        /// <summary>
        /// 获取菜单样式描述
        /// </summary>
        /// <param name="style">菜单样式</param>
        public string GetMenuStyleDescription( string style ) {
            return SiteManager.GetSkinDescription( style );
        }

        /// <summary>
        /// 获取皮肤
        /// </summary>
        public string GetSkin() {
            return SiteManager.GetSkin();
        }

        /// <summary>
        /// 获取模块列表
        /// </summary>
        public List<Module> GetModules() {
            return ResourceRepository.GetModules();
        }
    }
}
