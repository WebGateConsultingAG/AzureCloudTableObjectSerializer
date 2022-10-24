using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
using System.Linq;
namespace WebGate.Azure.CloudTableUtils {

    public class CloudTableService {
        private Dictionary<string, CloudTable> _tables;
        private HashSet<string> _checked = new HashSet<string>();

        public CloudTableService(string connectionString, List<string> tableNames) {
           CloudTableClient cloudTableClient = CloudStorageAccount.Parse(connectionString).CreateCloudTableClient();
           _tables = tableNames.ToDictionary(tableName => tableName, tableName => {
            CloudTable table = cloudTableClient.GetTableReference(tableName);
            return table;
           });
        }

        public CloudTable GetTableByName(string tableName) {
            CloudTable cloudTable = _tables[tableName];
            if (!_checked.Contains(tableName)) {
                cloudTable.CreateIfNotExists();
                _checked.Add(tableName);
            }
            return cloudTable;
        }
    }
}