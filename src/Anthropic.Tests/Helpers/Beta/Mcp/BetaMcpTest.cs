using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Anthropic.Exceptions;
using Anthropic.Helpers.Beta.Mcp;
using Anthropic.Models.Beta.Messages;
using ModelContextProtocol.Protocol;
using McpRole = ModelContextProtocol.Protocol.Role;

namespace Anthropic.Tests.Helpers.Beta.Mcp;

public class BetaMcpTest
{
    [Theory]
    [InlineData("image/png", "image/png")]
    [InlineData("IMAGE/PNG", "image/png")]
    [InlineData("image/jpeg; charset=binary", "image/jpeg")]
    [InlineData(" IMAGE/GIF ; profile=\"A;B\" ", "image/gif")]
    [InlineData("Image/WebP; profile=srgb", "image/webp")]
    public void Content_ImageMediaTypeVariantsPreserveBytes(string mimeType, string expected)
    {
        var image = ImageContentBlock.FromBytes(new byte[] { 1, 2, 3 }, mimeType);
        var cache = new BetaCacheControlEphemeral();
        var result = BetaMcp.Content(image, cache);
        var wire = JsonSerializer.SerializeToElement(result);
        Assert.Equal("image", wire.GetProperty("type").GetString());
        Assert.Equal(expected, wire.GetProperty("source").GetProperty("media_type").GetString());
        Assert.Equal("AQID", wire.GetProperty("source").GetProperty("data").GetString());
        Assert.Equal(
            "ephemeral",
            wire.GetProperty("cache_control").GetProperty("type").GetString()
        );
        Assert.Equal(mimeType, image.MimeType);
        Assert.Equal(new byte[] { 1, 2, 3 }, image.DecodedData.ToArray());
        var message = BetaMcp.Message(new PromptMessage { Role = McpRole.User, Content = image });
        var messageWire = JsonSerializer.SerializeToElement(message);
        Assert.Equal(
            expected,
            messageWire
                .GetProperty("content")[0]
                .GetProperty("source")
                .GetProperty("media_type")
                .GetString()
        );
        result.Validate();
    }

    [Theory]
    [InlineData(" IMAGE/PNG ; profile=\"A;B\" ", "image/png")]
    [InlineData("Application/PDF; version=1.7", "application/pdf")]
    [InlineData("TEXT/PLAIN; charset=utf-8", "text/plain")]
    [InlineData(" Text/Markdown ; charset=utf-8 ", "text/plain")]
    public void ResourceMediaTypesPreserveSelectionAndFileMetadata(string mimeType, string expected)
    {
        var bytes = Encoding.UTF8.GetBytes("exact bytes");
        var resource = BlobResourceContents.FromBytes(bytes, "file:///item", mimeType);
        var response = new ReadResourceResult
        {
            Contents =
            {
                BlobResourceContents.FromBytes(
                    new byte[] { 0 },
                    "file:///unknown",
                    "application/octet-stream"
                ),
                resource,
                new TextResourceContents
                {
                    Uri = "file:///fallback",
                    MimeType = "text/plain",
                    Text = "wrong item",
                },
            },
        };
        var block = BetaMcp.ResourceToContent(response, new BetaCacheControlEphemeral());
        var wire = JsonSerializer.SerializeToElement(block);
        var source = wire.GetProperty("source");
        Assert.Equal(expected, source.GetProperty("media_type").GetString());
        Assert.Equal(
            expected == "text/plain" ? "exact bytes" : Convert.ToBase64String(bytes),
            source.GetProperty("data").GetString()
        );
        Assert.Equal(
            "ephemeral",
            wire.GetProperty("cache_control").GetProperty("type").GetString()
        );
        var embedded = BetaMcp.Content(new EmbeddedResourceBlock { Resource = resource });
        Assert.Equal(
            source.GetRawText(),
            JsonSerializer.SerializeToElement(embedded).GetProperty("source").GetRawText()
        );
        var file = BetaMcp.ResourceToFile(new ReadResourceResult { Contents = { resource } });
        Assert.Equal(mimeType, file.MediaType);
        Assert.Equal(bytes, file.Data);
        Assert.Equal(mimeType, resource.MimeType);
        Assert.Equal(bytes, resource.DecodedData.ToArray());
        block.Validate();
    }

    [Theory]
    [InlineData("IMAGE/BMP; version=1")]
    [InlineData("application/octet-stream")]
    [InlineData("")]
    [InlineData("; charset=utf-8")]
    public void NormalizedMediaTypesDoNotBroadenSupportedKinds(string mimeType)
    {
        var image = new ImageContentBlock
        {
            Data = Encoding.UTF8.GetBytes("AA=="),
            MimeType = mimeType,
        };
        Assert.Throws<AnthropicInvalidDataException>(() => BetaMcp.Content(image));
        var resource = new BlobResourceContents
        {
            Uri = "file:///x",
            Blob = Encoding.UTF8.GetBytes("AA=="),
            MimeType = mimeType,
        };
        Assert.Throws<AnthropicInvalidDataException>(() =>
            BetaMcp.ResourceToContent(new ReadResourceResult { Contents = { resource } })
        );
    }

