﻿using System;
using Util.Datas;
using Util.Domains;
using Util.Domains.Repositories;

namespace Util.ApplicationServices {
    /// <summary>
    /// 应用服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQuery">查询实体类型</typeparam>
    public abstract class ServiceBase<TEntity, TDto, TQuery> : ServiceBase<TEntity, TDto, TQuery, Guid>
        where TEntity : class, IAggregateRoot<Guid>
        where TDto : DtoBase,new()
        where TQuery : IPager {
        /// <summary>
        /// 初始化应用服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="repository">仓储</param>
        protected ServiceBase( IUnitOfWork unitOfWork, IRepository<TEntity> repository )
            : base( unitOfWork, repository ) {
        }
    }
}
