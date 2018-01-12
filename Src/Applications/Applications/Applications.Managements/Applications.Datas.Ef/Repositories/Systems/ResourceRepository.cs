using System.Collections.Generic;
using System.Linq;
using Applications.Domains.Security.Models;
using Applications.Domains.Security.Repositories;

namespace Applications.Datas.Ef.Repositories.Systems {
    /// <summary>
    /// 资源仓储
    /// </summary>
    public class ResourceRepository : RepositoryBase<Resource>, IResourceRepository {
        /// <summary>
        /// 初始化资源仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ResourceRepository( IApplicationUnitOfWork unitOfWork )
            : base( unitOfWork ) {
        }

        /// <summary>
        /// 获取应用程序的全部模块
        /// </summary>
        public List<Module> GetModules() {
            return Find().OfType<Module>().OrderBy( t => t.SortId ).ToList();
        }
    }
}
