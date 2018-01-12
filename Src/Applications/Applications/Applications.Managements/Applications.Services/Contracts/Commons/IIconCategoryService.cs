using Applications.Domains.Commons.Queries;
using Applications.Services.Dtos.Commons;
using Util.ApplicationServices;

namespace Applications.Services.Contracts.Commons {
    /// <summary>
    /// 图标分类服务
    /// </summary>
    public interface IIconCategoryService : IBatchService<IconCategoryDto, IconCategoryQuery> {
    }
}