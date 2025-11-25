// This file provides minimal compatibility shims for types not available
// when targeting .NET Standard 2.0.

#if !NET
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace System.Runtime.CompilerServices
{
    // Shim to enable `init` accessors when compiling against older targets.
    // The compiler looks for the `IsExternalInit` type
    internal static class IsExternalInit { }

    // Supports `required` members feature: marks members that must be
    // initialized during object construction.
    [AttributeUsage(
        AttributeTargets.Class
            | AttributeTargets.Struct
            | AttributeTargets.Property
            | AttributeTargets.Field
            | AttributeTargets.Event,
        Inherited = false
    )]
    internal sealed class RequiredMemberAttribute : Attribute { }

    // Applied to constructors (or factory methods) that ensure required
    // members are set. Compiler recognizes this attribute when analyzing
    // object initialization for `required` members.
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
    internal sealed class SetsRequiredMembersAttribute : Attribute { }
}

// Additional shims required by generated model code when compiling
// against netstandard2.0. These are minimal stubs that provide the
// types and constructors the compiler and source-generated code expect.
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    internal sealed class CompilerFeatureRequiredAttribute : Attribute
    {
        public CompilerFeatureRequiredAttribute(string feature)
        {
            Feature = feature;
        }

        public string Feature { get; }
    }
}

namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
    internal sealed class SetsRequiredMembersAttribute : Attribute
    {
        public SetsRequiredMembersAttribute() { }
    }

    [AttributeUsage(
        AttributeTargets.Class
            | AttributeTargets.Struct
            | AttributeTargets.Property
            | AttributeTargets.Field
            | AttributeTargets.Event,
        Inherited = false
    )]
    internal sealed class RequiredMemberAttribute : Attribute
    {
        public RequiredMemberAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    internal sealed class NotNullWhenAttribute : Attribute
    {
        public NotNullWhenAttribute(bool returnValue) { }
    }
}

namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    internal sealed class MaybeNullWhenAttribute : Attribute
    {
        public MaybeNullWhenAttribute(bool returnValue) { }
    }

    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    internal sealed class MaybeNullAttribute : Attribute
    {
        public MaybeNullAttribute() { }
    }
}
#else
// The compiler emits a reference to the internal copy of this type in the non-.NET builds,
// so we must include a forward to be compatible.
[assembly: System.Runtime.CompilerServices.TypeForwardedTo(
    typeof(System.Runtime.CompilerServices.IsExternalInit)
)]
#endif
