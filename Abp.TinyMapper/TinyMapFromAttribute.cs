using System;
using Nelibur.ObjectMapper;
using Abp.Collections.Extensions;

namespace Abp.TinyMapper
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TinyMapFromAttribute : TinyMapAttributeBase
    {
        
        public TinyMapFromAttribute(params Type[] targetTypes): base(targetTypes)
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
                Nelibur.ObjectMapper.TinyMapper.Bind(targetType, type);
            }
        }
    }
}
