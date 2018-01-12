CREATE SCHEMA application;
use application;
SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for commons.areas
-- ----------------------------
DROP TABLE IF EXISTS `commons.areas`;
CREATE TABLE `commons.areas` (
  `AreaId` char(36) NOT NULL COMMENT '地区编号',
  `ParentId` char(36) DEFAULT NULL COMMENT '父编号',
  `Code` varchar(10) NOT NULL COMMENT '编码',
  `Text` varchar(200) NOT NULL COMMENT '地区名称',
  `Path` varchar(800) NOT NULL COMMENT '路径',
  `Level` int(11) NOT NULL COMMENT '级数',
  `SortId` int(11) NOT NULL COMMENT '排序号',
  `PinYin` varchar(200) NOT NULL COMMENT '拼音简码',
  `FullPinYin` varchar(500) DEFAULT NULL COMMENT '全拼',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `Version` tinyblob COMMENT '版本号',
  PRIMARY KEY (`AreaId`),
  KEY `cls_idx_sortid` (`SortId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='地区';

-- ----------------------------
-- Table structure for commons.dics
-- ----------------------------
DROP TABLE IF EXISTS `commons.dics`;
CREATE TABLE `commons.dics` (
  `DicId` char(36) NOT NULL COMMENT '字典编号',
  `TenantId` char(36) DEFAULT NULL COMMENT '租户编号',
  `ParentId` char(36) DEFAULT NULL COMMENT '父编号',
  `Code` varchar(10) DEFAULT NULL COMMENT '编码',
  `Text` varchar(50) NOT NULL COMMENT '文本',
  `Path` varchar(800) NOT NULL COMMENT '路径',
  `Level` int(11) NOT NULL COMMENT '级数',
  `SortId` int(11) NOT NULL COMMENT '排序号',
  `PinYin` varchar(50) NOT NULL COMMENT '拼音简码',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `Version` tinyblob COMMENT '版本号',
  PRIMARY KEY (`DicId`),
  KEY `cls_idx_sortid` (`SortId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='字典';

-- ----------------------------
-- Table structure for commons.iconcategories
-- ----------------------------
DROP TABLE IF EXISTS `commons.iconcategories`;
CREATE TABLE `commons.iconcategories` (
  `CategoryId` char(36) NOT NULL COMMENT '图标分类编号',
  `TenantId` char(36) DEFAULT NULL COMMENT '租户编号',
  `Name` varchar(50) NOT NULL COMMENT '分类名称',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `SortId` int(11) NOT NULL COMMENT '排序号',
  `Version` tinyblob COMMENT '版本号',
  PRIMARY KEY (`CategoryId`),
  KEY `cls_idx_createtime` (`CreateTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='图标分类';

-- ----------------------------
-- Table structure for commons.icons
-- ----------------------------
DROP TABLE IF EXISTS `commons.icons`;
CREATE TABLE `commons.icons` (
  `IconId` char(36) NOT NULL COMMENT '图标编号',
  `CategoryId` char(36) DEFAULT NULL COMMENT '图标分类编号',
  `TenantId` char(36) DEFAULT NULL COMMENT '租户编号',
  `Name` varchar(100) NOT NULL COMMENT '图标名称',
  `Path` varchar(200) DEFAULT NULL COMMENT '图标路径',
  `ClassName` varchar(100) NOT NULL COMMENT '类名',
  `Size` int(11) NOT NULL COMMENT '图标大小',
  `Width` int(11) NOT NULL COMMENT '宽度',
  `Height` int(11) NOT NULL COMMENT '高度',
  `Css` varchar(500) NOT NULL COMMENT 'Css代码',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `Version` tinyblob COMMENT '版本号',
  PRIMARY KEY (`IconId`),
  KEY `cls_idx_createtime` (`CreateTime`),
  KEY `FK_Icons_IconCategories` (`CategoryId`),
  CONSTRAINT `FK_Icons_IconCategories` FOREIGN KEY (`CategoryId`) REFERENCES `commons.iconcategories` (`CategoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='图标';

-- ----------------------------
-- Table structure for configs.systemconfigcategories
-- ----------------------------
DROP TABLE IF EXISTS `configs.systemconfigcategories`;
CREATE TABLE `configs.systemconfigcategories` (
  `CategoryId` char(36) NOT NULL COMMENT '配置分类编号',
  `Name` varchar(50) NOT NULL COMMENT '分类名称',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `SortId` int(11) NOT NULL COMMENT '排序号',
  `Version` tinyblob COMMENT '版本号',
  PRIMARY KEY (`CategoryId`),
  KEY `cls_idx_sortid` (`SortId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系统配置分类';

-- ----------------------------
-- Table structure for configs.systemconfigs
-- ----------------------------
DROP TABLE IF EXISTS `configs.systemconfigs`;
CREATE TABLE `configs.systemconfigs` (
  `ConfigId` char(36) NOT NULL COMMENT '配置编号',
  `CategoryId` char(36) NOT NULL COMMENT '配置分类编号',
  `Code` varchar(10) NOT NULL COMMENT '编码',
  `Value` varchar(200) NOT NULL COMMENT '值',
  `Description` varchar(200) DEFAULT NULL COMMENT '描述',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `Version` tinyblob COMMENT '版本号',
  PRIMARY KEY (`ConfigId`),
  KEY `cls_idx_createtime` (`CreateTime`),
  KEY `FK_SystemConfigs_SystemConfigC` (`CategoryId`),
  CONSTRAINT `FK_SystemConfigs_SystemConfigC` FOREIGN KEY (`CategoryId`) REFERENCES `configs.systemconfigcategories` (`CategoryId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系统配置';

-- ----------------------------
-- Table structure for systems.applications
-- ----------------------------
DROP TABLE IF EXISTS `systems.applications`;
CREATE TABLE `systems.applications` (
  `ApplicationId` char(36) NOT NULL COMMENT '应用程序编号',
  `Code` varchar(10) NOT NULL COMMENT '应用程序编码',
  `Name` varchar(30) NOT NULL COMMENT '应用程序名称',
  `Note` varchar(100) DEFAULT NULL COMMENT '备注',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `Version` tinyblob COMMENT '版本号',
  PRIMARY KEY (`ApplicationId`),
  KEY `clus_idx_createtime` (`CreateTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='应用程序';


-- ----------------------------
-- Table structure for systems.resources
-- ----------------------------
DROP TABLE IF EXISTS `systems.resources`;
CREATE TABLE `systems.resources` (
  `ResourceId` char(36) NOT NULL COMMENT '资源编号',
  `ApplicationId` char(36) NOT NULL COMMENT '应用程序编号',
  `ParentId` char(36) DEFAULT NULL COMMENT '父编号',
  `Path` varchar(800) NOT NULL COMMENT '路径',
  `Level` int(11) NOT NULL COMMENT '级数',
  `Uri` varchar(200) NOT NULL COMMENT '资源标识',
  `Name` varchar(200) NOT NULL COMMENT '资源名称',
  `Type` int(11) NOT NULL COMMENT '资源类型',
  `SmallIcon` varchar(50) DEFAULT NULL COMMENT '小图标',
  `LargeIcon` varchar(50) DEFAULT NULL COMMENT '大图标',
  `Note` varchar(100) DEFAULT NULL COMMENT '备注',
  `PinYin` varchar(30) NOT NULL COMMENT '拼音简码',
  `Enabled` tinyint(1) NOT NULL COMMENT '启用',
  `SortId` int(11) DEFAULT NULL COMMENT '排序号',
  `CreateTime` datetime NOT NULL COMMENT '创建时间',
  `Extend` longblob COMMENT '扩展',
  `Discriminator` varchar(128) DEFAULT NULL COMMENT '鉴别类型',
  `Version` tinyblob COMMENT '版本号',
  PRIMARY KEY (`ResourceId`),
  KEY `cls_idx_sortid` (`SortId`),
  KEY `FK_Resources_Applications` (`ApplicationId`),
  CONSTRAINT `FK_Resources_Applications` FOREIGN KEY (`ApplicationId`) REFERENCES `systems.applications` (`ApplicationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='资源';



