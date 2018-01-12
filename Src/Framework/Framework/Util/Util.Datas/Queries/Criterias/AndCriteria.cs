﻿using System;
using System.Linq.Expressions;
using Util.Domains;

namespace Util.Datas.Queries.Criterias {
    /// <summary>
    /// 与查询条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public class AndCriteria<TEntity> : CriteriaBase<TEntity> where TEntity : class, IAggregateRoot {
        /// <summary>
        /// 初始化与查询条件
        /// </summary>
        /// <param name="first">谓词1</param>
        /// <param name="second">谓词2</param>
        public AndCriteria( Expression<Func<TEntity, bool>> first, Expression<Func<TEntity, bool>> second ) {
            Predicate = first.And( second );
        }
    }
}
