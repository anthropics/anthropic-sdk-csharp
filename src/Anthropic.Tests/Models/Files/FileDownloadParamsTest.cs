using System;
using Anthropic.Models.Files;

namespace Anthropic.Tests.Models.Files;

public class FileDownloadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileDownloadParams { FileID = "file_id" };

        string expectedFileID = "file_id";

        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        FileDownloadParams parameters = new() { FileID = "file_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/files/file_id/content"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileDownloadParams { FileID = "file_id" };

        FileDownloadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
