using System;
using System.Linq.Expressions;
using Util.Webs.EasyUi;
using Util.Webs.EasyUi.Configs;
using Util.Webs.EasyUi.Grids;

namespace Presentation.GridColumns {
    /// <summary>
    /// 表格列业务控件 - 公共控件
    /// </summary>
    public partial class BusinessGridColumn<T> {
        /// <summary>
        /// 字典控件
        /// </summary>
        /// <param name="expression">属性表达式</param>
        /// <param name="code">字典编码</param>
        public IDataGridColumn Dic<TProperty>( Expression<Func<T, TProperty>> expression, string code ) {
            return EasyUiFactory<T>.CreateDataGridColumn( expression, _helper, true ).ComboTree( "/Commons/Dic/DicControl?code=" + code ).Editable( false ).Width( 150 ).PanelHeight();
        }

        /// <summary>
        /// 图标控件
        /// </summary>
        /// <typeparam name="TProperty">属性类型</typeparam>
        /// <param name="expression">属性表达式</param>
        /// <param name="dialogWidth">选择图标窗口宽度</param>
        /// <param name="dialogHeight">选择图标窗口高度</param>
        public IDataGridColumn Icon<TProperty>( Expression<Func<T, TProperty>> expression, int? dialogWidth = null,int? dialogHeight = null ) {
            return EasyUiFactory<T>.CreateDataGridColumn( expression, _helper, true ).Lookup( CreateLookupOption( dialogWidth, dialogHeight ) )
                .Width( 150 ).Align( AlignLeftRigthCenter.Center, AlignLeftRigthCenter.Center ).FormatImage( 16, 16, true );
        }

        /// <summary>
        /// 创建查找带回配置项
        /// </summary>
        private LookupOption CreateLookupOption( int? dialogWidth ,int? dialogHeight) {
            return new LookupOption {
                Url = "/Commons/Icon/IconsControl",
                Title = "选择图标",
                Icon = "icon-rainbow",
                Editable = false,
                Width = dialogWidth ?? 920,
                Height = dialogHeight
            };
        }
    }
}
