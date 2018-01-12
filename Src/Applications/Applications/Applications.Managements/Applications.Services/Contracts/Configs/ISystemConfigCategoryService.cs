using Applications.Domains.Configs.Queries;
using Applications.Services.Dtos.Configs;
using Util.ApplicationServices;

namespace Applications.Services.Contracts.Configs {
    /// <summary>
    /// 系统配置分类服务
    /// </summary>
    public interface ISystemConfigCategoryService : IBatchService<SystemConfigCategoryDto, SystemConfigCategoryQuery> {
    }
}