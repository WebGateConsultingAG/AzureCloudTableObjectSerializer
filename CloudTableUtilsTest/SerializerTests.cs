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
            Assert.AreEqual(7, allEntities.Count);
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

        }
        [TestMethod]
        public void TestExtractAllEnitiesFromSimplePocoWithNullId()
        {
            SimplePoco spo = SimplePoco.CreatePocoWithoutID();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(spo);
            Assert.AreEqual(6, allEntities.Count);
            Assert.IsFalse(allEntities.ContainsKey("Id"));
           
        }
    }
}
