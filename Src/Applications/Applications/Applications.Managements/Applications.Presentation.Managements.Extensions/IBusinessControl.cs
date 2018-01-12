using System;
using System.Linq.Expressions;
using Presentation.Commons;
using Util.Webs.EasyUi.Forms.ComboTrees;

namespace Presentation {
    /// <summary>
    /// 业务控件
    /// </summary>
    public interface IBusinessControl<T> {
        /// <summary>
        /// 表格列业务控件
        /// </summary>
        IBusinessGridColumn<T> GridColumn();
        /// <summary>
        /// 字典控件
        /// </summary>
        /// <param name="name">控件name属性</param>
        /// <param name="code">字典编码</param>
        /// <param name="value">字典Id</param>
        IComboTree Dic( string name, string code,string value = "" );
        /// <summary>
        /// 字典控件
        /// </summary>
        /// <param name="expression">对象属性表达式</param>
        /// <param name="code">字典编码</param>
        IComboTree Dic<TProperty>( Expression<Func<T,TProperty>> expression,string code );
        /// <summary>
        /// 地区控件
        /// </summary>
        IAreaControl<T> Area();
    }
}
