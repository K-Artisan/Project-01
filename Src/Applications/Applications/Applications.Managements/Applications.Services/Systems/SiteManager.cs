using System.Collections.Generic;
using Applications.Domains.Systems.Services;
using Util;

namespace Applications.Services.Systems {
    /// <summary>
    /// 站点管理器
    /// </summary>
    public class SiteManager : SiteManagerBase{
        /// <summary>
        /// 获取皮肤列表
        /// </summary>
        public override List<Item> GetSkins() {
            return new List<Item> {
                new Item("default","default"),
                new Item("bootstrap","bootstrap"),
                new Item("black","black"),
                new Item("gray","gray"),
                new Item("metro","metro")
            };
        }

        /// <summary>
        /// 获取菜单样式列表
        /// </summary>
        public override List<Item> GetMenuStyles() {
            return new List<Item> {
                new Item("横向菜单","HorizontalMenus"),
                new Item("一级横向菜单+手风琴","HorizontalMenus_Accordion")
            };
        }
    }
}
