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
    /// 系统配置分类服务
    /// </summary>
    public class SystemConfigCategoryService : BatchService<SystemConfigCategory, SystemConfigCategoryDto, SystemConfigCategoryQuery>, ISystemConfigCategoryService {
        
        #region 构造方法
        
        /// <summary>
        /// 初始化系统配置分类服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">系统配置分类仓储</param>
        public SystemConfigCategoryService( IApplicationUnitOfWork unitOfWork, ISystemConfigCategoryRepository repository )
            : base( unitOfWork, repository ) {
            Repository = repository;
        }
        
        #endregion

        #region 属性
        
        /// <summary>
        /// 系统配置分类仓储
        /// </summary>
        protected new ISystemConfigCategoryRepository Repository { get; set; }
        
        #endregion
        
        #region 实体与Dto转换

        /// <summary>
        /// 转换为Dto
        /// </summary>
        /// <param name="entity">实体</param>
        protected override SystemConfigCategoryDto ToDto( SystemConfigCategory entity ) {
            return entity.ToDto();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected override SystemConfigCategory ToEntity( SystemConfigCategoryDto dto ) {
            return dto.ToEntity();
        }
        
        #endregion

        #region GetAll(获取全部系统配置分类)

        /// <summary>
        /// 获取全部系统配置分类
        /// </summary>
        public override List<SystemConfigCategoryDto> GetAll() {
            return base.GetAll().OrderBy( t => t.SortId ).ToList();
        }

        #endregion
        
        #region GetQuery(查询)

        /// <summary>
        /// 获取查询对象
        /// </summary>
        /// <param name="query">系统配置分类查询参数</param>
        public override IQueryBase<SystemConfigCategory> GetQuery( SystemConfigCategoryQuery query ) {
            return new Query<SystemConfigCategory>( query ).OrderBy( t => t.SortId ); ;
        }
        
        #endregion

        #region AddBefore(添加前操作)

        /// <summary>
        /// 添加前操作
        /// </summary>
        protected override void AddBefore( SystemConfigCategory entity ) {
            base.AddBefore( entity );
            if ( Repository.Exists( t => t.Name == entity.Name ) )
                ThrowRepeatException( entity.Name );
        }

        /// <summary>
        /// 抛出重复异常
        /// </summary>
        private void ThrowRepeatException( string name ) {
            throw new Warning( string.Format( ConfigResource.SystemConfigCategoryRepeat, name ) );
        }

        #endregion

        #region UpdateBefore(修改前操作)

        /// <summary>
        /// 修改前操作
        /// </summary>
        protected override void UpdateBefore( SystemConfigCategory newEntity, SystemConfigCategory oldEntity ) {
            base.UpdateBefore( newEntity, oldEntity );
            if ( Repository.Exists( t => t.Id != newEntity.Id && t.Name == newEntity.Name ) )
                ThrowRepeatException( newEntity.Name );
        }

        #endregion
    }
}