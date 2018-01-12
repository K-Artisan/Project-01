using Applications.Domains.Commons.Models;
using Applications.Domains.Commons.Repositories;

namespace Applications.Datas.Ef.Repositories.Commons {
    /// <summary>
    /// 图标分类仓储
    /// </summary>
    public class IconCategoryRepository : RepositoryBase<IconCategory>, IIconCategoryRepository {
        /// <summary>
        /// 初始化图标分类仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public IconCategoryRepository( IApplicationUnitOfWork unitOfWork )
            : base( unitOfWork ) {
        }
    }
}
