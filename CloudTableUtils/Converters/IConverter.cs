using System;
using Microsoft.Azure.Cosmos.Table;

public interface IConverter {
    public bool IsType(Type type);

    public EntityProperty GetValue(Type type, Object value);
}