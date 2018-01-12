﻿namespace Util.Datas.Sql.Queries.Builders.Conditions {
    /// <summary>
    /// Sql小于条件
    /// </summary>
    public class LessCondition : SqlCondition{
        /// <summary>
        /// 初始化Sql条件
        /// </summary>
        /// <param name="name">列名</param>
        /// <param name="prefix">参数前缀</param>
        public LessCondition( string name, string prefix ) 
            : base( name,prefix ){
        }

        /// <summary>
        /// 获取条件
        /// </summary>
        public override string GetCondition() {
            return string.Format( "{0}<{1}{2}", Name, Prefix, GetParamName( Name ) );
        }
    }
}
