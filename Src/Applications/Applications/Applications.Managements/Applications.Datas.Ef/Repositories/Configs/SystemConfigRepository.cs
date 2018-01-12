using Applications.Domains.Configs.Models;
using Applications.Domains.Configs.Repositories;

namespace Applications.Datas.Ef.Repositories.Configs {
    /// <summary>
    /// 系统配置仓储
    /// </summary>
    public class SystemConfigRepository : RepositoryBase<SystemConfig>, ISystemConfigRepository {
        /// <summary>
        /// 初始化系统配置仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public SystemConfigRepository( IApplicationUnitOfWork unitOfWork )
            : base( unitOfWork ) {
        }
    }
}
