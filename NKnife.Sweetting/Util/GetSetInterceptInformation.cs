﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NKnife.Sweetting.Extensions;
using NKnife.Sweetting.Interfaces;

namespace NKnife.Sweetting.Util
{
    /// <summary>
    /// This is the type information for configuration types.
    /// </summary>
    public class GetSetInterceptInformation
    {
        /// <summary>
        /// Store of setter methods
        /// </summary>
        public MethodInfo[] SetterMethods { get; }

        /// <summary>
        /// Store of setter methods
        /// </summary>
        public MethodInfo[] GetterMethods { get; }

        /// <summary>
        /// Fill all the values
        /// </summary>
        /// <param name="containingType">Type</param>
        public GetSetInterceptInformation(Type containingType)
        {
            var methods = new List<Tuple<MethodInfo, GetSetInterceptorAttribute>>();
            var currentType = containingType;
            do
            {
                foreach(var methodInfo in currentType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    var interceptAttribute = methodInfo.GetAttribute<GetSetInterceptorAttribute>();
                    if (interceptAttribute == null)
                    {
                        continue;
                    }
                    methods.Add(new Tuple<MethodInfo, GetSetInterceptorAttribute>(methodInfo, interceptAttribute));
                }
                currentType = currentType.BaseType;
            } while (currentType != null && currentType != typeof(object));

            GetterMethods = methods
                .Where(method => !method.Item2.IsSetter)
                .OrderBy(method => method.Item2.Order)
                .Select(method => method.Item1)
                .ToArray();
            SetterMethods = methods
                .Where(method => method.Item2.IsSetter)
                .OrderBy(method => method.Item2.Order)
                .Select(method => method.Item1)
                .ToArray();
        }
    }
}
