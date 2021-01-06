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

        [TestMethod]
        public async Task TestGetAllWithPartitionKeyExtension() {
            
            TableQuerySegment<DynamicTableEntity> result = TestHelper.CreateTableQuerySegment(TestHelper.GenerateListOfSimplePoco());
            var mock = new Mock<CloudTableMock>();
            mock.Setup(cloudTable=>cloudTable.ExecuteQuerySegmentedAsync(It.IsAny<TableQuery<DynamicTableEntity>>(),It.IsAny<TableContinuationToken>())).ReturnsAsync(result);
            List<SimplePoco> simplePocos = await CloudTableUtils.CloudTableExtension.CloudTableExtensions.GetAllAsync<SimplePoco>(mock.Object,"SimplePoco");
            Assert.IsNotNull(simplePocos);
            Assert.AreEqual(6, simplePocos.Count());
            SimplePoco spo = simplePocos.ElementAt(0);
            Assert.IsInstanceOfType(spo, typeof(SimplePoco));
            Assert.AreEqual("001", spo.Id);
        }
        [TestMethod]
        public async Task TestGetAlByQuery() {
            
            TableQuery<DynamicTableEntity> query = new TableQuery<DynamicTableEntity>();
            TableQuerySegment<DynamicTableEntity> result = TestHelper.CreateTableQuerySegment(TestHelper.GenerateListOfSimplePoco());
            var mock = new Mock<CloudTableMock>();
            mock.Setup(cloudTable=>cloudTable.ExecuteQuerySegmentedAsync(It.IsAny<TableQuery<DynamicTableEntity>>(),It.IsAny<TableContinuationToken>())).ReturnsAsync(result);
            List<SimplePoco> simplePocos = await CloudTableUtils.CloudTableExtension.CloudTableExtensions.GetAllByQueryAsync<SimplePoco>(mock.Object,query);
            Assert.IsNotNull(simplePocos);
            Assert.AreEqual(6, simplePocos.Count());
            SimplePoco spo = simplePocos.ElementAt(0);
            Assert.IsInstanceOfType(spo, typeof(SimplePoco));
            Assert.AreEqual("001", spo.Id);
        }
        [TestMethod]
        public async Task TestGetAllById() {
            
            TableResult result = new TableResult();
            result.Result = TestHelper.GenerateListOfSimplePoco().ElementAt(0);
            var mock = new Mock<CloudTableMock>();
            mock.Setup(cloudTable=>cloudTable.ExecuteAsync(It.IsAny<TableOperation>() )).ReturnsAsync(result);
            SimplePoco spo = await CloudTableUtils.CloudTableExtension.CloudTableExtensions.GetByIdAsync<SimplePoco>(mock.Object, "001");
            Assert.IsInstanceOfType(spo, typeof(SimplePoco));
            Assert.AreEqual("001", spo.Id);
        }

        [TestMethod]
        public async Task TestGetAllByIdAndPartionKey() {
            
            TableResult result = new TableResult();
            result.Result = TestHelper.GenerateListOfSimplePoco().ElementAt(0);
            var mock = new Mock<CloudTableMock>();
            mock.Setup(cloudTable=>cloudTable.ExecuteAsync(It.IsAny<TableOperation>() )).ReturnsAsync(result);
            SimplePoco spo = await CloudTableUtils.CloudTableExtension.CloudTableExtensions.GetByIdAsync<SimplePoco>(mock.Object, "001", "SimplePoco");
            Assert.IsInstanceOfType(spo, typeof(SimplePoco));
            Assert.AreEqual("001", spo.Id);
        }

        [TestMethod]
        public async Task TestInsertOrReplace() {
            
            TableResult result = new TableResult();
            SimplePoco spo =SimplePoco.CreateInitializedPoco();
            result.Result = TestHelper.GenerateListOfSimplePoco().ElementAt(0);
            var mock = new Mock<CloudTableMock>();
            mock.Setup(cloudTable=>cloudTable.ExecuteAsync(It.IsAny<TableOperation>() )).ReturnsAsync(result);
            TableResult tableResult = await CloudTableUtils.CloudTableExtension.CloudTableExtensions.InsertOrReplaceAsync(mock.Object, "001", "SimplePoco", spo);
            Assert.IsNotNull(tableResult);
        }
        [TestMethod]
        public async Task TestInsertOrMerge() {
            
            TableResult result = new TableResult();
            SimplePoco spo =SimplePoco.CreateInitializedPoco();
            result.Result = TestHelper.GenerateListOfSimplePoco().ElementAt(0);
            var mock = new Mock<CloudTableMock>();
            mock.Setup(cloudTable=>cloudTable.ExecuteAsync(It.IsAny<TableOperation>() )).ReturnsAsync(result);
            TableResult tableResult = await CloudTableUtils.CloudTableExtension.CloudTableExtensions.InsertOrMergeAsync(mock.Object, "001", "SimplePoco", spo);
            Assert.IsNotNull(tableResult);
        }

        [TestMethod]
        public async Task TestDelete() {
            
            TableResult result = new TableResult();
            result.Result = TestHelper.GenerateListOfSimplePoco().ElementAt(0);
            var mock = new Mock<CloudTableMock>();
            mock.Setup(cloudTable=>cloudTable.ExecuteAsync(It.IsAny<TableOperation>() )).ReturnsAsync(result);
            TableResult tableResult = await CloudTableUtils.CloudTableExtension.CloudTableExtensions.DeleteAsync(mock.Object, "001", "SimplePoco");
            Assert.IsNotNull(tableResult);
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