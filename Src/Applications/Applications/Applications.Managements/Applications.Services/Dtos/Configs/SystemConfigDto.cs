using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Util;
using Util.ApplicationServices;

namespace Applications.Services.Dtos.Configs {
    /// <summary>
    /// 系统配置数据传输对象
    /// </summary>
    [DataContract]
    public class SystemConfigDto : DtoBase {
        /// <summary>
        /// 配置分类编号
        /// </summary>
        [Display( Name = "配置分类" )]
        [DataMember]
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// 配置分类
        /// </summary>
        [Display( Name = "配置分类" )]
        [DataMember]
        public string CategoryName { get; set; }
        
        /// <summary>
        /// 编码
        /// </summary>
        [Required( ErrorMessage = "编码不能为空" )]
        [StringLength( 10, ErrorMessage = "编码输入过长，不能超过10位" )]
        [Display( Name = "编码" )]
        [DataMember]
        public string Code { get; set; }
        
        /// <summary>
        /// 值
        /// </summary>
        [Required(ErrorMessage = "值不能为空")]
        [StringLength( 200, ErrorMessage = "值输入过长，不能超过200位" )]
        [Display( Name = "值" )]
        [DataMember]
        public string Value { get; set; }
        
        /// <summary>
        /// 描述
        /// </summary>
        [StringLength( 200, ErrorMessage = "描述输入过长，不能超过200位" )]
        [Display( Name = "描述" )]
        [DataMember]
        public string Description { get; set; }
        
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
        [Display( Name = "版本号" )]
        [DataMember]
        public Byte[] Version { get; set; }
        
        /// <summary>
        /// 输出系统配置状态
        /// </summary>
        public override string ToString() {
            return this.ToEntity().ToString();
        }

        /// <summary>
        /// 获取分类名称
        /// </summary>
        public string GetCategoryName() {
            return CategoryName.IsEmpty() ? "请选择系统配置分类" : CategoryName;
        }
    }
}
