using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Anthropic.Foundry;
using Xunit.Sdk;

namespace Anthropic.Tests;

public class AnthropicTestClientsAttribute : DataAttribute
{
    public static string DataServiceUrl { get; } =
        Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010";
    public static string ApiKey { get; } = "YourApiKeyHere";
    public static string Resource { get; } = "YourRegionOrResourceHere";

    public AnthropicTestClientsAttribute(TestSupportTypes testSupportTypes = TestSupportTypes.All)
    {
        TestSupportTypes = testSupportTypes;
    }

    public TestSupportTypes TestSupportTypes { get; }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        var testData = testMethod.GetCustomAttributes<AnthropicTestDataAttribute>().ToArray();
        if (TestSupportTypes.HasFlag(TestSupportTypes.Anthropic))
        {
            yield return
            [
                new AnthropicClient() { BaseUrl = DataServiceUrl, APIKey = ApiKey },
                .. testData
                    .Where(e => e.TestSupport.HasFlag(TestSupportTypes.Anthropic))
                    .Select(f => f.TestData)
                    .ToArray(),
            ];
        }
        if (TestSupportTypes.HasFlag(TestSupportTypes.Foundry))
        {
            yield return
            [
                new AnthropicFoundryClient(new AnthropicFoundryApiKeyCredentials(ApiKey, Resource!))
                {
                    BaseUrl = DataServiceUrl,
                },
                .. testData
                    .Where(e => e.TestSupport.HasFlag(TestSupportTypes.Foundry))
                    .Select(f => f.TestData)
                    .ToArray(),
            ];
        }
    }
}

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
sealed class AnthropicTestDataAttribute : Attribute
{
    public AnthropicTestDataAttribute(TestSupportTypes testSupport, object testData)
    {
        TestSupport = testSupport;
        TestData = testData;
    }

    public TestSupportTypes TestSupport { get; }
    public object TestData { get; }
}

[Flags]
public enum TestSupportTypes
{
    All = Anthropic | Foundry,
    Anthropic = 1 << 1,
    Foundry = 1 << 2,
}
