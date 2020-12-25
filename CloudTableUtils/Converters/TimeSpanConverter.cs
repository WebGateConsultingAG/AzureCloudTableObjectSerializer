using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class TimeSpanConverter:IConverter {
        public bool IsType(Type type) {
            return type == typeof(TimeSpan) || type == typeof(TimeSpan?);
        }

        public EntityProperty GetValue(Type type, Object value){
            return type== typeof(TimeSpan) ? new EntityProperty(value.ToString()) : new EntityProperty(value != null ? value.ToString():null);
        }
    }
}
