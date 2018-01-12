using System;
using System.ComponentModel.DataAnnotations;
using Applications.Domains.Security.Enums;
using Util.Domains;

namespace Applications.Domains.Security.Models {
    /// <summary>
    /// 资源
    /// </summary>
    public partial class Resource : TreeEntityBase<Resource> {
        /// <summary>
        /// 初始化资源
        /// </summary>
        public Resource()
            : this( Guid.Empty, "", 0 ) {
        }
        /// <summary>
        /// 初始化资源
        /// </summary>
        /// <param name="id">资源标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        public Resource( Guid id, string path, int level )
            : base( id, path,level ) {
        }

        /// <summary>
        /// 应用程序编号
        /// </summary>
        [Required(ErrorMessage = "应用程序编号不能为空")]
        public Guid? ApplicationId { get; set; }

        /// <summary>
        /// 资源标识
        /// </summary>
        [Required(ErrorMessage = "资源标识不能为空")]
        [StringLength( 200, ErrorMessage = "资源标识输入过长，不能超过200位" )]
        public string Uri { get; set; }

        /// <summary>
        /// 资源名称
        /// </summary>
        [Required(ErrorMessage = "资源名称不能为空")]
        [StringLength( 200, ErrorMessage = "资源名称输入过长，不能超过200位" )]
        public string Name { get; set; }

        /// <summary>
        /// 资源类型
        /// </summary>
        [Required(ErrorMessage = "资源类型不能为空")]
        public ResourceType? Type { get; set; }

        /// <summary>
        /// 小图标
        /// </summary>
        [StringLength( 50, ErrorMessage = "小图标输入过长，不能超过50位" )]
        public string SmallIcon { get; set; }
        /// <summary>
        /// 大图标
        /// </summary>
        [StringLength( 50, ErrorMessage = "大图标输入过长，不能超过50位" )]
        public string LargeIcon { get; set; }

        /// <summary>
        /// 扩展
        /// </summary>
        public string Extend { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 100, ErrorMessage = "备注输入过长，不能超过100位" )]
        public string Note { get; set; }

        /// <summary>
        /// 拼音简码
        /// </summary>
        [Required(ErrorMessage = "拼音简码不能为空")]
        [StringLength( 30, ErrorMessage = "拼音简码输入过长，不能超过30位" )]
        public string PinYin { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "创建时间不能为空")]
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 应用程序
        /// </summary>
        public virtual Application Application { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            base.AddDescriptions();
            AddDescription( "资源编号", Id );
            AddDescription( "应用程序编号", ApplicationId );
            AddDescription( "资源标识", Uri ); 
            AddDescription( "资源名称", Name ); 
            AddDescription( "资源类型", Type );
            AddDescription( "小图标", SmallIcon );
            AddDescription( "大图标", LargeIcon ); 
            AddDescription( "扩展", Extend ); 
            AddDescription( "备注", Note ); 
            AddDescription( "拼音简码", PinYin ); 
            AddDescription( "创建时间", CreateTime ); 
        }

        /// <summary>
        /// 创建空资源
        /// </summary>
        public static Resource Null {
            get { return new NullResource();}
        }
    }
}