﻿/*
 * Copyright (c) 2002 World Wide Web Consortium,
 * (Massachusetts Institute of Technology, Institut National de
 * Recherche en Informatique et en Automatique, Keio University). All
 * Rights Reserved. This program is distributed under the W3C's Software
 * Intellectual Property License. This program is distributed in the
 * hope that it will be useful, but WITHOUT ANY WARRANTY; without even
 * the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR
 * PURPOSE.
 * See W3C License http://www.w3.org/Consortium/Legal/ for more details.
 */

namespace org.apache.xpath.domapi
{

	/// 
	/// <summary>
	/// A new exception to add support for DOM Level 3 XPath API.
	/// This class is needed to throw a org.w3c.dom.DOMException with proper error code in
	/// createExpression method of XPathEvaluatorImpl (a DOM Level 3 class).
	/// 
	/// This class extends TransformerException because the error message includes information
	/// about where the XPath problem is in the stylesheet as well as the XPath expression itself.
	/// 
	/// @xsl.usage internal
	/// </summary>
	public sealed class XPathStylesheetDOM3Exception : TransformerException
	{
		public XPathStylesheetDOM3Exception(string msg, SourceLocator arg1) : base(msg, arg1)
		{
		}
	}

}