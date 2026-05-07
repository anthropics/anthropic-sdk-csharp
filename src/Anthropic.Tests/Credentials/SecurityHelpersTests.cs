using System;
using System.Text.Json;
using Anthropic.Credentials;

namespace Anthropic.Tests.Credentials;

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
    public void RedactErrorBody_TruncatesLongRfc6749Bodies()
    {
        var body =
            "{\"error\":\"invalid_grant\",\"error_description\":\"" + new string('x', 3000) + "\"}";
        var redacted = SecurityHelpers.RedactErrorBody(body);

        Assert.Contains("invalid_grant", redacted);
        Assert.True(redacted.Length <= CredentialsConstants.MaxErrorBodyLength + 3); // cap + "..."
        Assert.EndsWith("...", redacted);
    }

    [Fact]
    public void RedactErrorBody_NonJsonBody_ReturnsRedactedPlaceholder()
    {
        var body = "<html>500 Internal Server Error - debug token: abc123def456</html>";
        var redacted = SecurityHelpers.RedactErrorBody(body);

        Assert.StartsWith("<non-standard error body redacted", redacted);
        Assert.Contains(body.Length.ToString(), redacted);
        // 40-char prefix is shown, but the full token must not be.
        Assert.DoesNotContain("abc123def456", redacted);
    }

    [Fact]
    public void RedactErrorBody_JsonWithoutErrorFields_ReturnsRedactedPlaceholder()
    {
        // Secret appears after the 40-char hint window so the prefix never reaches it.
        var body =
            "{\"some_unrecognised_response_field_name\":1,\"refresh_token\":\"secret-value-xyz\"}";
        var redacted = SecurityHelpers.RedactErrorBody(body);

        Assert.StartsWith("<non-standard error body redacted", redacted);
        Assert.DoesNotContain("secret-value-xyz", redacted);
        Assert.DoesNotContain("refresh_token", redacted);
    }

    [Fact]
    public void RedactErrorBody_HandlesEmpty()
    {
        Assert.Equal("", SecurityHelpers.RedactErrorBody(""));
    }

    [Fact]
    public void ParseExpiresIn_FractionalNumber_Accepted()
    {
        var root = JsonSerializer.Deserialize<JsonElement>("{\"expires_in\":3600.7}");
        var before = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var result = SecurityHelpers.ParseExpiresIn(root);
        Assert.NotNull(result);
        Assert.InRange(result!.Value, before + 3600 - 5, before + 3600 + 5);
    }

    [Fact]
    public void ParseExpiresIn_StringNumber_Accepted()
    {
        var root = JsonSerializer.Deserialize<JsonElement>("{\"expires_in\":\"3600\"}");
        var before = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var result = SecurityHelpers.ParseExpiresIn(root);
        Assert.NotNull(result);
        Assert.InRange(result!.Value, before + 3600 - 5, before + 3600 + 5);
    }

    [Fact]
    public void ParseExpiresIn_NonNumeric_Throws()
    {
        var root = JsonSerializer.Deserialize<JsonElement>("{\"expires_in\":true}");
        Assert.Throws<WorkloadIdentityException>(() => SecurityHelpers.ParseExpiresIn(root));
    }

    [Fact]
    public void ParseExpiresIn_Absent_ReturnsNull()
    {
        var root = JsonSerializer.Deserialize<JsonElement>("{}");
        Assert.Null(SecurityHelpers.ParseExpiresIn(root));
    }
}
