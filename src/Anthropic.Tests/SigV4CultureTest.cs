using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Aws;
using Anthropic.Bedrock;
using Anthropic.Core;
using Anthropic.Models.Models;

namespace Anthropic.Tests;

/// <summary>
/// SigV4 signatures don't depend on the current culture: AWS expects Gregorian dates and
/// header names lowercased the invariant way.
/// </summary>
public class SigV4CultureTest
{
    static readonly DateTime Now = new(2026, 10, 26, 1, 2, 3, DateTimeKind.Utc);

    static readonly Uri RequestUri = new(
        "https://bedrock-runtime.us-east-1.amazonaws.com/model/claude/invoke"
    );

    // th-TH formats dates in the Thai Buddhist calendar, where 2026 is 2569; tr-TR lowercases
    // "I" to a dotless i (U+0131).
    public static TheoryData<string> Cultures => new() { "th-TH", "tr-TR" };

    [Theory]
    [MemberData(nameof(Cultures))]
    public void BedrockSigner_SignsTheSameInAnyCulture(string cultureName)
    {
        var culture = GetCulture(cultureName);

        static string Sign() =>
            AWSSigner.GetAuthorizationHeader(
                "bedrock",
                "us-east-1",
                "POST",
                RequestUri,
                Now,
                new Dictionary<string, string> { ["X-Request-Id"] = "req_1" },
                AWSSigner.CalculateHash("{}"),
                "AKIDEXAMPLE",
                "secret"
            );

        var authorization = InCulture(culture, Sign);

        Assert.Equal(InCulture(CultureInfo.InvariantCulture, Sign), authorization);
        Assert.Contains(
            "Credential=AKIDEXAMPLE/20261026/us-east-1/bedrock/aws4_request",
            authorization
        );
        Assert.Contains("SignedHeaders=host;x-amz-date;x-request-id,", authorization);
        Assert.Equal("20261026T010203Z", InCulture(culture, () => AWSSigner.ToAmzDate(Now)));
    }

    [Theory]
    [MemberData(nameof(Cultures))]
    public void MantleSigner_SignsTheSameInAnyCulture(string cultureName)
    {
        var culture = GetCulture(cultureName);

        static string Sign() =>
            MantleAwsSigner.GetAuthorizationHeader(
                new MantleSigningRequest
                {
                    Service = "bedrock-mantle",
                    Region = "us-east-1",
                    HttpMethod = "POST",
                    Uri = RequestUri,
                    Now = Now,
                    Headers = new Dictionary<string, string>
                    {
                        ["host"] = RequestUri.Host,
                        ["x-amz-date"] = "20261026T010203Z",
                        ["X-Request-Id"] = "req_1",
                    },
                    PayloadHash = MantleAwsSigner.CalculateHash("{}"),
                    AwsAccessKey = "AKIDEXAMPLE",
                    AwsSecretKey = "secret",
                }
            );

        var authorization = InCulture(culture, Sign);

        Assert.Equal(InCulture(CultureInfo.InvariantCulture, Sign), authorization);
        Assert.Contains(
            "Credential=AKIDEXAMPLE/20261026/us-east-1/bedrock-mantle/aws4_request",
            authorization
        );
        Assert.Equal("20261026T010203Z", InCulture(culture, () => MantleAwsSigner.ToAmzDate(Now)));
    }

    [Theory]
    [MemberData(nameof(Cultures))]
    public async Task AwsClient_SignsWithGregorianDate(string cultureName)
    {
        var culture = GetCulture(cultureName);
        var handler = new RecordingHandler();
        var client = new AnthropicAwsClient(
            new AwsClientOptions
            {
                AwsAccessKey = "AKIDEXAMPLE",
                AwsSecretAccessKey = "secret",
                AwsRegion = "us-east-1",
                WorkspaceId = "wrkspc_123",
                BaseUrl = "https://aws-external-anthropic.us-east-1.api.aws",
            }
        )
        {
            HttpClient = new HttpClient(handler),
        };

        var originalCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;
        try
        {
            using var response = await client.WithRawResponse.Execute(
                new HttpRequest<ModelListParams> { Method = HttpMethod.Get, Params = new() },
                TestContext.Current.CancellationToken
            );
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }

        Assert.NotNull(handler.AmzDate);
        var signedAt = DateTime.ParseExact(
            handler.AmzDate,
            "yyyyMMddTHHmmssZ",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal
        );
        Assert.InRange(signedAt, DateTime.UtcNow.AddHours(-1), DateTime.UtcNow.AddHours(1));
        Assert.Contains(
            $"Credential=AKIDEXAMPLE/{handler.AmzDate.Substring(0, 8)}/us-east-1/",
            handler.Authorization
        );
    }

    sealed class RecordingHandler : HttpMessageHandler
    {
        public string? AmzDate { get; private set; }

        public string? Authorization { get; private set; }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken
        )
        {
            AmzDate = request.Headers.GetValues("x-amz-date").Single();
            Authorization = request.Headers.GetValues("Authorization").Single();
            return Task.FromResult(
                new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{}") }
            );
        }
    }

    static CultureInfo GetCulture(string name)
    {
        CultureInfo? culture = null;
        try
        {
            culture = new CultureInfo(name);
        }
        catch (CultureNotFoundException)
        {
            // ignored
        }
        Assert.SkipWhen(
            culture is null,
            $"{name} culture data isn't available (globalization-invariant mode)"
        );
        return culture;
    }

    static T InCulture<T>(CultureInfo culture, Func<T> action)
    {
        var originalCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = culture;
        try
        {
            return action();
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }
    }
}
