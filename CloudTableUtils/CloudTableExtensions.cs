using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.CloudTableExtension {
    public static class CloudTableExtensions {
        public static async Task<List<T>> GetAll<T>(this CloudTable cloudTable) {
            return null;
        }
        public static async Task<List<T>> GetAll<T>(this CloudTable cloudTable, string partition) {
            return null;
        }

        public static async Task<T> GetById<T>(this CloudTable cloudTable, String id) {
            return default(T);
        }
        public static async Task<T> GetById<T>(this CloudTable cloudTable, String id, string partition) {
            return default(T);
        }
    }
}