﻿using System;

namespace Nelibur.ObjectMapper.CodeGenerators.Emitters
{
    internal static class EmitThis
    {
        public static IEmitterType Load(Type thisType)
        {
            return EmitArgument.Load(thisType, 0);
        }
    }
}
