using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class StringConverter:IConverter {
        public bool IsType(Type type) {
            return type == typeof(string);
        }

        public EntityProperty GetValue(Type type, Object value){
            return new EntityProperty((string) value);
        }
        public object BuildValue(EntityProperty entityProperty, Type type) {
            return entityProperty.StringValue;
        }

    }
}