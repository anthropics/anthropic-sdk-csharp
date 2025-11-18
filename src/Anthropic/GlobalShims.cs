// This file provides minimal compatibility shims for types not available
// when targeting .NET Standard 2.0. The definitions are intentionally
// small — they forward to `Task` where appropriate so the library can
// compile under netstandard2.0 while remaining source-compatible with
// newer frameworks.

#if NETSTANDARD2_0
global using ValueTask = System.Threading.Tasks.Task;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;


/* ValueTask and related async interface types are provided by
   referenced compatibility packages (e.g. System.Threading.Tasks.Extensions,
   Microsoft.Bcl.AsyncInterfaces). Defining them here can conflict with
   those packages, so we do not provide ValueTask/IAsync* shims in this file. */

/* IAsyncDisposable is provided by compatibility packages on netstandard2.0
   targets; avoid redefining it here to prevent type conflicts. */

/* IAsyncEnumerable/IAsyncEnumerator are supplied by Microsoft.Bcl.AsyncInterfaces
   when the project references it; redefining them causes conflicts, so
   they are omitted here. */

#if !NET5_0_OR_GREATER
namespace System.Runtime.CompilerServices
{
    // Shim to enable `init` accessors when compiling against older targets.
    // The compiler looks for the `IsExternalInit` type; an empty public
    // static class is sufficient as a placeholder.
    public static class IsExternalInit { }

    // Supports `required` members feature: marks members that must be
    // initialized during object construction.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event, Inherited = false)]
    public sealed class RequiredMemberAttribute : Attribute { }

    // Applied to constructors (or factory methods) that ensure required
    // members are set. Compiler recognizes this attribute when analyzing
    // object initialization for `required` members.
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
    public sealed class SetsRequiredMembersAttribute : Attribute { }
}
#endif

// Additional shims required by generated model code when compiling
// against netstandard2.0. These are minimal stubs that provide the
// types and constructors the compiler and source-generated code expect.
namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class CompilerFeatureRequiredAttribute : Attribute
    {
        public CompilerFeatureRequiredAttribute(string feature) { Feature = feature; }
        public string Feature { get; }
    }
}

namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
    public sealed class SetsRequiredMembersAttribute : Attribute
    {
        public SetsRequiredMembersAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event, Inherited = false)]
    public sealed class RequiredMemberAttribute : Attribute
    {
        public RequiredMemberAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class NotNullWhenAttribute : Attribute
    {
        public NotNullWhenAttribute(bool returnValue) { }
    }
}

namespace System.Collections.Generic
{
    // Intentionally left empty: prefer the `System.Collections.Frozen.FrozenDictionary`
    // shim below. Avoid defining `FrozenDictionary` in `System.Collections.Generic`
    // to prevent ambiguous type references when generated code imports both
    // `System.Collections` and `System.Collections.Frozen`.
}

namespace System.Collections.Frozen
{
    // Provide a FrozenDictionary in the System.Collections.Frozen namespace
    // to match usages of that API in generated code.
    public class FrozenDictionary<TKey, TValue> : System.Collections.Generic.Dictionary<TKey, TValue>
    {
        public FrozenDictionary() : base() { }
        public FrozenDictionary(System.Collections.Generic.IDictionary<TKey, TValue> source) : base(source) { }

        public static FrozenDictionary<TKey, TValue> ToFrozenDictionary(System.Collections.Generic.IDictionary<TKey, TValue> source)
        {
            if (source is FrozenDictionary<TKey, TValue> fd) return fd;
            return new FrozenDictionary<TKey, TValue>(source);
        }
    }
    // Provide a FrozenDictionary in the System.Collections.Frozen namespace
    // to match usages of that API in generated code.
    public class FrozenDictionary
    {
        public static FrozenDictionary<TKey, TValue> ToFrozenDictionary<TKey, TValue>(System.Collections.Generic.IDictionary<TKey, TValue> source)
        {
            if (source is FrozenDictionary<TKey, TValue> fd) return fd;
            return new FrozenDictionary<TKey, TValue>(source);
        }

        public static FrozenDictionary<TKey, TValue> ToFrozenDictionary<TKey, TValue>(System.Collections.Generic.IReadOnlyDictionary<TKey, TValue> source)
        {
            if (source is FrozenDictionary<TKey, TValue> fd) return fd;
            return new FrozenDictionary<TKey, TValue>(source.ToDictionary(e => e.Key, e => e.Value));
        }
    }
}

namespace System.Collections.Immutable
{
    // Marker type so the `System.Collections.Immutable` namespace exists
    // for files that `using` it but do not require concrete immutable types
    public static class _NamespaceMarker { }

    public interface IImmutableList<T> : System.Collections.Generic.IReadOnlyList<T> { }

    public class ImmutableArray<T> : IImmutableList<T>
    {
        private readonly T[] _array;

        public ImmutableArray(T[] array)
        {
            _array = array;
        }

        public T this[int index] => _array[index];

        public int Count => _array.Length;

        public System.Collections.Generic.IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _array)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static ImmutableArray<T> ToImmutableArray(System.Collections.Generic.IEnumerable<T> source)
        {
            return new ImmutableArray<T>(source.ToArray());
        }
    }

    public class ImmutableArray
    {
        public static ImmutableArray<T> ToImmutableArray<T>(System.Collections.Generic.IEnumerable<T> source)
        {
            return ImmutableArray<T>.ToImmutableArray(source);
        }
    }
}

namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class MaybeNullWhenAttribute : Attribute
    {
        public MaybeNullWhenAttribute(bool returnValue) { }
    }

    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    public sealed class MaybeNullAttribute : Attribute
    {
        public MaybeNullAttribute() { }
    }
}

public static class ModelConverterConstructionShim
{
    public const string FromRawUncheckedMethodName = "FromRawUnchecked";

    static ModelConverterConstructionShim()
    {
        Assembly.GetCallingAssembly()
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Anthropic.Core.ModelBase)))
            .ToList()
            .ForEach(t =>
            {
                var converterType = typeof(Anthropic.Core.ModelConverter<>).MakeGenericType(t);
                var converterMethod = converterType.GetMethod(FromRawUncheckedMethodName, BindingFlags.Static | BindingFlags.Public);
                if (converterMethod is null)
                {
                    return;
                }
                var fromRaw =
                        (Func<IReadOnlyDictionary<string, JsonElement>, object>)
                        Delegate.CreateDelegate(
                            typeof(Func<IReadOnlyDictionary<string, JsonElement>, object>),
                            converterMethod
                        );
                FromRawFactories.Add(t, fromRaw);
            });
    }

    internal static Dictionary<Type, Func<IReadOnlyDictionary<string, JsonElement>, object>> FromRawFactories { get; }
        = new Dictionary<Type, Func<IReadOnlyDictionary<string, JsonElement>, object>>();
}

#endif
