using Anthropic;
using Anthropic.Helpers;
using Anthropic.Models.Messages;
using Anthropic.Services;

// Configured using the ANTHROPIC_API_KEY environment variable
var client = new AnthropicClient();

Console.WriteLine("=== Structured Output Example ===\n");

// Example 1: Simple structured output
Console.WriteLine("--- Example 1: Extract Person Information ---\n");

var personMessage = await client.Messages.Create<PersonInfo>(
    new MessageCreateParams
    {
        Model = "claude-sonnet-4-5",
        MaxTokens = 1024,
        Messages =
        [
            new()
            {
                Role = Role.User,
                Content =
                    "Extract the person information from this text: John Smith is a 32-year-old software engineer. His email is john.smith@example.com and he is currently employed at a tech startup.",
            },
        ],
    }
);

var person = personMessage.Content[0].Parsed();
if (person != null)
{
    Console.WriteLine($"Name: {person.Name}");
    Console.WriteLine($"Age: {person.Age}");
    Console.WriteLine($"Email: {person.Email}");
    Console.WriteLine($"Status (string enum): {person.Status}");
    Console.WriteLine($"Status (C# enum):    {person.EmploymentType}");
}

Console.WriteLine();

// Example 2: Complex nested structured output
Console.WriteLine("--- Example 2: Extract Company Information (Nested Objects & Arrays) ---\n");

var companyMessage = await client.Messages.Create<CompanyInfo>(
    new MessageCreateParams
    {
        Model = "claude-sonnet-4-5",
        MaxTokens = 2048,
        Messages =
        [
            new()
            {
                Role = Role.User,
                Content = """
                Extract the company information from this text:

                Acme Corporation was founded in 1995 and is headquartered at 123 Innovation Drive,
                San Francisco, USA. The company's key employees include:
                - Jane Doe (CEO, 45 years old, jane.doe@acme.com, employed)
                - Bob Wilson (CTO, 38 years old, bob.wilson@acme.com, employed)
                - Alice Chen (CFO, 42 years old, alice.chen@acme.com, employed)
                """,
            },
        ],
    }
);

var company = companyMessage.Content[0].Parsed();
if (company != null)
{
    Console.WriteLine($"Company: {company.Name}");
    Console.WriteLine($"Founded: {company.Founded}");
    Console.WriteLine(
        $"Headquarters: {company.Headquarters.Street}, {company.Headquarters.City}, {company.Headquarters.Country}"
    );
    Console.WriteLine($"Key Employees ({company.KeyEmployees.Count}):");
    foreach (var employee in company.KeyEmployees)
    {
        Console.WriteLine(
            $"  - {employee.Name}, Age {employee.Age}, {employee.Email} ({employee.Status} / {employee.EmploymentType})"
        );
    }
}

Console.WriteLine();

// Example 3: Create<T> — full Message metadata alongside structured parsing
Console.WriteLine("--- Example 3: Full Message with Structured Parsing ---\n");

var sentimentMessage = await client.Messages.Create<SentimentResult>(
    new MessageCreateParams
    {
        Model = "claude-sonnet-4-5",
        MaxTokens = 256,
        Messages =
        [
            new()
            {
                Role = Role.User,
                Content =
                    "Analyze the sentiment of this review: \"The battery life is outstanding and the screen is gorgeous, but the price feels steep for what you get.\"",
            },
        ],
    }
);

// Access message metadata alongside the parsed result
Console.WriteLine($"Stop reason : {sentimentMessage.StopReason}");
Console.WriteLine(
    $"Tokens used : {sentimentMessage.Usage.InputTokens} in / {sentimentMessage.Usage.OutputTokens} out"
);

var sentiment = sentimentMessage.Content[0].Parsed();
if (sentiment != null)
{
    Console.WriteLine($"Sentiment   : {sentiment.Overall}");
    Console.WriteLine($"Score       : {sentiment.Score:F2}");
    Console.WriteLine($"Summary     : {sentiment.Summary}");
}

Console.WriteLine();

// Example 4: Access the raw JSON schema
Console.WriteLine("--- Example 4: View Generated JSON Schema ---\n");

var schema = StructuredOutput.ToJsonSchema<PersonInfo>();
var schemaJson = schema.ToJsonString(
    new System.Text.Json.JsonSerializerOptions { WriteIndented = true }
);
Console.WriteLine(schemaJson);

