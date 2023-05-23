using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
using System.Linq;
using System.Collections.Concurrent;

namespace WebGate.Azure.CloudTableUtils
{

    public class CloudTableService
    {
        private ConcurrentDictionary<string, CloudTable> _tables;
        private HashSet<string> _checked = new HashSet<string>();
        private readonly Object _checkedLock = new Object();

        public CloudTableService(string connectionString, List<string> tableNames)
        {
            CloudTableClient cloudTableClient = CloudStorageAccount.Parse(connectionString).CreateCloudTableClient();
            lock (_checked)
            {
                var allTables = tableNames.ToDictionary(tableName => tableName, tableName =>
                {
                    CloudTable table = cloudTableClient.GetTableReference(tableName);
                    return table;
                });
                _tables = new ConcurrentDictionary<string, CloudTable>(allTables);
            }
        }

        public CloudTable GetTableByName(string tableName)
        {
            if (!_tables.ContainsKey(tableName))
            {
                throw new ArgumentOutOfRangeException(tableName + " not defined in Service");
            }
            CloudTable cloudTable = _tables[tableName];
            lock (_checkedLock)
            {
                if (!_checked.Contains(tableName))
                {
                    cloudTable.CreateIfNotExists();
                    _checked.Add(tableName);
                }
            }
            return cloudTable;
        }
    }
}