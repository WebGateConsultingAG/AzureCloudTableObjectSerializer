using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class GuidConverter:IConverter {
        public bool IsType(Type type) {
            return type == typeof(Guid) || type == typeof(Guid?);
        }

        public EntityProperty GetValue(Type type, Object value){
            return type== typeof(Guid) ? new EntityProperty((Guid) value) : new EntityProperty((Guid?) value);
        }
        public object BuildValue(EntityProperty entityProperty, Type type) {
            return entityProperty.GuidValue;
        }
    }

}
