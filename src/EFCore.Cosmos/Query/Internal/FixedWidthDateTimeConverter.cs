// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.


using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Microsoft.EntityFrameworkCore.Cosmos.Storage.Internal;

/// <summary>
/// Converts <see cref="DateTime"/> values to and from fixed-width JSON strings.
/// </summary>
public sealed class FixedWidthDateTimeConverter : JsonConverter<DateTime>
{
    /// <summary>
    /// The fixed-width format used to serialize date/time values.
    /// </summary>
    public const string Format = "yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'";

    /// <inheritdoc/>
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        => reader.GetDateTime();

    /// <inheritdoc/>
    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        => writer.WriteStringValue(value.ToUniversalTime().ToString(Format, CultureInfo.InvariantCulture));
}