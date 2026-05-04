using System;
using Anthropic.Oidc;

namespace Anthropic.Tests.Oidc;

public class SecurityHelpersTests
{
    [Theory]
    [InlineData("https://api.anthropic.com")]
    [InlineData("https://custom.example.com")]
    [InlineData("http://localhost")]
    [InlineData("http://localhost:8080")]
    [InlineData("http://127.0.0.1")]
    [InlineData("http://127.0.0.1:4010")]
    [InlineData("http://[::1]")]
    public void EnforceHttps_AllowsValidUrls(string url)
    {
        SecurityHelpers.EnforceHttps(url);
    }

    [Theory]
    [InlineData("http://evil.example.com")]
    [InlineData("http://10.0.0.1")]
    [InlineData("ftp://api.anthropic.com")]
    public void EnforceHttps_RejectsInsecureUrls(string url)
    {
        Assert.Throws<ArgumentException>(() => SecurityHelpers.EnforceHttps(url));
    }

    [Fact]
    public void EnforceHttps_RejectsInvalidUrls()
    {
        Assert.Throws<ArgumentException>(() => SecurityHelpers.EnforceHttps("not-a-url"));
    }

    [Theory]
    [InlineData("default")]
    [InlineData("my-profile")]
    [InlineData("production_v2")]
    public void ValidateProfileName_AllowsValid(string profile)
    {
        SecurityHelpers.ValidateProfileName(profile);
    }

    [Theory]
    [InlineData("")]
    [InlineData(".hidden")]
    [InlineData("../escape")]
    [InlineData("sub/dir")]
    [InlineData("sub\\dir")]
    [InlineData("has\0null")]
    [InlineData("bad..path")]
    public void ValidateProfileName_RejectsInvalid(string profile)
    {
        Assert.ThrowsAny<ArgumentException>(() => SecurityHelpers.ValidateProfileName(profile));
    }

    [Fact]
    public void RedactErrorBody_KeepsRfc6749Fields()
    {
        var body =
            "{\"error\":\"invalid_grant\",\"error_description\":\"Expired JWT\",\"secret_field\":\"should-be-removed\"}";
        var redacted = SecurityHelpers.RedactErrorBody(body);

        Assert.Contains("invalid_grant", redacted);
        Assert.Contains("Expired JWT", redacted);
        Assert.DoesNotContain("secret_field", redacted);
        Assert.DoesNotContain("should-be-removed", redacted);
    }

    [Fact]
    public void RedactErrorBody_TruncatesLongBodies()
    {
        var body = new string('x', 500);
        var redacted = SecurityHelpers.RedactErrorBody(body);

        Assert.True(redacted.Length <= 256 + 3); // 256 + "..."
        Assert.EndsWith("...", redacted);
    }

    [Fact]
    public void RedactErrorBody_HandlesNonJson()
    {
        var body = "Internal Server Error";
        var redacted = SecurityHelpers.RedactErrorBody(body);
        Assert.Equal("Internal Server Error", redacted);
    }

    [Fact]
    public void RedactErrorBody_HandlesEmpty()
    {
        Assert.Equal("", SecurityHelpers.RedactErrorBody(""));
    }
}
