using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
using WebGate.Azure.CloudTableUtils.Converter;
namespace WebGate.Azure.CloudTableUtils
{
    public static class ObjectSerializer{

        public static IDictionary<String,EntityProperty>Serialize(object obj) {
            IDictionary<String,EntityProperty> entities = new Dictionary<String,EntityProperty>();
            ProcessObject(obj, null,entities);
            return entities;
        }

        private static void ProcessObject(object obj, string path, IDictionary<String,EntityProperty> entities) {
            obj.GetType().GetProperties().Where(propertInfo => propertInfo.CanRead && propertInfo.CanWrite).ToList().ForEach(propertyInfo => {
                string id = propertyInfo.Name;
                object value = propertyInfo.GetValue(obj, index:null);
                if (value != null) {
                    IConverter converter = ConveterFactory.FindConverter(value.GetType());
                    if (converter == null) {
                        if (value.GetType().IsValueType) {
                            throw new ConverterException("No convertor found for: "+id +" / "+ propertyInfo.GetType().ToString());
                        } else {
                            ProcessObject(value, BuildEntityName(path,id), entities);
                        }
                    } else {
                        EntityProperty ep = converter.GetValue(propertyInfo.GetType(), propertyInfo.GetValue(obj));
                        entities.Add(BuildEntityName(path,id),ep);
                    }
                }
            });

        }

        private static string BuildEntityName(string path, string id) {
            if (string.IsNullOrEmpty(path)) {
                return id;
            }
            return path +"_"+id;
        }
    }

    
}
