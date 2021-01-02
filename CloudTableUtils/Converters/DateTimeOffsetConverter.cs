using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class DateTimeOffsetConverter:IConverter {
        public bool IsType(Type type) {
            return type == typeof(DateTimeOffset) || type == typeof(DateTimeOffset?);
        }

        public EntityProperty GetValue(Type type, Object value){
            return type== typeof(DateTimeOffset) ? new EntityProperty((DateTimeOffset) value) : new EntityProperty((DateTimeOffset?) value);
        }

        public object BuildValue(EntityProperty entityProperty, Type type) {
            return entityProperty.DateTimeOffsetValue;
        }

    }
}