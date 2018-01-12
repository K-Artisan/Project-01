using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains.Repositories;

namespace Applications.Domains.Configs.Queries {
    /// <summary>
    /// 系统配置查询实体
    /// </summary>
    public class SystemConfigQuery : Pager {
        /// <summary>
        /// 配置编号
        /// </summary>
        [Display(Name="配置编号")]
        public Guid? ConfigId { get; set; }

        private Guid? _categoryId;
        /// <summary>
        /// 配置分类
        /// </summary>
        [Display( Name = "配置分类" )]
        public Guid? CategoryId {
            get { return _categoryId.SafeValue() == Guid.Empty ? null : _categoryId; }
            set { _categoryId = value; }
        }
        
        private string _code = string.Empty;
        /// <summary>
        /// 编码
        /// </summary>
        [Display(Name="编码")]
        public string Code {
            get { return _code == null ? string.Empty : _code.Trim(); }
            set{ _code=value;}
        }
        
        private string _value = string.Empty;
        /// <summary>
        /// 值
        /// </summary>
        [Display(Name="值")]
        public string Value {
            get { return _value == null ? string.Empty : _value.Trim(); }
            set{ _value=value;}
        }
        
        private string _description = string.Empty;
        /// <summary>
        /// 描述
        /// </summary>
        [Display(Name="描述")]
        public string Description {
            get { return _description == null ? string.Empty : _description.Trim(); }
            set{ _description=value;}
        }
        
        /// <summary>
        /// 起始创建时间
        /// </summary>
        [Display( Name = "起始创建时间" )]
        public DateTime? BeginCreateTime { get; set; }

        /// <summary>
        /// 结束创建时间
        /// </summary>
        [Display( Name = "结束创建时间" )]
        public DateTime? EndCreateTime { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            base.AddDescriptions();
            AddDescription( "配置编号", ConfigId ); 
            AddDescription( "配置分类编号", CategoryId ); 
            AddDescription( "编码", Code ); 
            AddDescription( "值", Value ); 
            AddDescription( "描述", Description ); 
            AddDescription( "起始创建时间", BeginCreateTime );
            AddDescription( "结束创建时间", EndCreateTime );
        } 
    }
}
