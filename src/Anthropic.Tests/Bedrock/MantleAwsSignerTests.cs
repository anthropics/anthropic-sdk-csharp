using System;
using System.Collections.Generic;
using System.Globalization;
using Anthropic.Bedrock;

namespace Anthropic.Tests.Bedrock;

public class MantleAwsSignerTests
{
    [Fact]
    public void GetAuthorizationHeader_NonGregorianCulture_SignsGregorianDate()
    {
        var originalCulture = CultureInfo.CurrentCulture;
        CultureInfo.CurrentCulture = new CultureInfo("th-TH");
        try
        {
            var now = new DateTime(2026, 1, 2, 3, 4, 5, DateTimeKind.Utc);

            var amzDate = MantleAwsSigner.ToAmzDate(now);
            var authorization = MantleAwsSigner.GetAuthorizationHeader(
                new()
                {
                    Service = "bedrock-mantle",
                    Region = "us-east-1",
                    HttpMethod = "POST",
                    Uri = new Uri("https://bedrock-mantle.us-east-1.api.aws/anthropic/v1/messages"),
                    Now = now,
                    Headers = new Dictionary<string, string> { ["x-amz-date"] = amzDate },
                    PayloadHash = MantleAwsSigner.CalculateHash("{}"),
                    AwsAccessKey = "AKIAIOSFODNN7EXAMPLE",
                    AwsSecretKey = "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY",
                }
            );

            Assert.Equal("20260102T030405Z", amzDate);
            Assert.Contains("Credential=AKIAIOSFODNN7EXAMPLE/20260102/us-east-1/", authorization);
        }
        finally
        {
            CultureInfo.CurrentCulture = originalCulture;
        }
    }
}
