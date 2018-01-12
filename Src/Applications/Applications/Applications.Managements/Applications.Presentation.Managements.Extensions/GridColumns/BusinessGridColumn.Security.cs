using System;
using System.Linq.Expressions;
using Util.Webs.EasyUi;
using Util.Webs.EasyUi.Grids;

namespace Presentation.GridColumns {
    /// <summary>
    /// 表格列业务控件 - 权限控件
    /// </summary>
    public partial class BusinessGridColumn<T> {
        /// <summary>
        /// 应用程序控件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        public IDataGridColumn Application<TProperty>( Expression<Func<T, TProperty>> expression ) {
            return EasyUiFactory<T>.CreateDataGridColumn( expression, _helper, true ).Combox( "/Systems/Application/ApplicationsControl" ).Editable( false ).Width( 120 ).PanelHeight();
        }
    }
}
