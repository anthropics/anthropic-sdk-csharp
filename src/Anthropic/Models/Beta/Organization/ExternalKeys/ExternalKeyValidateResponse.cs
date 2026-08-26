using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalKeys;

/// <summary>
/// Result of a validation roundtrip against the customer's KMS.
///
/// <para>HTTP 200 for both outcomes — the operation completed; `status` says whether
/// the key works.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ExternalKeyValidateResponse, ExternalKeyValidateResponseFromRaw>)
)]
public sealed record class ExternalKeyValidateResponse : JsonModel
{
    /// <summary>
    /// Error message when status is `failure`. Null otherwise.
    /// </summary>
    public required string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// `success` — encrypt/decrypt roundtrip succeeded. `failure` — the roundtrip
    /// failed or timed out; see `error`.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Error;
        this.Status.Validate();
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("external_key_validation")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ExternalKeyValidateResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("external_key_validation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalKeyValidateResponse(ExternalKeyValidateResponse externalKeyValidateResponse)
        : base(externalKeyValidateResponse) { }
#pragma warning restore CS8618

    public ExternalKeyValidateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("external_key_validation");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalKeyValidateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalKeyValidateResponseFromRaw.FromRawUnchecked"/>
    public static ExternalKeyValidateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ExternalKeyValidateResponseFromRaw : IFromRawJson<ExternalKeyValidateResponse>
{
    /// <inheritdoc/>
    public ExternalKeyValidateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExternalKeyValidateResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// `success` — encrypt/decrypt roundtrip succeeded. `failure` — the roundtrip failed
/// or timed out; see `error`.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Failure,
    Success,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "failure" => Status.Failure,
            "success" => Status.Success,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Failure => "failure",
                Status.Success => "success",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
