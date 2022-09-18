﻿using System;

/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements. See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership. The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the  "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
/*
 * $Id: FuncLang.java 468655 2006-10-28 07:12:06Z minchau $
 */
namespace org.apache.xpath.functions
{
	using DTM = org.apache.xml.dtm.DTM;
	using XPathContext = org.apache.xpath.XPathContext;
	using XBoolean = org.apache.xpath.objects.XBoolean;
	using XObject = org.apache.xpath.objects.XObject;

	/// <summary>
	/// Execute the Lang() function.
	/// @xsl.usage advanced
	/// </summary>
	[Serializable]
	public class FuncLang : FunctionOneArg
	{
		internal new const long serialVersionUID = -7868705139354872185L;

	  /// <summary>
	  /// Execute the function.  The function must return
	  /// a valid object. </summary>
	  /// <param name="xctxt"> The current execution context. </param>
	  /// <returns> A valid XObject.
	  /// </returns>
	  /// <exception cref="javax.xml.transform.TransformerException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.apache.xpath.objects.XObject execute(org.apache.xpath.XPathContext xctxt) throws javax.xml.transform.TransformerException
	  public override XObject execute(XPathContext xctxt)
	  {

		string lang = m_arg0.execute(xctxt).str();
		int parent = xctxt.CurrentNode;
		bool isLang = false;
		DTM dtm = xctxt.getDTM(parent);

		while (DTM.NULL != parent)
		{
		  if (DTM.ELEMENT_NODE == dtm.getNodeType(parent))
		  {
			int langAttr = dtm.getAttributeNode(parent, "http://www.w3.org/XML/1998/namespace", "lang");

			if (DTM.NULL != langAttr)
			{
			  string langVal = dtm.getNodeValue(langAttr);
			  // %OPT%
			  if (langVal.ToLower().StartsWith(lang.ToLower(), StringComparison.Ordinal))
			  {
				int valLen = lang.Length;

				if ((langVal.Length == valLen) || (langVal[valLen] == '-'))
				{
				  isLang = true;
				}
			  }

			  break;
			}
		  }

		  parent = dtm.getParent(parent);
		}

		return isLang ? XBoolean.S_TRUE : XBoolean.S_FALSE;
	  }
	}

}