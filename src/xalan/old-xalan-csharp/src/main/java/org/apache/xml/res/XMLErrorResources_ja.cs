﻿/*
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
 * $Id: XMLErrorResources_ja.java 468653 2006-10-28 07:07:05Z minchau $
 */
namespace org.apache.xml.res
{



	/// <summary>
	/// Set up error messages.
	/// We build a two dimensional array of message keys and
	/// message strings. In order to add a new message here,
	/// you need to first add a String constant. And you need
	/// to enter key, value pair as part of the contents
	/// array. You also need to update MAX_CODE for error strings
	/// and MAX_WARNING for warnings ( Needed for only information
	/// purpose )
	/// </summary>
	public class XMLErrorResources_ja : ListResourceBundle
	{

	/*
	 * This file contains error and warning messages related to Xalan Error
	 * Handling.
	 *
	 *  General notes to translators:
	 *
	 *  1) Xalan (or more properly, Xalan-interpretive) and XSLTC are names of
	 *     components.
	 *     XSLT is an acronym for "XML Stylesheet Language: Transformations".
	 *     XSLTC is an acronym for XSLT Compiler.
	 *
	 *  2) A stylesheet is a description of how to transform an input XML document
	 *     into a resultant XML document (or HTML document or text).  The
	 *     stylesheet itself is described in the form of an XML document.
	 *
	 *  3) A template is a component of a stylesheet that is used to match a
	 *     particular portion of an input document and specifies the form of the
	 *     corresponding portion of the output document.
	 *
	 *  4) An element is a mark-up tag in an XML document; an attribute is a
	 *     modifier on the tag.  For example, in <elem attr='val' attr2='val2'>
	 *     "elem" is an element name, "attr" and "attr2" are attribute names with
	 *     the values "val" and "val2", respectively.
	 *
	 *  5) A namespace declaration is a special attribute that is used to associate
	 *     a prefix with a URI (the namespace).  The meanings of element names and
	 *     attribute names that use that prefix are defined with respect to that
	 *     namespace.
	 *
	 *  6) "Translet" is an invented term that describes the class file that
	 *     results from compiling an XML stylesheet into a Java class.
	 *
	 *  7) XPath is a specification that describes a notation for identifying
	 *     nodes in a tree-structured representation of an XML document.  An
	 *     instance of that notation is referred to as an XPath expression.
	 *
	 */

