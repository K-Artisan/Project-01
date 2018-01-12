﻿using System.Web.Mvc;
using Util;
using Util.ApplicationServices;
using Util.Domains.Repositories;
using Util.Webs;
using Util.Webs.EasyUi.Forms;

namespace Presentation.Base {
    /// <summary>
    /// 表单控制器
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询实体类型</typeparam>
    public abstract class FormControllerBase<TDto, TQuery> : QueryControllerBase<TDto, TQuery>
        where TQuery : IPager
        where TDto : DtoBase, new() {
        /// <summary>
        /// 初始化表单控制器
        /// </summary>
        /// <param name="service">服务</param>
        protected FormControllerBase( IServiceBase<TDto, TQuery> service ) 
            : base( service ){
        }

        /// <summary>
        /// 获取新增表单
        /// </summary>
        [AjaxOnly]
        public virtual PartialViewResult Add() {
            return PartialView( "Parts/Form", Service.Create() );
        }

        /// <summary>
        /// 获取编辑表单
        /// </summary>
        /// <param name="id">实体编号</param>
        [AjaxOnly]
        public virtual PartialViewResult Edit( string id ) {
            return PartialView( "Parts/Form", Service.Get( id ) );
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormExceptionHandler]
        [AjaxOnly]
        public virtual ActionResult Save( TDto dto ) {
            SaveBefore( dto );
            Service.Save( dto );
            return Ok( R.SaveSuccess );
        }

        /// <summary>
        /// 保存前操作
        /// </summary>
        /// <param name="dto">数据传输对象</param>
        protected virtual void SaveBefore( TDto dto ) {
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ids">Id集合字符串，多个Id用逗号分隔</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormExceptionHandler]
        [AjaxOnly]
        public virtual ActionResult Delete( string ids ) {
            Service.Delete( ids );
            return Ok( R.DeleteSuccess );
        }

        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id">实体编号</param>
        [AjaxOnly]
        public virtual PartialViewResult Detail( string id ) {
            return PartialView( "Parts/Detail", Service.Get( id ) );
        }
    }
}