Console.WriteLine();

// Example 5: Using a class WITHOUT StructuredOutputModel base class
Console.WriteLine("--- Example 5: Plain Class (No Base Class Required) ---\n");

var productMessage = await client.Messages.Create<Product>(
    new MessageCreateParams
    {
        Model = "claude-sonnet-4-5",
        MaxTokens = 1024,
        Messages =
        [
            new()
            {
                Role = Role.User,
                Content =
                    "Extract product info: The Quantum X2000 laptop costs $1,299.99 and is currently in stock with 42 units available.",
            },
        ],
    }
);

var product = productMessage.Content[0].Parsed();
if (product != null)
{
    Console.WriteLine($"Product: {product.Name}");
    Console.WriteLine($"Price: ${product.Price}");
    Console.WriteLine($"In Stock: {product.InStock}");
    Console.WriteLine($"Quantity: {product.Quantity}");
}

Console.WriteLine("\n=== Done ===");

// ============================================================================
// Model Definitions
// ============================================================================

/// <summary>
/// A C# enum representing employment status.
/// Enum values are automatically converted to snake_case strings in the JSON schema.
/// </summary>
public enum EmploymentStatus
{
    Employed,
    Unemployed,
    Student,
    Retired,
    SelfEmployed,
}

/// <summary>
/// Sentiment analysis result used in the Create&lt;T&gt; example.
/// </summary>
public class SentimentResult
{
    [SchemaProperty(
        "Overall sentiment",
        Enum = new object[] { "positive", "negative", "mixed", "neutral" }
    )]
    public string Overall { get; set; } = "";

    [SchemaProperty("Sentiment score from -1.0 (most negative) to 1.0 (most positive)")]
    public double Score { get; set; }

    [SchemaProperty("One-sentence summary of the sentiment")]
    public string Summary { get; set; } = "";
}

/// <summary>
/// A simple model for extracting person information.
/// Uses StructuredOutputModel base class for convenience.
/// </summary>
public class PersonInfo : StructuredOutputModel
{
    [SchemaProperty("The person's full name")]
    public string Name { get; set; } = "";

    [SchemaProperty("Age in years", Minimum = 0, Maximum = 150)]
    public int Age { get; set; }

    [SchemaProperty("Email address", Format = StringFormat.Email)]
    public string? Email { get; set; }

    [SchemaProperty(
        "Current employment status as a string",
        Enum = new object[] { "employed", "unemployed", "student", "retired" }
    )]
    public string Status { get; set; } = "";

    [SchemaProperty("Current employment status as a C# enum")]
    public EmploymentStatus EmploymentType { get; set; }
}

/// <summary>
/// A nested model for address information.
/// </summary>
public class Address : StructuredOutputModel
{
    [SchemaProperty("Street address")]
    public string Street { get; set; } = "";

    [SchemaProperty("City name")]
    public string City { get; set; } = "";

    [SchemaProperty("Country name")]
    public string Country { get; set; } = "";
}

/// <summary>
/// A model with nested objects and arrays.
/// Uses StructuredOutputModel base class for convenience.
/// </summary>
[SchemaClass("Information about a company including its key employees")]
public class CompanyInfo : StructuredOutputModel
{
    [SchemaProperty("Company name")]
    public string Name { get; set; } = "";

    [SchemaProperty("Year the company was founded", Minimum = 1800, Maximum = 2030)]
    public int Founded { get; set; }

    [SchemaProperty("Company headquarters address")]
    public Address Headquarters { get; set; } = new();

    [SchemaProperty("List of key employees", MinItems = 1)]
    public List<PersonInfo> KeyEmployees { get; set; } = new();
}

/// <summary>
/// A plain class without StructuredOutputModel base class.
/// Base class is optional - any class with public properties works!
/// </summary>
public class Product
{
    [SchemaProperty("Product name")]
    public string Name { get; set; } = "";

    [SchemaProperty("Price in USD", Minimum = 0)]
    public double Price { get; set; }

    [SchemaProperty("Whether the product is in stock")]
    public bool InStock { get; set; }

    [SchemaProperty("Number of units available", Minimum = 0)]
    public int? Quantity { get; set; }
}
