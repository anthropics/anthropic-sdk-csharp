using System;
using System.Collections.Generic;
using Anthropic.Models.Files;

namespace Anthropic.Tests.Models.Files;

public class FileListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FileListParams
        {
            Ids = ["string"],
            Limit = 1,
            Page = "page",
        };

        List<string> expectedIds = ["string"];
        long expectedLimit = 1;
        string expectedPage = "page";

        Assert.NotNull(parameters.Ids);
        Assert.Equal(expectedIds.Count, parameters.Ids.Count);
        for (int i = 0; i < expectedIds.Count; i++)
        {
            Assert.Equal(expectedIds[i], parameters.Ids[i]);
        }
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPage, parameters.Page);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileListParams { Ids = ["string"], Page = "page" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FileListParams
        {
            Ids = ["string"],
            Page = "page",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FileListParams { Limit = 1 };

        Assert.Null(parameters.Ids);
        Assert.False(parameters.RawQueryData.ContainsKey("ids"));
        Assert.Null(parameters.Page);
        Assert.False(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new FileListParams
        {
            Limit = 1,

            Ids = null,
            Page = null,
        };

        Assert.Null(parameters.Ids);
        Assert.True(parameters.RawQueryData.ContainsKey("ids"));
        Assert.Null(parameters.Page);
        Assert.True(parameters.RawQueryData.ContainsKey("page"));
    }

    [Fact]
    public void Url_Works()
    {
        FileListParams parameters = new()
        {
            Ids = ["string"],
            Limit = 1,
            Page = "page",
        };

        var url = parameters.Url(new() { ApiKey = "my-anthropic-api-key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.anthropic.com/v1/files?ids%5b%5d=string&limit=1&page=page"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FileListParams
        {
            Ids = ["string"],
            Limit = 1,
            Page = "page",
        };

        FileListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
