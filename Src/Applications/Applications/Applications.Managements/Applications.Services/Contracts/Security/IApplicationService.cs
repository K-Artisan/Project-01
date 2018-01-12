using System;
using System.Collections.Generic;
using Applications.Domains.Security.Queries;
using Applications.Services.Dtos.Security;
using Util.ApplicationServices;

namespace Applications.Services.Contracts.Security {
    /// <summary>
    /// 应用程序服务
    /// </summary>
    public interface IApplicationService : IBatchService<ApplicationDto, ApplicationQuery> {
        /// <summary>
        /// 导出
        /// </summary>
        void Export();
        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="ids">应用程序编号</param>
        void Enable( List<Guid> ids );
        /// <summary>
        /// 冻结
        /// </summary>
        /// <param name="ids">应用程序编号</param>
        void Disable( List<Guid> ids );
    }
}