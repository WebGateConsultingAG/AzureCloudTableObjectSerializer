using System;
using System.Linq;
using Microsoft.Azure.Cosmos.Table;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace WebGate.Azure.CloudTableUtils.Converter {
    public class IEnumerableConverter:IConverter {
        
        public bool IsType(Type type) {
            return type.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof (IEnumerable<>)) ;
        }

        public EntityProperty GetValue(Type type, object value) {
            string jsonValue = JsonConvert.SerializeObject(value);
            return new EntityProperty(jsonValue);
        }
        public object BuildValue(EntityProperty entityProperty, Type type) {
            return JsonConvert.DeserializeObject(entityProperty.StringValue, type);
        }

    }
}