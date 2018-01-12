using Applications.Domains.Configs.Queries;
using Applications.Services.Dtos.Configs;
using Util.ApplicationServices;

namespace Applications.Services.Contracts.Configs {
    /// <summary>
    /// 系统配置服务
    /// </summary>
    public interface ISystemConfigService : IBatchService<SystemConfigDto, SystemConfigQuery> {
    }
}