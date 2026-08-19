using System;
using Anthropic.Models.Files;

namespace Anthropic.Tests.Models.Files;

public class FileRetrieveMetadataParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileRetrieveMetadataParams { FileID = "file_id" };

        string expectedFileID = "file_id";

        Assert.Equal(expectedFileID, parameters.FileID);
    }

    [Fact]
    public void Url_Works()
    {
        FileRetrieveMetadataParams parameters = new() { FileID = "file_id" };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.anthropic.com/v1/files/file_id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileRetrieveMetadataParams { FileID = "file_id" };

        FileRetrieveMetadataParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
