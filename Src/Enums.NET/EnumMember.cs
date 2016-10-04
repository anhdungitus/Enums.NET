﻿#region License
// Copyright (c) 2016 Tyler Brinkley
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using EnumsNET.Numerics;
using ExtraConstraints;

namespace EnumsNET
{
    /// <summary>
    /// Represents an enum member's Name, Value, and Attributes
    /// </summary>
    public abstract class EnumMember : IEnumMember, IComparable<EnumMember>, IEquatable<EnumMember>, IComparable
    {
        internal readonly IEnumMember Member;

        /// <summary>
        /// The defined enum member's value
        /// </summary>
        public object Value => GetValue();

        /// <summary>
        /// The defined enum member's name
        /// </summary>
        public string Name => Member.Name;

        /// <summary>
        /// The defined enum member's attributes
        /// </summary>
        public IEnumerable<Attribute> Attributes => Member.Attributes;

        internal EnumMember(IEnumMember member)
        {
            Member = member;
        }

        /// <summary>
        /// The defined enum member's underlying integer value
        /// </summary>
        public object GetUnderlyingValue() => Member.GetUnderlyingValue();

        /// <summary>
        /// Converts <see cref="Value"/> to its equivalent string representation.
        /// </summary>
        /// <returns></returns>
        public sealed override string ToString() => Member.ToString();

        /// <summary>
        /// Converts <see cref="Value"/> to its equivalent string representation according to the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"><paramref name="format"/> is an invalid value.</exception>
        public string ToString(string format) => Member.ToString(format);

        /// <summary>
        /// Converts <see cref="Value"/> to its equivalent string representation according to the specified <paramref name="formatOrder"/>.
        /// </summary>
        /// <param name="formatOrder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="formatOrder"/> contains an invalid value.</exception>
        public string ToString(params EnumFormat[] formatOrder) => Member.ToString(formatOrder);

        /// <summary>
        /// Converts the specified <see cref="Value"/> to its equivalent string representation.
        /// </summary>
        /// <returns></returns>
        public string AsString() => Member.AsString();

        /// <summary>
        /// Converts <see cref="Value"/> to its equivalent string representation according to the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="FormatException"><paramref name="format"/> is an invalid value.</exception>
        public string AsString(string format) => Member.AsString(format);

        /// <summary>
        /// Converts <see cref="Value"/> to its equivalent string representation according to the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="format"/> is an invalid value.</exception>
        public string AsString(EnumFormat format) => Member.AsString(format);

        /// <summary>
        /// Converts <see cref="Value"/> to its equivalent string representation in the specified format order.
        /// </summary>
        /// <param name="format0"></param>
        /// <param name="format1"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="format0"/> or <paramref name="format1"/> is an invalid value.</exception>
        public string AsString(EnumFormat format0, EnumFormat format1) => Member.AsString(format0, format1);

        /// <summary>
        /// Converts <see cref="Value"/> to its equivalent string representation in the specified format order.
        /// </summary>
        /// <param name="format0"></param>
        /// <param name="format1"></param>
        /// <param name="format2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="format0"/>, <paramref name="format1"/>, or <paramref name="format2"/> is an invalid value.</exception>
        public string AsString(EnumFormat format0, EnumFormat format1, EnumFormat format2) => Member.AsString(format0, format1, format2);

        /// <summary>
        /// Converts <see cref="Value"/> to its equivalent string representation according to the specified <paramref name="formatOrder"/>.
        /// </summary>
        /// <param name="formatOrder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="formatOrder"/> contains an invalid value.</exception>
        public string AsString(params EnumFormat[] formatOrder) => Member.AsString(formatOrder);

        /// <summary>
        /// Converts <see cref="Value"/> to its equivalent string representation according to the specified <paramref name="format"/>.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="format"/> is null.</exception>
        /// <exception cref="FormatException"><paramref name="format"/> is an invalid value.</exception>
        public string Format(string format) => Member.Format(format);

        /// <summary>
        /// Converts <see cref="Value"/> to its equivalent string representation according to the specified <paramref name="formatOrder"/>.
        /// </summary>
        /// <param name="formatOrder"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="formatOrder"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="formatOrder"/> contains an invalid value.</exception>
        public string Format(params EnumFormat[] formatOrder) => Member.Format(formatOrder);

        /// <summary>
        /// Indicates if <see cref="Attributes"/> contains a <typeparamref name="TAttribute"/>.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns>Indication if <see cref="Attributes"/> contains a <typeparamref name="TAttribute"/>.</returns>
        public bool HasAttribute<TAttribute>() where TAttribute : Attribute => Member.HasAttribute<TAttribute>();

        /// <summary>
        /// Retrieves the first <typeparamref name="TAttribute"/> in <see cref="Attributes"/> if defined else null.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public TAttribute GetAttribute<TAttribute>() where TAttribute : Attribute => Member.GetAttribute<TAttribute>();

