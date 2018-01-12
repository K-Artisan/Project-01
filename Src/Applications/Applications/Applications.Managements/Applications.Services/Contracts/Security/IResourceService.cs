using Applications.Domains.Security.Queries;
using Applications.Services.Dtos.Security;
using Util.ApplicationServices;

namespace Applications.Services.Contracts.Security {
    /// <summary>
    /// 资源服务
    /// </summary>
    public interface IResourceService : ITreeBatchService<ResourceDto, ResourceQuery> {
    }
}