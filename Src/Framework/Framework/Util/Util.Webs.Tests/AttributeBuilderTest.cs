using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Util.Webs.Tests {
    /// <summary>
    /// ��������������
    /// </summary>
    [TestClass]
    public class AttributeBuilderTest {
        /// <summary>
        /// ����������
        /// </summary>
        private AttributeBuilder _builder;

        /// <summary>
        /// ���Գ�ʼ��
        /// </summary>
        [TestInitialize]
        public void TestInit() {
            _builder = new AttributeBuilder();
        }

        /// <summary>
        /// ��ȡĬ�Ͻ��
        /// </summary>
        [TestMethod]
        public void TestGetResult_Default() {
            Assert.AreEqual( "",_builder.GetResult() );
        }

        /// <summary>
        /// ��֤���������Ϊ��ֵ
        /// </summary>
        [TestMethod]
        public void TestAdd_Validate_NameIsEmpty() {
            _builder.Add( "", "a" );
            Assert.AreEqual( "", _builder.GetResult() );
        }

        /// <summary>
        /// ���1������
        /// </summary>
        [TestMethod]
        public void TestAdd_1Attribute() {
            _builder.Add( "class","a" );
            Assert.AreEqual( "class=\"a\"",_builder.GetResult() );
        }

        /// <summary>
        /// Ϊͬ1�������������ֵ
        /// </summary>
        [TestMethod]
        public void TestAdd_1Attribute_2Value() {
            _builder.Add( "class", "a" );
            _builder.Add( "class", "b" );
            Assert.AreEqual( "class=\"a;b\"", _builder.GetResult() );
        }

        /// <summary>
        /// ���2������
        /// </summary>
        [TestMethod]
        public void TestAdd_2Attribute() {
            _builder.Add( "class", "a" );
            _builder.Add( "name", "b" );
            Assert.AreEqual( "class=\"a\" name=\"b\"", _builder.GetResult() );
        }

        /// <summary>
        /// Ϊͬ1�������������ֵ��ʹ�ö��ŷָ�
        /// </summary>
        [TestMethod]
        public void TestAdd_1Attribute_2Value_Comma() {
            _builder.Add( "class", "a","," );
            _builder.Add( "class", "b", "," );
            Assert.AreEqual( "class=\"a,b\"", _builder.GetResult() );
        }

        /// <summary>
        /// Ϊclass�����������ֵ��ͨ���ո�ָ�
        /// </summary>
        [TestMethod]
        public void TestAddClass_2Value() {
            _builder.AddClass( "a" );
            _builder.AddClass( "b" );
            Assert.AreEqual( "class=\"a b\"", _builder.GetResult() );
        }

        /// <summary>
        /// ����class����
        /// </summary>
        [TestMethod]
        public void TestUpdateClass() {
            _builder.AddClass( "a" );
            _builder.UpdateClass( "b" );
            Assert.AreEqual( "class=\"b\"", _builder.GetResult() );
        }

        /// <summary>
        /// �������Էָ���
        /// </summary>
        [TestMethod]
        public void TestAttributeSeparator() {
            _builder = new AttributeBuilder(":");
            _builder.Add( "class", "a" );
            Assert.AreEqual( "class:\"a\"", _builder.GetResult() );
        }

        /// <summary>
        /// �������Խڵ�ָ���
        /// </summary>
        [TestMethod]
        public void TestNodeSeparator() {
            _builder = new AttributeBuilder( ":","," );
            _builder.Add( "a", "1" );
            _builder.Add( "b", "2" );
            Assert.AreEqual( "a:\"1\",b:\"2\"", _builder.GetResult() );
        }

        /// <summary>
        /// ��������
        /// </summary>
        [TestMethod]
        public void TestUpdate() {
            _builder.Add( "class", "a" );
            _builder.Update( "class", "b" );
            Assert.AreEqual( "class=\"b\"", _builder.GetResult() );
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        [TestMethod]
        public void TestAdd_Attributes() {
            _builder.Add( "a", "1" );
            _builder.Add( "b=\"2\"" );
            Assert.AreEqual( "a=\"1\" b=\"2\"", _builder.GetResult() );
        }
    }
}