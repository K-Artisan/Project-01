using System;

namespace Applications.Services.Configs {
    /// <summary>
    /// 系统信息
    /// </summary>
    public class SystemInfo {
        /// <summary>
        /// 机构编号
        /// </summary>
        public Guid OrganizationId { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string Organization { get; set; }
    }
}
