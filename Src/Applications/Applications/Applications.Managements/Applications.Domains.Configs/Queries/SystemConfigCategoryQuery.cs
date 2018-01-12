using System;
using System.ComponentModel.DataAnnotations;
using Util.Domains.Repositories;

namespace Applications.Domains.Configs.Queries {
    /// <summary>
    /// 系统配置分类查询实体
    /// </summary>
    public class SystemConfigCategoryQuery : Pager {
        /// <summary>
        /// 配置分类编号
        /// </summary>
        [Display(Name="配置分类编号")]
        public Guid? CategoryId { get; set; }
        
        private string _name = string.Empty;
        /// <summary>
        /// 分类名称
        /// </summary>
        [Display(Name="分类名称")]
        public string Name {
            get { return _name == null ? string.Empty : _name.Trim(); }
            set{ _name=value;}
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
        /// 排序号
        /// </summary>
        [Display(Name="排序号")]
        public int? SortId { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            base.AddDescriptions();
            AddDescription( "配置分类编号", CategoryId ); 
            AddDescription( "分类名称", Name ); 
            AddDescription( "起始创建时间", BeginCreateTime );
            AddDescription( "结束创建时间", EndCreateTime );
            AddDescription( "排序号", SortId ); 
        } 
    }
}
