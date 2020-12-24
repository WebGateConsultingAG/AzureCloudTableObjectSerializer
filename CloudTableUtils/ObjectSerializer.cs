using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;

namespace WebGate.Azure.CloudTableUtils
{
    public class ObjectSerializer{

        public static IDictionary<String,EntityProperty>Serialize(object obj) {
            IDictionary<String,EntityProperty> entities = new Dictionary<String,EntityProperty>();
            obj.GetType().GetProperties().Where(propertInfo => propertInfo.CanRead && propertInfo.CanWrite).ToList().ForEach(propertyInfo => {
                string id = propertyInfo.Name;
                EntityProperty ep = new EntityProperty(""+propertyInfo.GetValue(obj));
                
                entities.Add(id,ep);
            });
            return entities;
        }
    }
}
