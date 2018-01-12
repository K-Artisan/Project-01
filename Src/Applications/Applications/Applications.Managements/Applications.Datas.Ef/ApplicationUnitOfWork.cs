using System.Data.Entity;
using Util.Datas.Ef;

namespace Applications.Datas.Ef {
    /// <summary>
    /// 应用程序工作单元
    /// </summary>
    public class ApplicationUnitOfWork : EfUnitOfWork, IApplicationUnitOfWork {
        /// <summary>
        /// 初始化应用程序工作单元
        /// </summary>
        static ApplicationUnitOfWork() {
            Database.SetInitializer<ApplicationUnitOfWork>( null );
        }

        /// <summary>
        /// 初始化应用程序工作单元
        /// </summary>
        public ApplicationUnitOfWork()
            : base( "Application" ) { }
    }
}