	  /*
	   * Message keys
	   */
	  public const string ER_FUNCTION_NOT_SUPPORTED = "ER_FUNCTION_NOT_SUPPORTED";
	  public const string ER_CANNOT_OVERWRITE_CAUSE = "ER_CANNOT_OVERWRITE_CAUSE";
	  public const string ER_NO_DEFAULT_IMPL = "ER_NO_DEFAULT_IMPL";
	  public const string ER_CHUNKEDINTARRAY_NOT_SUPPORTED = "ER_CHUNKEDINTARRAY_NOT_SUPPORTED";
	  public const string ER_OFFSET_BIGGER_THAN_SLOT = "ER_OFFSET_BIGGER_THAN_SLOT";
	  public const string ER_COROUTINE_NOT_AVAIL = "ER_COROUTINE_NOT_AVAIL";
	  public const string ER_COROUTINE_CO_EXIT = "ER_COROUTINE_CO_EXIT";
	  public const string ER_COJOINROUTINESET_FAILED = "ER_COJOINROUTINESET_FAILED";
	  public const string ER_COROUTINE_PARAM = "ER_COROUTINE_PARAM";
	  public const string ER_PARSER_DOTERMINATE_ANSWERS = "ER_PARSER_DOTERMINATE_ANSWERS";
	  public const string ER_NO_PARSE_CALL_WHILE_PARSING = "ER_NO_PARSE_CALL_WHILE_PARSING";
	  public const string ER_TYPED_ITERATOR_AXIS_NOT_IMPLEMENTED = "ER_TYPED_ITERATOR_AXIS_NOT_IMPLEMENTED";
	  public const string ER_ITERATOR_AXIS_NOT_IMPLEMENTED = "ER_ITERATOR_AXIS_NOT_IMPLEMENTED";
	  public const string ER_ITERATOR_CLONE_NOT_SUPPORTED = "ER_ITERATOR_CLONE_NOT_SUPPORTED";
	  public const string ER_UNKNOWN_AXIS_TYPE = "ER_UNKNOWN_AXIS_TYPE";
	  public const string ER_AXIS_NOT_SUPPORTED = "ER_AXIS_NOT_SUPPORTED";
	  public const string ER_NO_DTMIDS_AVAIL = "ER_NO_DTMIDS_AVAIL";
	  public const string ER_NOT_SUPPORTED = "ER_NOT_SUPPORTED";
	  public const string ER_NODE_NON_NULL = "ER_NODE_NON_NULL";
	  public const string ER_COULD_NOT_RESOLVE_NODE = "ER_COULD_NOT_RESOLVE_NODE";
	  public const string ER_STARTPARSE_WHILE_PARSING = "ER_STARTPARSE_WHILE_PARSING";
	  public const string ER_STARTPARSE_NEEDS_SAXPARSER = "ER_STARTPARSE_NEEDS_SAXPARSER";
	  public const string ER_COULD_NOT_INIT_PARSER = "ER_COULD_NOT_INIT_PARSER";
	  public const string ER_EXCEPTION_CREATING_POOL = "ER_EXCEPTION_CREATING_POOL";
	  public const string ER_PATH_CONTAINS_INVALID_ESCAPE_SEQUENCE = "ER_PATH_CONTAINS_INVALID_ESCAPE_SEQUENCE";
	  public const string ER_SCHEME_REQUIRED = "ER_SCHEME_REQUIRED";
	  public const string ER_NO_SCHEME_IN_URI = "ER_NO_SCHEME_IN_URI";
	  public const string ER_NO_SCHEME_INURI = "ER_NO_SCHEME_INURI";
	  public const string ER_PATH_INVALID_CHAR = "ER_PATH_INVALID_CHAR";
	  public const string ER_SCHEME_FROM_NULL_STRING = "ER_SCHEME_FROM_NULL_STRING";
	  public const string ER_SCHEME_NOT_CONFORMANT = "ER_SCHEME_NOT_CONFORMANT";
	  public const string ER_HOST_ADDRESS_NOT_WELLFORMED = "ER_HOST_ADDRESS_NOT_WELLFORMED";
	  public const string ER_PORT_WHEN_HOST_NULL = "ER_PORT_WHEN_HOST_NULL";
	  public const string ER_INVALID_PORT = "ER_INVALID_PORT";
	  public const string ER_FRAG_FOR_GENERIC_URI = "ER_FRAG_FOR_GENERIC_URI";
	  public const string ER_FRAG_WHEN_PATH_NULL = "ER_FRAG_WHEN_PATH_NULL";
	  public const string ER_FRAG_INVALID_CHAR = "ER_FRAG_INVALID_CHAR";
	  public const string ER_PARSER_IN_USE = "ER_PARSER_IN_USE";
	  public const string ER_CANNOT_CHANGE_WHILE_PARSING = "ER_CANNOT_CHANGE_WHILE_PARSING";
	  public const string ER_SELF_CAUSATION_NOT_PERMITTED = "ER_SELF_CAUSATION_NOT_PERMITTED";
	  public const string ER_NO_USERINFO_IF_NO_HOST = "ER_NO_USERINFO_IF_NO_HOST";
	  public const string ER_NO_PORT_IF_NO_HOST = "ER_NO_PORT_IF_NO_HOST";
	  public const string ER_NO_QUERY_STRING_IN_PATH = "ER_NO_QUERY_STRING_IN_PATH";
	  public const string ER_NO_FRAGMENT_STRING_IN_PATH = "ER_NO_FRAGMENT_STRING_IN_PATH";
	  public const string ER_CANNOT_INIT_URI_EMPTY_PARMS = "ER_CANNOT_INIT_URI_EMPTY_PARMS";
	  public const string ER_METHOD_NOT_SUPPORTED = "ER_METHOD_NOT_SUPPORTED";
	  public const string ER_INCRSAXSRCFILTER_NOT_RESTARTABLE = "ER_INCRSAXSRCFILTER_NOT_RESTARTABLE";
	  public const string ER_XMLRDR_NOT_BEFORE_STARTPARSE = "ER_XMLRDR_NOT_BEFORE_STARTPARSE";
	  public const string ER_AXIS_TRAVERSER_NOT_SUPPORTED = "ER_AXIS_TRAVERSER_NOT_SUPPORTED";
	  public const string ER_ERRORHANDLER_CREATED_WITH_NULL_PRINTWRITER = "ER_ERRORHANDLER_CREATED_WITH_NULL_PRINTWRITER";
	  public const string ER_SYSTEMID_UNKNOWN = "ER_SYSTEMID_UNKNOWN";
	  public const string ER_LOCATION_UNKNOWN = "ER_LOCATION_UNKNOWN";
	  public const string ER_PREFIX_MUST_RESOLVE = "ER_PREFIX_MUST_RESOLVE";
	  public const string ER_CREATEDOCUMENT_NOT_SUPPORTED = "ER_CREATEDOCUMENT_NOT_SUPPORTED";
	  public const string ER_CHILD_HAS_NO_OWNER_DOCUMENT = "ER_CHILD_HAS_NO_OWNER_DOCUMENT";
	  public const string ER_CHILD_HAS_NO_OWNER_DOCUMENT_ELEMENT = "ER_CHILD_HAS_NO_OWNER_DOCUMENT_ELEMENT";
	  public const string ER_CANT_OUTPUT_TEXT_BEFORE_DOC = "ER_CANT_OUTPUT_TEXT_BEFORE_DOC";
	  public const string ER_CANT_HAVE_MORE_THAN_ONE_ROOT = "ER_CANT_HAVE_MORE_THAN_ONE_ROOT";
	  public const string ER_ARG_LOCALNAME_NULL = "ER_ARG_LOCALNAME_NULL";
	  public const string ER_ARG_LOCALNAME_INVALID = "ER_ARG_LOCALNAME_INVALID";
	  public const string ER_ARG_PREFIX_INVALID = "ER_ARG_PREFIX_INVALID";
	  public const string ER_NAME_CANT_START_WITH_COLON = "ER_NAME_CANT_START_WITH_COLON";

