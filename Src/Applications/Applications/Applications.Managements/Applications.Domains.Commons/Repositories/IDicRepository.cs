using System;
using Applications.Domains.Commons.Models;
using Util.Domains.Repositories;

namespace Applications.Domains.Commons.Repositories {
    /// <summary>
    /// 字典仓储
    /// </summary>
    public interface IDicRepository : IRepository<Dic> {
        /// <summary>
        /// 根据编码获取字典
        /// </summary>
        /// <param name="code">字典编码</param>
        /// <param name="tenantId">租户编号</param>
        Dic GetDic( string code, Guid? tenantId = null );
    }
}
