using System;
using Abp.Collections.Extensions;

namespace Abp.TinyMapper
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TinyMapToAttribute : TinyMapAttributeBase
    {
     
        public TinyMapToAttribute(params Type[] targetTypes)
            : base(targetTypes)
        {

        }


        public override void CreateMap(Type type)
        {
            if (TargetTypes.IsNullOrEmpty())
            {
                return;
            }

            foreach (var targetType in TargetTypes)
            {
                Nelibur.ObjectMapper.TinyMapper.Bind(type, targetType);
            }
        }
    }
}