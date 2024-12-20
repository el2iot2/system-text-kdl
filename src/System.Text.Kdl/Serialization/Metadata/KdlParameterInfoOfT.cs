// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics;

namespace System.Text.Kdl.Serialization.Metadata
{
    /// <summary>
    /// Represents a strongly-typed parameter to prevent boxing where have less than 4 parameters.
    /// Holds relevant state like the default value of the parameter, and the position in the method's parameter list.
    /// </summary>
    internal sealed class KdlParameterInfo<T> : KdlParameterInfo
    {
        public new KdlConverter<T> EffectiveConverter => MatchingProperty.EffectiveConverter;
        public new KdlPropertyInfo<T> MatchingProperty { get; }
        public new T? EffectiveDefaultValue { get; }

        public KdlParameterInfo(KdlParameterInfoValues parameterInfoValues, KdlPropertyInfo<T> matchingPropertyInfo)
            : base(parameterInfoValues, matchingPropertyInfo)
        {
            Debug.Assert(parameterInfoValues.ParameterType == typeof(T));
            Debug.Assert(!matchingPropertyInfo.IsConfigured);

            if (parameterInfoValues is { HasDefaultValue: true, DefaultValue: object defaultValue })
            {
                EffectiveDefaultValue = (T)defaultValue;
            }

            MatchingProperty = matchingPropertyInfo;
            base.EffectiveDefaultValue = EffectiveDefaultValue;
        }
    }
}