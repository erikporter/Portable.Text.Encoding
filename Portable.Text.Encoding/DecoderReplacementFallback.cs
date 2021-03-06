//
// DecoderReplacementFallback.cs
//
// Author:
//	Atsushi Enomoto <atsushi@ximian.com>
//

//
// Copyright (C) 2005 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;

namespace Portable.Text
{
	public sealed class DecoderReplacementFallback : DecoderFallback
	{
		readonly string replacement;

		public DecoderReplacementFallback () : this ("?")
		{
		}

		public DecoderReplacementFallback (string replacement)
		{
			if (replacement == null)
				throw new ArgumentNullException ();

			// FIXME: check replacement validity (invalid surrogate)

			this.replacement = replacement;
		}

		public string DefaultString {
			get { return replacement; }
		}

		public override int MaxCharCount {
			get { return replacement.Length; }
		}

		public override DecoderFallbackBuffer CreateFallbackBuffer ()
		{
			return new DecoderReplacementFallbackBuffer (this);
		}

		public override bool Equals (object obj)
		{
			var fallback = obj as DecoderReplacementFallback;

			return fallback != null && replacement == fallback.replacement;
		}

		public override int GetHashCode ()
		{
			return replacement.GetHashCode ();
		}
	}
}
