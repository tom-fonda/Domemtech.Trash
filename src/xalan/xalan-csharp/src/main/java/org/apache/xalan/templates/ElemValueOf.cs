﻿using System;
using System.Collections;

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
 * $Id: ElemValueOf.java 468643 2006-10-28 06:56:03Z minchau $
 */
namespace org.apache.xalan.templates
{

	using XSLTErrorResources = org.apache.xalan.res.XSLTErrorResources;
	using TransformerImpl = org.apache.xalan.transformer.TransformerImpl;
	using DTM = org.apache.xml.dtm.DTM;
	using SerializationHandler = org.apache.xml.serializer.SerializationHandler;
	using Expression = org.apache.xpath.Expression;
	using XPath = org.apache.xpath.XPath;
	using XPathContext = org.apache.xpath.XPathContext;
	using XObject = org.apache.xpath.objects.XObject;
	using SAXException = org.xml.sax.SAXException;

	/// <summary>
	/// Implement xsl:value-of.
	/// <pre>
	/// <!ELEMENT xsl:value-of EMPTY>
	/// <!ATTLIST xsl:value-of
	///   select %expr; #REQUIRED
	///   disable-output-escaping (yes|no) "no"
	/// >
	/// </pre> </summary>
	/// <seealso cref="<a href="http://www.w3.org/TR/xslt.value-of">value-of in XSLT Specification</a>"
	/// @xsl.usage advanced/>
	[Serializable]
	public class ElemValueOf : ElemTemplateElement
	{
		internal new const long serialVersionUID = 3490728458007586786L;

	  /// <summary>
	  /// The select expression to be executed.
	  /// @serial
	  /// </summary>
	  private XPath m_selectExpression = null;

	  /// <summary>
	  /// True if the pattern is a simple ".".
	  /// @serial
	  /// </summary>
	  private bool m_isDot = false;

	  /// <summary>
	  /// Set the "select" attribute.
	  /// The required select attribute is an expression; this expression
	  /// is evaluated and the resulting object is converted to a
	  /// string as if by a call to the string function.
	  /// </summary>
	  /// <param name="v"> The value to set for the "select" attribute. </param>
	  public virtual XPath Select
	  {
		  set
		  {
    
			if (null != value)
			{
			  string s = value.PatternString;
    
			  m_isDot = (null != s) && s.Equals(".");
			}
    
			m_selectExpression = value;
		  }
		  get
		  {
			return m_selectExpression;
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
	  /// <param name="v"> The value to set for the "disable-output-escaping" attribute. </param>
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
			return Constants.ELEMNAME_VALUEOF;
		  }
	  }

	  /// <summary>
	  /// This function is called after everything else has been
	  /// recomposed, and allows the template to set remaining
	  /// values that may be based on some other property that
	  /// depends on recomposition.
	  /// </summary>
	  /// NEEDSDOC <param name="sroot">
	  /// </param>
	  /// <exception cref="TransformerException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void compose(StylesheetRoot sroot) throws javax.xml.transform.TransformerException
	  public override void compose(StylesheetRoot sroot)
	  {

		base.compose(sroot);

		ArrayList vnames = sroot.ComposeState.VariableNames;

		if (null != m_selectExpression)
		{
		  m_selectExpression.fixupVariables(vnames, sroot.ComposeState.GlobalsSize);
		}
	  }

	  /// <summary>
	  /// Return the node name.
	  /// </summary>
	  /// <returns> The node name </returns>
	  public override string NodeName
	  {
		  get
		  {
			return Constants.ELEMNAME_VALUEOF_STRING;
		  }
	  }

