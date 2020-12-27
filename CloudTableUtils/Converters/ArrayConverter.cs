using System;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;
namespace WebGate.Azure.CloudTableUtils.Converter {
    public class ArrayConverter:IConverter {
        
        public bool IsType(Type type) {
            return type.IsArray;
        }

        public EntityProperty GetValue(Type type, object value) {
            string jsonValue = JsonConvert.SerializeObject(value);
            return new EntityProperty(jsonValue);
        }
    }
}