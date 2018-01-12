using System;
using System.ComponentModel.DataAnnotations;
using Util.Domains;

namespace Applications.Domains.Configs.Models {
    /// <summary>
    /// 系统配置
    /// </summary>
    public partial class SystemConfig : AggregateRoot{
        /// <summary>
        /// 初始化系统配置
        /// </summary>
        public SystemConfig() : this( Guid.Empty ) {
        }

        /// <summary>
        /// 初始化系统配置
        /// </summary>
        /// <param name="id">系统配置标识</param>
        public SystemConfig( Guid id ) : base( id ) {
        }
        
        /// <summary>
        /// 编码
        /// </summary>
        [Required( ErrorMessage = "编码不能为空" )]
        [StringLength( 10, ErrorMessage = "编码输入过长，不能超过10位" )]
        public string Code { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [Required(ErrorMessage = "值不能为空")]
        [StringLength( 200, ErrorMessage = "值输入过长，不能超过200位" )]
        public string Value { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength( 200, ErrorMessage = "描述输入过长，不能超过200位" )]
        public string Description { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "创建时间不能为空")]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 配置分类编号
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// 系统配置分类
        /// </summary>
        public virtual SystemConfigCategory SystemConfigCategory { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( "配置编号", Id );
            AddDescription( "配置分类编号", CategoryId ); 
            AddDescription( "编码", Code ); 
            AddDescription( "值", Value ); 
            AddDescription( "描述", Description ); 
            AddDescription( "创建时间", CreateTime ); 
        } 
    }
}