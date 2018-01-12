using Applications.Domains.Security.Queries;
using Applications.Services.Contracts.Security;
using Applications.Services.Dtos.Security;
using Presentation.Base;

namespace Presentation.Areas.Systems.Controllers {
    /// <summary>
    /// 资源控制器
    /// </summary>
    public class ResourceController : TreeGridControllerBase<ResourceDto, ResourceQuery> {
        /// <summary>
        /// 初始化资源控制器
        /// </summary>
        /// <param name="service">资源服务</param>
        public ResourceController( IResourceService service ) 
            : base( service ) {
            Service = service;
        }

        /// <summary>
        /// 资源服务
        /// </summary>
        public new IResourceService Service { get; private set; }
    }
}