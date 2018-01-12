using System.Collections.Generic;
using System.Linq;
using Applications.Domains.Configs;
using Applications.Domains.Configs.Models;
using Applications.Domains.Configs.Queries;
using Applications.Domains.Configs.Repositories;
using Applications.Services.Contracts.Configs;
using Applications.Services.Dtos.Configs;
using Util;
using Util.ApplicationServices;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace Applications.Services.Impl.Configs {
    /// <summary>
    /// 系统配置服务
    /// </summary>
    public class SystemConfigService : BatchService<SystemConfig, SystemConfigDto, SystemConfigQuery>, ISystemConfigService {
        
        #region 构造方法
        
        /// <summary>
        /// 初始化系统配置服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">系统配置仓储</param>
        public SystemConfigService( IApplicationUnitOfWork unitOfWork, ISystemConfigRepository repository )
            : base( unitOfWork, repository ) {
            Repository = repository;
        }
        
        #endregion

        #region 属性
        
        /// <summary>
        /// 系统配置仓储
        /// </summary>
        protected new ISystemConfigRepository Repository { get; set; }
        
        #endregion
        
        #region 实体与Dto转换

        /// <summary>
        /// 转换为Dto
        /// </summary>
        /// <param name="entity">实体</param>
        protected override SystemConfigDto ToDto( SystemConfig entity ) {
            return entity.ToDto();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected override SystemConfig ToEntity( SystemConfigDto dto ) {
            return dto.ToEntity();
        }
        
        #endregion
        
        #region GetQuery(查询)

        /// <summary>
        /// 获取查询对象
        /// </summary>
        /// <param name="query">系统配置查询参数</param>
        public override IQueryBase<SystemConfig> GetQuery( SystemConfigQuery query ) {
            return new Query<SystemConfig>( query )
                .Filter( t => t.CategoryId == query.CategoryId )
                .Filter( t => t.Code == query.Code )
                .Filter( t => t.Description.Contains( query.Description ) )
                .Filter( t => t.Value == query.Value )
                .FilterDate( t => t.CreateTime, query.BeginCreateTime, query.EndCreateTime );
        }
        
        #endregion

        #region SaveBefore(保存前操作)

        /// <summary>
        /// 保存前操作
        /// </summary>
        /// <param name="addList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        protected override void SaveBefore( List<SystemConfigDto> addList, List<SystemConfigDto> updateList, List<SystemConfigDto> deleteList ) {
            base.SaveBefore( addList, updateList, deleteList );
            Validate( addList );
            Validate( updateList );
        }

        /// <summary>
        /// 验证
        /// </summary>
        private void Validate( IEnumerable<SystemConfigDto> list ) {
            foreach ( var each in list.GroupBy( t => t.Code ) ) {
                if ( each.Count( t => t.Code.IsEmpty() == false ) > 1 )
                    ThrowRepeatException( each.Key );
            }
        }

        /// <summary>
        /// 抛出编码重复异常
        /// </summary>
        private void ThrowRepeatException( string code ) {
            throw new Warning( string.Format( ConfigResource.SystemConfigCodeRepeat, code ) );
        }

        #endregion

        #region AddBefore(添加前操作)

        /// <summary>
        /// 添加前操作
        /// </summary>
        /// <param name="entity">配置实体</param>
        protected override void AddBefore( SystemConfig entity ) {
            base.AddBefore( entity );
            var exists = Repository.Exists( t => t.Code != "" && t.Code == entity.Code );
            if ( exists )
                ThrowRepeatException( entity.Code );
        }

        #endregion

        #region UpdateBefore(修改前操作)

        /// <summary>
        /// 修改前操作
        /// </summary>
        /// <param name="newEntity">新实体</param>
        /// <param name="oldEntity">数据库中的旧实体</param>
        protected override void UpdateBefore( SystemConfig newEntity, SystemConfig oldEntity ) {
            base.UpdateBefore( newEntity, oldEntity );
            ValidateUpdateExists( newEntity );
        }

        /// <summary>
        /// 验证更新时是否存在重复编码
        /// </summary>
        private void ValidateUpdateExists( SystemConfig entity ) {
            var exists = Repository.Exists( t => t.Id != entity.Id && t.Code != "" && t.Code == entity.Code );
            if ( exists )
                ThrowRepeatException( entity.Code );
        }

        #endregion
    }
}