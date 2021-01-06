using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebGate.Azure.CloudTableUtils;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtilsTest
{
    [TestClass]
    public class BuilderTests {
        [TestMethod]
        public void TestBuildAllEnitiesFromSimplePoco()
        {
            SimplePoco spo = SimplePoco.CreateInitializedPoco();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(spo);
            Assert.AreEqual(11, allEntities.Count);
            SimplePoco build = ObjectBuilder.Build<SimplePoco>(allEntities);
            Assert.IsNotNull(build);
            Assert.AreEqual(spo.Id, build.Id);
            Assert.AreEqual(spo.DoubleValue, build.DoubleValue);
            Assert.AreEqual(spo.DTOValue, build.DTOValue);
            Assert.AreEqual(spo.DTValue, build.DTValue);
            Assert.AreEqual(spo.GuidValue, build.GuidValue);
            Assert.AreEqual(spo.IntValue, build.IntValue);
            Assert.AreEqual(spo.LongValue, build.LongValue);
            Assert.AreEqual(spo.UIntValue, build.UIntValue);
            Assert.AreEqual(spo.ULongValue, build.ULongValue);
            Assert.AreEqual(spo.TimeSpanValue, build.TimeSpanValue);
            Assert.AreEqual(spo.EnumValue, build.EnumValue);
            


        }
        [TestMethod]
        public void TestBuildAllEnitiesFromSimplePocoWithNullId()
        {
            SimplePoco spo = SimplePoco.CreatePocoWithoutID();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(spo);
            Assert.AreEqual(10, allEntities.Count);
            Assert.IsFalse(allEntities.ContainsKey("Id"));
            SimplePoco build = ObjectBuilder.Build<SimplePoco>(allEntities);
            Assert.IsNotNull(build);
            Assert.IsNull(build.Id);
           
        }
        [TestMethod]
        public void TestBuildAllEnitiesFromParentPoco()
        {
            ParentPoco pp = ParentPoco.CreateParentWithChild();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(pp);
            Assert.AreEqual(12, allEntities.Count);
            ParentPoco build = ObjectBuilder.Build<ParentPoco>(allEntities);
            Assert.IsNotNull(build);
            Assert.IsInstanceOfType(build, typeof(ParentPoco));

        }
        [TestMethod]
        public void TestBuildAllEnitiesFromMainWithParent()
        {
            MainWithParent mwp = MainWithParent.CreateMainWithParent();
            IDictionary<String,EntityProperty> allEntities = ObjectSerializer.Serialize(mwp);
            Assert.AreEqual(24, allEntities.Count);
            Assert.IsTrue(allEntities.ContainsKey("Id"));
            MainWithParent build = ObjectBuilder.Build<MainWithParent>(allEntities);
            Assert.IsNotNull(build);
            Assert.IsInstanceOfType(build, typeof(MainWithParent));
        }
    }
}
