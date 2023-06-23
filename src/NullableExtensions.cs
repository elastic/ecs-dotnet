using System.Diagnostics.CodeAnalysis;

namespace System;
internal static class NullableStringExtensions {
	internal static bool IsNullOrEmpty([NotNullWhen(false)] this string? data) =>
		string.IsNullOrEmpty(data);
}
