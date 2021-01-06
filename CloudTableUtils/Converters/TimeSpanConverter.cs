using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
using System.Globalization;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class TimeSpanConverter:IConverter {
        public bool IsType(Type type) {
            return type == typeof(TimeSpan) || type == typeof(TimeSpan?);
        }

        public EntityProperty GetValue(Type type, Object value){
            string stringValue = value != null ? value.ToString(): null; 
            return new EntityProperty(stringValue);
        }
        public object BuildValue(EntityProperty entityProperty, Type type) {
            return TimeSpan.Parse(entityProperty.StringValue, CultureInfo.InvariantCulture);
        }

    }
}
