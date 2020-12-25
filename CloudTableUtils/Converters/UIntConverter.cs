using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
using System.Globalization;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class UIntConverter:IConverter {
        public bool IsType(Type type) {
            return type == typeof(uint) || type == typeof(uint?);
        }

        public EntityProperty GetValue(Type type, Object value){
            return type== typeof(uint) ? new EntityProperty(unchecked(Convert.ToInt32(value, CultureInfo.InvariantCulture))) : new EntityProperty(unchecked((int?) Convert.ToInt32(value,CultureInfo.InvariantCulture)));
        }
    }
}
