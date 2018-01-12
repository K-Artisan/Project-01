using System.Data.Entity;
using Util.Datas.MySql;

namespace Applications.Datas.Ef.MySql {
    /// <summary>
    /// MySql应用程序工作单元
    /// </summary>
    public class MySqlApplicationUnitOfWork : MySqlUnitOfWork, IApplicationUnitOfWork {
        /// <summary>
        /// 初始化MySql应用程序工作单元
        /// </summary>
        static MySqlApplicationUnitOfWork() {
            Database.SetInitializer<MySqlApplicationUnitOfWork>( null );
        }

        /// <summary>
        /// 初始化MySql应用程序工作单元
        /// </summary>
        public MySqlApplicationUnitOfWork()
            : base( "Application_MySql" ) { }
    }
}