    [Theory]
    [InlineData("IMAGE/PNG; version=1")]
    [InlineData("APPLICATION/PDF; version=1")]
    public void NormalizedBinaryResourcesStillRequireBlobData(string mimeType)
    {
        var embedded = new EmbeddedResourceBlock
        {
            Resource = new TextResourceContents
            {
                Uri = "file:///x",
                MimeType = mimeType,
                Text = "not a blob",
            },
        };
        var error = Assert.Throws<AnthropicInvalidDataException>(() => BetaMcp.Content(embedded));
        Assert.Contains("must have blob data", error.Message);
    }

    [Fact]
    public void MissingResourceMediaTypeKeepsTextDefault()
    {
        var result = BetaMcp.ResourceToContent(
            new ReadResourceResult
            {
                Contents =
                {
                    new TextResourceContents { Uri = "file:///x", Text = "default" },
                },
            }
        );
        var source = JsonSerializer.SerializeToElement(result).GetProperty("source");
        Assert.Equal("text/plain", source.GetProperty("media_type").GetString());
        Assert.Equal("default", source.GetProperty("data").GetString());
    }

    [Fact]
    public void Content_TextBlock_ConvertsToBetaText()
    {
        var block = new TextContentBlock { Text = "hello world" };

        var result = BetaMcp.Content(block);

        Assert.True(result.TryPickText(out var text));
        Assert.Equal("hello world", text!.Text);
        Assert.Null(text.CacheControl);
    }

    [Fact]
    public void Content_TextBlock_AppliesCacheControl()
    {
        var block = new TextContentBlock { Text = "hi" };
        var cache = new BetaCacheControlEphemeral();

        var result = BetaMcp.Content(block, cacheControl: cache);

        Assert.True(result.TryPickText(out var text));
        Assert.NotNull(text!.CacheControl);
    }

    [Fact]
    public void Content_ImageBlock_ConvertsToBase64Image()
    {
        var image = ImageContentBlock.FromBytes(new byte[] { 1, 2, 3 }, "image/png");

        var result = BetaMcp.Content(image);

        Assert.True(result.TryPickImage(out var imageBlock));
        Assert.True(imageBlock!.Source.TryPickBetaBase64Image(out var source));
        Assert.Equal("AQID", source!.Data);
        Assert.Equal("image/png", (string)source.MediaType);
    }

    [Fact]
    public void Content_ImageBlock_UnsupportedMimeTypeThrows()
    {
        var image = ImageContentBlock.FromBytes(new byte[] { 0 }, "image/bmp");

        Assert.Throws<AnthropicInvalidDataException>(() => BetaMcp.Content(image));
    }

    [Fact]
    public void Content_AudioBlock_Throws()
    {
        var audio = new AudioContentBlock
        {
            Data = Encoding.UTF8.GetBytes("xyz"),
            MimeType = "audio/wav",
        };

        Assert.Throws<AnthropicInvalidDataException>(() => BetaMcp.Content(audio));
    }

    [Fact]
    public void Content_ResourceLink_Throws()
    {
        var link = new ResourceLinkBlock { Uri = "file:///foo.txt", Name = "foo" };

        Assert.Throws<AnthropicInvalidDataException>(() => BetaMcp.Content(link));
    }

    [Fact]
    public void Content_EmbeddedTextResource_ConvertsToTextDocument()
    {
        var embedded = new EmbeddedResourceBlock
        {
            Resource = new TextResourceContents
            {
                Uri = "file:///notes.txt",
                MimeType = "text/plain",
                Text = "note body",
            },
        };

        var result = BetaMcp.Content(embedded);

        Assert.True(result.TryPickRequestDocumentBlock(out var doc));
        Assert.Equal("note body", doc!.Source.Data);
    }

    [Fact]
    public void Content_EmbeddedImageResource_BlobConvertsToImageBlock()
    {
        var embedded = new EmbeddedResourceBlock
        {
            Resource = BlobResourceContents.FromBytes(
                new byte[] { 0x10, 0x20 },
                "file:///image.png",
                "image/png"
            ),
        };

        var result = BetaMcp.Content(embedded);

        Assert.True(result.TryPickImage(out var image));
        Assert.True(image!.Source.TryPickBetaBase64Image(out var source));
        Assert.Equal("ECA=", source!.Data);
    }

