using Applications.Domains.Commons.Models;
using Applications.Domains.Commons.Repositories;

namespace Applications.Datas.Ef.Repositories.Commons {
    /// <summary>
    /// 地区仓储
    /// </summary>
    public class AreaRepository : RepositoryBase<Area>, IAreaRepository {
        /// <summary>
        /// 初始化地区仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public AreaRepository( IApplicationUnitOfWork unitOfWork )
            : base( unitOfWork ) {
        }
    }
}
