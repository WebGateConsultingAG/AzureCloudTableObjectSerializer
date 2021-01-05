using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.CloudTableExtension {
    public static class CloudTableExtensions {
        public static async Task<List<T>> GetAllAsync<T>(this CloudTable cloudTable) {
            TableQuery<DynamicTableEntity> query = new TableQuery<DynamicTableEntity>();
            TableContinuationToken token = null;
            List<DynamicTableEntity> resultTE = new List<DynamicTableEntity>();
            do {
                TableQuerySegment<DynamicTableEntity> segment = await cloudTable.ExecuteQuerySegmentedAsync<DynamicTableEntity>(query, null);
                Console.Out.WriteLine("Segement: "+segment);
                token = segment.ContinuationToken;
                resultTE.AddRange(segment.Results);
            } while(token != null);
            return resultTE.Select(dte => ObjectBuilder.Build<T>(dte.Properties)).ToList();
        }
        public static async Task<List<T>> GetAllAsync<T>(this CloudTable cloudTable, string partition) {
            return null;
        }

        public static async Task<T> GetByIdAsync<T>(this CloudTable cloudTable, String id) {
            return default(T);
        }
        public static async Task<T> GetByIdAsync<T>(this CloudTable cloudTable, String id, string partition) {
            return default(T);
        }
    }
}