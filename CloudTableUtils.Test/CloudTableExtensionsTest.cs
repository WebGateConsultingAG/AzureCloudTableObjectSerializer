using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebGate.Azure.CloudTableUtils;
using Microsoft.Azure.Cosmos.Table;
using Moq;

namespace WebGate.Azure.CloudTableUtilsTest {
    [TestClass]
    public class CloudTableExtensionsTest {
        [TestMethod]
        public async Task TestGetAllExtension() {
            
            TableQuerySegment<DynamicTableEntity> result = TestHelper.CreateTableQuerySegment(TestHelper.GenerateListOfSimplePoco());
            var mock = new Mock<CloudTableMock>();
            mock.Setup(cloudTable=>cloudTable.ExecuteQuerySegmentedAsync(It.IsAny<TableQuery<DynamicTableEntity>>(),It.IsAny<TableContinuationToken>())).ReturnsAsync(result);
            List<SimplePoco> simplePocos = await CloudTableUtils.CloudTableExtension.CloudTableExtensions.GetAllAsync<SimplePoco>(mock.Object);
            Assert.IsNotNull(simplePocos);
            Assert.AreEqual(6, simplePocos.Count());
            SimplePoco spo = simplePocos.ElementAt(0);
            Assert.IsInstanceOfType(spo, typeof(SimplePoco));
            Assert.AreEqual("001", spo.Id);
        }
    }



    public class CloudTableMock : CloudTable
    {
        public CloudTableMock() : base(new Uri("http://127.0.0.1:10002/devstoreaccount1/screenSettings"))
        {
        }
    }

    public static class TestHelper {
        public static List<DynamicTableEntity> GenerateListOfSimplePoco() {
            IEnumerable<String> ids = new List<string>(){"001","003","031","101","0301","21001"};
            List<DynamicTableEntity> listSP = ids.Select(id=> {
                SimplePoco spo = SimplePoco.CreateInitializedPoco();
                spo.Id = id;
                IDictionary<string,EntityProperty> entities = ObjectSerializer.Serialize(spo);
                DynamicTableEntity dte =  new DynamicTableEntity(typeof(SimplePoco).ToString(), id);
                dte.Properties = entities;
                return dte;
            }).ToList();
            return listSP;
        }
        public static TableQuerySegment<DynamicTableEntity> CreateTableQuerySegment(List<DynamicTableEntity> lstResult) {
            var ctor = typeof(TableQuerySegment<DynamicTableEntity>)
                .GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(c => c.GetParameters().Count() == 1);

            return ctor.Invoke(new object[] { lstResult }) as TableQuerySegment<DynamicTableEntity>;
        }
    }
}