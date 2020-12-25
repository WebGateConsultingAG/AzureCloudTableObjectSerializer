using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class LongConverter:IConverter {
        public bool IsType(Type type) {
            return type == typeof(long) || type == typeof(long?);
        }

        public EntityProperty GetValue(Type type, Object value){
            return type== typeof(long) ? new EntityProperty((long) value) : new EntityProperty((long?) value);
        }
    }
}
