using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using System = System;

namespace Anthropic.Models.Beta.Files;

[JsonConverter(typeof(ModelConverter<FileListPageResponse>))]
public sealed record class FileListPageResponse : ModelBase, IFromRaw<FileListPageResponse>
{
    /// <summary>
    /// List of file metadata objects.
    /// </summary>
    public required List<FileMetadata> Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                throw new System::ArgumentOutOfRangeException("data", "Missing required argument");

            return JsonSerializer.Deserialize<List<FileMetadata>>(
                    element,
                    ModelBase.SerializerOptions
                ) ?? throw new System::ArgumentNullException("data");
        }
        set { this.Properties["data"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// ID of the first file in this page of results.
    /// </summary>
    public string? FirstID
    {
        get
        {
            if (!this.Properties.TryGetValue("first_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["first_id"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// Whether there are more results available.
    /// </summary>
    public bool? HasMore
    {
        get
        {
            if (!this.Properties.TryGetValue("has_more", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["has_more"] = JsonSerializer.SerializeToElement(value); }
    }

    /// <summary>
    /// ID of the last file in this page of results.
    /// </summary>
    public string? LastID
    {
        get
        {
            if (!this.Properties.TryGetValue("last_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set { this.Properties["last_id"] = JsonSerializer.SerializeToElement(value); }
    }

    public override void Validate()
    {
        foreach (var item in this.Data)
        {
            item.Validate();
        }
        _ = this.FirstID;
        _ = this.HasMore;
        _ = this.LastID;
    }

    public FileListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileListPageResponse(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static FileListPageResponse FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
