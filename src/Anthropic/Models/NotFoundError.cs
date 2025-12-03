using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(ModelConverter<NotFoundError, NotFoundErrorFromRaw>))]
public sealed record class NotFoundError : ModelBase
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
                JsonSerializer.Deserialize<JsonElement>("\"not_found_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public NotFoundError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"not_found_error\"");
    }

    public NotFoundError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"not_found_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    NotFoundError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="NotFoundErrorFromRaw.FromRawUnchecked"/>
    public static NotFoundError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public NotFoundError(string message)
        : this()
    {
        this.Message = message;
    }
}

class NotFoundErrorFromRaw : IFromRaw<NotFoundError>
{
    /// <inheritdoc/>
    public NotFoundError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        NotFoundError.FromRawUnchecked(rawData);
}
