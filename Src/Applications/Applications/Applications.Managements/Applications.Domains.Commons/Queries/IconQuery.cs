using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains.Repositories;

namespace Applications.Domains.Commons.Queries {
    /// <summary>
    /// 图标查询实体
    /// </summary>
    public class IconQuery : Pager {        
        /// <summary>
        /// 图标编号
        /// </summary>
        [Display(Name="图标编号")]
        public Guid? IconId { get; set; }

        private Guid? _categoryId;
        /// <summary>
        /// 图标分类
        /// </summary>
        [Display(Name="图标分类")]
        public Guid? CategoryId {
            get { return _categoryId.SafeValue() == Guid.Empty ? null : _categoryId; }
            set { _categoryId = value; }
        }
        
        /// <summary>
        /// 租户编号
        /// </summary>
        [Display(Name="租户编号")]
        public Guid? TenantId { get; set; }
        
        private string _name = string.Empty; 
        /// <summary>
        /// 图标名称
        /// </summary>
        [Display(Name="图标名称")]
        public string Name {
            get { return _name == null ? string.Empty : _name.Trim(); }
            set{ _name=value;}
        }
        
        private string _path = string.Empty; 
        /// <summary>
        /// 图标路径
        /// </summary>
        [Display(Name="图标路径")]
        public string Path {
            get { return _path == null ? string.Empty : _path.Trim(); }
            set{ _path=value;}
        }
        
        private string _className = string.Empty; 
        /// <summary>
        /// 类名
        /// </summary>
        [Display(Name="类名")]
        public string ClassName {
            get { return _className == null ? string.Empty : _className.Trim(); }
            set{ _className=value;}
        }
        
        /// <summary>
        /// 最小图标容量
        /// </summary>
        [Display( Name = "最小容量(B)" )]
        public int? MinSize { get; set; }

        /// <summary>
        /// 最大图标容量
        /// </summary>
        [Display( Name = "最大容量(B)" )]
        public int? MaxSize { get; set; }
        
        /// <summary>
        /// 宽度
        /// </summary>
        [Display(Name="宽度")]
        public int? Width { get; set; }
        
        /// <summary>
        /// 高度
        /// </summary>
        [Display(Name="高度")]
        public int? Height { get; set; }
        
        private string _css = string.Empty; 
        /// <summary>
        /// Css代码
        /// </summary>
        [Display(Name="Css代码")]
        public string Css {
            get { return _css == null ? string.Empty : _css.Trim(); }
            set{ _css=value;}
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
            AddDescription( "图标编号", IconId ); 
            AddDescription( "图标分类编号", CategoryId ); 
            AddDescription( "租户编号", TenantId ); 
            AddDescription( "图标名称", Name ); 
            AddDescription( "图标路径", Path ); 
            AddDescription( "类名", ClassName );
            AddDescription( "最小图标容量", MinSize );
            AddDescription( "最大图标容量", MaxSize ); 
            AddDescription( "宽度", Width ); 
            AddDescription( "高度", Height ); 
            AddDescription( "Css代码", Css ); 
            AddDescription( "起始创建时间", BeginCreateTime );
            AddDescription( "结束创建时间", EndCreateTime );
        } 
    }
}