        /// <summary>
        /// Retrieves all <typeparamref name="TAttribute"/>'s in <see cref="Attributes"/>.
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public IEnumerable<TAttribute> GetAttributes<TAttribute>() where TAttribute : Attribute => Member.GetAttributes<TAttribute>();

        /// <summary>
        /// Converts <see cref="Value"/> to an <see cref="sbyte"/>.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OverflowException"><see cref="Value"/> cannot fit within <see cref="sbyte"/>'s value range without overflowing.</exception>
        [CLSCompliant(false)]
        public sbyte ToSByte() => Member.ToSByte();

        /// <summary>
        /// Converts <see cref="Value"/> to a <see cref="byte"/>.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OverflowException"><see cref="Value"/> cannot fit within <see cref="byte"/>'s value range without overflowing.</exception>
        public byte ToByte() => Member.ToByte();

        /// <summary>
        /// Converts <see cref="Value"/> to an <see cref="short"/>.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OverflowException"><see cref="Value"/> cannot fit within <see cref="short"/>'s value range without overflowing.</exception>
        public short ToInt16() => Member.ToInt16();

        /// <summary>
        /// Converts <see cref="Value"/> to a <see cref="ushort"/>.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OverflowException"><see cref="Value"/> cannot fit within <see cref="ushort"/>'s value range without overflowing.</exception>
        [CLSCompliant(false)]
        public ushort ToUInt16() => Member.ToUInt16();

        /// <summary>
        /// Converts <see cref="Value"/> to an <see cref="int"/>.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OverflowException"><see cref="Value"/> cannot fit within <see cref="int"/>'s value range without overflowing.</exception>
        public int ToInt32() => Member.ToInt32();

        /// <summary>
        /// Converts <see cref="Value"/> to a <see cref="uint"/>.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OverflowException"><see cref="Value"/> cannot fit within <see cref="uint"/>'s value range without overflowing.</exception>
        [CLSCompliant(false)]
        public uint ToUInt32() => Member.ToUInt32();

        /// <summary>
        /// Converts <see cref="Value"/> to an <see cref="long"/>.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OverflowException"><see cref="Value"/> cannot fit within <see cref="long"/>'s value range without overflowing.</exception>
        public long ToInt64() => Member.ToInt64();

        /// <summary>
        /// Converts <see cref="Value"/> to a <see cref="ulong"/>.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="OverflowException"><see cref="Value"/> cannot fit within <see cref="ulong"/>'s value range without overflowing.</exception>
        [CLSCompliant(false)]
        public ulong ToUInt64() => Member.ToUInt64();

        /// <summary>
        /// A more efficient GetHashCode method as it doesn't require boxing and unboxing of the value
        /// </summary>
        /// <returns></returns>
        public sealed override int GetHashCode() => Member.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="EnumMember"/> is equal to the current <see cref="EnumMember"/>.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(EnumMember other) => EqualsMethod(other);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public sealed override bool Equals(object other) => EqualsMethod(other as EnumMember);

        internal abstract object GetValue();

        internal abstract bool EqualsMethod(EnumMember other);

        internal abstract IEnumerable<object> GetFlags();

        internal abstract IEnumerable<EnumMember> GetFlagMembers();

        #region Explicit Interface Implementation
        string IFormattable.ToString(string format, IFormatProvider formatProvider) => Member.ToString(format, formatProvider);

#if ICONVERTIBLE
        TypeCode IConvertible.GetTypeCode() => Member.GetTypeCode();

        bool IConvertible.ToBoolean(IFormatProvider provider) => Member.ToBoolean(provider);

        char IConvertible.ToChar(IFormatProvider provider) => Member.ToChar(provider);

        sbyte IConvertible.ToSByte(IFormatProvider provider) => Member.ToSByte(provider);

        byte IConvertible.ToByte(IFormatProvider provider) => Member.ToByte(provider);

        short IConvertible.ToInt16(IFormatProvider provider) => Member.ToInt16(provider);

        ushort IConvertible.ToUInt16(IFormatProvider provider) => Member.ToUInt16(provider);

        int IConvertible.ToInt32(IFormatProvider provider) => Member.ToInt32(provider);

        uint IConvertible.ToUInt32(IFormatProvider provider) => Member.ToUInt32(provider);

        long IConvertible.ToInt64(IFormatProvider provider) => Member.ToInt64(provider);

        ulong IConvertible.ToUInt64(IFormatProvider provider) => Member.ToUInt64(provider);

        float IConvertible.ToSingle(IFormatProvider provider) => Member.ToSingle(provider);

        double IConvertible.ToDouble(IFormatProvider provider) => Member.ToDouble(provider);

        decimal IConvertible.ToDecimal(IFormatProvider provider) => Member.ToDecimal(provider);

