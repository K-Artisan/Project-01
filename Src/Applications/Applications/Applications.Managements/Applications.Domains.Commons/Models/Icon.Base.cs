using System;
using System.ComponentModel.DataAnnotations;
using Applications.Domains.Core;
using Util;

namespace Applications.Domains.Commons.Models {
    /// <summary>
    /// 图标
    /// </summary>
    public partial class Icon : TenantAggregateRoot {
        /// <summary>
        /// 初始化图标
        /// </summary>
        public Icon()
            : this( Guid.Empty,"","" ) {
        }

        /// <summary>
        /// 初始化图标
        /// </summary>
        /// <param name="id">图标标识</param>
        /// <param name="className">类名</param>
        /// <param name="css">Css内容</param>
        public Icon( Guid id,string className,string css )
            : base( id ) {
            ClassName = className;
            Css = css;
        }
        
        /// <summary>
        /// 图标名称
        /// </summary>
        [Required( ErrorMessage = "图标名称不能为空" )]
        [StringLength( 100, ErrorMessage = "图标名称输入过长，不能超过100位" )]
        public string Name { get; set; }
        /// <summary>
        /// 图标路径
        /// </summary>
        [StringLength( 200, ErrorMessage = "图标路径输入过长，不能超过200位" )]
        public string Path { get; set; }
        /// <summary>
        /// 类名
        /// </summary>
        [Required( ErrorMessage = "类名不能为空" )]
        [StringLength( 100, ErrorMessage = "类名输入过长，不能超过100位" )]
        public string ClassName { get;private set; }
        /// <summary>
        /// 图标大小
        /// </summary>
        [Required( ErrorMessage = "图标大小不能为空" )]
        public int Size { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        [Required( ErrorMessage = "宽度不能为空" )]
        public int Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
        [Required( ErrorMessage = "高度不能为空" )]
        public int Height { get; set; }
        /// <summary>
        /// Css代码
        /// </summary>
        [Required( ErrorMessage = "Css代码不能为空" )]
        [StringLength( 500, ErrorMessage = "Css代码输入过长，不能超过500位" )]
        public string Css { get; private set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required( ErrorMessage = "创建时间不能为空" )]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( "图标编号", Id );
            AddDescription( "图标分类编号", CategoryId );
            AddDescription( "租户编号", TenantId );
            AddDescription( "图标名称", Name );
            AddDescription( "图标路径", Path );
            AddDescription( "类名", ClassName );
            AddDescription( "图标大小", GetSize() );
            AddDescription( "宽度", Width );
            AddDescription( "高度", Height );
            AddDescription( "Css代码", Css );
            AddDescription( "创建时间", CreateTime.ToDateTimeString() );
        }
    }
}