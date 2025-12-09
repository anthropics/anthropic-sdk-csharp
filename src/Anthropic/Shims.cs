#if !NET
#pragma warning disable IDE0130 // Namespace does not match folder structure
#pragma warning disable CS9113 // Unused parameters

namespace System.Runtime.CompilerServices
{
    // Allow `required` to compile when targeting .NET Standard 2.0.
    [AttributeUsage(
        AttributeTargets.Class
            | AttributeTargets.Struct
            | AttributeTargets.Property
            | AttributeTargets.Field,
        AllowMultiple = false,
        Inherited = false
    )]
    internal sealed class RequiredMemberAttribute : Attribute;

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    internal sealed class CompilerFeatureRequiredAttribute(string feature) : Attribute;

    // Allow `init` to compile when targeting .NET Standard 2.0.
    internal static class IsExternalInit;
}

namespace System.Diagnostics.CodeAnalysis
{
    // Allow `[SetsRequiredMembers]` to compile when targeting .NET Standard 2.0.
    [AttributeUsage(AttributeTargets.Constructor, AllowMultiple = false, Inherited = false)]
    internal sealed class SetsRequiredMembersAttribute : Attribute;

    // Allow `[MaybeNullWhen(...)]` to compile when targeting .NET Standard 2.0.
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    internal sealed class MaybeNullWhenAttribute(bool returnValue) : Attribute;

    // Allow `[NotNullWhen(...)]` to compile when targeting .NET Standard 2.0.
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    internal sealed class NotNullWhenAttribute(bool returnValue) : Attribute;
}
#endif
