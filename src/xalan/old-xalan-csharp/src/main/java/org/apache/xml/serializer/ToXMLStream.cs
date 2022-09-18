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
 * $Id: ToXMLStream.java 469359 2006-10-31 03:43:19Z minchau $
 */
 namespace org.apache.xml.serializer
 {


	using MsgKey = org.apache.xml.serializer.utils.MsgKey;
	using Utils = org.apache.xml.serializer.utils.Utils;
	using SAXException = org.xml.sax.SAXException;

	/// <summary>
	/// This class converts SAX or SAX-like calls to a 
	/// serialized xml document.  The xsl:output method is "xml".
	/// 
	/// This class is used explicitly in code generated by XSLTC, 
	/// so it is "public", but it should 
	/// be viewed as internal or package private, this is not an API.
	/// 
	/// @xsl.usage internal
	/// </summary>
	public class ToXMLStream : ToStream
	{
		/// <summary>
		/// Map that tells which XML characters should have special treatment, and it
		///  provides character to entity name lookup.
		/// </summary>
		private CharInfo m_xmlcharInfo = CharInfo.getCharInfo(CharInfo.XML_ENTITIES_RESOURCE, Method.XML);

		/// <summary>
		/// Default constructor.
		/// </summary>
		public ToXMLStream()
		{
			m_charInfo = m_xmlcharInfo;

			initCDATA();
			// initialize namespaces
			m_prefixMap = new NamespaceMappings();

		}

		/// <summary>
		/// Copy properties from another SerializerToXML.
		/// </summary>
		/// <param name="xmlListener"> non-null reference to a SerializerToXML object. </param>
		public virtual void CopyFrom(ToXMLStream xmlListener)
		{

			Writer = xmlListener.m_writer;


			// m_outputStream = xmlListener.m_outputStream;
			string encoding = xmlListener.Encoding;
			Encoding = encoding;

			OmitXMLDeclaration = xmlListener.OmitXMLDeclaration;

			m_ispreserve = xmlListener.m_ispreserve;
			m_preserves = xmlListener.m_preserves;
			m_isprevtext = xmlListener.m_isprevtext;
			m_doIndent = xmlListener.m_doIndent;
			IndentAmount = xmlListener.IndentAmount;
			m_startNewLine = xmlListener.m_startNewLine;
			m_needToOutputDocTypeDecl = xmlListener.m_needToOutputDocTypeDecl;
			DoctypeSystem = xmlListener.DoctypeSystem;
			DoctypePublic = xmlListener.DoctypePublic;
			Standalone = xmlListener.Standalone;
			MediaType = xmlListener.MediaType;
			m_encodingInfo = xmlListener.m_encodingInfo;
			m_spaceBeforeClose = xmlListener.m_spaceBeforeClose;
			m_cdataStartCalled = xmlListener.m_cdataStartCalled;

		}

		/// <summary>
		/// Receive notification of the beginning of a document.
		/// </summary>
		/// <exception cref="org.xml.sax.SAXException"> Any SAX exception, possibly
		///            wrapping another exception.
		/// </exception>
		/// <exception cref="org.xml.sax.SAXException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void startDocumentInternal() throws org.xml.sax.SAXException
		public override void startDocumentInternal()
		{

			if (m_needToCallStartDocument)
			{
				base.startDocumentInternal();
				m_needToCallStartDocument = false;

				if (m_inEntityRef)
				{
					return;
				}

				m_needToOutputDocTypeDecl = true;
				m_startNewLine = false;
				/* The call to getXMLVersion() might emit an error message
				 * and we should emit this message regardless of if we are 
				 * writing out an XML header or not.
				 */ 
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String version = getXMLVersion();
				string version = XMLVersion;
				if (OmitXMLDeclaration == false)
				{
					string encoding = Encodings.getMimeEncoding(Encoding);
					string standalone;

					if (m_standaloneWasSpecified)
					{
						standalone = " standalone=\"" + Standalone + "\"";
					}
					else
					{
						standalone = "";
					}

					try
					{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.Writer writer = m_writer;
						java.io.Writer writer = m_writer;
						writer.write("<?xml version=\"");
						writer.write(version);
						writer.write("\" encoding=\"");
						writer.write(encoding);
						writer.write('\"');
						writer.write(standalone);
						writer.write("?>");
						if (m_doIndent)
						{
							if (m_standaloneWasSpecified || !string.ReferenceEquals(DoctypePublic, null) || !string.ReferenceEquals(DoctypeSystem, null))
							{
								// We almost never put a newline after the XML
								// header because this XML could be used as
								// an extenal general parsed entity
								// and we don't know the context into which it
								// will be used in the future.  Only when
								// standalone, or a doctype system or public is
								// specified are we free to insert a new line
								// after the header.  Is it even worth bothering
								// in these rare cases?                           
								writer.write(m_lineSep, 0, m_lineSepLen);
							}
						}
					}
					catch (IOException e)
					{
						throw new SAXException(e);
					}

				}
			}
		}

		/// <summary>
		/// Receive notification of the end of a document.
		/// </summary>
		/// <exception cref="org.xml.sax.SAXException"> Any SAX exception, possibly
		///            wrapping another exception.
		/// </exception>
		/// <exception cref="org.xml.sax.SAXException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void endDocument() throws org.xml.sax.SAXException
		public virtual void endDocument()
		{
			flushPending();
			if (m_doIndent && !m_isprevtext)
			{
				try
				{
				outputLineSep();
				}
				catch (IOException e)
				{
					throw new SAXException(e);
				}
			}

			flushWriter();

			if (m_tracer != null)
			{
				base.fireEndDoc();
			}
		}

		/// <summary>
		/// Starts a whitespace preserving section. All characters printed
		/// within a preserving section are printed without indentation and
		/// without consolidating multiple spaces. This is equivalent to
		/// the <tt>xml:space=&quot;preserve&quot;</tt> attribute. Only XML
		/// and HTML serializers need to support this method.
		/// <para>
		/// The contents of the whitespace preserving section will be delivered
		/// through the regular <tt>characters</tt> event.
		/// 
		/// </para>
		/// </summary>
		/// <exception cref="org.xml.sax.SAXException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void startPreserving() throws org.xml.sax.SAXException
		public virtual void startPreserving()
		{

			// Not sure this is really what we want.  -sb
			m_preserves.push(true);

			m_ispreserve = true;
		}

		/// <summary>
		/// Ends a whitespace preserving section.
		/// </summary>
		/// <seealso cref= #startPreserving
		/// </seealso>
		/// <exception cref="org.xml.sax.SAXException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void endPreserving() throws org.xml.sax.SAXException
		public virtual void endPreserving()
		{

			// Not sure this is really what we want.  -sb
			m_ispreserve = m_preserves.Empty ? false : m_preserves.pop();
		}

		/// <summary>
		/// Receive notification of a processing instruction.
		/// </summary>
		/// <param name="target"> The processing instruction target. </param>
		/// <param name="data"> The processing instruction data, or null if
		///        none was supplied. </param>
		/// <exception cref="org.xml.sax.SAXException"> Any SAX exception, possibly
		///            wrapping another exception.
		/// </exception>
		/// <exception cref="org.xml.sax.SAXException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void processingInstruction(String target, String data) throws org.xml.sax.SAXException
		public virtual void processingInstruction(string target, string data)
		{
			if (m_inEntityRef)
			{
				return;
			}

			flushPending();

			if (target.Equals(Result.PI_DISABLE_OUTPUT_ESCAPING))
			{
				startNonEscaping();
			}
			else if (target.Equals(Result.PI_ENABLE_OUTPUT_ESCAPING))
			{
				endNonEscaping();
			}
			else
			{
				try
				{
					if (m_elemContext.m_startTagOpen)
					{
						closeStartTag();
						m_elemContext.m_startTagOpen = false;
					}
					else if (m_needToCallStartDocument)
					{
						startDocumentInternal();
					}

					if (shouldIndent())
					{
						indent();
					}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.Writer writer = m_writer;
					java.io.Writer writer = m_writer;
					writer.write("<?");
					writer.write(target);

					if (data.Length > 0 && !Character.isSpaceChar(data[0]))
					{
						writer.write(' ');
					}

					int indexOfQLT = data.IndexOf("?>", StringComparison.Ordinal);

					if (indexOfQLT >= 0)
					{

						// See XSLT spec on error recovery of "?>" in PIs.
						if (indexOfQLT > 0)
						{
							writer.write(data.Substring(0, indexOfQLT));
						}

						writer.write("? >"); // add space between.

						if ((indexOfQLT + 2) < data.Length)
						{
							writer.write(data.Substring(indexOfQLT + 2));
						}
					}
					else
					{
						writer.write(data);
					}

					writer.write('?');
					writer.write('>');

					/*
					 * Don't write out any indentation whitespace now,
					 * because there may be non-whitespace text after this.
					 * 
					 * Simply mark that at this point if we do decide
					 * to indent that we should 
					 * add a newline on the end of the current line before
					 * the indentation at the start of the next line.
					 */ 
					m_startNewLine = true;
				}
				catch (IOException e)
				{
					throw new SAXException(e);
				}
			}

			if (m_tracer != null)
			{
				base.fireEscapingEvent(target, data);
			}
		}

		/// <summary>
		/// Receive notivication of a entityReference.
		/// </summary>
		/// <param name="name"> The name of the entity.
		/// </param>
		/// <exception cref="org.xml.sax.SAXException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void entityReference(String name) throws org.xml.sax.SAXException
		public override void entityReference(string name)
		{
			if (m_elemContext.m_startTagOpen)
			{
				closeStartTag();
				m_elemContext.m_startTagOpen = false;
			}

			try
			{
				if (shouldIndent())
				{
					indent();
				}

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.Writer writer = m_writer;
				java.io.Writer writer = m_writer;
				writer.write('&');
				writer.write(name);
				writer.write(';');
			}
			catch (IOException e)
			{
				throw new SAXException(e);
			}

			if (m_tracer != null)
			{
				base.fireEntityReference(name);
			}
		}

		/// <summary>
		/// This method is used to add an attribute to the currently open element. 
		/// The caller has guaranted that this attribute is unique, which means that it
		/// not been seen before and will not be seen again.
		/// </summary>
		/// <param name="name"> the qualified name of the attribute </param>
		/// <param name="value"> the value of the attribute which can contain only
		/// ASCII printable characters characters in the range 32 to 127 inclusive. </param>
		/// <param name="flags"> the bit values of this integer give optimization information. </param>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void addUniqueAttribute(String name, String value, int flags) throws org.xml.sax.SAXException
		public override void addUniqueAttribute(string name, string value, int flags)
		{
			if (m_elemContext.m_startTagOpen)
			{

				try
				{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final String patchedName = patchName(name);
					string patchedName = patchName(name);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final java.io.Writer writer = m_writer;
					java.io.Writer writer = m_writer;
					if ((flags & ExtendedContentHandler_Fields.NO_BAD_CHARS) > 0 && m_xmlcharInfo.onlyQuotAmpLtGt)
					{
						// "flags" has indicated that the characters
						// '>'  '<'   '&'  and '"' are not in the value and
						// m_htmlcharInfo has recorded that there are no other
						// entities in the range 32 to 127 so we write out the
						// value directly

						writer.write(' ');
						writer.write(patchedName);
						writer.write("=\"");
						writer.write(value);
						writer.write('"');
					}
					else
					{
						writer.write(' ');
						writer.write(patchedName);
						writer.write("=\"");
						writeAttrString(writer, value, this.Encoding);
						writer.write('"');
					}
				}
				catch (IOException e)
				{
					throw new SAXException(e);
				}
			}
		}

		/// <summary>
		/// Add an attribute to the current element. </summary>
		/// <param name="uri"> the URI associated with the element name </param>
		/// <param name="localName"> local part of the attribute name </param>
		/// <param name="rawName">   prefix:localName </param>
		/// <param name="type"> </param>
		/// <param name="value"> the value of the attribute </param>
		/// <param name="xslAttribute"> true if this attribute is from an xsl:attribute,
		/// false if declared within the elements opening tag. </param>
		/// <exception cref="SAXException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void addAttribute(String uri, String localName, String rawName, String type, String value, boolean xslAttribute) throws org.xml.sax.SAXException
		public override void addAttribute(string uri, string localName, string rawName, string type, string value, bool xslAttribute)
		{
			if (m_elemContext.m_startTagOpen)
			{
				bool was_added = addAttributeAlways(uri, localName, rawName, type, value, xslAttribute);


				/*
				 * We don't run this block of code if:
				 * 1. The attribute value was only replaced (was_added is false).
				 * 2. The attribute is from an xsl:attribute element (that is handled
				 *    in the addAttributeAlways() call just above.
				 * 3. The name starts with "xmlns", i.e. it is a namespace declaration.
				 */
				if (was_added && !xslAttribute && !rawName.StartsWith("xmlns", StringComparison.Ordinal))
				{
					string prefixUsed = ensureAttributesNamespaceIsDeclared(uri, localName, rawName);
					if (!string.ReferenceEquals(prefixUsed, null) && !string.ReferenceEquals(rawName, null) && !rawName.StartsWith(prefixUsed, StringComparison.Ordinal))
					{
						// use a different raw name, with the prefix used in the
						// generated namespace declaration
						rawName = prefixUsed + ":" + localName;

					}
				}
				addAttributeAlways(uri, localName, rawName, type, value, xslAttribute);
			}
			else
			{
				/*
				 * The startTag is closed, yet we are adding an attribute?
				 *
				 * Section: 7.1.3 Creating Attributes Adding an attribute to an
				 * element after a PI (for example) has been added to it is an
				 * error. The attributes can be ignored. The spec doesn't explicitly
				 * say this is disallowed, as it does for child elements, but it
				 * makes sense to have the same treatment.
				 *
				 * We choose to ignore the attribute which is added too late.
				 */
				// Generate a warning of the ignored attributes

				// Create the warning message
				string msg = Utils.messages.createMessage(MsgKey.ER_ILLEGAL_ATTRIBUTE_POSITION,new object[]{localName});

				try
				{
					// Prepare to issue the warning message
					Transformer tran = base.Transformer;
					ErrorListener errHandler = tran.ErrorListener;


					// Issue the warning message
					if (null != errHandler && m_sourceLocator != null)
					{
					  errHandler.warning(new TransformerException(msg, m_sourceLocator));
					}
					else
					{
					  Console.WriteLine(msg);
					}
				}
				catch (TransformerException e)
				{
					// A user defined error handler, errHandler, may throw
					// a TransformerException if it chooses to, and if it does
					// we will wrap it with a SAXException and re-throw.
					// Of course if the handler throws another type of
					// exception, like a RuntimeException, then that is OK too.
					SAXException se = new SAXException(e);
					throw se;
				}
			}
		}

		/// <seealso cref= ExtendedContentHandler#endElement(String) </seealso>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void endElement(String elemName) throws org.xml.sax.SAXException
		public override void endElement(string elemName)
		{
			endElement(null, null, elemName);
		}

		/// <summary>
		/// This method is used to notify the serializer of a namespace mapping (or node)
		/// that applies to the current element whose startElement() call has already been seen.
		/// The official SAX startPrefixMapping(prefix,uri) is to define a mapping for a child
		/// element that is soon to be seen with a startElement() call. The official SAX call 
		/// does not apply to the current element, hence the reason for this method.
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void namespaceAfterStartElement(final String prefix, final String uri) throws org.xml.sax.SAXException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
		public override void namespaceAfterStartElement(string prefix, string uri)
		{

			// hack for XSLTC with finding URI for default namespace
			if (string.ReferenceEquals(m_elemContext.m_elementURI, null))
			{
				string prefix1 = getPrefixPart(m_elemContext.m_elementName);
				if (string.ReferenceEquals(prefix1, null) && SerializerConstants_Fields.EMPTYSTRING.Equals(prefix))
				{
					// the elements URI is not known yet, and it
					// doesn't have a prefix, and we are currently
					// setting the uri for prefix "", so we have
					// the uri for the element... lets remember it
					m_elemContext.m_elementURI = uri;
				}
			}
			startPrefixMapping(prefix,uri,false);
			return;

		}

		/// <summary>
		/// From XSLTC
		/// Declare a prefix to point to a namespace URI. Inform SAX handler
		/// if this is a new prefix mapping.
		/// </summary>
		protected internal virtual bool pushNamespace(string prefix, string uri)
		{
			try
			{
				if (m_prefixMap.pushNamespace(prefix, uri, m_elemContext.m_currentElemDepth))
				{
					startPrefixMapping(prefix, uri);
					return true;
				}
			}
			catch (SAXException)
			{
				// falls through
			}
			return false;
		}
		/// <summary>
		/// Try's to reset the super class and reset this class for 
		/// re-use, so that you don't need to create a new serializer 
		/// (mostly for performance reasons).
		/// </summary>
		/// <returns> true if the class was successfuly reset. </returns>
		public override bool reset()
		{
			bool wasReset = false;
			if (base.reset())
			{
				// Make this call when resetToXMLStream does
				// something.
				// resetToXMLStream();
				wasReset = true;
			}
			return wasReset;
		}

		/// <summary>
		/// Reset all of the fields owned by ToStream class
		/// 
		/// </summary>
		private void resetToXMLStream()
		{
			// This is an empty method, but is kept for future use
			// as a place holder for a location to reset fields
			// defined within this class
			return;
		}

		/// <summary>
		/// This method checks for the XML version of output document.
		/// If XML version of output document is not specified, then output 
		/// document is of version XML 1.0.
		/// If XML version of output doucment is specified, but it is not either 
		/// XML 1.0 or XML 1.1, a warning message is generated, the XML Version of
		/// output document is set to XML 1.0 and processing continues. </summary>
		/// <returns> string (XML version) </returns>
		private string XMLVersion
		{
			get
			{
				string xmlVersion = Version;
				if (string.ReferenceEquals(xmlVersion, null) || xmlVersion.Equals(SerializerConstants_Fields.XMLVERSION10))
				{
					xmlVersion = SerializerConstants_Fields.XMLVERSION10;
				}
				else if (xmlVersion.Equals(SerializerConstants_Fields.XMLVERSION11))
				{
					xmlVersion = SerializerConstants_Fields.XMLVERSION11;
				}
				else
				{
					string msg = Utils.messages.createMessage(MsgKey.ER_XML_VERSION_NOT_SUPPORTED,new object[]{xmlVersion});
					try
					{
						// Prepare to issue the warning message
						Transformer tran = base.Transformer;
						ErrorListener errHandler = tran.ErrorListener;
						// Issue the warning message
						if (null != errHandler && m_sourceLocator != null)
						{
							errHandler.warning(new TransformerException(msg, m_sourceLocator));
						}
						else
						{
							Console.WriteLine(msg);
						}
					}
					catch (Exception)
					{
					}
					xmlVersion = SerializerConstants_Fields.XMLVERSION10;
				}
				return xmlVersion;
			}
		}
	}

 }