	  /// <summary>
	  /// Execute the string expression and copy the text to the
	  /// result tree.
	  /// The required select attribute is an expression; this expression
	  /// is evaluated and the resulting object is converted to a string
	  /// as if by a call to the string function. The string specifies
	  /// the string-value of the created text node. If the string is
	  /// empty, no text node will be created. The created text node will
	  /// be merged with any adjacent text nodes. </summary>
	  /// <seealso cref="<a href="http://www.w3.org/TR/xslt.value-of">value-of in XSLT Specification</a>"
	  ////>
	  /// <param name="transformer"> non-null reference to the the current transform-time state.
	  /// </param>
	  /// <exception cref="TransformerException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void execute(org.apache.xalan.transformer.TransformerImpl transformer) throws javax.xml.transform.TransformerException
	  public override void execute(TransformerImpl transformer)
	  {

		XPathContext xctxt = transformer.XPathContext;
		SerializationHandler rth = transformer.ResultTreeHandler;

		if (transformer.Debug)
		{
		  transformer.TraceManager.fireTraceEvent(this);
		}

		try
		{
		  // Optimize for "."
		  if (false && m_isDot && !transformer.Debug)
		  {
			int child = xctxt.CurrentNode;
			DTM dtm = xctxt.getDTM(child);

			xctxt.pushCurrentNode(child);

			if (m_disableOutputEscaping)
			{
			  rth.processingInstruction(javax.xml.transform.Result.PI_DISABLE_OUTPUT_ESCAPING, "");
			}

			try
			{
			  dtm.dispatchCharactersEvents(child, rth, false);
			}
			finally
			{
			  if (m_disableOutputEscaping)
			  {
				rth.processingInstruction(javax.xml.transform.Result.PI_ENABLE_OUTPUT_ESCAPING, "");
			  }

			  xctxt.popCurrentNode();
			}
		  }
		  else
		  {
			xctxt.pushNamespaceContext(this);

			int current = xctxt.CurrentNode;

			xctxt.pushCurrentNodeAndExpression(current, current);

			if (m_disableOutputEscaping)
			{
			  rth.processingInstruction(javax.xml.transform.Result.PI_DISABLE_OUTPUT_ESCAPING, "");
			}

			try
			{
			  Expression expr = m_selectExpression.Expression;

			  if (transformer.Debug)
			  {
				XObject obj = expr.execute(xctxt);

				transformer.TraceManager.fireSelectedEvent(current, this, "select", m_selectExpression, obj);
				obj.dispatchCharactersEvents(rth);
			  }
			  else
			  {
				expr.executeCharsToContentHandler(xctxt, rth);
			  }
			}
			finally
			{
			  if (m_disableOutputEscaping)
			  {
				rth.processingInstruction(javax.xml.transform.Result.PI_ENABLE_OUTPUT_ESCAPING, "");
			  }

			  xctxt.popNamespaceContext();
			  xctxt.popCurrentNodeAndExpression();
			}
		  }
		}
		catch (SAXException se)
		{
		  throw new TransformerException(se);
		}
		catch (Exception re)
		{
			TransformerException te = new TransformerException(re);
			te.setLocator(this);
			throw te;
		}
		finally
		{
		  if (transformer.Debug)
		  {
			transformer.TraceManager.fireTraceEndEvent(this);
		  }
		}
	  }

	  /// <summary>
	  /// Add a child to the child list.
	  /// </summary>
	  /// <param name="newChild"> Child to add to children list
	  /// </param>
	  /// <returns> Child just added to children list
	  /// </returns>
	  /// <exception cref="DOMException"> </exception>
	  public override ElemTemplateElement appendChild(ElemTemplateElement newChild)
	  {

		error(XSLTErrorResources.ER_CANNOT_ADD, new object[]{newChild.NodeName, this.NodeName}); //"Can not add " +((ElemTemplateElement)newChild).m_elemName +

		//" to " + this.m_elemName);
		return null;
	  }

	  /// <summary>
	  /// Call the children visitors. </summary>
	  /// <param name="visitor"> The visitor whose appropriate method will be called. </param>
	  protected internal override void callChildVisitors(XSLTVisitor visitor, bool callAttrs)
	  {
		  if (callAttrs)
		  {
			  m_selectExpression.Expression.callVisitors(m_selectExpression, visitor);
		  }
		base.callChildVisitors(visitor, callAttrs);
	  }

	}

}