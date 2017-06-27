using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Abp.TinyMapper
{
    internal static class TinyMapperConfigurationExtensions
    {
        public static void CreateTinyAttributeMaps(this Type type)
        {
            foreach (var autoMapAttribute in type.GetTypeInfo().GetCustomAttributes<TinyMapAttributeBase>())
            {
                autoMapAttribute.CreateMap(type);
            }
        }
    }
}
