﻿using System;
using System.Text;

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
 * $Id: FuncTranslate.java 468655 2006-10-28 07:12:06Z minchau $
 */
namespace org.apache.xpath.functions
{
	using XPathContext = org.apache.xpath.XPathContext;
	using XObject = org.apache.xpath.objects.XObject;
	using XString = org.apache.xpath.objects.XString;

	/// <summary>
	/// Execute the Translate() function.
	/// @xsl.usage advanced
	/// </summary>
	[Serializable]
	public class FuncTranslate : Function3Args
	{
		internal new const long serialVersionUID = -1672834340026116482L;

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

		string theFirstString = m_arg0.execute(xctxt).str();
		string theSecondString = m_arg1.execute(xctxt).str();
		string theThirdString = m_arg2.execute(xctxt).str();
		int theFirstStringLength = theFirstString.Length;
		int theThirdStringLength = theThirdString.Length;

		// A vector to contain the new characters.  We'll use it to construct
		// the result string.
		StringBuilder sbuffer = new StringBuilder();

		for (int i = 0; i < theFirstStringLength; i++)
		{
		  char theCurrentChar = theFirstString[i];
		  int theIndex = theSecondString.IndexOf(theCurrentChar);

		  if (theIndex < 0)
		  {

			// Didn't find the character in the second string, so it
			// is not translated.
			sbuffer.Append(theCurrentChar);
		  }
		  else if (theIndex < theThirdStringLength)
		  {

			// OK, there's a corresponding character in the
			// third string, so do the translation...
			sbuffer.Append(theThirdString[theIndex]);
		  }
		  else
		  {

			// There's no corresponding character in the
			// third string, since it's shorter than the
			// second string.  In this case, the character
			// is removed from the output string, so don't
			// do anything.
		  }
		}

		return new XString(sbuffer.ToString());
	  }
	}

}