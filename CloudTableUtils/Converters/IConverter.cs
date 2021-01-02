using System;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils.Converter {
    public interface IConverter {
        public bool IsType(Type type);

        public EntityProperty GetValue(Type type, Object value);

        public object BuildValue(EntityProperty entityProperty, Type type);
    }
}