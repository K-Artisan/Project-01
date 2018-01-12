using Applications.Domains.Security.Models;
using Applications.Domains.Security.Queries;
using Util.Domains.Repositories;

namespace Applications.Domains.Security.Repositories {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public interface IApplicationRepository : IRepository<Application> {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询实体</param>
        PagerList<Application> Query( ApplicationQuery query );
    }
}
