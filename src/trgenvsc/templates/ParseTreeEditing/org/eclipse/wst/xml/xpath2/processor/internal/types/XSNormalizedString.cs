﻿using System;

/// <summary>
///*****************************************************************************
/// Copyright (c) 2010, 2011 Mukul Gandhi, and others
/// All rights reserved. This program and the accompanying materials
/// are made available under the terms of the Eclipse Public License 2.0
/// which accompanies this distribution, and is available at
/// https://www.eclipse.org/legal/epl-2.0/
/// 
/// SPDX-License-Identifier: EPL-2.0
/// 
/// Contributors:
///     Mukul Gandhi - bug 309585 - implementation of xs:normalizedString data type
///     Mukul Gandhi - bug 334478 - refactoring code to cater to xs:token data type
/// ******************************************************************************
/// </summary>

namespace org.eclipse.wst.xml.xpath2.processor.@internal.types
{

	using Item = org.eclipse.wst.xml.xpath2.api.Item;
	using ResultBuffer = org.eclipse.wst.xml.xpath2.api.ResultBuffer;
	using ResultSequence = org.eclipse.wst.xml.xpath2.api.ResultSequence;
	using TypeDefinition = org.eclipse.wst.xml.xpath2.api.typesystem.TypeDefinition;
	using BuiltinTypeLibrary = org.eclipse.wst.xml.xpath2.processor.@internal.types.builtin.BuiltinTypeLibrary;

	/// <summary>
	/// A representation of the xs:normalizedString datatype
	/// </summary>
	public class XSNormalizedString : XSString
	{

		private const string XS_NORMALIZEDSTRING = "xs:normalizedString";

		/// <summary>
		/// Initialises using the supplied String
		/// </summary>
		/// <param name="x">
		///            The String to initialise to </param>
		public XSNormalizedString(string x) : base(x)
		{
		}

		/// <summary>
		/// Initialises to null
		/// </summary>
		public XSNormalizedString() : this(null)
		{
		}

		/// <summary>
		/// Retrieves the datatype's full pathname
		/// </summary>
		/// <returns> "xs:normalizedString" which is the datatype's full pathname </returns>
		public override string string_type()
		{
			return XS_NORMALIZEDSTRING;
		}

		/// <summary>
		/// Retrieves the datatype's name
		/// </summary>
		/// <returns> "normalizedString" which is the datatype's name </returns>
		public override string type_name()
		{
			return "normalizedString";
		}

		/// <summary>
		/// Creates a new ResultSequence consisting of the extractable String in the
		/// supplied ResultSequence
		/// </summary>
		/// <param name="arg">
		///            The ResultSequence from which to extract the String </param>
		/// <returns> New ResultSequence consisting of the supplied String </returns>
		/// <exception cref="DynamicError"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public org.eclipse.wst.xml.xpath2.api.ResultSequence constructor(org.eclipse.wst.xml.xpath2.api.ResultSequence arg) throws org.eclipse.wst.xml.xpath2.processor.DynamicError
		public override ResultSequence constructor(ResultSequence arg)
		{
			if (arg.empty())
			{
			   return ResultBuffer.EMPTY;
			}

			Item aat = arg.first();

			string srcString = aat.StringValue;
			if (!isSatisfiesConstraints(srcString))
			{
				// invalid input
				DynamicError.throw_type_error();
			}

			return new XSNormalizedString(srcString);
		}

		/*
		 * Does the string in context satisfies constraints of the datatype, xs:normalizedString. 
		 */
		protected internal virtual bool isSatisfiesConstraints(string srcString)
		{

			bool isNormalizedStr = true;

			// the xs:normalizedString value cannot contain, 'carriage return', 'line feed' and 'tab' characters.
			if ((srcString.IndexOf("\r", StringComparison.Ordinal) != -1) || (srcString.IndexOf("\n", StringComparison.Ordinal) != -1) || (srcString.IndexOf("\t", StringComparison.Ordinal) != -1))
			{
				// invalid input
				isNormalizedStr = false;
			}

			return isNormalizedStr;

		} // isSatisfiesConstraints

		public override TypeDefinition TypeDefinition
		{
			get
			{
				return BuiltinTypeLibrary.XS_NORMALIZEDSTRING;
			}
		}

	}

}