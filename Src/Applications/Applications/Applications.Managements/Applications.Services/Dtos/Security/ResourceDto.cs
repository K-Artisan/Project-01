using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Applications.Domains.Security.Enums;
using Util.ApplicationServices;
using Util.Webs.EasyUi.Trees;

namespace Applications.Services.Dtos.Security {
    /// <summary>
    /// 资源数据传输对象
    /// </summary>
    [DataContract]
    public class ResourceDto : DtoBase,ITreeNode {
        /// <summary>
        /// 应用程序编号
        /// </summary>
        [Required(ErrorMessage = "应用程序不能为空")]
        [Display( Name = "应用程序" )]
        [DataMember]
        public Guid? ApplicationId { get; set; }
        
        /// <summary>
        /// 父编号
        /// </summary>
        [DataMember]
        public string ParentId { get; set; }
        
        /// <summary>
        /// 路径
        /// </summary>
        [Required(ErrorMessage = "路径不能为空")]
        [StringLength( 800, ErrorMessage = "路径输入过长，不能超过800位" )]
        [DataMember]
        public string Path { get; set; }
        
        /// <summary>
        /// 级数
        /// </summary>
        [Required(ErrorMessage = "级数不能为空")]
        [DataMember]
        public int? Level { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [DataMember]
        public string state { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        [DataMember]
        public List<ITreeNode> children { get; set; }

        /// <summary>
        /// 资源标识
        /// </summary>
        [Required(ErrorMessage = "资源标识不能为空")]
        [StringLength( 200, ErrorMessage = "资源标识输入过长，不能超过200位" )]
        [Display( Name = "资源标识" )]
        [DataMember]
        public string Uri { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [DataMember]
        public string Url { get; set; }
        
        /// <summary>
        /// 资源名称
        /// </summary>
        [Required(ErrorMessage = "资源名称不能为空")]
        [StringLength( 200, ErrorMessage = "资源名称输入过长，不能超过200位" )]
        [Display( Name = "资源名称" )]
        [DataMember]
        public string Name { get; set; }
        
        /// <summary>
        /// 资源类型
        /// </summary>
        [Required(ErrorMessage = "资源类型不能为空")]
        [Display( Name = "资源类型" )]
        [DataMember]
        public ResourceType? Type { get; set; }

        /// <summary>
        /// 小图标
        /// </summary>
        [StringLength( 50, ErrorMessage = "小图标输入过长，不能超过50位" )]
        [Display( Name = "小图标" )]
        [DataMember]
        public string SmallIcon { get; set; }

        /// <summary>
        /// 大图标
        /// </summary>
        [StringLength( 50, ErrorMessage = "大图标输入过长，不能超过50位" )]
        [Display( Name = "大图标" )]
        [DataMember]
        public string LargeIcon { get; set; }
        
        /// <summary>
        /// 扩展
        /// </summary>
        [Display( Name = "扩展" )]
        [DataMember]
        public string Extend { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        [StringLength( 100, ErrorMessage = "备注输入过长，不能超过100位" )]
        [Display( Name = "备注" )]
        [DataMember]
        public string Note { get; set; }
        
        /// <summary>
        /// 拼音简码
        /// </summary>
        [Required(ErrorMessage = "拼音简码不能为空")]
        [StringLength( 30, ErrorMessage = "拼音简码输入过长，不能超过30位" )]
        [Display( Name = "拼音简码" )]
        [DataMember]
        public string PinYin { get; set; }
        
        /// <summary>
        /// 启用
        /// </summary>
        [Required(ErrorMessage = "启用不能为空")]
        [Display( Name = "启用" )]
        [DataMember]
        public bool Enabled { get; set; }
        
        /// <summary>
        /// 排序号
        /// </summary>
        [Display( Name = "排序号" )]
        [DataMember]
        public int? SortId { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "创建时间不能为空")]
        [Display( Name = "创建时间" )]
        [DataMember]
        public DateTime? CreateTime { get; set; }
        
        /// <summary>
        /// 版本号
        /// </summary>
        [DataMember]
        public Byte[] Version { get; set; }
        
        /// <summary>
        /// 输出资源状态
        /// </summary>
        public override string ToString() {
            return this.ToEntity().ToString();
        }
    }
}
