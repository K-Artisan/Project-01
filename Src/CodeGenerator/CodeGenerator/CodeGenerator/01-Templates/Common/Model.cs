﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SchemaMapper {
    /// <summary>
    /// 系统操作
    /// </summary>
    public class Sys {
        /// <summary>
        /// 调试
        /// </summary>
        public static void Debug() {
            System.Diagnostics.Debugger.Launch();
            System.Diagnostics.Debugger.Break();
        }
    }

    /// <summary>
    /// 扩展 - 可空类型
    /// </summary>
    public static class NullExtensions {
        /// <summary>
        /// 安全返回值
        /// </summary>
        /// <param name="value">可空值</param>
        public static T SafeValue<T>(this T? value) where T : struct {
            return value ?? default(T);
        }
    }

    #region Base
    public enum Cardinality {
        ZeroOrOne,
        One,
        Many
    }

    public class EntityBase {
        public bool IsProcessed { get; set; }
    }
    #endregion

    #region Model
    [DebuggerDisplay("Context: {ContextName}, Database: {DatabaseName}")]
    public class EntityContext : EntityBase {
        public EntityContext() {
            Entities = new EntityCollection();
        }

        public string ClassName { get; set; }
        public string DatabaseName { get; set; }

        public EntityCollection Entities { get; set; }

        public void RenameEntity(string originalName, string newName) {
            if (originalName == newName)
                return;

            Debug.WriteLine("Rename Entity '{0}' to '{1}'.", originalName, newName);
            foreach (var entity in Entities) {
                if (entity.ClassName == originalName)
                    entity.ClassName = newName;

                foreach (var relationship in entity.Relationships) {
                    if (relationship.ThisEntity == originalName)
                        relationship.ThisEntity = newName;
                    if (relationship.OtherEntity == originalName)
                        relationship.OtherEntity = newName;
                }
            }
        }

        public void RenameProperty(string entityName, string originalName, string newName) {
            if (originalName == newName)
                return;

            Debug.WriteLine("Rename Property '{0}' to '{1}' in Entity '{2}'.", originalName, newName, entityName);
            foreach (var entity in Entities) {
                if (entity.ClassName == entityName) {
                    var property = entity.Properties.ByProperty(originalName);
                    if (property != null)
                        property.PropertyName = newName;
                }

                foreach (var relationship in entity.Relationships) {
                    if (relationship.ThisEntity == entityName)
                        for (int i = 0; i < relationship.ThisProperties.Count; i++)
                            if (relationship.ThisProperties[i] == originalName)
                                relationship.ThisProperties[i] = newName;

                    if (relationship.OtherEntity == entityName)
                        for (int i = 0; i < relationship.OtherProperties.Count; i++)
                            if (relationship.OtherProperties[i] == originalName)
                                relationship.OtherProperties[i] = newName;
                }
            }

        }
    }

    [DebuggerDisplay("Class: {ClassName}, Table: {FullName}, Context: {ContextName}")]
    public class Entity : EntityBase {
        public Entity() {
            Properties = new PropertyCollection();
            Relationships = new RelationshipCollection();
            Methods = new MethodCollection();
        }

        public EntityContext Context { get; set; }
        public string ContextName { get; set; }
        public string ClassName { get; set; }
        public string MappingName { get; set; }

        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public string FullName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public PropertyCollection Properties { get; set; }
        public RelationshipCollection Relationships { get; set; }
        public MethodCollection Methods { get; set; }

        /// <summary>
        /// 获取主键
        /// </summary>
        public Property GetId() {
            foreach (var property in Properties) {
                if (property.IsPrimaryKey.SafeValue())
                    return property;
            }
            return new Property();
        }

        /// <summary>
        /// 获取导航属性描述
        /// </summary>
        public string GetOtherDescription(string name) {
            return Context.Entities.ByClass(name).Description;
        }

        /// <summary>
        /// 获取属性集合,不包含Version属性
        /// </summary>
        public List<Property> GetProperties() {
            return Properties.Where(t => (t.ColumnName == "Version" && t.DataType == DbType.Binary) == false).ToList();
        }

        /// <summary>
        /// 获取第一个不是Id的属性
        /// </summary>
        public Property GetFirstProperty() {
            return GetProperties().FirstOrDefault(t => t.IsPrimaryKey != true) ?? new Property();
        }

        /// <summary>
        /// 是否最后一个属性
        /// </summary>
        public bool IsLast(Property property) {
            return GetProperties().Last() == property;
        }

        /// <summary>
        /// 获取逗号
        /// </summary>
        public string GetComma(Property property) {
            return IsLast(property) ? "" : ",";
        }

        /// <summary>
        /// 获取主键
        /// </summary>
        public Property GetKey() {
            var key = Properties.FirstOrDefault(t => t.IsPrimaryKey.SafeValue());
            if (key == null)
                throw new Exception("没有设置主键");
            return key;
        }

        /// <summary>
        /// 获取主键类型
        /// </summary>
        public Type GetKeyType() {
            var key = GetKey();
            return key.SystemType;
        }

        /// <summary>
        /// 获取主键类型
        /// </summary>
        public string GetKeyTypeString() {
            return GetKeyType().ToNullableType();
        }

        /// <summary>
        /// 获取聚合根
        /// </summary>
        public string GetAggregateRoot() {
            if (GetKeyType() == typeof(string))
                return "AggregateRoot<string>";
            if (GetKeyType() == typeof(int))
                return "AggregateRoot<int>";
            return "AggregateRoot";
        }

        /// <summary>
        /// 获取主键默认值
        /// </summary>
        public string GetKeyDefault() {
            if (GetKeyType() == typeof(string))
                return "string.Empty";
            if (GetKeyType() == typeof(int))
                return "0";
            return "Guid.Empty";
        }

        /// <summary>
        /// 获取键类型，但不包括Guid
        /// </summary>
        /// <param name="isAddCommon">是否在前面添加逗号</param>
        public string GetKeyTypeNoContainsGuid(bool isAddCommon = true) {
            if (GetKeyType() == typeof(Guid))
                return "";
            string comma = isAddCommon ? "," : "";
            return comma + GetKeyTypeString();
        }

        /// <summary>
        /// 获取转换为实体
        /// </summary>
        public string GetToEntityConvert() {
            if (GetKeyType() == typeof(Guid))
                return ".ToGuid()";
            return "";
        }

        /// <summary>
        /// 获取转换为Dto
        /// </summary>
        public string GetToDtoConvert() {
            if (GetKeyType() == typeof(Guid))
                return ".ToString()";
            return "";
        }

        /// <summary>
        /// 获取新的主键值
        /// </summary>
        public string GetNewKey() {
            if (GetKeyType() == typeof(Guid))
                return "Guid.NewGuid()";
            if (GetKeyType() == typeof(string))
                return "Guid.NewGuid().ToString()";
            return "";
        }

        /// <summary>
        /// 获取排序字段
        /// </summary>
        public string GetOrderBy() {
            var exists = Properties.Any(t => t.PropertyName == "CreateTime" && t.SystemType == typeof(DateTime));
            if (exists)
                return "CreateTime";
            return "Id";
        }

        /// <summary>
        /// 获取名称空间
        /// </summary>
        /// <param name="baseNamespace">基名称空间</param>
        /// <param name="layer">层</param>
        /// <param name="category">分类</param>
        public string GetNamespace(string baseNamespace, string layer, string category = "") {
            if (string.IsNullOrWhiteSpace(TableSchema) || TableSchema.ToLower().Trim() == "dbo")
                return string.Format("{0}.{1}{2}", baseNamespace, layer, GetCategory(category));
            return string.Format("{0}.{1}.{2}{3}", baseNamespace, layer, TableSchema, GetCategory(category));
        }

        /// <summary>
        /// 获取分类
        /// </summary>
        private string GetCategory(string category) {
            if (string.IsNullOrWhiteSpace(category))
                return string.Empty;
            return string.Format(".{0}", category);
        }
    }

    [DebuggerDisplay("Property: {PropertyName}, Column: {ColumnName}, Type: {NativeType}")]
    public class Property : EntityBase {
        /// <summary>
        /// 属性名
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 列名
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public DbType DataType { get; set; }
        public string NativeType { get; set; }

        [XmlIgnore]
        public Type SystemType { get; set; }

        public int? Order { get; set; }
        public bool OrderSpecified {
            get { return Order.HasValue; }
        }

        public bool? IsNullable { get; set; }
        public bool IsNullableSpecified {
            get { return IsNullable.HasValue; }
        }

        public bool IsRequired {
            get { return IsNullable == false; }
            set { IsNullable = !value; }
        }
        public bool IsOptional {
            get { return IsNullable == true; }
            set { IsNullable = value; }
        }

        public bool? IsPrimaryKey { get; set; }
        public bool IsPrimaryKeySpecified {
            get { return IsPrimaryKey.HasValue; }
        }
        public bool? IsForeignKey { get; set; }
        public bool IsForeignKeySpecified {
            get { return IsForeignKey.HasValue; }
        }

        public bool? IsAutoGenerated { get; set; }
        public bool IsAutoGeneratedSpecified {
            get { return IsAutoGenerated.HasValue; }
        }
        public bool? IsReadOnly { get; set; }
        public bool IsReadOnlySpecified {
            get { return IsReadOnly.HasValue; }
        }
        public bool? IsRowVersion { get; set; }
        public bool IsRowVersionSpecified {
            get { return IsRowVersion.HasValue; }
        }
        public bool? IsIdentity { get; set; }
        public bool IsIdentitySpecified {
            get { return IsIdentity.HasValue; }
        }
        public bool? IsUnique { get; set; }
        public bool IsUniqueSpecified {
            get { return IsUnique.HasValue; }
        }

        public bool? IsUnicode { get; set; }
        public bool IsUnicodeSpecified {
            get { return IsUnicode.HasValue; }
        }
        public bool? IsFixedLength { get; set; }
        public bool IsFixedLengthSpecified {
            get { return IsFixedLength.HasValue; }
        }

        public int? MaxLength { get; set; }
        public bool MaxLengthSpecified {
            get { return MaxLength.HasValue; }
        }

        public byte? Precision { get; set; }
        public bool PrecisionSpecified {
            get { return Precision.HasValue; }
        }
        public int? Scale { get; set; }
        public bool ScaleSpecified {
            get { return Scale.HasValue; }
        }

        /// <summary>
        /// 是否需要验证
        /// </summary>
        public bool HasValidate() {
            var result = GetValidations();
            if (result.Count > 0)
                return true;
            return false;
        }

        /// <summary>
        /// 获取验证列表
        /// </summary>
        private List<string> GetValidations() {
            List<string> result = new List<string>();
            ValidateRequired(result);
            ValidateStringLength(result);
            return result;
        }

        /// <summary>
        /// 验证是否必填项
        /// </summary>
        private void ValidateRequired(List<string> result) {
            if (IsRequired == false)
                return;
            result.Add(string.Format("[Required(ErrorMessage = \"{0}不能为空\")]", Description));
        }

        /// <summary>
        /// 验证字符串长度
        /// </summary>
        private void ValidateStringLength(List<string> result) {
            if (SystemType != typeof(String))
                return;
            if (MaxLength == -1)
                return;
            result.Add(string.Format("[StringLength( {0}, ErrorMessage = \"{1}输入过长，不能超过{0}位\" )]", MaxLength, Description));
        }

        /// <summary>
        /// 验证
        /// </summary>
        public string Validate() {
            StringBuilder result = new StringBuilder();
            List<string> validations = GetValidations();
            if (validations.Count == 1)
                result.Append(validations[0]);
            else
                AddValidations(result, validations);
            return result.ToString();
        }

        /// <summary>
        /// 添加验证列表
        /// </summary>
        private void AddValidations(StringBuilder result, List<string> validations) {
            for (int i = 0; i < validations.Count; i++) {
                if (i == 0) {
                    result.AppendFormat("{0}\r\n", validations[i]);
                    continue;
                }
                if (i == validations.Count - 1)
                    result.AppendFormat("        {0}", validations[i]);
                else {
                    result.AppendFormat("        {0}\r\n", validations[i]);
                }
            }
        }

        /// <summary>
        /// 设置Description方法
        /// </summary>
        public string ShowDescription() {
            if (DataType == DbType.Boolean)
                return ".Description()";
            return string.Empty;
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName {
            get { return SystemType.ToNullableType(IsNullable == true); }
        }

        /// <summary>
        /// 是否标识 
        /// </summary>
        public bool IsKey {
            get { return IsPrimaryKey.SafeValue(); }
        }

        /// <summary>
        /// 格式化表格列
        /// </summary>
        public string FormatGridColumn() {
            if (SystemType == typeof(DateTime))
                return ".FormatDate()";
            if (SystemType == typeof(bool))
                return ".FormatBool()";
            return string.Empty;
        }

        /// <summary>
        /// 获取表格列宽
        /// </summary>
        public string GetGridColumnWidth() {
            if (SystemType == typeof(DateTime))
                return "120";
            if (SystemType == typeof(bool))
                return "60";
            return "100";
        }
    }



    [DebuggerDisplay("Other: {OtherEntity}, Property: {OtherPropertyName}, Relationship: {RelationshipName}")]
    public class Relationship : EntityBase {
        public Relationship() {
            OtherProperties = new List<string>();
            ThisProperties = new List<string>();
        }

        public string RelationshipName { get; set; }

        public string ThisEntity { get; set; }
        public string ThisPropertyName { get; set; }
        public Cardinality ThisCardinality { get; set; }
        public List<string> ThisProperties { get; set; }

        public string OtherEntity { get; set; }
        public string OtherPropertyName { get; set; }
        public Cardinality OtherCardinality { get; set; }
        public List<string> OtherProperties { get; set; }

        public bool? DeleteOnNull { get; set; }
        public bool IsForeignKey { get; set; }
        public bool IsMapped { get; set; }

        public bool IsManyToMany {
            get {
                return ThisCardinality == Cardinality.Many
                  && OtherCardinality == Cardinality.Many;
            }
        }

        public bool IsOneToOne {
            get {
                return ThisCardinality != Cardinality.Many
                  && OtherCardinality != Cardinality.Many;
            }
        }

        public string JoinTable { get; set; }
        public string JoinSchema { get; set; }
        public List<string> JoinThisColumn { get; set; }
        public List<string> JoinOtherColumn { get; set; }

    }

    [DebuggerDisplay("Suffix: {NameSuffix}, IsKey: {IsKey}, IsUnique: {IsUnique}")]
    public class Method : EntityBase {
        public Method() {
            Properties = new List<Property>();
        }

        public string NameSuffix { get; set; }
        public string SourceName { get; set; }

        public bool IsKey { get; set; }
        public bool IsUnique { get; set; }
        public bool IsIndex { get; set; }

        public List<Property> Properties { get; set; }
    }
    #endregion

    #region Collections
    public class EntityCollection
      : ObservableCollection<Entity> {
        public bool IsProcessed { get; set; }

        public Entity ByTable(string fullName) {
            return this.FirstOrDefault(x => x.FullName == fullName);
        }

        public Entity ByTable(string tableName, string tableSchema) {
            return this.FirstOrDefault(x => x.TableName == tableName && x.TableSchema == tableSchema);
        }

        public Entity ByClass(string className) {
            return this.FirstOrDefault(x => x.ClassName == className);
        }

        public Entity ByContext(string contextName) {
            return this.FirstOrDefault(x => x.ContextName == contextName);
        }
    }

    public class PropertyCollection
      : ObservableCollection<Property> {
        public bool IsProcessed { get; set; }

        public IEnumerable<Property> PrimaryKeys {
            get { return this.Where(p => p.IsPrimaryKey == true); }
        }

        public IEnumerable<Property> ForeignKeys {
            get { return this.Where(p => p.IsForeignKey == true); }
        }

        public Property ByColumn(string columnName) {
            return this.FirstOrDefault(x => x.ColumnName == columnName);
        }

        public Property ByProperty(string propertyName) {
            return this.FirstOrDefault(x => x.PropertyName == propertyName);
        }
    }

    public class RelationshipCollection
      : ObservableCollection<Relationship> {
        public bool IsProcessed { get; set; }

        public Relationship ByName(string name) {
            return this.FirstOrDefault(x => x.RelationshipName == name);
        }

        public Relationship ByProperty(string propertyName) {
            return this.FirstOrDefault(x => x.ThisPropertyName == propertyName);
        }

        public Relationship ByOther(string name) {
            return this.FirstOrDefault(x => x.OtherEntity == name);
        }
    }

    public class MethodCollection
        : ObservableCollection<Method> {
        public bool IsProcessed { get; set; }
    }

    #endregion
}

