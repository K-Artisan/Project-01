﻿using System;
using System.Linq.Expressions;
using Util.Domains;

namespace Util.Datas.Queries.Criterias {
    /// <summary>
    /// decimal数值段过滤条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class DecimalSegmentCriteria<TEntity, TProperty> : SegmentCriteria<TEntity, TProperty, decimal> where TEntity : class,IAggregateRoot {
        /// <summary>
        /// 初始化decimal数值段过滤条件
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        public DecimalSegmentCriteria( Expression<Func<TEntity, TProperty>> propertyExpression, decimal? min, decimal? max )
            : base( propertyExpression, min, max ) {
        }

        /// <summary>
        /// 最小值是否大于最大值
        /// </summary>
        protected override bool IsMinGreaterMax( decimal? min, decimal? max ) {
            return min > max;
        }
    }
}
