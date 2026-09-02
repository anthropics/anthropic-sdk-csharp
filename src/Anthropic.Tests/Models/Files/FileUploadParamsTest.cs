using System;
using System.Net.Http;
using System.Text;
using Anthropic.Core;
using Anthropic.Models.Files;

namespace Anthropic.Tests.Models.Files;

public class FileUploadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileUploadParams
        {
            File = file,
            ExpiresInSeconds = 3600,
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        BinaryContent expectedFile = file;
        long expectedExpiresInSeconds = 3600;
        string expectedWorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy";

        Assert.Equal(expectedFile, parameters.File);
        Assert.Equal(expectedExpiresInSeconds, parameters.ExpiresInSeconds);
        Assert.Equal(expectedWorkspaceID, parameters.WorkspaceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileUploadParams { File = file };

        Assert.Null(parameters.ExpiresInSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_in_seconds"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileUploadParams
        {
            File = file,

            // Null should be interpreted as omitted for these properties
            ExpiresInSeconds = null,
            WorkspaceID = null,
        };

        Assert.Null(parameters.ExpiresInSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_in_seconds"));
        Assert.Null(parameters.WorkspaceID);
        Assert.False(parameters.RawHeaderData.ContainsKey("anthropic-workspace-id"));
    }

    [Fact]
    public void Url_Works()
    {
        FileUploadParams parameters = new() { File = Encoding.UTF8.GetBytes("Example data") };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/files"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        FileUploadParams parameters = new()
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "my-anthropic-api-key" });

        Assert.Equal(
            ["wrkspc_011CZkZaBF1tNoB5wlCeusgy"],
            requestMessage.Headers.GetValues("anthropic-workspace-id")
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileUploadParams
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            ExpiresInSeconds = 3600,
            WorkspaceID = "wrkspc_011CZkZaBF1tNoB5wlCeusgy",
        };

        FileUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
