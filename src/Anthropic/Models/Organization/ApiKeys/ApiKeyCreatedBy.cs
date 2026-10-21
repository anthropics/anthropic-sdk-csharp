using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Organization.ApiKeys;

[JsonConverter(typeof(JsonModelConverter<ApiKeyCreatedBy, ApiKeyCreatedByFromRaw>))]
public sealed record class ApiKeyCreatedBy : JsonModel
{
    /// <summary>
    /// ID of the actor that created the object.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Type of the actor that created the object.
    /// </summary>
    public required ApiEnum<string, global::Anthropic.Models.Organization.ApiKeys.Type> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, global::Anthropic.Models.Organization.ApiKeys.Type>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Type.Validate();
    }

    public ApiKeyCreatedBy() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKeyCreatedBy(ApiKeyCreatedBy apiKeyCreatedBy)
        : base(apiKeyCreatedBy) { }
#pragma warning restore CS8618

    public ApiKeyCreatedBy(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKeyCreatedBy(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyCreatedByFromRaw.FromRawUnchecked"/>
    public static ApiKeyCreatedBy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ApiKeyCreatedByFromRaw : IFromRawJson<ApiKeyCreatedBy>
{
    /// <inheritdoc/>
    public ApiKeyCreatedBy FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiKeyCreatedBy.FromRawUnchecked(rawData);
}

/// <summary>
/// Type of the actor that created the object.
/// </summary>
[JsonConverter(typeof(TypeConverter))]
public enum Type
{
    ServiceAccount,
    User,
}

sealed class TypeConverter : JsonConverter<global::Anthropic.Models.Organization.ApiKeys.Type>
{
    public override global::Anthropic.Models.Organization.ApiKeys.Type Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "service_account" => global::Anthropic.Models.Organization.ApiKeys.Type.ServiceAccount,
            "user" => global::Anthropic.Models.Organization.ApiKeys.Type.User,
            _ => (global::Anthropic.Models.Organization.ApiKeys.Type)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        global::Anthropic.Models.Organization.ApiKeys.Type value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                global::Anthropic.Models.Organization.ApiKeys.Type.ServiceAccount =>
                    "service_account",
                global::Anthropic.Models.Organization.ApiKeys.Type.User => "user",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
