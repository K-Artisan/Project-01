using Applications.Domains.Commons.Queries;
using Applications.Services.Dtos.Commons;
using Util.ApplicationServices;

namespace Applications.Services.Contracts.Commons {
    /// <summary>
    /// 图标服务
    /// </summary>
    public interface IIconService : IServiceBase<IconDto, IconQuery> {
        /// <summary>
        /// 上传图标
        /// </summary>
        /// <param name="categoryId">图标分类编号</param>
        void Upload( string categoryId );
    }
}