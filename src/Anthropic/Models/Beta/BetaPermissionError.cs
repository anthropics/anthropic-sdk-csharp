using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta;

[JsonConverter(typeof(ModelConverter<BetaPermissionError, BetaPermissionErrorFromRaw>))]
public sealed record class BetaPermissionError : ModelBase
{
    public required string Message
    {
        get { return ModelBase.GetNotNullClass<string>(this.RawData, "message"); }
        init { ModelBase.Set(this._rawData, "message", value); }
    }

    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.Deserialize<JsonElement>("\"permission_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaPermissionError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"permission_error\"");
    }

    public BetaPermissionError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"permission_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPermissionError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPermissionErrorFromRaw.FromRawUnchecked"/>
    public static BetaPermissionError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaPermissionError(string message)
        : this()
    {
        this.Message = message;
    }
}

class BetaPermissionErrorFromRaw : IFromRaw<BetaPermissionError>
{
    /// <inheritdoc/>
    public BetaPermissionError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaPermissionError.FromRawUnchecked(rawData);
}
