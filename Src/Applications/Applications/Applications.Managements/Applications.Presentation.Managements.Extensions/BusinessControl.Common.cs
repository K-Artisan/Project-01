using System;
using System.Linq.Expressions;
using Presentation.Commons;
using Util;
using Util.Webs;
using Util.Webs.EasyUi;
using Util.Webs.EasyUi.Forms.ComboTrees;

namespace Presentation {
    /// <summary>
    /// 业务控件 - 公共控件
    /// </summary>
    public partial class BusinessControl<T> {
        /// <summary>
        /// 字典控件
        /// </summary>
        /// <param name="name">控件name属性</param>
        /// <param name="code">字典编码</param>
        /// <param name="value">字典Id</param>
        public IComboTree Dic( string name, string code, string value = "" ) {
            return EasyUiFactory.CreateComboTree( name, "control_Commons_Dic", "/Commons/Dic/DicControl", value ).Params( new { code } ).Editable( false ).Width( 150 ).SelectLeafOnly();
        }

        /// <summary>
        /// 字典控件
        /// </summary>
        /// <param name="expression">对象属性表达式</param>
        /// <param name="code">字典编码</param>
        public IComboTree Dic<TProperty>( Expression<Func<T, TProperty>> expression, string code ) {
            var name = Lambda.GetName( expression );
            var value = _helper.Value( expression ).ToStr();
            return Dic( name, code, value );
        }

        /// <summary>
        /// 地区控件
        /// </summary>
        public IAreaControl<T> Area() {
            return new AreaControl<T>( _helper );
        }
    }
}
