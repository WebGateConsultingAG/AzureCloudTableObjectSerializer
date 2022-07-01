using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
using System.Linq;
namespace WebGate.Azure.CloudTableUtils {

    public class CloudTableService {
        private Dictionary<string, CloudTable> _tables;

        public CloudTableService(string connectionString, List<string> tableNames) {
           CloudTableClient cloudTableClient = CloudStorageAccount.Parse(connectionString).CreateCloudTableClient();
           _tables = tableNames.ToDictionary(tableName => tableName, tableName => {
            CloudTable table = cloudTableClient.GetTableReference(tableName);
            table.CreateIfNotExists();
            return table;
           });
        }

        public CloudTable GetTableByName(string tableName) {
            return _tables[tableName];
        }
    }
}