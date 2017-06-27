using System;
using Nelibur.ObjectMapper;
using Abp.Collections.Extensions;
 

namespace Abp.TinyMapper
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class TinyMapAttribute : TinyMapAttributeBase
    {
        public TinyMapAttribute(params Type[] targetTypes)
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
                //if (targetType.FullName == "WinMS.Core.Entities.Info.BarcodeInfo")
                //{
                //    var ww = "";
                //}
                Nelibur.ObjectMapper.TinyMapper.Bind(type, targetType);
                Nelibur.ObjectMapper.TinyMapper.Bind(targetType, type);
            }
        }
    }
}