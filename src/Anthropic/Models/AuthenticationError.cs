using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models;

[JsonConverter(typeof(JsonModelConverter<AuthenticationError, AuthenticationErrorFromRaw>))]
public sealed record class AuthenticationError : JsonModel
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
                JsonSerializer.SerializeToElement("authentication_error")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public AuthenticationError()
    {
        this.Type = JsonSerializer.SerializeToElement("authentication_error");
    }

    public AuthenticationError(AuthenticationError authenticationError)
        : base(authenticationError) { }

    public AuthenticationError(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("authentication_error");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AuthenticationError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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

class AuthenticationErrorFromRaw : IFromRawJson<AuthenticationError>
{
    /// <inheritdoc/>
    public AuthenticationError FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AuthenticationError.FromRawUnchecked(rawData);
}
