using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class DateTimeConverter:IConverter {
        public bool IsType(Type type) {
            return type == typeof(DateTime) || type == typeof(DateTime?);
        }

        public EntityProperty GetValue(Type type, Object value){
            return type== typeof(DateTime) ? new EntityProperty((DateTime) value) : new EntityProperty((DateTime?) value);
        }

        public object BuildValue(EntityProperty entityProperty, Type type) {
            return entityProperty.DateTime;
        }

    }
}