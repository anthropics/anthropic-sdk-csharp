using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
#if !NET
using System.Linq;
using System.Reflection;
#endif

namespace Anthropic.Core;

sealed class ModelConverter<TModel> : JsonConverter<TModel>
    where TModel : ModelBase, IFromRaw<TModel>
{
    public override TModel? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        var rawData = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(
            ref reader,
            options
        );
        if (rawData == null)
            return null;

#if NET
        return TModel.FromRawUnchecked(rawData);
#else
        return (TModel)ModelConverterConstructionShim.FromRawFactories[typeof(TModel)](rawData);
#endif
    }

    public override void Write(Utf8JsonWriter writer, TModel value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.RawData, options);
    }
}

#if !NET
internal static class ModelConverterConstructionShim
{
    public const string FromRawUncheckedMethodName = "FromRawUnchecked";

    static ModelConverterConstructionShim()
    {
        Assembly
            .GetCallingAssembly()
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(ModelBase)))
            .ToList()
            .ForEach(t =>
            {
                var converterType = typeof(ModelConverter<>).MakeGenericType(t);
                var converterMethod = converterType.GetMethod(
                    FromRawUncheckedMethodName,
                    BindingFlags.Static | BindingFlags.Public
                );
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

    internal static Dictionary<
        Type,
        Func<IReadOnlyDictionary<string, JsonElement>, object>
    > FromRawFactories { get; } =
        new Dictionary<Type, Func<IReadOnlyDictionary<string, JsonElement>, object>>();
}
#endif
