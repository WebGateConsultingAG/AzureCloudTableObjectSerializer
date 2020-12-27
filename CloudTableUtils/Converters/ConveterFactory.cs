using System;
using System.Collections.Generic;
using System.Linq;

namespace WebGate.Azure.CloudTableUtils.Converter {

    public class ConveterFactory {
        private static List<IConverter> converters = null;

        public static IConverter FindConverter(Type type) {
            if (converters == null) {
                converters = InitConverters();
            }
            return converters.Find(converter=>converter.IsType(type));
        }

        private static List<IConverter> InitConverters() {
            List<IConverter> list = new List<IConverter>();
            list.Add(new BooleanConverter());
            list.Add(new ByteConverter());
            list.Add(new DateTimeConverter());
            list.Add(new DateTimeOffsetConverter());
            list.Add(new DoubleConverter());
            list.Add(new EnumConverter());
            list.Add(new GuidConverter());
            list.Add(new IntConverter());
            list.Add(new LongConverter());
            list.Add(new StringConverter());
            list.Add(new TimeSpanConverter());
            list.Add(new UIntConverter());
            list.Add(new ULongConverter());
            list.Add(new ArrayConverter());
            return list;
        }
    }
}