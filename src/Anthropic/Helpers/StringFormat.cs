using System;

namespace Anthropic.Helpers;

/// <summary>
/// Supported string formats for JSON Schema <c>format</c> keyword.
/// All values in this enum are accepted by the API.
/// </summary>
public enum StringFormat
{
    /// <summary>No format specified.</summary>
    Unspecified = 0,

    /// <summary>RFC 3339 date-time string (e.g. <c>2024-01-01T00:00:00Z</c>).</summary>
    DateTime,

    /// <summary>RFC 3339 full-time string (e.g. <c>23:59:59Z</c>).</summary>
    Time,

    /// <summary>RFC 3339 full-date string (e.g. <c>2024-01-01</c>).</summary>
    Date,

    /// <summary>ISO 8601 duration string (e.g. <c>P1Y2M3DT4H5M6S</c>).</summary>
    Duration,

    /// <summary>RFC 5321 email address.</summary>
    Email,

    /// <summary>RFC 1123 hostname.</summary>
    Hostname,

    /// <summary>RFC 3986 URI.</summary>
    Uri,

    /// <summary>IPv4 address (dotted-decimal notation).</summary>
    IPv4,

    /// <summary>IPv6 address.</summary>
    IPv6,

    /// <summary>UUID (RFC 4122).</summary>
    Uuid,
}

internal static class StringFormatExtensions
{
    internal static string ToFormatString(this StringFormat format) =>
        format switch
        {
            StringFormat.DateTime => "date-time",
            StringFormat.Time => "time",
            StringFormat.Date => "date",
            StringFormat.Duration => "duration",
            StringFormat.Email => "email",
            StringFormat.Hostname => "hostname",
            StringFormat.Uri => "uri",
            StringFormat.IPv4 => "ipv4",
            StringFormat.IPv6 => "ipv6",
            StringFormat.Uuid => "uuid",
            _ => throw new ArgumentOutOfRangeException(nameof(format), format, null),
        };
}
