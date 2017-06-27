﻿using System;
using System.Collections.Generic;
using Nelibur.ObjectMapper.Core.DataStructures;
using Nelibur.ObjectMapper.Core.Extensions;

namespace Nelibur.ObjectMapper.Bindings
{
    internal class BindingConfig
    {
    
        private readonly Dictionary<string, string> _bindFields = new Dictionary<string, string>();
        private readonly Dictionary<string, Type> _bindTypes = new Dictionary<string, Type>();
        private readonly Dictionary<string, Func<object, object>> _customMemberConverters = new Dictionary<string, Func<object, object>>();
        private readonly HashSet<string> _ignoreFields = new HashSet<string>();
        private Func<object, object> _customObjcetConverters;

        public void BindObjectConverter(Func<object, object> func)
        {
            _customObjcetConverters = func;
        }

        internal Option<Func<object, object>> GetObjectConverter()
        {
            bool exsist = null != _customObjcetConverters;
            return new Option<Func<object, object>>(_customObjcetConverters, exsist);
        }


        internal void BindMemberConverter(string targetName, Func<object, object> func)
        {
            _customMemberConverters[targetName] = func;
        }

        internal void BindFields(string sourceName, string targetName)
        {
            _bindFields[sourceName] = targetName;
        }

        internal void BindType(string targetName, Type value)
        {
            _bindTypes[targetName] = value;
        }

       

        internal Option<string> GetBindField(string sourceName)
        {
            string result;
            bool exsist = _bindFields.TryGetValue(sourceName, out result);
            return new Option<string>(result, exsist);
        }

        internal Option<Type> GetBindType(string targetName)
        {
            Type result;
            bool exsist = _bindTypes.TryGetValue(targetName, out result);
            return new Option<Type>(result, exsist);
        }

        internal Option<Func<object, object>> GetCustomTypeConverter(string targetName)
        {
            return _customMemberConverters.GetValue(targetName);
        }

        internal bool HasCustomTypeConverter(string targetName)
        {
            return _customMemberConverters.ContainsKey(targetName);
        }

        internal void IgnoreSourceField(string sourceName)
        {
            _ignoreFields.Add(sourceName);
        }

        internal bool IsIgnoreSourceField(string sourceName)
        {
            if (string.IsNullOrEmpty(sourceName))
            {
                return true;
            }
            return _ignoreFields.Contains(sourceName);
        }
    }
}
