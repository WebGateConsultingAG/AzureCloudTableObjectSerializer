using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class EnumConverter:IConverter {
        public bool IsType(Type type) {
            return type.IsEnum;
        }

        public EntityProperty GetValue(Type type, Object value){
            return new EntityProperty(value.ToString());
        }
        public object BuildValue(EntityProperty entityProperty, Type type) {
            return Enum.Parse(type,entityProperty.StringValue);
        }

    }
}