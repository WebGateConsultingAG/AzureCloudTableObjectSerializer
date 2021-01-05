using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
using WebGate.Azure.CloudTableUtils.Converter;
using System.Runtime.Serialization;

namespace WebGate.Azure.CloudTableUtils
{
    public class ObjectBuilder {
        public static T Build<T>(IDictionary<string,EntityProperty> entities) {
            T result = (T)FormatterServices.GetUninitializedObject(typeof(T));
            ProcessObject(result, null, entities);
            return result;
     
        }
        private static void ProcessObject(object obj, string path, IDictionary<String,EntityProperty> entities) {
            obj.GetType().GetProperties().Where(propertyInfo => propertyInfo.CanRead && propertyInfo.CanWrite).ToList().ForEach(propertyInfo => {
                string id = propertyInfo.Name;
                string entityName = BuildEntityName(path,id);
                if (entities.ContainsKey(entityName)) {
                    Type pType = propertyInfo.PropertyType;
                    IConverter converter = ConveterFactory.FindConverter(pType);
                    if (pType != null) {
                        propertyInfo.SetValue(obj, converter.BuildValue(entities[entityName], pType), index:null);
                    } else {
                        if (pType.IsValueType) {
                            throw new Exception("No convertor found for: "+id +" / "+ pType.ToString());
                        }
                        object child = FormatterServices.GetUninitializedObject(pType);
                        ProcessObject(child, id,entities);
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