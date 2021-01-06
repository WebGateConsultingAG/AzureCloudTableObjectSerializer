using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebGate.Azure.CloudTableUtils;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;

namespace WebGate.Azure.CloudTableUtilsTest {
     [TestClass]
    public class SerializerListArrayTest {
        [TestMethod]
        public void TestPocoWithEmptyArray() {
            SimplePocoWithArray spwa = SimplePocoWithArray.CreateEmptySimplePocoWithArray();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(spwa);
            Assert.AreEqual(0, allEntities.Count);
        }
        [TestMethod]
        public void TestPocoWithInitializedArray() {
            SimplePocoWithArray spwa = SimplePocoWithArray.CreateFilledSimplePocoWithArray();
            string jsonArray = JsonConvert.SerializeObject(spwa.DateTimeArray);
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(spwa);
            Assert.AreEqual(3, allEntities.Count);
            Assert.AreEqual(jsonArray, allEntities["DateTimeArray"].StringValue);
        }
    }
}