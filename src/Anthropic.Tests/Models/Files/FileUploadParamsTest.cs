using System;
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

        var parameters = new FileUploadParams { File = file, ExpiresInSeconds = 3600 };

        BinaryContent expectedFile = file;
        long expectedExpiresInSeconds = 3600;

        Assert.Equal(expectedFile, parameters.File);
        Assert.Equal(expectedExpiresInSeconds, parameters.ExpiresInSeconds);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        BinaryContent file = Encoding.UTF8.GetBytes("Example data");

        var parameters = new FileUploadParams { File = file };

        Assert.Null(parameters.ExpiresInSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_in_seconds"));
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
        };

        Assert.Null(parameters.ExpiresInSeconds);
        Assert.False(parameters.RawBodyData.ContainsKey("expires_in_seconds"));
    }

    [Fact]
    public void Url_Works()
    {
        FileUploadParams parameters = new() { File = Encoding.UTF8.GetBytes("Example data") };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/files"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileUploadParams
        {
            File = Encoding.UTF8.GetBytes("Example data"),
            ExpiresInSeconds = 3600,
        };

        FileUploadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
