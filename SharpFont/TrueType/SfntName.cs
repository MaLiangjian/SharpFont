﻿#region MIT License
/*Copyright (c) 2012 Robert Rouhani <robert.rouhani@gmail.com>

SharpFont based on Tao.FreeType, Copyright (c) 2003-2007 Tao Framework Team

Permission is hereby granted, free of charge, to any person obtaining a copy of
this software and associated documentation files (the "Software"), to deal in
the Software without restriction, including without limitation the rights to
use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
of the Software, and to permit persons to whom the Software is furnished to do
so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/
#endregion

using System;
using System.Runtime.InteropServices;

using SharpFont.TrueType.Internal;

namespace SharpFont.TrueType
{
	/// <summary>
	/// A structure used to model an SFNT ‘name’ table entry.
	/// </summary>
	/// <remarks>
	/// Possible values for ‘platform_id’, ‘encoding_id’, ‘language_id’, and
	/// ‘name_id’ are given in the file ‘ttnameid.h’. For details please refer
	/// to the TrueType or OpenType specification.
	/// </remarks>
	/// <see cref="PlatformID"/>
	/// <see cref="AppleEncodingID"/>
	/// <see cref="MacEncodingID"/>
	/// <see cref="MicrosoftEncodingID"/>
	public class SfntName
	{
		internal IntPtr reference;
		internal SfntNameInternal nameInt;

		internal SfntName(IntPtr reference)
		{
			this.reference = reference;
			this.nameInt = (SfntNameInternal)Marshal.PtrToStructure(reference, typeof(SfntNameInternal));
		}

		/// <summary>
		/// The platform ID for ‘string’.
		/// </summary>
		[CLSCompliant(false)]
		public PlatformID PlatformID
		{
			get
			{
				return nameInt.platform_id;
			}
		}

		/// <summary>
		/// The encoding ID for ‘string’.
		/// </summary>
		[CLSCompliant(false)]
		public ushort EncodingID
		{
			get
			{
				return nameInt.encoding_id;
			}
		}

		/// <summary>
		/// The language ID for ‘string’.
		/// </summary>
		[CLSCompliant(false)]
		public ushort LanguageID
		{
			get
			{
				return nameInt.language_id;
			}
		}

		/// <summary>
		/// An identifier for ‘string’.
		/// </summary>
		[CLSCompliant(false)]
		public ushort NameID
		{
			get
			{
				return nameInt.name_id;
			}
		}

		/// <summary><para>
		/// The ‘name’ string. Note that its format differs depending on the
		/// (platform,encoding) pair. It can be a Pascal String, a UTF-16 one,
		/// etc.
		/// </para><para>
		/// Generally speaking, the string is not zero-terminated. Please refer
		/// to the TrueType specification for details.
		/// </para></summary>
		public string String
		{
			get
			{
				//TODO look at TrueType specs, interpret string based on platform, encoding pair.
				return string.Empty;
			}
		}
	}
}
