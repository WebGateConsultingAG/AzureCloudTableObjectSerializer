using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class DoubleConverter:IConverter {
        public bool IsType(Type type) {
            return type == typeof(double) || type == typeof(double?);
        }

        public EntityProperty GetValue(Type type, Object value){
            return type== typeof(double) ? new EntityProperty((double) value) : new EntityProperty((double?) value);
        }
    }
}
