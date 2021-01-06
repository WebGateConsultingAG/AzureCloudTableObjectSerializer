using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.CloudTableExtension {
    public static class CloudTableExtensions {
        public static async Task<List<T>> GetAllAsync<T>(this CloudTable cloudTable) {
            TableQuery<DynamicTableEntity> query = new TableQuery<DynamicTableEntity>();
            return await GetAllByQueryAsync<T>(cloudTable, query);
        }
        public static async Task<List<T>> GetAllAsync<T>(this CloudTable cloudTable, string partition) {
            TableQuery<DynamicTableEntity> query = new TableQuery<DynamicTableEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partition));
            return await GetAllByQueryAsync<T>(cloudTable, query);
        }

        public static async Task<List<T>> GetAllByQueryAsync<T>(this CloudTable cloudTable, TableQuery<DynamicTableEntity> query) {
            TableContinuationToken token = null;
            List<DynamicTableEntity> resultTE = new List<DynamicTableEntity>();
            do {
                TableQuerySegment<DynamicTableEntity> segment = await cloudTable.ExecuteQuerySegmentedAsync<DynamicTableEntity>(query, null);
                token = segment.ContinuationToken;
                resultTE.AddRange(segment.Results);
            } while(token != null);
            return resultTE.Select(dte => ObjectBuilder.Build<T>(dte.Properties)).ToList();
        }

        public static async Task<T> GetByIdAsync<T>(this CloudTable cloudTable, String id) {
            string partitionKey = typeof(T).ToString();
            return await GetByIdAsync<T>(cloudTable, id, partitionKey);
        }   
        public static async Task<T> GetByIdAsync<T>(this CloudTable cloudTable, String id, string partition) {
            TableOperation retrive = TableOperation.Retrieve<DynamicTableEntity>(partition,id);
            TableResult result = await cloudTable.ExecuteAsync(retrive);
            DynamicTableEntity dte = result.Result as DynamicTableEntity;
            return ObjectBuilder.Build<T>(dte.Properties);
        }

        public static async Task<TableResult> InsertOrReplaceAsync(this CloudTable cloudTable, string id, string partition, object obj) {
            DynamicTableEntity dte = new DynamicTableEntity(partition, id);
            dte.Properties = ObjectSerializer.Serialize(obj);
            TableOperation inserOrReplace = TableOperation.InsertOrReplace(dte);
            return await cloudTable.ExecuteAsync(inserOrReplace);
        }
        public static async Task<TableResult> InsertOrMergeAsync(this CloudTable cloudTable, string id, string partition, object obj) {
            DynamicTableEntity dte = new DynamicTableEntity(partition, id);
            dte.Properties = ObjectSerializer.Serialize(obj);
            TableOperation inserOrReplace = TableOperation.InsertOrMerge(dte);
            return await cloudTable.ExecuteAsync(inserOrReplace);
        }
        public static async Task<TableResult> DeleteAsync(this CloudTable cloudTable, string id, string partition) {
            DynamicTableEntity dte = new DynamicTableEntity(partition, id){ ETag = "*" };
            TableOperation inserOrReplace = TableOperation.Delete(dte);
            return await cloudTable.ExecuteAsync(inserOrReplace);
        }
    }
}