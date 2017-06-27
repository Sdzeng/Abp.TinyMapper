using System;


namespace Abp.TinyMapper
{
    public abstract class TinyMapAttributeBase : Attribute
    {
        public Type[] TargetTypes { get; private set; }

        protected TinyMapAttributeBase(params Type[] targetTypes)
        {
            TargetTypes = targetTypes;
        }

        public abstract void CreateMap(Type type);
    }
}