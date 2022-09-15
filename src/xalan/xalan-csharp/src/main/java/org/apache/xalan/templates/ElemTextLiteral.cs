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
 * $Id: ElemTextLiteral.java 468643 2006-10-28 06:56:03Z minchau $
 */
namespace org.apache.xalan.templates
{

	using TransformerImpl = org.apache.xalan.transformer.TransformerImpl;
	using SerializationHandler = org.apache.xml.serializer.SerializationHandler;
	using SAXException = org.xml.sax.SAXException;

	/// <summary>
	/// Implement a text literal. </summary>
	/// <seealso cref="<a href="http://www.w3.org/TR/xslt.section-Creating-Text">section-Creating-Text in XSLT Specification</a>"
	/// @xsl.usage advanced/>
	[Serializable]
	public class ElemTextLiteral : ElemTemplateElement
	{
		internal new const long serialVersionUID = -7872620006767660088L;

	  /// <summary>
	  /// Tell if space should be preserved.
	  /// @serial
	  /// </summary>
	  private bool m_preserveSpace;

	  /// <summary>
	  /// Set whether or not space should be preserved.
	  /// </summary>
	  /// <param name="v"> Boolean flag indicating whether 
	  /// or not space should be preserved </param>
	  public virtual bool PreserveSpace
	  {
		  set
		  {
			m_preserveSpace = value;
		  }
		  get
		  {
			return m_preserveSpace;
		  }
	  }


	  /// <summary>
	  /// The character array.
	  /// @serial
	  /// </summary>
	  private char[] m_ch;

	  /// <summary>
	  /// The character array as a string.
	  /// @serial
	  /// </summary>
	  private string m_str;

	  /// <summary>
	  /// Set the characters that will be output to the result tree..
	  /// </summary>
	  /// <param name="v"> Array of characters that will be output to the result tree  </param>
	  public virtual char[] Chars
	  {
		  set
		  {
			m_ch = value;
		  }
		  get
		  {
			return m_ch;
		  }
	  }


	  /// <summary>
	  /// Get the value of the node as a string.
	  /// </summary>
	  /// <returns> null </returns>
	  public override string NodeValue
	  {
		  get
		  {
			  lock (this)
			  {
            
				if (null == m_str)
				{
				  m_str = new string(m_ch);
				}
            
				return m_str;
			  }
		  }
	  }


	  /// <summary>
	  /// Tells if this element should disable escaping.
	  /// @serial
	  /// </summary>
	  private bool m_disableOutputEscaping = false;

	  /// <summary>
	  /// Set the "disable-output-escaping" attribute.
	  /// Normally, the xml output method escapes & and < (and
	  /// possibly other characters) when outputting text nodes.
	  /// This ensures that the output is well-formed XML. However,
	  /// it is sometimes convenient to be able to produce output
	  /// that is almost, but not quite well-formed XML; for
	  /// example, the output may include ill-formed sections
	  /// which are intended to be transformed into well-formed
	  /// XML by a subsequent non-XML aware process. For this reason,
	  /// XSLT provides a mechanism for disabling output escaping.
	  /// An xsl:value-of or xsl:text element may have a
	  /// disable-output-escaping attribute; the allowed values
	  /// are yes or no; the default is no; if the value is yes,
	  /// then a text node generated by instantiating the xsl:value-of
	  /// or xsl:text element should be output without any escaping. </summary>
	  /// <seealso cref="<a href="http://www.w3.org/TR/xslt.disable-output-escaping">disable-output-escaping in XSLT Specification</a>"
	  ////>
	  /// <param name="v"> Boolean value for "disable-output-escaping" attribute. </param>
	  public virtual bool DisableOutputEscaping
	  {
		  set
		  {
			m_disableOutputEscaping = value;
		  }
		  get
		  {
			return m_disableOutputEscaping;
		  }
	  }

	  /// <summary>
	  /// Get the "disable-output-escaping" attribute.
	  /// Normally, the xml output method escapes & and < (and
	  /// possibly other characters) when outputting text nodes.
	  /// This ensures that the output is well-formed XML. However,
	  /// it is sometimes convenient to be able to produce output
	  /// that is almost, but not quite well-formed XML; for
	  /// example, the output may include ill-formed sections
	  /// which are intended to be transformed into well-formed
	  /// XML by a subsequent non-XML aware process. For this reason,
	  /// XSLT provides a mechanism for disabling output escaping.
	  /// An xsl:value-of or xsl:text element may have a
	  /// disable-output-escaping attribute; the allowed values
	  /// are yes or no; the default is no; if the value is yes,
	  /// then a text node generated by instantiating the xsl:value-of
	  /// or xsl:text element should be output without any escaping. </summary>
	  /// <seealso cref="<a href="http://www.w3.org/TR/xslt.disable-output-escaping">disable-output-escaping in XSLT Specification</a>"
	  ////>

	  /// <summary>
	  /// Get an integer representation of the element type.
	  /// </summary>
	  /// <returns> An integer representation of the element, defined in the
	  ///     Constants class. </returns>
	  /// <seealso cref="org.apache.xalan.templates.Constants"/>
	  public override int XSLToken
	  {
		  get
		  {
			return Constants.ELEMNAME_TEXTLITERALRESULT;
		  }
	  }

	  /// <summary>
	  /// Return the node name.
	  /// </summary>
	  /// <returns> The element's name </returns>
	  public override string NodeName
	  {
		  get
		  {
			return "#Text";
		  }
	  }

	  /// <summary>
	  /// Copy the text literal to the result tree.
	  /// </summary>
	  /// <param name="transformer"> non-null reference to the the current transform-time state.
	  /// </param>
	  /// <exception cref="TransformerException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void execute(org.apache.xalan.transformer.TransformerImpl transformer) throws javax.xml.transform.TransformerException
	  public override void execute(TransformerImpl transformer)
	  {
		try
		{
		  SerializationHandler rth = transformer.ResultTreeHandler;
		  if (transformer.Debug)
		  {
			// flush any pending cached processing before the trace event.
			rth.flushPending();
			transformer.TraceManager.fireTraceEvent(this);
		  }

		  if (m_disableOutputEscaping)
		  {
			rth.processingInstruction(javax.xml.transform.Result.PI_DISABLE_OUTPUT_ESCAPING, "");
		  }

		  rth.characters(m_ch, 0, m_ch.Length);

		  if (m_disableOutputEscaping)
		  {
			rth.processingInstruction(javax.xml.transform.Result.PI_ENABLE_OUTPUT_ESCAPING, "");
		  }
		}
		catch (SAXException se)
		{
		  throw new TransformerException(se);
		}
		finally
		{
		  if (transformer.Debug)
		  {
			try
			{
				// flush any pending cached processing before sending the trace event
				transformer.ResultTreeHandler.flushPending();
				transformer.TraceManager.fireTraceEndEvent(this);
			}
			catch (SAXException se)
			{
				throw new TransformerException(se);
			}
		  }
		}
	  }
	}

}