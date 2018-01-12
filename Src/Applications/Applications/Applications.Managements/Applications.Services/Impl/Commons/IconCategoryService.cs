using System.Collections.Generic;
using System.Linq;
using Applications.Domains.Commons;
using Applications.Domains.Commons.Models;
using Applications.Domains.Commons.Queries;
using Applications.Domains.Commons.Repositories;
using Applications.Services.Contracts.Commons;
using Applications.Services.Dtos.Commons;
using Util;
using Util.ApplicationServices;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace Applications.Services.Impl.Commons {
    /// <summary>
    /// 图标分类服务
    /// </summary>
    public class IconCategoryService : BatchService<IconCategory, IconCategoryDto, IconCategoryQuery>, IIconCategoryService {
        
        #region 构造方法
        
        /// <summary>
        /// 初始化图标分类服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">图标分类仓储</param>
        public IconCategoryService( IApplicationUnitOfWork unitOfWork, IIconCategoryRepository repository )
            : base( unitOfWork, repository ) {
            Repository = repository;
        }
        
        #endregion

        #region 属性
        
        /// <summary>
        /// 图标分类仓储
        /// </summary>
        protected new IIconCategoryRepository Repository { get; set; }
        
        #endregion
        
        #region 实体与Dto转换

        /// <summary>
        /// 转换为Dto
        /// </summary>
        /// <param name="entity">实体</param>
        protected override IconCategoryDto ToDto( IconCategory entity ) {
            return entity.ToDto();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected override IconCategory ToEntity( IconCategoryDto dto ) {
            return dto.ToEntity();
        }
        
        #endregion

        #region GetAll(获取全部图标分类)

        /// <summary>
        /// 获取全部图标分类
        /// </summary>
        public override List<IconCategoryDto> GetAll() {
            return base.GetAll().OrderBy( t => t.SortId ).ToList();
        }

        #endregion

        #region GetQuery(查询)

        /// <summary>
        /// 获取查询对象
        /// </summary>
        /// <param name="query">图标分类查询参数</param>
        public override IQueryBase<IconCategory> GetQuery( IconCategoryQuery query ) {
            return new Query<IconCategory>( query ).OrderBy( t => t.SortId );
        }
        
        #endregion

        #region AddBefore(添加前操作)

        /// <summary>
        /// 添加前操作
        /// </summary>
        protected override void AddBefore( IconCategory entity ) {
            base.AddBefore( entity );
            if ( Repository.Exists( t => t.Name == entity.Name ) )
                ThrowRepeatException( entity.Name );
        }

        /// <summary>
        /// 抛出重复异常
        /// </summary>
        private void ThrowRepeatException( string name ) {
            throw new Warning( string.Format( CommonResource.IconCategoryRepeat, name ) );
        }

        #endregion

        #region UpdateBefore(修改前操作)

        /// <summary>
        /// 修改前操作
        /// </summary>
        protected override void UpdateBefore( IconCategory newEntity, IconCategory oldEntity ) {
            base.UpdateBefore( newEntity, oldEntity );
            if ( Repository.Exists( t => t.Id != newEntity.Id && t.Name == newEntity.Name ) )
                ThrowRepeatException( newEntity.Name );
        }

        #endregion
    }
}