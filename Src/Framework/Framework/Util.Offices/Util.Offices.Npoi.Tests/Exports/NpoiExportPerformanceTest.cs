using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Exports;
using Util.Offices.Npoi.Tests.Samples;

namespace Util.Offices.Npoi.Tests.Exports {
    /// <summary>
    /// Npoi导出性能测试
    /// </summary>
    [TestClass]
    public class NpoiExportPerformanceTest {
        /// <summary>
        /// 导出
        /// </summary>
        private IExport _export;
        /// <summary>
        /// 列表
        /// </summary>
        private IList<OfficeTest> _list;

        /// <summary>
        /// 测试初始化
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _export = ExportFactory.CreateNpoiExcel2007Export();
            _list = OfficeTest.CreateList2();
        }

        /// <summary>
        /// 测试
        /// </summary>
        [TestMethod]
        public void Test_1() {
            _export.Head( "测试报表" )
                .Head( new Cell( "测试", 1, 3 ), new Cell( "测试", 1, 3 ), new Cell( "测试", 1, 3 ), new Cell( "测试", 2, 2 ), new Cell( "测试", 11 ) )
                .Head( new Cell( "测试", 2 ), new Cell( "测试", 2 ), new Cell( "测试", 2 ), new Cell( "测试", 2 ), new Cell( "测试", 3 ) )
                .Head( "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试", "测试" )
                .Body( _list, t => new object[] { t.Test16, t.Test15, t.Test14, t.Test13, t.Test12, t.Test11, t.Test10, t.Test9, t.Test8, t.Test7, t.Test6, t.Test5, t.Test4, t.Test3, t.Test2, t.Test1 } )
                .Write( @"d:\", "Test_Performance_1" );
        }
    }
}