	  /*
	   * Now fill in the message text.
	   * Then fill in the message text for that message code in the
	   * array. Use the new error code as the index into the array.
	   */

	  // Error messages...

	  /// <summary>
	  /// Get the lookup table for error messages
	  /// </summary>
	  /// <returns> The association list. </returns>
	  public virtual object[][] Contents
	  {
		  get
		  {
			return new object[][]
			{
				new object[] {"ER0000", "{0}"},
				new object[] {ER_FUNCTION_NOT_SUPPORTED, "\u6a5f\u80fd\u306f\u30b5\u30dd\u30fc\u30c8\u3055\u308c\u3066\u3044\u307e\u305b\u3093\u3002"},
				new object[] {ER_CANNOT_OVERWRITE_CAUSE, "cause \u3092\u4e0a\u66f8\u304d\u3067\u304d\u307e\u305b\u3093"},
				new object[] {ER_NO_DEFAULT_IMPL, "\u30c7\u30d5\u30a9\u30eb\u30c8\u5b9f\u88c5\u304c\u898b\u3064\u304b\u308a\u307e\u305b\u3093 "},
				new object[] {ER_CHUNKEDINTARRAY_NOT_SUPPORTED, "\u73fe\u5728 ChunkedIntArray({0}) \u306f\u30b5\u30dd\u30fc\u30c8\u3055\u308c\u3066\u3044\u307e\u305b\u3093"},
				new object[] {ER_OFFSET_BIGGER_THAN_SLOT, "\u30aa\u30d5\u30bb\u30c3\u30c8\u304c\u30b9\u30ed\u30c3\u30c8\u3088\u308a\u5927\u3067\u3059"},
				new object[] {ER_COROUTINE_NOT_AVAIL, "\u30b3\u30eb\u30fc\u30c1\u30f3\u304c\u4f7f\u7528\u53ef\u80fd\u3067\u3042\u308a\u307e\u305b\u3093\u3002id={0}"},
				new object[] {ER_COROUTINE_CO_EXIT, "CoroutineManager \u304c co_exit() \u8981\u6c42\u3092\u53d7\u3051\u53d6\u308a\u307e\u3057\u305f"},
				new object[] {ER_COJOINROUTINESET_FAILED, "co_joinCoroutineSet() \u304c\u5931\u6557\u3057\u307e\u3057\u305f"},
				new object[] {ER_COROUTINE_PARAM, "\u30b3\u30eb\u30fc\u30c1\u30f3\u30fb\u30d1\u30e9\u30e1\u30fc\u30bf\u30fc\u30fb\u30a8\u30e9\u30fc ({0})"},
				new object[] {ER_PARSER_DOTERMINATE_ANSWERS, "\n\u4e88\u60f3\u5916: \u30d1\u30fc\u30b5\u30fc doTerminate \u304c {0} \u3092\u5fdc\u7b54\u3057\u3066\u3044\u307e\u3059"},
				new object[] {ER_NO_PARSE_CALL_WHILE_PARSING, "parse \u306f\u69cb\u6587\u89e3\u6790\u4e2d\u306b\u547c\u3073\u51fa\u3057\u3066\u306f\u3044\u3051\u307e\u305b\u3093"},
				new object[] {ER_TYPED_ITERATOR_AXIS_NOT_IMPLEMENTED, "\u30a8\u30e9\u30fc: \u8ef8 {0} \u306e\u578b\u4ed8\u304d\u30a4\u30c6\u30ec\u30fc\u30bf\u30fc\u306f\u5b9f\u88c5\u3055\u308c\u3066\u3044\u307e\u305b\u3093"},
				new object[] {ER_ITERATOR_AXIS_NOT_IMPLEMENTED, "\u30a8\u30e9\u30fc: \u8ef8 {0} \u306e\u30a4\u30c6\u30ec\u30fc\u30bf\u30fc\u306f\u5b9f\u88c5\u3055\u308c\u3066\u3044\u307e\u305b\u3093 "},
				new object[] {ER_ITERATOR_CLONE_NOT_SUPPORTED, "\u30a4\u30c6\u30ec\u30fc\u30bf\u30fc\u306e\u8907\u88fd\u306f\u30b5\u30dd\u30fc\u30c8\u3055\u308c\u3066\u3044\u307e\u305b\u3093"},
				new object[] {ER_UNKNOWN_AXIS_TYPE, "\u4e0d\u660e\u306e\u8ef8\u30c8\u30e9\u30d0\u30fc\u30b9\u30fb\u30bf\u30a4\u30d7: {0}"},
				new object[] {ER_AXIS_NOT_SUPPORTED, "\u8ef8\u30c8\u30e9\u30d0\u30fc\u30b5\u30fc\u306f\u30b5\u30dd\u30fc\u30c8\u3055\u308c\u3066\u3044\u307e\u305b\u3093: {0}"},
				new object[] {ER_NO_DTMIDS_AVAIL, "\u4f7f\u7528\u53ef\u80fd\u306a DTM ID \u306f\u3053\u308c\u4ee5\u4e0a\u3042\u308a\u307e\u305b\u3093"},
				new object[] {ER_NOT_SUPPORTED, "\u30b5\u30dd\u30fc\u30c8\u3055\u308c\u3066\u3044\u307e\u305b\u3093: {0}"},
				new object[] {ER_NODE_NON_NULL, "getDTMHandleFromNode \u306e\u30ce\u30fc\u30c9\u306f\u975e\u30cc\u30eb\u3067\u306a\u3051\u308c\u3070\u306a\u308a\u307e\u305b\u3093"},
				new object[] {ER_COULD_NOT_RESOLVE_NODE, "\u30ce\u30fc\u30c9\u3092\u30cf\u30f3\u30c9\u30eb\u306b\u89e3\u6c7a\u3067\u304d\u307e\u305b\u3093\u3067\u3057\u305f"},
				new object[] {ER_STARTPARSE_WHILE_PARSING, "startParse \u306f\u69cb\u6587\u89e3\u6790\u4e2d\u306b\u547c\u3073\u51fa\u3057\u3066\u306f\u3044\u3051\u307e\u305b\u3093"},
				new object[] {ER_STARTPARSE_NEEDS_SAXPARSER, "startParse \u306b\u306f\u30cc\u30eb\u4ee5\u5916\u306e SAXParser \u304c\u5fc5\u8981\u3067\u3059"},
				new object[] {ER_COULD_NOT_INIT_PARSER, "\u30d1\u30fc\u30b5\u30fc\u3092\u6b21\u3067\u521d\u671f\u5316\u3067\u304d\u307e\u305b\u3093\u3067\u3057\u305f:"},
				new object[] {ER_EXCEPTION_CREATING_POOL, "\u30d7\u30fc\u30eb\u306e\u65b0\u898f\u30a4\u30f3\u30b9\u30bf\u30f3\u30b9\u3092\u4f5c\u6210\u4e2d\u306b\u4f8b\u5916"},
				new object[] {ER_PATH_CONTAINS_INVALID_ESCAPE_SEQUENCE, "\u30d1\u30b9\u306b\u7121\u52b9\u306a\u30a8\u30b9\u30b1\u30fc\u30d7\u30fb\u30b7\u30fc\u30b1\u30f3\u30b9\u304c\u542b\u307e\u308c\u3066\u3044\u307e\u3059"},
				new object[] {ER_SCHEME_REQUIRED, "\u30b9\u30ad\u30fc\u30e0\u304c\u5fc5\u8981\u3067\u3059\u3002"},
				new object[] {ER_NO_SCHEME_IN_URI, "\u30b9\u30ad\u30fc\u30e0\u306f URI {0} \u3067\u898b\u3064\u304b\u308a\u307e\u305b\u3093"},
				new object[] {ER_NO_SCHEME_INURI, "\u30b9\u30ad\u30fc\u30e0\u306f URI \u3067\u898b\u3064\u304b\u308a\u307e\u305b\u3093"},
				new object[] {ER_PATH_INVALID_CHAR, "\u30d1\u30b9\u306b\u7121\u52b9\u6587\u5b57: {0} \u304c\u542b\u307e\u308c\u3066\u3044\u307e\u3059"},
				new object[] {ER_SCHEME_FROM_NULL_STRING, "\u30cc\u30eb\u30fb\u30b9\u30c8\u30ea\u30f3\u30b0\u304b\u3089\u306f\u30b9\u30ad\u30fc\u30e0\u3092\u8a2d\u5b9a\u3067\u304d\u307e\u305b\u3093"},
				new object[] {ER_SCHEME_NOT_CONFORMANT, "\u30b9\u30ad\u30fc\u30e0\u306f\u4e00\u81f4\u3057\u3066\u3044\u307e\u305b\u3093\u3002"},
				new object[] {ER_HOST_ADDRESS_NOT_WELLFORMED, "\u30db\u30b9\u30c8\u306f\u3046\u307e\u304f\u69cb\u6210\u3055\u308c\u305f\u30a2\u30c9\u30ec\u30b9\u3067\u3042\u308a\u307e\u305b\u3093"},
				new object[] {ER_PORT_WHEN_HOST_NULL, "\u30db\u30b9\u30c8\u304c\u30cc\u30eb\u3067\u3042\u308b\u3068\u30dd\u30fc\u30c8\u3092\u8a2d\u5b9a\u3067\u304d\u307e\u305b\u3093"},
				new object[] {ER_INVALID_PORT, "\u7121\u52b9\u306a\u30dd\u30fc\u30c8\u756a\u53f7"},
				new object[] {ER_FRAG_FOR_GENERIC_URI, "\u7dcf\u79f0 URI \u306e\u30d5\u30e9\u30b0\u30e1\u30f3\u30c8\u3057\u304b\u8a2d\u5b9a\u3067\u304d\u307e\u305b\u3093"},
				new object[] {ER_FRAG_WHEN_PATH_NULL, "\u30d1\u30b9\u304c\u30cc\u30eb\u3067\u3042\u308b\u3068\u30d5\u30e9\u30b0\u30e1\u30f3\u30c8\u3092\u8a2d\u5b9a\u3067\u304d\u307e\u305b\u3093"},
				new object[] {ER_FRAG_INVALID_CHAR, "\u30d5\u30e9\u30b0\u30e1\u30f3\u30c8\u306b\u7121\u52b9\u6587\u5b57\u304c\u542b\u307e\u308c\u3066\u3044\u307e\u3059"},
				new object[] {ER_PARSER_IN_USE, "\u30d1\u30fc\u30b5\u30fc\u306f\u3059\u3067\u306b\u4f7f\u7528\u4e2d\u3067\u3059"},
				new object[] {ER_CANNOT_CHANGE_WHILE_PARSING, "\u69cb\u6587\u89e3\u6790\u4e2d\u306b {0} {1} \u3092\u5909\u66f4\u3067\u304d\u307e\u305b\u3093"},
				new object[] {ER_SELF_CAUSATION_NOT_PERMITTED, "\u81ea\u5206\u81ea\u8eab\u3092\u539f\u56e0\u3068\u3059\u308b\u3053\u3068\u306f\u3067\u304d\u307e\u305b\u3093"},
				new object[] {ER_NO_USERINFO_IF_NO_HOST, "\u30db\u30b9\u30c8\u304c\u6307\u5b9a\u3055\u308c\u3066\u3044\u306a\u3044\u5834\u5408\u306f Userinfo \u3092\u6307\u5b9a\u3057\u3066\u306f\u3044\u3051\u307e\u305b\u3093"},
				new object[] {ER_NO_PORT_IF_NO_HOST, "\u30db\u30b9\u30c8\u304c\u6307\u5b9a\u3055\u308c\u3066\u3044\u306a\u3044\u5834\u5408\u306f\u30dd\u30fc\u30c8\u3092\u6307\u5b9a\u3057\u3066\u306f\u3044\u3051\u307e\u305b\u3093"},
				new object[] {ER_NO_QUERY_STRING_IN_PATH, "\u7167\u4f1a\u30b9\u30c8\u30ea\u30f3\u30b0\u306f\u30d1\u30b9\u304a\u3088\u3073\u7167\u4f1a\u30b9\u30c8\u30ea\u30f3\u30b0\u5185\u306b\u6307\u5b9a\u3067\u304d\u307e\u305b\u3093"},
				new object[] {ER_NO_FRAGMENT_STRING_IN_PATH, "\u30d5\u30e9\u30b0\u30e1\u30f3\u30c8\u306f\u30d1\u30b9\u3068\u30d5\u30e9\u30b0\u30e1\u30f3\u30c8\u306e\u4e21\u65b9\u306b\u6307\u5b9a\u3067\u304d\u307e\u305b\u3093"},
				new object[] {ER_CANNOT_INIT_URI_EMPTY_PARMS, "URI \u306f\u7a7a\u306e\u30d1\u30e9\u30e1\u30fc\u30bf\u30fc\u3092\u4f7f\u7528\u3057\u3066\u521d\u671f\u5316\u3067\u304d\u307e\u305b\u3093"},
				new object[] {ER_METHOD_NOT_SUPPORTED, "\u30e1\u30bd\u30c3\u30c9\u306f\u307e\u3060\u30b5\u30dd\u30fc\u30c8\u3055\u308c\u3066\u3044\u307e\u305b\u3093 "},
				new object[] {ER_INCRSAXSRCFILTER_NOT_RESTARTABLE, "\u73fe\u5728 IncrementalSAXSource_Filter \u306f\u518d\u59cb\u52d5\u53ef\u80fd\u3067\u3042\u308a\u307e\u305b\u3093"},
				new object[] {ER_XMLRDR_NOT_BEFORE_STARTPARSE, "XMLReader \u304c startParse \u8981\u6c42\u306e\u524d\u3067\u3042\u308a\u307e\u305b\u3093"},
				new object[] {ER_AXIS_TRAVERSER_NOT_SUPPORTED, "\u8ef8\u30c8\u30e9\u30d0\u30fc\u30b5\u30fc\u306f\u30b5\u30dd\u30fc\u30c8\u3055\u308c\u3066\u3044\u307e\u305b\u3093: {0}"},
				new object[] {ER_ERRORHANDLER_CREATED_WITH_NULL_PRINTWRITER, "ListingErrorHandler \u304c\u30cc\u30eb PrintWriter \u3067\u4f5c\u6210\u3055\u308c\u307e\u3057\u305f\u3002"},
				new object[] {ER_SYSTEMID_UNKNOWN, "SystemId \u306f\u4e0d\u660e"},
				new object[] {ER_LOCATION_UNKNOWN, "\u30a8\u30e9\u30fc\u306e\u4f4d\u7f6e\u306f\u4e0d\u660e"},
				new object[] {ER_PREFIX_MUST_RESOLVE, "\u63a5\u982d\u90e8\u306f\u540d\u524d\u7a7a\u9593\u306b\u89e3\u6c7a\u3055\u308c\u306a\u3051\u308c\u3070\u306a\u308a\u307e\u305b\u3093: {0}"},
				new object[] {ER_CREATEDOCUMENT_NOT_SUPPORTED, "createDocument() \u306f XPathContext \u5185\u3067\u30b5\u30dd\u30fc\u30c8\u3055\u308c\u307e\u305b\u3093\u3002"},
				new object[] {ER_CHILD_HAS_NO_OWNER_DOCUMENT, "\u5c5e\u6027\u306e\u5b50\u306b\u6240\u6709\u8005\u6587\u66f8\u304c\u3042\u308a\u307e\u305b\u3093\u3002"},
				new object[] {ER_CHILD_HAS_NO_OWNER_DOCUMENT_ELEMENT, "\u5c5e\u6027\u306e\u5b50\u306b\u6240\u6709\u8005\u6587\u66f8\u8981\u7d20\u304c\u3042\u308a\u307e\u305b\u3093\u3002"},
				new object[] {ER_CANT_OUTPUT_TEXT_BEFORE_DOC, "\u8b66\u544a: \u6587\u66f8\u8981\u7d20\u306e\u524d\u306b\u30c6\u30ad\u30b9\u30c8\u3092\u51fa\u529b\u3067\u304d\u307e\u305b\u3093\u3002  \u7121\u8996\u3057\u3066\u3044\u307e\u3059..."},
				new object[] {ER_CANT_HAVE_MORE_THAN_ONE_ROOT, "DOM \u3067\u306f\u8907\u6570\u306e\u30eb\u30fc\u30c8\u3092\u6301\u3064\u3053\u3068\u306f\u3067\u304d\u307e\u305b\u3093\u3002"},
				new object[] {ER_ARG_LOCALNAME_NULL, "\u5f15\u6570 'localName' \u304c\u30cc\u30eb\u3067\u3059\u3002"},
				new object[] {ER_ARG_LOCALNAME_INVALID, "QNAME \u5185\u306e\u30ed\u30fc\u30ab\u30eb\u540d\u306f\u6709\u52b9\u306a NCName \u3067\u3042\u308b\u306f\u305a\u3067\u3059"},
				new object[] {ER_ARG_PREFIX_INVALID, "QNAME \u5185\u306e\u63a5\u982d\u90e8\u306f\u6709\u52b9\u306a NCName \u3067\u3042\u308b\u306f\u305a\u3067\u3059"},
				new object[] {ER_NAME_CANT_START_WITH_COLON, "\u540d\u524d\u306f\u30b3\u30ed\u30f3\u3067\u59cb\u3081\u308b\u3053\u3068\u304c\u3067\u304d\u307e\u305b\u3093"},
				new object[] {"BAD_CODE", "createMessage \u3078\u306e\u30d1\u30e9\u30e1\u30fc\u30bf\u30fc\u304c\u7bc4\u56f2\u5916\u3067\u3057\u305f\u3002"},
				new object[] {"FORMAT_FAILED", "messageFormat \u547c\u3073\u51fa\u3057\u4e2d\u306b\u4f8b\u5916\u304c\u30b9\u30ed\u30fc\u3055\u308c\u307e\u3057\u305f\u3002"},
				new object[] {"line", "\u884c #"},
				new object[] {"column","\u6841 #"}
			};
		  }
	  }

