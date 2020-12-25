using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public class ByteConverter:IConverter {
        public bool IsType(Type type) {
        return type == typeof(byte[]);
        }

        public EntityProperty GetValue(Type type, Object value){
            return new EntityProperty((byte[]) value);
        }
    }
}