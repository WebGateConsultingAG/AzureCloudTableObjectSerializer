using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebGate.Azure.CloudTableUtils;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;

namespace WebGate.Azure.CloudTableUtilsTest {
    [TestClass]
    public class BuilderIEnumberableTest {
        [TestMethod]
        public void TestListObjects() {
            PocoWihtListChildren pwlc = PocoWihtListChildren.CreateInitializdedPWLC();
            IDictionary<string,EntityProperty> allEntities = ObjectSerializer.Serialize(pwlc);
            PocoWihtListChildren build = ObjectBuilder.Build<PocoWihtListChildren>(allEntities);
            Assert.AreEqual(2, allEntities.Count);

            Assert.AreEqual(3, build.Children.Count);
            CollectionAssert.AreEqual(build.Children, pwlc.Children);

        }
    }
}