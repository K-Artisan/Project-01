﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Util.Domains {
    /// <summary>
    /// 树型实体
    /// </summary>
    /// <typeparam name="TEntity">树型实体类型</typeparam>
    /// <typeparam name="TKey">标识类型</typeparam>
    /// <typeparam name="TParentId">父编号类型</typeparam>
    public abstract class TreeEntityBase<TEntity, TKey, TParentId> : AggregateRoot<TKey>, ITreeEntity<TEntity, TKey, TParentId> where TEntity : ITreeEntity<TEntity, TKey, TParentId> {
        /// <summary>
        /// 初始化树型实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="path">路径</param>
        /// <param name="level">级数</param>
        protected TreeEntityBase( TKey id,string path,int level )
            : base( id ) {
            Path = path;
            Level = level;
        }

        /// <summary>
        /// 父对象
        /// </summary>
        public virtual TEntity Parent { get; set; }

        /// <summary>
        /// 父编号
        /// </summary>
        public TParentId ParentId { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        [Required]
        public virtual string Path { get;private set; }

        /// <summary>
        /// 级数
        /// </summary>
        public virtual int Level { get; private set; }

        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [Required( ErrorMessageResourceType = typeof( DomainResource ), ErrorMessageResourceName = "SortIdIsNull" )]
        public int? SortId { get; set; }

        /// <summary>
        /// 初始化路径
        /// </summary>
        /// <param name="parent">父对象</param>
        public void InitPath( TEntity parent ) {
            if ( Equals( parent, null ) )
                InitFirstLevel();
            else
                InitChild( parent );
        }

        /// <summary>
        /// 初始化路径
        /// </summary>
        public void InitPath() {
            InitPath( Parent );
        }        

        /// <summary>
        /// 初始化1级节点
        /// </summary>
        private void InitFirstLevel() {
            Level = 1;
            Path = string.Format( "{0},", Id );
        }

        /// <summary>
        /// 初始化下级节点
        /// </summary>
        private void InitChild( TEntity parent ) {
            Level = parent.Level + 1;
            Path = string.Format( "{0}{1},", parent.Path, Id );
        }

        /// <summary>
        /// 从路径中获取所有上级节点编号
        /// </summary>
        public List<TKey> GetParentIdsFromPath() {
            if( Path.IsEmpty() )
                return new List<TKey>();
            var result = Path.Split( ',' ).Where( id => !id.IsEmpty() && id != "," && id != Id.ToString() ).ToList();
            return result.Select( Conv.To<TKey> ).ToList();
        }
    }
}
