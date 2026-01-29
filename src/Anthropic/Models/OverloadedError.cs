using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(JsonModelConverter<OverloadedError, OverloadedErrorFromRaw>))]
public sealed record class OverloadedError : JsonModel
{
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
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
        _ = this.Message;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("overloaded_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public OverloadedError()
    {
        this.Type = JsonSerializer.SerializeToElement("overloaded_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OverloadedError(OverloadedError overloadedError)
        : base(overloadedError) { }
#pragma warning restore CS8618

    public OverloadedError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("overloaded_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OverloadedError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class OverloadedErrorFromRaw : IFromRawJson<OverloadedError>
{
    /// <inheritdoc/>
    public OverloadedError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        OverloadedError.FromRawUnchecked(rawData);
}
