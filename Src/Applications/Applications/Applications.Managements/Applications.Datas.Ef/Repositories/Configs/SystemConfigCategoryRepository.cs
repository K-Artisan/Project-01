using Applications.Domains.Configs.Models;
using Applications.Domains.Configs.Repositories;

namespace Applications.Datas.Ef.Repositories.Configs {
    /// <summary>
    /// 系统配置分类仓储
    /// </summary>
    public class SystemConfigCategoryRepository : RepositoryBase<SystemConfigCategory>, ISystemConfigCategoryRepository {
        /// <summary>
        /// 初始化系统配置分类仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public SystemConfigCategoryRepository( IApplicationUnitOfWork unitOfWork )
            : base( unitOfWork ) {
        }
    }
}
