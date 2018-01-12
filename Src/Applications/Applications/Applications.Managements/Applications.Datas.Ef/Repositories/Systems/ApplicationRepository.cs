using Applications.Domains.Security.Models;
using Applications.Domains.Security.Queries;
using Applications.Domains.Security.Repositories;
using Util.Datas.Sql.Queries;
using Util.Domains.Repositories;

namespace Applications.Datas.Ef.Repositories.Systems {
    /// <summary>
    /// 应用程序仓储
    /// </summary>
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository {
        /// <summary>
        /// 初始化应用程序仓储
        /// </summary>
        /// <param name="unitOfWork">安全工作单元</param>
        /// <param name="sqlQuery">Sql查询对象</param>
        public ApplicationRepository( IApplicationUnitOfWork unitOfWork, ISqlQuery sqlQuery )
            : base( unitOfWork ) {
            _sqlQuery = sqlQuery;
        }

        /// <summary>
        /// Sql查询对象
        /// </summary>
        private readonly ISqlQuery _sqlQuery;

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="query">查询实体</param>
        public PagerList<Application> Query( ApplicationQuery query ) {
            return _sqlQuery.Starts( "Name",query.Name )
                .Select( "ApplicationId As Id,*" )
                .GetPageList<Application>( "Systems.Applications", Connection, query );
        }
    }
}
