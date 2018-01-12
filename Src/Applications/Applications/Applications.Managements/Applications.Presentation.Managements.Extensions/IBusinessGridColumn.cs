using System;
using System.Linq.Expressions;
using Util.Webs.EasyUi.Grids;

namespace Presentation {
    /// <summary>
    /// 表格列业务控件
    /// </summary>
    public interface IBusinessGridColumn<T> {
        /// <summary>
        /// 字典控件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        /// <param name="code">字典编码</param>
        IDataGridColumn Dic<TProperty>( Expression<Func<T, TProperty>> expression, string code );
        /// <summary>
        /// 图标控件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        /// <param name="dialogWidth">选择图标窗口宽度</param>
        /// <param name="dialogHeight">选择图标窗口高度</param>
        IDataGridColumn Icon<TProperty>( Expression<Func<T, TProperty>> expression, int? dialogWidth = null, int? dialogHeight = null );
        /// <summary>
        /// 应用程序控件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        IDataGridColumn Application<TProperty>( Expression<Func<T, TProperty>> expression );
    }
}
