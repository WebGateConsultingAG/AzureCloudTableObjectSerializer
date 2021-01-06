using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebGate.Azure.CloudTableUtils;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;

namespace WebGate.Azure.CloudTableUtilsTest {
    [TestClass]
    public class SerializerIEnumberableTest {
        [TestMethod]
        public void TestListObjects() {
            PocoWihtListChildren pwlc = PocoWihtListChildren.CreateInitializdedPWLC();
            IDictionary<string,EntityProperty> allEntities = ObjectSerializer.Serialize(pwlc);
            Assert.AreEqual(2, allEntities.Count);
        }
    }
}