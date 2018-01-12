/*========================================================== 1. 创建数据库 ===========================================================*/
USE [master]
GO

--删除数据库
EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'Log'
GO
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'Log')
Begin
DROP DATABASE [Log]
End
GO

--创建数据库
CREATE DATABASE [Log] CONTAINMENT = NONE ON  PRIMARY 
( NAME = N'Log', FILENAME = N'D:\DATA\Log.mdf' , SIZE = 5120KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Log_log', FILENAME = N'D:\DATA\Log_log.ldf' , SIZE = 2048KB , FILEGROWTH = 10%)
GO

/*========================================================== 2. 创建架构 ===========================================================*/
USE [Log]
GO

/* 1. 日志[Logs] */
IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'Logs')
DROP SCHEMA [Logs]
GO
CREATE SCHEMA [Logs] AUTHORIZATION [dbo]
GO

/*========================================================== 3. 创建表及索引 ===========================================================*/

/*==============================================*/
/* 操作日志( OperationLogs )                   */
/*============================================*/


if exists (select 1
            from  sysindexes
           where  id    = object_id('Logs.OperationLogs')
            and   name  = 'Time'
            and   indid > 0
            and   indid < 255)
   drop index Logs.OperationLogs.Time
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Logs.OperationLogs')
            and   type = 'U')
   drop table Logs.OperationLogs
go

/*==============================================================*/
/* Table: OperationLogs                                         */
/*==============================================================*/
create table Logs.OperationLogs (
   LogId                int                  identity,
   Level                nvarchar(10)         not null,
   TraceId              nvarchar(40)         not null,
   Time                 nvarchar(40)         not null,
   TotalSeconds         nvarchar(50)         null,
   Url                  nvarchar(4000)       null,
   BusinessId           nvarchar(40)         null,
   Application          nvarchar(100)        null,
   Tenant               nvarchar(100)        null,
   Category             nvarchar(50)         null,
   Class                nvarchar(200)        null,
   Method               nvarchar(50)         null,
   Params               nvarchar(2000)       null,
   Ip                   nvarchar(30)         null,
   Host                 nvarchar(50)         null,
   ThreadId             nvarchar(12)         null,
   UserId               nvarchar(30)         null,
   Operator             nvarchar(30)         null,
   Role                 nvarchar(30)         null,
   Caption              nvarchar(100)        null,
   Content              nvarchar(MAX)        null,
   Sql                  nvarchar(4000)       null,
   SqlParams            nvarchar(4000)       null,
   Error                nvarchar(2000)       null,
   StackTrace           nvarchar(max)        null,
   ErrorCode            nvarchar(10)         null,
   constraint PK_OPERATIONLOGS primary key nonclustered (LogId)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Logs.OperationLogs') and minor_id = 0)
begin 
   execute sp_dropextendedproperty 'MS_Description',  
   'schema', 'Logs', 'table', 'OperationLogs' 
 
end 


execute sp_addextendedproperty 'MS_Description',  
   '操作日志', 
   'schema', 'Logs', 'table', 'OperationLogs'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'LogId'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作编号',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'LogId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Level')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Level'

end


execute sp_addextendedproperty 'MS_Description', 
   '日志级别',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Level'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TraceId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'TraceId'

end


execute sp_addextendedproperty 'MS_Description', 
   '跟踪号',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'TraceId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Time')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Time'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作时间',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Time'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TotalSeconds')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'TotalSeconds'

end


execute sp_addextendedproperty 'MS_Description', 
   '执行时间',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'TotalSeconds'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Url')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Url'

end


execute sp_addextendedproperty 'MS_Description', 
   '网址',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Url'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BusinessId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'BusinessId'

end


execute sp_addextendedproperty 'MS_Description', 
   '业务编号',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'BusinessId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Application')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Application'

end


execute sp_addextendedproperty 'MS_Description', 
   '应用程序',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Application'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Tenant')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Tenant'

end


execute sp_addextendedproperty 'MS_Description', 
   '租户',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Tenant'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Category')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Category'

end


execute sp_addextendedproperty 'MS_Description', 
   '分类',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Category'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Class')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Class'

end


execute sp_addextendedproperty 'MS_Description', 
   '类名',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Class'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Method')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Method'

end


execute sp_addextendedproperty 'MS_Description', 
   '方法名',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Method'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Params')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Params'

end


execute sp_addextendedproperty 'MS_Description', 
   '参数',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Params'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Ip')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Ip'

end


execute sp_addextendedproperty 'MS_Description', 
   'IP',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Ip'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Host')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Host'

end


execute sp_addextendedproperty 'MS_Description', 
   '主机',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Host'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ThreadId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'ThreadId'

end


execute sp_addextendedproperty 'MS_Description', 
   '线程号',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'ThreadId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UserId')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'UserId'

end


execute sp_addextendedproperty 'MS_Description', 
   '用户编号',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'UserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Operator')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Operator'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作人姓名',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Operator'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Role')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Role'

end


execute sp_addextendedproperty 'MS_Description', 
   '操作人角色',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Role'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Caption')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Caption'

end


execute sp_addextendedproperty 'MS_Description', 
   '标题',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Caption'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Content')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Content'

end


execute sp_addextendedproperty 'MS_Description', 
   '内容',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sql')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Sql'

end


execute sp_addextendedproperty 'MS_Description', 
   'Sql语句',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Sql'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SqlParams')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'SqlParams'

end


execute sp_addextendedproperty 'MS_Description', 
   'Sql参数',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'SqlParams'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Error')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Error'

end


execute sp_addextendedproperty 'MS_Description', 
   '错误消息',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'Error'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StackTrace')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'StackTrace'

end


execute sp_addextendedproperty 'MS_Description', 
   '堆栈跟踪',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'StackTrace'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Logs.OperationLogs')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ErrorCode')
)
begin
   execute sp_dropextendedproperty 'MS_Description', 
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'ErrorCode'

end


execute sp_addextendedproperty 'MS_Description', 
   '错误码',
   'schema', 'Logs', 'table', 'OperationLogs', 'column', 'ErrorCode'
go

/*==============================================================*/
/* Index: Time                                                  */
/*==============================================================*/
create clustered index Time on Logs.OperationLogs (
Time ASC
)
go
