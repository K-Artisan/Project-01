using Applications.Domains.Security.Queries;
using Applications.Services.Contracts.Security;
using Applications.Services.Dtos.Security;
using Presentation.Base;

namespace Presentation.Areas.Systems.Controllers {
    /// <summary>
    /// 应用程序控制器
    /// </summary>
    public class Application2Controller : FormControllerBase<ApplicationDto, ApplicationQuery> {
        /// <summary>
        /// 初始化应用程序控制器
        /// </summary>
        /// <param name="applicationService">应用程序服务</param>
        public Application2Controller( IApplicationService applicationService )
            : base( applicationService ) {
        }
    }
}
