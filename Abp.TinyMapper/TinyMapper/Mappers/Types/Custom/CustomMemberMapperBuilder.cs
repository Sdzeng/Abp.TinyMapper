﻿using System;
using Nelibur.ObjectMapper.Bindings;
using Nelibur.ObjectMapper.Core.DataStructures;
using Nelibur.ObjectMapper.Mappers.Classes.Members;

namespace Nelibur.ObjectMapper.Mappers.Types.Custom
{
    /// <summary>
    /// 类内部成员的自定义转换
    /// </summary>
    internal sealed class CustomMemberMapperBuilder : MapperBuilder
    {
        public CustomMemberMapperBuilder(IMapperBuilderConfig config) : base(config)
        {
        }

        protected override string ScopeName
        {
            get { return "CustomMemberMapper"; }
        }

        public bool IsSupported(TypePair parentTypePair, MappingMember mappingMember)
        {
            Option<BindingConfig> bindingConfig = _config.GetBindingConfig(parentTypePair);
            if (bindingConfig.HasNoValue)
            {
                return false;
            }
            return bindingConfig.Value.HasCustomTypeConverter(mappingMember.Target.Name);
        }

        protected override Mapper BuildCore(TypePair typePair)
        {
            throw new NotSupportedException();
        }

        protected override Mapper BuildCore(TypePair parentTypePair, MappingMember mappingMember)
        {
            Option<BindingConfig> bindingConfig = _config.GetBindingConfig(parentTypePair);
            Func<object, object> converter = bindingConfig.Value.GetCustomTypeConverter(mappingMember.Target.Name).Value;
            return new CustomMemberMapper(converter);
        }

        protected override bool IsSupportedCore(TypePair typePair)
        {
            throw new NotSupportedException();
        }
    }
}
