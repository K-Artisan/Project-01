using System.Web.Mvc;

namespace Presentation.GridColumns {
    /// <summary>
    /// 表格列业务控件
    /// </summary>
    public partial class BusinessGridColumn<T> : IBusinessGridColumn<T> {
        /// <summary>
        /// 初始化表格列业务控件
        /// </summary>
        /// <param name="helper">HtmlHelper</param>
        public BusinessGridColumn( HtmlHelper<T> helper ) {
            _helper = helper;
        }

        /// <summary>
        /// HtmlHelper
        /// </summary>
        private readonly HtmlHelper<T> _helper;
    }
}
