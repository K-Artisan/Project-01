using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EntityFramework.Mapping {
    /// <summary>
    /// A class representing a property map
    /// </summary>
    [DebuggerDisplay( "Property: {PropertyName}, Column: {ColumnName}" )]
    public class PropertyMap {
        public PropertyMap() : this( "","",null ){
        }

        public PropertyMap( string propertyName, string columnName, Type propertyType ) {
            _childs = new List<PropertyMap>();
            PropertyName = propertyName;
            ColumnName = columnName;
            PropertyType = propertyType;
        }

        /// <summary>
        /// ������
        /// </summary>
        private readonly List<PropertyMap> _childs;

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// �Ƿ�������
        /// </summary>
        public bool IsComplex { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public Type PropertyType { get; set; }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="child">������</param>
        public void AddProperty( PropertyMap child ) {
            if ( child == null )
                return;
            _childs.Add( child );
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        public List<PropertyMap> GetChilds() {
            return _childs;
        }
    }
}