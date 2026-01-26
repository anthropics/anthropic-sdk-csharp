using System.Collections.Generic;

namespace Anthropic.Core;

/// <summary>
/// The base class for all API objects that are serialized as a mix of JSON objects
/// and binary content.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
/// </summary>
public abstract record class MultipartJsonModel : ModelBase
{
    private protected MultipartJsonDictionary _rawData = new();

    protected MultipartJsonModel(MultipartJsonModel jsonModel)
        : base(jsonModel)
    {
        this._rawData = new(jsonModel._rawData);
    }

    /// <summary>
    /// The backing mix of JSON and binary content properties of the instance.
    /// </summary>
    public IReadOnlyDictionary<string, MultipartJsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
///
/// <para>NOTE: This interface is in the style of a factory instance instead of using
/// abstract static methods because .NET Standard 2.0 doesn't support abstract static methods.</para>
/// </summary>
interface IFromRawMultipartJson<T>
{
    /// <summary>
    /// Returns an instance constructed from the given raw JSON properties.
    ///
    /// <para>Required field and type mismatches are not checked. In these cases accessing
    /// the relevant properties of the constructed instance may throw.</para>
    ///
    /// <para>This method is useful for constructing an instance from already serialized
    /// data or for sending arbitrary data to the API (e.g. for undocumented or not
    /// yet supported properties or values).</para>
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, MultipartJsonElement> rawData);
}
