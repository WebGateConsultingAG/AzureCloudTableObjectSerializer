using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebGate.Azure.CloudTableUtils;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtilsTest
{
    [TestClass]
    public class SerlializerTests {
        [TestMethod]
        public void TestExtractAllEnitiesFromSimplePoco()
        {
            SimplePoco spo = SimplePoco.CreateInitializedPoco();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(spo);
            Assert.AreEqual(11, allEntities.Count);
            //CHECK ID
            Assert.IsTrue(allEntities.ContainsKey("Id"));
            Assert.AreEqual(allEntities["Id"].StringValue, spo.Id);
            Assert.AreEqual(allEntities["Id"].PropertyType, EdmType.String);
            
            Assert.IsTrue(allEntities.ContainsKey("IntValue"));
            Assert.AreEqual(allEntities["IntValue"].Int32Value, spo.IntValue);
            Assert.AreEqual(allEntities["IntValue"].PropertyType, EdmType.Int32);

            Assert.IsTrue(allEntities.ContainsKey("LongValue"));
            Assert.AreEqual(allEntities["LongValue"].Int64Value, spo.LongValue);
            Assert.AreEqual(allEntities["LongValue"].PropertyType, EdmType.Int64);

            Assert.IsTrue(allEntities.ContainsKey("DoubleValue"));
            Assert.AreEqual(allEntities["DoubleValue"].DoubleValue, spo.DoubleValue);
            Assert.AreEqual(allEntities["DoubleValue"].PropertyType, EdmType.Double);

            Assert.IsTrue(allEntities.ContainsKey("GuidValue"));
            Assert.AreEqual(allEntities["GuidValue"].GuidValue, spo.GuidValue);
            Assert.AreEqual(allEntities["GuidValue"].PropertyType, EdmType.Guid);

            Assert.IsTrue(allEntities.ContainsKey("DTValue"));
            Assert.AreEqual(allEntities["DTValue"].DateTime, spo.DTValue);
            Assert.AreEqual(allEntities["DTValue"].PropertyType, EdmType.DateTime);

            Assert.IsTrue(allEntities.ContainsKey("DTOValue"));
            Assert.AreEqual(allEntities["DTOValue"].DateTimeOffsetValue, spo.DTOValue);
            Assert.AreEqual(allEntities["DTOValue"].PropertyType, EdmType.DateTime);

          
            Assert.IsTrue(allEntities.ContainsKey("EnumValue"));
            Assert.AreEqual(allEntities["EnumValue"].StringValue, spo.EnumValue.ToString());
            Assert.AreEqual(allEntities["EnumValue"].PropertyType, EdmType.String);


        }
        [TestMethod]
        public void TestExtractAllEnitiesFromSimplePocoWithNullId()
        {
            SimplePoco spo = SimplePoco.CreatePocoWithoutID();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(spo);
            Assert.AreEqual(10, allEntities.Count);
            Assert.IsFalse(allEntities.ContainsKey("Id"));
           
        }
        [TestMethod]
        public void TestExtractAllEnitiesFromParentPoco()
        {
            ParentPoco pp = ParentPoco.CreateParentWithChild();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(pp);
            Assert.AreEqual(12, allEntities.Count);
            Assert.IsTrue(allEntities.ContainsKey("Id"));

            Assert.IsTrue(allEntities.ContainsKey("Child_Id"));
            Assert.AreEqual(allEntities["Child_Id"].StringValue, pp.Child.Id);
            Assert.AreEqual(allEntities["Child_Id"].PropertyType, EdmType.String);
            
            Assert.IsTrue(allEntities.ContainsKey("Child_IntValue"));
            Assert.AreEqual(allEntities["Child_IntValue"].Int32Value, pp.Child.IntValue);
            Assert.AreEqual(allEntities["Child_IntValue"].PropertyType, EdmType.Int32);

            Assert.IsTrue(allEntities.ContainsKey("Child_LongValue"));
            Assert.AreEqual(allEntities["Child_LongValue"].Int64Value, pp.Child.LongValue);
            Assert.AreEqual(allEntities["Child_LongValue"].PropertyType, EdmType.Int64);

            Assert.IsTrue(allEntities.ContainsKey("Child_DoubleValue"));
            Assert.AreEqual(allEntities["Child_DoubleValue"].DoubleValue, pp.Child.DoubleValue);
            Assert.AreEqual(allEntities["Child_DoubleValue"].PropertyType, EdmType.Double);

            Assert.IsTrue(allEntities.ContainsKey("Child_GuidValue"));
            Assert.AreEqual(allEntities["Child_GuidValue"].GuidValue, pp.Child.GuidValue);
            Assert.AreEqual(allEntities["Child_GuidValue"].PropertyType, EdmType.Guid);

            Assert.IsTrue(allEntities.ContainsKey("Child_DTValue"));
            Assert.AreEqual(allEntities["Child_DTValue"].DateTime, pp.Child.DTValue);
            Assert.AreEqual(allEntities["Child_DTValue"].PropertyType, EdmType.DateTime);

            Assert.IsTrue(allEntities.ContainsKey("Child_DTOValue"));
            Assert.AreEqual(allEntities["Child_DTOValue"].DateTimeOffsetValue, pp.Child.DTOValue);
            Assert.AreEqual(allEntities["Child_DTOValue"].PropertyType, EdmType.DateTime);


        }
        [TestMethod]
        public void TestExtractAllEnitiesFromMainWithParent()
        {
            MainWithParent mwp = MainWithParent.CreateMainWithParent();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(mwp);
            Assert.AreEqual(24, allEntities.Count);
            Assert.IsTrue(allEntities.ContainsKey("Id"));

            Assert.IsTrue(allEntities.ContainsKey("Child_Id"));
            Assert.AreEqual(allEntities["Child_Id"].StringValue, mwp.Child.Id);
            Assert.AreEqual(allEntities["Child_Id"].PropertyType, EdmType.String);
            
            Assert.IsTrue(allEntities.ContainsKey("Child_IntValue"));
            Assert.AreEqual(allEntities["Child_IntValue"].Int32Value, mwp.Child.IntValue);
            Assert.AreEqual(allEntities["Child_IntValue"].PropertyType, EdmType.Int32);

            Assert.IsTrue(allEntities.ContainsKey("Child_LongValue"));
            Assert.AreEqual(allEntities["Child_LongValue"].Int64Value, mwp.Child.LongValue);
            Assert.AreEqual(allEntities["Child_LongValue"].PropertyType, EdmType.Int64);

            Assert.IsTrue(allEntities.ContainsKey("Child_DoubleValue"));
            Assert.AreEqual(allEntities["Child_DoubleValue"].DoubleValue, mwp.Child.DoubleValue);
            Assert.AreEqual(allEntities["Child_DoubleValue"].PropertyType, EdmType.Double);

            Assert.IsTrue(allEntities.ContainsKey("Child_GuidValue"));
            Assert.AreEqual(allEntities["Child_GuidValue"].GuidValue, mwp.Child.GuidValue);
            Assert.AreEqual(allEntities["Child_GuidValue"].PropertyType, EdmType.Guid);

            Assert.IsTrue(allEntities.ContainsKey("Child_DTValue"));
            Assert.AreEqual(allEntities["Child_DTValue"].DateTime, mwp.Child.DTValue);
            Assert.AreEqual(allEntities["Child_DTValue"].PropertyType, EdmType.DateTime);

            Assert.IsTrue(allEntities.ContainsKey("Child_DTOValue"));
            Assert.AreEqual(allEntities["Child_DTOValue"].DateTimeOffsetValue, mwp.Child.DTOValue);
            Assert.AreEqual(allEntities["Child_DTOValue"].PropertyType, EdmType.DateTime);

            //CHECK PARENT
            Assert.IsTrue(allEntities.ContainsKey("Parent_Id"));
            Assert.AreEqual(allEntities["Parent_Id"].StringValue, mwp.Parent.Id);
            Assert.AreEqual(allEntities["Parent_Id"].PropertyType, EdmType.String);
            
            Assert.IsTrue(allEntities.ContainsKey("Parent_Child_IntValue"));
            Assert.AreEqual(allEntities["Child_IntValue"].Int32Value, mwp.Parent.Child.IntValue);
            Assert.AreEqual(allEntities["Child_IntValue"].PropertyType, EdmType.Int32);

            Assert.IsTrue(allEntities.ContainsKey("Parent_Child_LongValue"));
            Assert.AreEqual(allEntities["Child_LongValue"].Int64Value, mwp.Parent.Child.LongValue);
            Assert.AreEqual(allEntities["Child_LongValue"].PropertyType, EdmType.Int64);

            Assert.IsTrue(allEntities.ContainsKey("Parent_Child_DoubleValue"));
            Assert.AreEqual(allEntities["Child_DoubleValue"].DoubleValue, mwp.Parent.Child.DoubleValue);
            Assert.AreEqual(allEntities["Child_DoubleValue"].PropertyType, EdmType.Double);

            Assert.IsTrue(allEntities.ContainsKey("Parent_Child_GuidValue"));
            Assert.AreEqual(allEntities["Parent_Child_GuidValue"].GuidValue, mwp.Parent.Child.GuidValue);
            Assert.AreEqual(allEntities["Parent_Child_GuidValue"].PropertyType, EdmType.Guid);

            Assert.IsTrue(allEntities.ContainsKey("Parent_Child_DTValue"));
            Assert.AreEqual(allEntities["Parent_Child_DTValue"].DateTime, mwp.Parent.Child.DTValue);
            Assert.AreEqual(allEntities["Parent_Child_DTValue"].PropertyType, EdmType.DateTime);

            Assert.IsTrue(allEntities.ContainsKey("Parent_Child_DTOValue"));
            Assert.AreEqual(allEntities["Parent_Child_DTOValue"].DateTimeOffsetValue, mwp.Parent.Child.DTOValue);
            Assert.AreEqual(allEntities["Parent_Child_DTOValue"].PropertyType, EdmType.DateTime);
        }

        [TestMethod]
        public void TestConverterException() {
            UnsupportedTypePoco ustp = new UnsupportedTypePoco();
            Assert.ThrowsException<ConverterException>(()=>ObjectSerializer.Serialize(ustp));
        } 

        [TestMethod]
        public void TestBooleanAndByte() {
            ByteAndBooleanPoco spo = ByteAndBooleanPoco.Create();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(spo);
            Assert.AreEqual(3, allEntities.Count);
            //CHECK ID
            Assert.IsTrue(allEntities.ContainsKey("BoolValue"));
            Assert.AreEqual(allEntities["BoolValue"].BooleanValue, spo.BoolValue);
            Assert.AreEqual(allEntities["BoolValue"].PropertyType, EdmType.Boolean);
            
            Assert.IsTrue(allEntities.ContainsKey("BooleanValue"));
            Assert.AreEqual(allEntities["BooleanValue"].BooleanValue, spo.BooleanValue);
            Assert.AreEqual(allEntities["BooleanValue"].PropertyType, EdmType.Boolean);

            Assert.IsTrue(allEntities.ContainsKey("ByteValue"));
            Assert.AreEqual(allEntities["ByteValue"].BinaryValue, spo.ByteValue);
            Assert.AreEqual(allEntities["ByteValue"].PropertyType, EdmType.Binary);

        }

    }
}
