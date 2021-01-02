using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
using System.Globalization;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class ULongConverter:IConverter {
        public bool IsType(Type type) {
            return type == typeof(ulong) || type == typeof(ulong?);
        }

        public EntityProperty GetValue(Type type, Object value){
            return type== typeof(ulong) ? new EntityProperty(unchecked(Convert.ToInt64(value, CultureInfo.InvariantCulture))) : new EntityProperty(unchecked((long?) Convert.ToInt64(value,CultureInfo.InvariantCulture)));
        }
        public object BuildValue(EntityProperty entityProperty, Type type) {
            return unchecked((ulong)entityProperty.Int64Value);
        }

    }
}
