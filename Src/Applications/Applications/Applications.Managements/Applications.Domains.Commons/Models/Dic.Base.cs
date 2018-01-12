using System;
using System.ComponentModel.DataAnnotations;
using Applications.Domains.Core;
using Util;

namespace Applications.Domains.Commons.Models {
    /// <summary>
    /// 字典
    /// </summary>
    public partial class Dic : TenantTreeAggregateRoot<Dic> {
        /// <summary>
        /// 初始化字典
        /// </summary>
        public Dic()
            : this( Guid.Empty, "", 0 ) {
        }

        /// <summary>
        /// 初始化字典
        /// </summary>
        /// <param name="id">字典标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        public Dic( Guid id, string path, int level )
            : base( id, path, level ) {
        }

        /// <summary>
        /// 编码
        /// </summary>
        [StringLength( 10, ErrorMessage = "编码输入过长，不能超过10位" )]
        public string Code { get; set; }

        /// <summary>
        /// 文本
        /// </summary>
        [Required( ErrorMessage = "文本不能为空" )]
        [StringLength( 50, ErrorMessage = "文本输入过长，不能超过50位" )]
        public string Text { get; set; }

        /// <summary>
        /// 拼音简码
        /// </summary>
        [Required( ErrorMessage = "拼音简码不能为空" )]
        [StringLength( 50, ErrorMessage = "拼音简码输入过长，不能超过50位" )]
        public string PinYin { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required( ErrorMessage = "创建时间不能为空" )]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( "字典编号", Id );
            AddDescription( "租户编号", TenantId );
            AddDescription( "父编号", ParentId );
            AddDescription( "编码", Code );
            AddDescription( "文本", Text );
            AddDescription( "路径", Path );
            AddDescription( "级数", Level );
            AddDescription( "排序号", SortId );
            AddDescription( "拼音简码", PinYin );
            AddDescription( "启用", Enabled.Description() );
            AddDescription( "创建时间", CreateTime );
        }
    }
}