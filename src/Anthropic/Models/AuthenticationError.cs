using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(ModelConverter<AuthenticationError, AuthenticationErrorFromRaw>))]
public sealed record class AuthenticationError : ModelBase
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
                JsonSerializer.Deserialize<JsonElement>("\"authentication_error\"")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public AuthenticationError()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"authentication_error\"");
    }

    public AuthenticationError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"authentication_error\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthenticationError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AuthenticationErrorFromRaw.FromRawUnchecked"/>
    public static AuthenticationError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AuthenticationError(string message)
        : this()
    {
        this.Message = message;
    }
}

class AuthenticationErrorFromRaw : IFromRaw<AuthenticationError>
{
    /// <inheritdoc/>
    public AuthenticationError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AuthenticationError.FromRawUnchecked(rawData);
}