    [Fact]
    public void Content_EmbeddedPdfResource_BlobConvertsToDocumentBlock()
    {
        var embedded = new EmbeddedResourceBlock
        {
            Resource = BlobResourceContents.FromBytes(
                new byte[] { 0xAA, 0xBB },
                "file:///doc.pdf",
                "application/pdf"
            ),
        };

        var result = BetaMcp.Content(embedded);

        Assert.True(result.TryPickRequestDocumentBlock(out var doc));
        Assert.Equal("qrs=", doc!.Source.Data);
    }

    [Fact]
    public void Content_EmbeddedImageAsText_Throws()
    {
        var embedded = new EmbeddedResourceBlock
        {
            Resource = new TextResourceContents
            {
                Uri = "file:///image.png",
                MimeType = "image/png",
                Text = "not actually base64",
            },
        };

        Assert.Throws<AnthropicInvalidDataException>(() => BetaMcp.Content(embedded));
    }

    [Fact]
    public void ResourceToContent_PicksFirstSupportedMimeType()
    {
        var result = new ReadResourceResult
        {
            Contents =
            {
                new BlobResourceContents
                {
                    Uri = "file:///bin",
                    MimeType = "application/octet-stream",
                    Blob = Encoding.UTF8.GetBytes("AA=="),
                },
                new TextResourceContents
                {
                    Uri = "file:///text",
                    MimeType = "text/plain",
                    Text = "hello",
                },
            },
        };

        var converted = BetaMcp.ResourceToContent(result);

        Assert.True(converted.TryPickRequestDocumentBlock(out var doc));
        Assert.Equal("hello", doc!.Source.Data);
    }

    [Fact]
    public void ResourceToContent_NoSupportedMimeType_Throws()
    {
        var result = new ReadResourceResult
        {
            Contents =
            {
                new BlobResourceContents
                {
                    Uri = "file:///bin",
                    MimeType = "application/octet-stream",
                    Blob = Encoding.UTF8.GetBytes("AA=="),
                },
            },
        };

        Assert.Throws<AnthropicInvalidDataException>(() => BetaMcp.ResourceToContent(result));
    }

    [Fact]
    public void ResourceToContent_EmptyContents_Throws()
    {
        var result = new ReadResourceResult();

        Assert.Throws<AnthropicInvalidDataException>(() => BetaMcp.ResourceToContent(result));
    }

    [Fact]
    public void ResourceToFile_BlobReturnsDecodedBytes()
    {
        var result = new ReadResourceResult
        {
            Contents =
            {
                BlobResourceContents.FromBytes(
                    new byte[] { 0xDE, 0xAD, 0xBE, 0xEF },
                    "file:///data/payload.bin",
                    "application/octet-stream"
                ),
            },
        };

        var file = BetaMcp.ResourceToFile(result);

        Assert.Equal("payload.bin", file.Filename);
        Assert.Equal(new byte[] { 0xDE, 0xAD, 0xBE, 0xEF }, file.Data);
        Assert.Equal("application/octet-stream", file.MediaType);
    }

    [Fact]
    public void ResourceToFile_TextEncodedAsUtf8()
    {
        var result = new ReadResourceResult
        {
            Contents =
            {
                new TextResourceContents
                {
                    Uri = "file:///docs/readme.txt",
                    MimeType = "text/plain",
                    Text = "héllo",
                },
            },
        };

        var file = BetaMcp.ResourceToFile(result);

        Assert.Equal("readme.txt", file.Filename);
        Assert.Equal(Encoding.UTF8.GetBytes("héllo"), file.Data);
        Assert.Equal("text/plain", file.MediaType);
    }

    [Fact]
    public void Message_PreservesRoleAndWrapsContent()
    {
        var promptMessage = new PromptMessage
        {
            Role = McpRole.Assistant,
            Content = new TextContentBlock { Text = "thinking..." },
        };

        var converted = BetaMcp.Message(promptMessage);

        Assert.Equal("assistant", (string)converted.Role);
        Assert.True(converted.Content.TryPickBetaContentBlockParams(out var blocks));
        Assert.Single(blocks!);
        Assert.True(blocks![0].TryPickText(out var text));
        Assert.Equal("thinking...", text!.Text);
    }

    [Fact]
    public void Messages_ConvertsEachItem()
    {
        var prompts = new[]
        {
            new PromptMessage
            {
                Role = McpRole.User,
                Content = new TextContentBlock { Text = "first" },
            },
            new PromptMessage
            {
                Role = McpRole.Assistant,
                Content = new TextContentBlock { Text = "second" },
            },
        };

        var converted = BetaMcp.Messages(prompts);

        Assert.Equal(2, converted.Count);
        Assert.Equal("user", (string)converted[0].Role);
        Assert.Equal("assistant", (string)converted[1].Role);
    }
}
