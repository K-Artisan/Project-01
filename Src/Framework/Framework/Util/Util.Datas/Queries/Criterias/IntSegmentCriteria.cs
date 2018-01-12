﻿using System;
using System.Linq.Expressions;
using Util.Domains;

namespace Util.Datas.Queries.Criterias {
    /// <summary>
    /// 整数段过滤条件
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TProperty">属性类型</typeparam>
    public class IntSegmentCriteria<TEntity, TProperty> : SegmentCriteria<TEntity, TProperty, int> where TEntity : class,IAggregateRoot {
        /// <summary>
        /// 初始化整数段过滤条件
        /// </summary>
        /// <param name="propertyExpression">属性表达式</param>
        /// <param name="min">最小值</param>
        /// <param name="max">最大值</param>
        public IntSegmentCriteria( Expression<Func<TEntity, TProperty>> propertyExpression, int? min, int? max ) 
            : base( propertyExpression,min,max){
        }

        /// <summary>
        /// 最小值是否大于最大值
        /// </summary>
        protected override bool IsMinGreaterMax( int? min, int? max ) {
            return min > max;
        }
    }
}
