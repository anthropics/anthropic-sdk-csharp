using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Files;
using Anthropic.Models.Messages.Batches;
using Batches = Anthropic.Models.Beta.Messages.Batches;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _properties = [];

    public IReadOnlyDictionary<string, JsonElement> Properties
    {
        get { return this._properties.Freeze(); }
    }

    internal static readonly JsonSerializerOptions SerializerOptions = new()
    {
        Converters =
        {
            new ApiEnumConverter<string, global::Anthropic.Models.Messages.MediaType>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Messages.TTL>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Messages.Role>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Messages.Model>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Messages.StopReason>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Messages.Type>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Messages.UsageServiceTier>(),
            new ApiEnumConverter<string, global::Anthropic.Models.Messages.ErrorCode>(),
            new ApiEnumConverter<
                string,
                global::Anthropic.Models.Messages.WebSearchToolResultErrorErrorCode
            >(),
            new ApiEnumConverter<string, global::Anthropic.Models.Messages.ServiceTier>(),
            new ApiEnumConverter<string, ProcessingStatus>(),
            new ApiEnumConverter<string, ServiceTier>(),
            new ApiEnumConverter<string, AnthropicBeta>(),
            new ApiEnumConverter<string, Messages::MediaType>(),
            new ApiEnumConverter<string, Messages::ErrorCode>(),
            new ApiEnumConverter<
                string,
                Messages::BetaBashCodeExecutionToolResultErrorParamErrorCode
            >(),
            new ApiEnumConverter<string, Messages::TTL>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::Role>(),
            new ApiEnumConverter<string, Messages::Name>(),
            new ApiEnumConverter<string, Messages::BetaServerToolUseBlockParamName>(),
            new ApiEnumConverter<string, Messages::Type>(),
            new ApiEnumConverter<string, Messages::BetaSkillParamsType>(),
            new ApiEnumConverter<string, Messages::BetaStopReason>(),
            new ApiEnumConverter<
                string,
                Messages::BetaTextEditorCodeExecutionToolResultErrorErrorCode
            >(),
            new ApiEnumConverter<
                string,
                Messages::BetaTextEditorCodeExecutionToolResultErrorParamErrorCode
            >(),
            new ApiEnumConverter<string, Messages::FileType>(),
            new ApiEnumConverter<
                string,
                Messages::BetaTextEditorCodeExecutionViewResultBlockParamFileType
            >(),
            new ApiEnumConverter<string, Messages::BetaToolType>(),
            new ApiEnumConverter<string, Messages::BetaUsageServiceTier>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::ServiceTier>(),
            new ApiEnumConverter<string, Batches::ProcessingStatus>(),
            new ApiEnumConverter<string, Batches::ServiceTier>(),
            new ApiEnumConverter<string, Type>(),
        },
    };

    static readonly JsonSerializerOptions _toStringSerializerOptions = new(SerializerOptions)
    {
        WriteIndented = true,
    };

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.Properties, _toStringSerializerOptions);
    }

    public abstract void Validate();
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
interface IFromRaw<T>
{
#if NET5_0_OR_GREATER
    static abstract T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties);
#endif
}
