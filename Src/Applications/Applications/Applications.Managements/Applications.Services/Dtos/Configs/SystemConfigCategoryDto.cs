using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util.ApplicationServices;

namespace Applications.Services.Dtos.Configs {
    /// <summary>
    /// 系统配置分类数据传输对象
    /// </summary>
    [DataContract]
    public class SystemConfigCategoryDto : DtoBase {
        /// <summary>
        /// 分类名称
        /// </summary>
        [Required(ErrorMessage = "分类名称不能为空")]
        [StringLength( 50, ErrorMessage = "分类名称输入过长，不能超过50位" )]
        [Display( Name = "分类名称" )]
        [DataMember]
        public string Name { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required(ErrorMessage = "创建时间不能为空")]
        [Display( Name = "创建时间" )]
        [DataMember]
        public DateTime CreateTime { get; set; }
        
        /// <summary>
        /// 排序号
        /// </summary>
        [Required(ErrorMessage = "排序号不能为空")]
        [Display( Name = "排序号" )]
        [DataMember]
        public int? SortId { get; set; }
        
        /// <summary>
        /// 版本号
        /// </summary>
        [Display( Name = "版本号" )]
        [DataMember]
        public Byte[] Version { get; set; }
        
        /// <summary>
        /// 输出系统配置分类状态
        /// </summary>
        public override string ToString() {
            return this.ToEntity().ToString();
        }
    }
}
