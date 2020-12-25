using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class IntConverter:IConverter {
        public bool IsType(Type type) {
            return type == typeof(int) || type == typeof(int?);
        }

        public EntityProperty GetValue(Type type, Object value){
            return type== typeof(int) ? new EntityProperty((int) value) : new EntityProperty((int?) value);
        }
    }
}
