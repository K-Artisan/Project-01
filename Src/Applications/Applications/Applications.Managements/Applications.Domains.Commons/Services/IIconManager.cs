using System;
using System.Collections.Generic;
using Applications.Domains.Commons.Models;
using Util.Domains;

namespace Applications.Domains.Commons.Services {
    /// <summary>
    /// 图标管理器
    /// </summary>
    public interface IIconManager : IDomainService {
        /// <summary>
        /// 上传图标
        /// </summary>
        /// <param name="categoryId">图标分类编号</param>
        /// <param name="uploadIconPath">上传图标的路径</param>
        /// <param name="cssPath">图标Css的路径</param>
        Icon Upload( Guid categoryId, string uploadIconPath, string cssPath );
        /// <summary>
        /// 删除图标
        /// </summary>
        /// <param name="ids">图标编号集合</param>
        /// <param name="cssPath">图标Css的路径</param>
        List<Icon> Delete( List<Guid> ids, string cssPath );
    }
}
