using System;
using Applications.Domains.Security.Models;
using Applications.Domains.Security.Queries;
using Applications.Domains.Security.Repositories;
using Applications.Services.Contracts.Security;
using Applications.Services.Dtos.Security;
using Util;
using Util.ApplicationServices;
using Util.ApplicationServices.Criterias;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace Applications.Services.Impl.Security {
    /// <summary>
    /// 资源服务
    /// </summary>
    public class ResourceService : TreeBatchService<Resource, ResourceDto, ResourceQuery>, IResourceService {
        
        #region 构造方法
        
        /// <summary>
        /// 初始化资源服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">资源仓储</param>
        public ResourceService( IApplicationUnitOfWork unitOfWork, IResourceRepository repository )
            : base( unitOfWork, repository ) {
            Repository = repository;
        }
        
        #endregion

        #region 属性
        
        /// <summary>
        /// 资源仓储
        /// </summary>
        protected new IResourceRepository Repository { get; set; }
        
        #endregion
        
        #region 实体与Dto转换

        /// <summary>
        /// 转换为Dto
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ResourceDto ToDto( Resource entity ) {
            return entity.ToDto();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected override Resource ToEntity( ResourceDto dto ) {
            return dto.ToEntity();
        }
        
        #endregion

        #region Create(创建Dto)

        /// <summary>
        /// 创建Dto
        /// </summary>
        public override ResourceDto Create( string parentId ) {
            var dto = base.Create( parentId );
            dto.CreateTime = DateTime.Now;
            dto.Enabled = true;
            var entity = Repository.Find( parentId.ToGuidOrNull() ) ?? Resource.Null;
            dto.ApplicationId = entity.ApplicationId;
            return dto;
        }

        #endregion

        #region GetQuery(查询)

        /// <summary>
        /// 获取查询对象
        /// </summary>
        /// <param name="query">资源查询参数</param>
        public override IQueryBase<Resource> GetQuery( ResourceQuery query ) {
            return new Query<Resource>( query ).Filter( new TreeEntityCriteria<Resource>( query ) )
                .Filter( t => t.ApplicationId == query.ApplicationId )
                .Filter( t => t.Name.Contains( query.Name ) )
                .Filter( t => t.PinYin.Contains( query.Name ), true )
                .FilterDate( t => t.CreateTime, query.BeginCreateTime, query.EndCreateTime );
        }
        
        #endregion
    }
}