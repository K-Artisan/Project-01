using Applications.Domains.Commons.Models;
using Applications.Domains.Commons.Queries;
using Applications.Domains.Commons.Repositories;
using Applications.Domains.Commons.Services;
using Applications.Services.Configs;
using Applications.Services.Contracts.Commons;
using Applications.Services.Dtos.Commons;
using Util;
using Util.ApplicationServices;
using Util.Datas.Queries;
using Util.Domains.Repositories;

namespace Applications.Services.Impl.Commons {
    /// <summary>
    /// 图标服务
    /// </summary>
    public class IconService : ServiceBase<Icon, IconDto, IconQuery>, IIconService {

        #region 构造方法

        /// <summary>
        /// 初始化图标服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">图标仓储</param>
        /// <param name="iconManager">图标管理器</param>
        public IconService( IApplicationUnitOfWork unitOfWork, IIconRepository repository, IIconManager iconManager )
            : base( unitOfWork, repository ) {
            Repository = repository;
            IconManager = iconManager;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 图标仓储
        /// </summary>
        protected new IIconRepository Repository { get; set; }
        /// <summary>
        /// 图标管理器
        /// </summary>
        protected IIconManager IconManager { get; set; }

        #endregion

        #region 实体与Dto转换

        /// <summary>
        /// 转换为Dto
        /// </summary>
        /// <param name="entity">实体</param>
        protected override IconDto ToDto( Icon entity ) {
            return entity.ToDto();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected override Icon ToEntity( IconDto dto ) {
            return dto.ToEntity();
        }

        #endregion

        #region GetQuery(查询)

        /// <summary>
        /// 获取查询对象
        /// </summary>
        /// <param name="query">图标查询参数</param>
        public override IQueryBase<Icon> GetQuery( IconQuery query ) {
            return new Query<Icon>( query )
                .Filter( t => t.CategoryId == query.CategoryId )
                .Filter( t => t.Name.Contains( query.Name ) )
                .Filter( t => t.ClassName.Contains( query.ClassName ) )
                .Filter( t => t.Width == query.Width )
                .Filter( t => t.Height == query.Height )
                .FilterInt( t => t.Size,query.MinSize,query.MaxSize )
                .FilterDate( t => t.CreateTime,query.BeginCreateTime,query.EndCreateTime );
        }

        #endregion

        #region Upload(上传图标)

        /// <summary>
        /// 上传图标
        /// </summary>
        /// <param name="categoryId">图标分类编号</param>
        public void Upload( string categoryId ) {
            UnitOfWork.Start();
            var result = IconManager.Upload( categoryId.ToGuid(), ConfigInfo.UploadIconPath, ConfigInfo.CssPath );
            UnitOfWork.Commit();
            WriteLog( "上传图标成功",result );
        }

        #endregion

        #region Delete(删除图标)

        /// <summary>
        /// 删除图标
        /// </summary>
        /// <param name="ids">图标编号集合</param>
        public override void Delete( string ids ) {
            UnitOfWork.Start();
            var result = IconManager.Delete( ids.ToGuidList(), ConfigInfo.CssPath );
            UnitOfWork.Commit();
            WriteLog( "删除图标成功", result );
        }

        #endregion
    }
}