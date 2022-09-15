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
 * $Id: Import.java 1225842 2011-12-30 15:14:35Z mrglavas $
 */

namespace org.apache.xalan.xsltc.compiler
{

	using ClassGenerator = org.apache.xalan.xsltc.compiler.util.ClassGenerator;
	using ErrorMsg = org.apache.xalan.xsltc.compiler.util.ErrorMsg;
	using MethodGenerator = org.apache.xalan.xsltc.compiler.util.MethodGenerator;
	using Type = org.apache.xalan.xsltc.compiler.util.Type;
	using TypeCheckError = org.apache.xalan.xsltc.compiler.util.TypeCheckError;
	using SystemIDResolver = org.apache.xml.utils.SystemIDResolver;
	using InputSource = org.xml.sax.InputSource;
	using XMLReader = org.xml.sax.XMLReader;

	/// <summary>
	/// @author Jacek Ambroziak
	/// @author Morten Jorgensen
	/// @author Erwin Bolwidt <ejb@klomp.org>
	/// @author Gunnlaugur Briem <gthb@dimon.is>
	/// </summary>
	internal sealed class Import : TopLevelElement
	{

		private Stylesheet _imported = null;

		public Stylesheet ImportedStylesheet
		{
			get
			{
			return _imported;
			}
		}

		public override void parseContents(in Parser parser)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final XSLTC xsltc = parser.getXSLTC();
		XSLTC xsltc = parser.XSLTC;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Stylesheet context = parser.getCurrentStylesheet();
		Stylesheet context = parser.CurrentStylesheet;

		try
		{
			string docToLoad = getAttribute("href");
			if (context.checkForLoop(docToLoad))
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.xalan.xsltc.compiler.util.ErrorMsg msg = new org.apache.xalan.xsltc.compiler.util.ErrorMsg(org.apache.xalan.xsltc.compiler.util.ErrorMsg.CIRCULAR_INCLUDE_ERR, docToLoad, this);
			ErrorMsg msg = new ErrorMsg(ErrorMsg.CIRCULAR_INCLUDE_ERR, docToLoad, this);
			parser.reportError(Constants.FATAL, msg);
			return;
			}

			InputSource input = null;
			XMLReader reader = null;
			string currLoadedDoc = context.SystemId;
			SourceLoader loader = context.SourceLoader;

				// Use SourceLoader if available
			if (loader != null)
			{
			input = loader.loadSource(docToLoad, currLoadedDoc, xsltc);
					if (input != null)
					{
						docToLoad = input.getSystemId();
						reader = xsltc.XMLReader;
					}
			}

				// No SourceLoader or not resolved by SourceLoader
				if (input == null)
				{
					docToLoad = SystemIDResolver.getAbsoluteURI(docToLoad, currLoadedDoc);
					input = new InputSource(docToLoad);
				}

			// Return if we could not resolve the URL
			if (input == null)
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.xalan.xsltc.compiler.util.ErrorMsg msg = new org.apache.xalan.xsltc.compiler.util.ErrorMsg(org.apache.xalan.xsltc.compiler.util.ErrorMsg.FILE_NOT_FOUND_ERR, docToLoad, this);
			ErrorMsg msg = new ErrorMsg(ErrorMsg.FILE_NOT_FOUND_ERR, docToLoad, this);
			parser.reportError(Constants.FATAL, msg);
			return;
			}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SyntaxTreeNode root;
			SyntaxTreeNode root;
				if (reader != null)
				{
					root = parser.parse(reader,input);
				}
				else
				{
					root = parser.parse(input);
				}

			if (root == null)
			{
				return;
			}
			_imported = parser.makeStylesheet(root);
			if (_imported == null)
			{
				return;
			}

			_imported.SourceLoader = loader;
			_imported.SystemId = docToLoad;
			_imported.ParentStylesheet = context;
			_imported.ImportingStylesheet = context;
			_imported.TemplateInlining = context.TemplateInlining;

			// precedence for the including stylesheet
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int currPrecedence = parser.getCurrentImportPrecedence();
			int currPrecedence = parser.CurrentImportPrecedence;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int nextPrecedence = parser.getNextImportPrecedence();
			int nextPrecedence = parser.NextImportPrecedence;
			_imported.ImportPrecedence = currPrecedence;
			context.ImportPrecedence = nextPrecedence;
			parser.CurrentStylesheet = _imported;
			_imported.parseContents(parser);

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.util.Enumeration elements = _imported.elements();
			System.Collections.IEnumerator elements = _imported.elements();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Stylesheet topStylesheet = parser.getTopLevelStylesheet();
			Stylesheet topStylesheet = parser.TopLevelStylesheet;
			while (elements.MoveNext())
			{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Object element = elements.Current;
			object element = elements.Current;
			if (element is TopLevelElement)
			{
				if (element is Variable)
				{
				topStylesheet.addVariable((Variable) element);
				}
				else if (element is Param)
				{
				topStylesheet.addParam((Param) element);
				}
				else
				{
				topStylesheet.addElement((TopLevelElement) element);
				}
			}
			}
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
			Console.Write(e.StackTrace);
		}
		finally
		{
			parser.CurrentStylesheet = context;
		}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.apache.xalan.xsltc.compiler.util.Type typeCheck(SymbolTable stable) throws org.apache.xalan.xsltc.compiler.util.TypeCheckError
		public override Type typeCheck(SymbolTable stable)
		{
		return Type.Void;
		}

		public override void translate(ClassGenerator classGen, MethodGenerator methodGen)
		{
		// do nothing
		}
	}

}