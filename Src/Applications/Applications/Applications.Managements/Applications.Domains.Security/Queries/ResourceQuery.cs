using System;
using System.ComponentModel.DataAnnotations;
using Util;
using Util.Domains;

namespace Applications.Domains.Security.Queries {
    /// <summary>
    /// 资源查询实体
    /// </summary>
    public class ResourceQuery : TreeEntityQuery {        
        /// <summary>
        /// 资源编号
        /// </summary>
        [Display(Name="资源编号")]
        public Guid? ResourceId { get; set; }
        
        /// <summary>
        /// 应用程序编号
        /// </summary>
        [Display(Name="应用程序编号")]
        public Guid? ApplicationId { get; set; }
        
        private string _uri = string.Empty; 
        /// <summary>
        /// 资源标识
        /// </summary>
        [Display(Name="资源标识")]
        public string Uri {
            get { return _uri == null ? string.Empty : _uri.Trim(); }
            set{ _uri=value;}
        }
        
        private string _name = string.Empty; 
        /// <summary>
        /// 资源名称
        /// </summary>
        [Display(Name="资源名称")]
        public string Name {
            get { return _name == null ? string.Empty : _name.Trim(); }
            set{ _name=value;}
        }
        
        /// <summary>
        /// 资源类型
        /// </summary>
        [Display(Name="资源类型")]
        public Guid? Type { get; set; }
        
        private string _note = string.Empty; 
        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name="备注")]
        public string Note {
            get { return _note == null ? string.Empty : _note.Trim(); }
            set{ _note=value;}
        }
        
        private string _pinYin = string.Empty; 
        /// <summary>
        /// 拼音简码
        /// </summary>
        [Display(Name="拼音简码")]
        public string PinYin {
            get { return _pinYin == null ? string.Empty : _pinYin.Trim(); }
            set{ _pinYin=value;}
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
            AddDescription( "资源编号", ResourceId ); 
            AddDescription( "应用程序编号", ApplicationId ); 
            AddDescription( "资源标识", Uri ); 
            AddDescription( "资源名称", Name ); 
            AddDescription( "资源类型", Type ); 
            AddDescription( "备注", Note ); 
            AddDescription( "拼音简码", PinYin ); 
            AddDescription( "启用", Enabled.Description() ); 
            AddDescription( "起始创建时间", BeginCreateTime );
            AddDescription( "结束创建时间", EndCreateTime );
        }

        /// <summary>
        /// 检查参数是否为空
        /// </summary>
        protected override void CheckEmpty() {
            base.CheckEmpty();
            AddValue( ResourceId );
            AddValue( ApplicationId );
            AddValue( Uri );
            AddValue( Name );
            AddValue( Type );
            AddValue( Note );
            AddValue( PinYin );
            AddValue( Enabled );
            AddValue( BeginCreateTime );
            AddValue( EndCreateTime );
        }
    }
}
