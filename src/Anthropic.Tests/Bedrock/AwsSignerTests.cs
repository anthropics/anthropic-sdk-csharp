using System;
using System.Collections.Generic;
using Anthropic.Bedrock;

namespace Anthropic.Tests.Bedrock;

public class AwsSignerTests
{
    [Theory]
    // The signatures botocore's SigV4Auth gives these requests, whose canonical paths have "%252F" and "%3B".
    [InlineData(
        "arn:aws:bedrock:us-east-1:123456789012:inference-profile%2Fus.anthropic.claude-sonnet-4-20250514-v1:0",
        "52a7a22cb711b8ec82fef488b957e001c2a15e3d598440db2eead4faaae45eba"
    )]
    [InlineData("a;b", "9df3b41e39eb7e2792990c5eb56fad083ce845f45eaa88c3d600ed424d9b6b78")]
    public void GetAuthorizationHeader_ModelSegment_IsSignedEncodedAgain(
        string modelSegment,
        string expectedSignature
    )
    {
        var uri = new Uri(
            $"https://bedrock-runtime.us-east-1.amazonaws.com/model/{modelSegment}/invoke"
        );

        var authorization = AWSSigner.GetAuthorizationHeader(
            "bedrock",
            "us-east-1",
            "POST",
            uri,
            new DateTime(2026, 1, 2, 3, 4, 5, DateTimeKind.Utc),
            new Dictionary<string, string>(),
            AWSSigner.CalculateHash("{}"),
            "AKIAIOSFODNN7EXAMPLE",
            "wJalrXUtnFEMI/K7MDENG/bPxRfiCYEXAMPLEKEY"
        );

        Assert.Equal(
            $"AWS4-HMAC-SHA256 Credential=AKIAIOSFODNN7EXAMPLE/20260102/us-east-1/bedrock/aws4_request, SignedHeaders=host;x-amz-date, Signature={expectedSignature}",
            authorization
        );
    }
}
