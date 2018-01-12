using System.Collections.Generic;
using Applications.Domains.Security.Models;
using Util.Domains.Repositories;

namespace Applications.Domains.Security.Repositories {
    /// <summary>
    /// 资源仓储
    /// </summary>
    public interface IResourceRepository : IRepository<Resource> {
        /// <summary>
        /// 获取应用程序的全部模块
        /// </summary>
        List<Module> GetModules();
    }
}
