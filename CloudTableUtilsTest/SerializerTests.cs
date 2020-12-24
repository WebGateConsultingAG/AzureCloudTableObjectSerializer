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
            SimplePoco spo = new SimplePoco();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(spo);
            Assert.AreEqual(7, allEntities.Count);
        }
    }
}
