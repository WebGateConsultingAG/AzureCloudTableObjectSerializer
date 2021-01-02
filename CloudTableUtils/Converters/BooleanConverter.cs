using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.Converter {

    public class BooleanConverter:IConverter {
        public bool IsType(Type type) {
            return type == typeof(bool) || type == typeof(bool?);
        }

        public EntityProperty GetValue(Type type, Object value){
            return type == typeof(bool) ? new EntityProperty((bool) value): new EntityProperty((bool?)value);
        }

        public object BuildValue(EntityProperty entityProperty, Type type) {
            return null;
        }

    }
}