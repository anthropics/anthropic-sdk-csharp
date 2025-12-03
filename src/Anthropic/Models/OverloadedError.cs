using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(ModelConverter<OverloadedError, OverloadedErrorFromRaw>))]
public sealed record class OverloadedError : ModelBase
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
                JsonSerializer.Deserialize<JsonElement>("\"overloaded_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public OverloadedError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"overloaded_error\"");
    }

    public OverloadedError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"overloaded_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OverloadedError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OverloadedErrorFromRaw.FromRawUnchecked"/>
    public static OverloadedError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public OverloadedError(string message)
        : this()
    {
        this.Message = message;
    }
}

class OverloadedErrorFromRaw : IFromRaw<OverloadedError>
{
    /// <inheritdoc/>
    public OverloadedError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OverloadedError.FromRawUnchecked(rawData);
}
