// This file is part of the DSharpPlus project.
//
// Copyright (c) 2015 Mike Santiago
// Copyright (c) 2016-2025 DSharpPlus Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using DSharpPlus.Net.Abstractions;

namespace DSharpPlus.Entities.AuditLogs;

/// <summary>
/// Represents a description of how a property changed.
/// </summary>
/// <typeparam name="T">Type of the changed property.</typeparam>
public readonly record struct PropertyChange<T>
{
    /// <summary>
    /// The property's value before it was changed.
    /// </summary>
    public T? Before { get; internal init; }

    /// <summary>
    /// The property's value after it was changed.
    /// </summary>
    public T? After { get; internal init; }

    /// <summary>
    /// Create a new <see cref="PropertyChange{T}"/> from the given before and after values.
    /// </summary>
    public static PropertyChange<T> From(object? before, object? after) =>
        new()
        {
            Before = before is not null and T ? (T)before : default,
            After = after is not null and T ? (T)after : default
        };

    /// <summary>
    /// Create a new <see cref="PropertyChange{T}"/> from the given change using before and after values.
    /// </summary>
    internal static PropertyChange<T> From(AuditLogActionChange change) =>
        From(change.OldValue, change.NewValue);
}
