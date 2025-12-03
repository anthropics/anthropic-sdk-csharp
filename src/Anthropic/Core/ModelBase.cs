using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Exceptions;
using Anthropic.Models.Beta;
using Anthropic.Models.Beta.Files;
using Anthropic.Models.Messages.Batches;
using Batches = Anthropic.Models.Beta.Messages.Batches;
using Messages = Anthropic.Models.Beta.Messages;

namespace Anthropic.Core;

public abstract record class ModelBase
{
    private protected FreezableDictionary<string, JsonElement> _rawData = [];

    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
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
            new ApiEnumConverter<string, Messages::AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionTool20250825AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaCodeExecutionToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaMemoryTool20250818AllowedCaller>(),
            new ApiEnumConverter<string, Messages::Role>(),
            new ApiEnumConverter<string, Messages::Effort>(),
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
            new ApiEnumConverter<string, Messages::BetaToolAllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolType>(),
            new ApiEnumConverter<string, Messages::BetaToolBash20241022AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolBash20250124AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolComputerUse20241022AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolComputerUse20250124AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolComputerUse20251124AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolSearchToolBm25_20251119Type>(),
            new ApiEnumConverter<string, Messages::BetaToolSearchToolBm25_20251119AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolSearchToolRegex20251119Type>(),
            new ApiEnumConverter<string, Messages::BetaToolSearchToolRegex20251119AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolSearchToolResultErrorErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaToolSearchToolResultErrorParamErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaToolTextEditor20241022AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolTextEditor20250124AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolTextEditor20250429AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaToolTextEditor20250728AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaUsageServiceTier>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchTool20250910AllowedCaller>(),
            new ApiEnumConverter<string, Messages::BetaWebFetchToolResultErrorCode>(),
            new ApiEnumConverter<string, Messages::BetaWebSearchTool20250305AllowedCaller>(),
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

    internal static void Set<T>(IDictionary<string, JsonElement> dictionary, string key, T value)
    {
        dictionary[key] = JsonSerializer.SerializeToElement(value, SerializerOptions);
    }

    internal static T GetNotNullClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new AnthropicInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T>(element, SerializerOptions)
                ?? throw new AnthropicInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T GetNotNullStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            throw new AnthropicInvalidDataException($"'{key}' cannot be absent");
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions)
                ?? throw new AnthropicInvalidDataException($"'{key}' cannot be null");
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableClass<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : class
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    internal static T? GetNullableStruct<T>(
        IReadOnlyDictionary<string, JsonElement> dictionary,
        string key
    )
        where T : struct
    {
        if (!dictionary.TryGetValue(key, out JsonElement element))
        {
            return null;
        }

        try
        {
            return JsonSerializer.Deserialize<T?>(element, SerializerOptions);
        }
        catch (JsonException e)
        {
            throw new AnthropicInvalidDataException(
                $"'{key}' must be of type {typeof(T).FullName}",
                e
            );
        }
    }

    public sealed override string? ToString()
    {
        return JsonSerializer.Serialize(this.RawData, _toStringSerializerOptions);
    }

    public virtual bool Equals(ModelBase? other)
    {
        if (other == null || this.RawData.Count != other.RawData.Count)
        {
            return false;
        }

        foreach (var item in this.RawData)
        {
            if (!other.RawData.TryGetValue(item.Key, out var otherValue))
            {
                return false;
            }

            if (!JsonElement.DeepEquals(item.Value, otherValue))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        return 0;
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
    /// <summary>
    /// NOTE: This interface is in the style of a factory instance instead of using
    /// abstract static methods because .NET Standard 2.0 doesn't support abstract
    /// static methods.
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