        DateTime IConvertible.ToDateTime(IFormatProvider provider) => Member.ToDateTime(provider);

        string IConvertible.ToString(IFormatProvider provider) => Member.ToString(provider);

        object IConvertible.ToType(Type conversionType, IFormatProvider provider) => Member.ToType(conversionType, provider);
#endif

        // implemented in derived class
        int IComparable.CompareTo(object obj) => 0;

        // implemented in derived class
        int IComparable<EnumMember>.CompareTo(EnumMember other) => 0;

        bool IEnumMember.IsValidFlagCombination() => Member.IsValidFlagCombination();

        bool IEnumMember.HasAnyFlags() => Member.HasAnyFlags();

        bool IEnumMember.HasAllFlags() => Member.HasAllFlags();
        #endregion
    }

    /// <summary>
    /// Represents a <typeparamref name="TEnum"/> member's Name, Value, and Attributes
    /// </summary>
    /// <typeparam name="TEnum"></typeparam>
    public abstract class EnumMember<TEnum> : EnumMember, IComparable<EnumMember<TEnum>>, IEquatable<EnumMember<TEnum>>
    {
        /// <summary>
        /// The defined enum member's value
        /// </summary>
        public new TEnum Value => GetGenericValue();

        internal EnumMember(IEnumMember member)
            : base(member)
        {
        }

        /// <summary>
        /// Determines whether the specified <see cref="EnumMember{TEnum}"/> is equal to the current <see cref="EnumMember{TEnum}"/>
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(EnumMember<TEnum> other) => GenericEqualsMethod(other);

        internal abstract TEnum GetGenericValue();

        internal abstract bool GenericEqualsMethod(EnumMember<TEnum> other);

        internal abstract IEnumerable<TEnum> GetGenericFlags();

        internal abstract IEnumerable<EnumMember<TEnum>> GetGenericFlagMembers();

        internal sealed override object GetValue() => GetGenericValue();

        internal sealed override bool EqualsMethod(EnumMember other) => GenericEqualsMethod(other as EnumMember<TEnum>);

        internal sealed override IEnumerable<object> GetFlags() => GetGenericFlags().Select(flag => (object)flag);

        internal sealed override IEnumerable<EnumMember> GetFlagMembers() => GetGenericFlagMembers()
#if !COVARIANCE
            .Select(flag => (EnumMember)flag)
#endif
            ;

        #region Explicit Interface Implementation
        // Implemented in derived class
        int IComparable<EnumMember<TEnum>>.CompareTo(EnumMember<TEnum> other) => 0;
        #endregion
    }

    internal sealed class EnumMember<[EnumConstraint] TEnum, TInt, TIntProvider> : EnumMember<TEnum>, IComparable<EnumMember<TEnum>>, IComparable<EnumMember>, IComparable
        where TEnum : struct
        where TInt : struct, IFormattable, IComparable<TInt>, IEquatable<TInt>
#if ICONVERTIBLE
        , IConvertible
#endif
        where TIntProvider : struct, INumericProvider<TInt>
    {
        internal new EnumMemberInternal<TInt, TIntProvider> Member => (EnumMemberInternal<TInt, TIntProvider>)base.Member;

        internal EnumMember(EnumMemberInternal<TInt, TIntProvider> member)
            : base(member)
        {
        }

        internal override bool GenericEqualsMethod(EnumMember<TEnum> other) => other != null && Member.Value.Equals(((EnumMember<TEnum, TInt, TIntProvider>)other).Member.Value) && Name == other.Name;

        internal override TEnum GetGenericValue() => EnumInfo<TEnum, TInt, TIntProvider>.ToEnum(Member.Value);

        internal override IEnumerable<TEnum> GetGenericFlags() => Member.GetFlags().Select(flag => EnumInfo<TEnum, TInt, TIntProvider>.ToEnum(flag));

        internal override IEnumerable<EnumMember<TEnum>> GetGenericFlagMembers() => Member.GetFlagMembers().Select(flag => (EnumMember<TEnum>)flag.EnumMember);

        #region Explicit Interface Implementation
        int IComparable.CompareTo(object other)
        {
            var otherMember = other as EnumMember<TEnum, TInt, TIntProvider>;
            return otherMember != null ? Member.CompareTo(otherMember.Member) : 1;
        }

        int IComparable<EnumMember>.CompareTo(EnumMember other)
        {
            var otherMember = other as EnumMember<TEnum, TInt, TIntProvider>;
            return otherMember != null ? Member.CompareTo(otherMember.Member) : 1;
        }

        int IComparable<EnumMember<TEnum>>.CompareTo(EnumMember<TEnum> other) => other != null ? Member.CompareTo(((EnumMember<TEnum, TInt, TIntProvider>)other).Member) : 1;
        #endregion
    }
}