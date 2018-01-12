using System;
using System.Collections.Generic;
using System.Linq;
using Applications.Domains.Security;
using Applications.Domains.Security.Models;
using Applications.Domains.Security.Queries;
using Applications.Domains.Security.Repositories;
using Applications.Services.Contracts.Security;
using Applications.Services.Dtos.Security;
using Util;
using Util.ApplicationServices;
using Util.Datas.Queries;
using Util.Domains.Repositories;
using Util.Exports;

namespace Applications.Services.Impl.Security {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public class ApplicationService : BatchService<Application, ApplicationDto, ApplicationQuery>, IApplicationService {

        #region 构造方法

        /// <summary>
        /// 初始化应用程序服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">应用程序仓储</param>
        /// <param name="exportFactory">文件导出操作工厂</param>
        public ApplicationService( IApplicationUnitOfWork unitOfWork, IApplicationRepository repository,
            IExportFactory exportFactory )
            : base( unitOfWork, repository ) {
            Repository = repository;
            ExportFactory = exportFactory;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 应用程序仓储
        /// </summary>
        protected new IApplicationRepository Repository { get; set; }

        /// <summary>
        /// 文件导出操作工厂
        /// </summary>
        protected IExportFactory ExportFactory { get; set; }

        #endregion

        #region 实体与Dto转换

        /// <summary>
        /// 转换为数据传输对象
        /// </summary>
        /// <param name="entity">实体</param>
        protected override ApplicationDto ToDto( Application entity ) {
            return entity.ToDto();
        }

        /// <summary>
        /// 转换为实体
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected override Application ToEntity( ApplicationDto dto ) {
            return dto.ToEntity();
        }

        #endregion

        #region SaveBefore(保存前操作)

        /// <summary>
        /// 保存前操作
        /// </summary>
        /// <param name="addList">新增列表</param>
        /// <param name="updateList">修改列表</param>
        /// <param name="deleteList">删除列表</param>
        protected override void SaveBefore( List<ApplicationDto> addList, List<ApplicationDto> updateList,
            List<ApplicationDto> deleteList ) {
            base.SaveBefore( addList, updateList, deleteList );
            Validate( addList );
            Validate( updateList );
        }

        /// <summary>
        /// 验证
        /// </summary>
        private void Validate( IEnumerable<ApplicationDto> list ) {
            foreach ( var each in list.GroupBy( t => t.Code ) ) {
                if ( each.Count() > 1 )
                    ThrowRepeatException( each.Key );
            }
        }

        /// <summary>
        /// 抛出编码重复异常
        /// </summary>
        private void ThrowRepeatException( string code ) {
            throw new Warning( string.Format( SecurityResource.ApplicationCodeRepeat, code ) );
        }

        #endregion

        #region AddBefore(添加前操作)

        /// <summary>
        /// 添加前操作
        /// </summary>
        protected override void AddBefore( Application entity ) {
            base.AddBefore( entity );
            if ( Repository.Exists( t => t.Code == entity.Code ) )
                ThrowRepeatException( entity.Code );
        }

        #endregion

        #region UpdateBefore(修改前操作)

        /// <summary>
        /// 修改前操作
        /// </summary>
        protected override void UpdateBefore( Application newEntity, Application oldEntity ) {
            base.UpdateBefore( newEntity, oldEntity );
            if ( Repository.Exists( t => t.Id != newEntity.Id && t.Code == newEntity.Code ) )
                ThrowRepeatException( newEntity.Code );
        }

        #endregion

        #region Create(创建应用程序)

        /// <summary>
        /// 创建应用程序
        /// </summary>
        public override ApplicationDto Create() {
            return new ApplicationDto { Enabled = true, CreateTime = DateTime.Now };
        }

        #endregion

        #region GetQuery(查询)

        /// <summary>
        /// 获取查询对象
        /// </summary>
        /// <param name="query">应用程序查询参数</param>
        public override IQueryBase<Application> GetQuery( ApplicationQuery query ) {
            return new Query<Application>( query )
                .Filter( t => t.Code == query.Code )
                .Filter( t => t.Name.Contains( query.Name ) )
                .Filter( t => t.Enabled == query.Enabled )
                .FilterDate( t => t.CreateTime, query.BeginCreateTime, query.EndCreateTime );
        }

        #endregion

        #region Export(导出)

        /// <summary>
        /// 导出
        /// </summary>
        public void Export() {
            IExport export = ExportFactory.Create( ExportFormat.Xlsx );
            export.ColumnWidth( 0, 30 ).ColumnWidth( 1, 42 ).ColumnWidth( 4, 100 )
                .Head( "应用程序管理" )
                .Head( "应用程序编码", "应用程序名称", "创建时间", "启用", "备注" )
                .Body( GetAll(), t => new object[] { t.Code, t.Name, t.CreateTime, t.Enabled, t.Note } )
                .Download();
        }

        #endregion

        #region Enable(启用冻结)

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">应用程序编号</param>
        public void Enable( List<Guid> ids ) {
            Enable( ids, true );
        }

        /// <summary>
        /// 启用
        /// </summary>
        private void Enable( IEnumerable<Guid> ids, bool isEnabled ) {
            UnitOfWork.Start();
            var entities = Repository.Find( ids );
            entities.ForEach( t => t.Enabled = isEnabled );
            UnitOfWork.Commit();
            WriteLog( GetCaption( isEnabled ), entities );
        }

        /// <summary>
        /// 获取标题
        /// </summary>
        private string GetCaption( bool isEnabled ) {
            return string.Format( "{0}应用程序成功", isEnabled ? "启用" : "禁用" );
        }

        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="ids">应用程序编号</param>
        public void Disable( List<Guid> ids ) {
            Enable( ids, false );
        }

        #endregion
    }
}