	  /// <summary>
	  ///   Return a named ResourceBundle for a particular locale.  This method mimics the behavior
	  ///   of ResourceBundle.getBundle().
	  /// </summary>
	  ///   <param name="className"> the name of the class that implements the resource bundle. </param>
	  ///   <returns> the ResourceBundle </returns>
	  ///   <exception cref="MissingResourceException"> </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public static final XMLErrorResources loadResourceBundle(String className) throws java.util.MissingResourceException
	  public static XMLErrorResources loadResourceBundle(string className)
	  {

		Locale locale = Locale.Default;
		string suffix = getResourceSuffix(locale);

		try
		{

		  // first try with the given locale
		  return (XMLErrorResources) ResourceBundle.getBundle(className + suffix, locale);
		}
		catch (MissingResourceException)
		{
		  try // try to fall back to en_US if we can't load
		  {

			// Since we can't find the localized property file,
			// fall back to en_US.
			return (XMLErrorResources) ResourceBundle.getBundle(className, new Locale("en", "US"));
		  }
		  catch (MissingResourceException)
		  {

			// Now we are really in trouble.
			// very bad, definitely very bad...not going to get very far
			throw new MissingResourceException("Could not load any resource bundles.", className, "");
		  }
		}
	  }

	  /// <summary>
	  /// Return the resource file suffic for the indicated locale
	  /// For most locales, this will be based the language code.  However
	  /// for Chinese, we do distinguish between Taiwan and PRC
	  /// </summary>
	  /// <param name="locale"> the locale </param>
	  /// <returns> an String suffix which canbe appended to a resource name </returns>
	  private static string getResourceSuffix(Locale locale)
	  {

		string suffix = "_" + locale.Language;
		string country = locale.Country;

		if (country.Equals("TW"))
		{
		  suffix += "_" + country;
		}

		return suffix;
	  }

	}

}