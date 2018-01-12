using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains;

namespace Applications.Domains.Security.Models {
    /// <summary>
    /// 应用程序
    /// </summary>
    public class Application : AggregateRoot {
        /// <summary>
        /// 初始化应用程序
        /// </summary>
        public Application() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化应用程序
        /// </summary>
        /// <param name="id">应用程序标识</param>
        public Application( Guid id ) : base( id ) {
        }

        /// <summary>
        /// 应用程序编码
        /// </summary>
        [Required( ErrorMessageResourceType = typeof( SecurityResource ), ErrorMessageResourceName = "ApplicationCodeIsEmpty" )]
        [StringLength( 10, ErrorMessage = "应用程序编码输入过长，不能超过10位" )]
        public string Code { get; set; }

        /// <summary>
        /// 应用程序名称
        /// </summary>
        [Required( ErrorMessage = "应用程序名称不能为空" )]
        [StringLength( 30, ErrorMessage = "应用程序名称输入过长，不能超过30位" )]
        public string Name { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 100, ErrorMessage = "备注输入过长，不能超过100位" )]
        public string Note { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public override void Init() {
            base.Init();
            if( CreateTime == null )
                CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( "应用程序编号", Id );
            AddDescription( "应用程序编码", Code );
            AddDescription( "应用程序名称", Name );
            AddDescription( "备注", Note );
            AddDescription( "启用", Enabled.Description() );
            AddDescription( "创建时间", CreateTime );
        }
    }
}
