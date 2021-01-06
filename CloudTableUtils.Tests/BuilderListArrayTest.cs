using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebGate.Azure.CloudTableUtils;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;

namespace WebGate.Azure.CloudTableUtilsTest {
     [TestClass]
    public class BuilderListArrayTest {
        [TestMethod]
        public void TestPocoWithEmptyArray() {
            SimplePocoWithArray spwa = SimplePocoWithArray.CreateEmptySimplePocoWithArray();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(spwa);
            SimplePocoWithArray build = ObjectBuilder.Build<SimplePocoWithArray>(allEntities);
            Assert.AreEqual(0, allEntities.Count);
            Assert.IsNull(build.DateTimeArray);
        }
        [TestMethod]
        public void TestPocoWithInitializedArray() {
            SimplePocoWithArray spwa = SimplePocoWithArray.CreateFilledSimplePocoWithArray();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(spwa);
            SimplePocoWithArray build = ObjectBuilder.Build<SimplePocoWithArray>(allEntities);
            Assert.AreEqual(3, allEntities.Count);
            CollectionAssert.AreEqual(build.DateTimeArray, spwa.DateTimeArray);
        }
    }
}