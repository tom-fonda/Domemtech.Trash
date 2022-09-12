﻿using System.Collections;

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
 * $Id: DOMAdapter.java 468651 2006-10-28 07:04:25Z minchau $
 */

namespace org.apache.xalan.xsltc.dom
{

	using Hashtable = org.apache.xalan.xsltc.runtime.Hashtable;
	using DTM = org.apache.xml.dtm.DTM;
	using DTMAxisIterator = org.apache.xml.dtm.DTMAxisIterator;
	using SerializationHandler = org.apache.xml.serializer.SerializationHandler;

	using Node = org.w3c.dom.Node;
	using NodeList = org.w3c.dom.NodeList;

	/// <summary>
	/// @author Jacek Ambroziak
	/// @author Morten Jorgensen
	/// </summary>
	public sealed class DOMAdapter : DOM
	{

		// Mutually exclusive casting of DOM interface to known implementations
		private DOMEnhancedForDTM _enhancedDOM;

		private DOM _dom;

		private string[] _namesArray;
		private string[] _urisArray;
		private int[] _typesArray;
		private string[] _namespaceArray;

		// Cached mappings
		private short[] _mapping = null;
		private int[] _reverse = null;
		private short[] _NSmapping = null;
		private short[] _NSreverse = null;

		private StripFilter _filter = null;

		private int _multiDOMMask;

		public DOMAdapter(DOM dom, string[] namesArray, string[] urisArray, int[] typesArray, string[] namespaceArray)
		{
			if (dom is DOMEnhancedForDTM)
			{
				_enhancedDOM = (DOMEnhancedForDTM) dom;
			}

			_dom = dom;
			_namesArray = namesArray;
			_urisArray = urisArray;
			_typesArray = typesArray;
			_namespaceArray = namespaceArray;
		}

		public void setupMapping(string[] names, string[] urisArray, int[] typesArray, string[] namespaces)
		{
			_namesArray = names;
			_urisArray = urisArray;
			_typesArray = typesArray;
			_namespaceArray = namespaces;
		}

		public string[] NamesArray
		{
			get
			{
				return _namesArray;
			}
		}

		public string[] UrisArray
		{
			get
			{
				return _urisArray;
			}
		}

		public int[] TypesArray
		{
			get
			{
				return _typesArray;
			}
		}

		public string[] NamespaceArray
		{
			get
			{
				return _namespaceArray;
			}
		}

		public DOM DOMImpl
		{
			get
			{
				return _dom;
			}
		}

		private short[] Mapping
		{
			get
			{
				if (_mapping == null)
				{
					if (_enhancedDOM != null)
					{
						_mapping = _enhancedDOM.getMapping(_namesArray, _urisArray, _typesArray);
					}
				}
				return _mapping;
			}
		}

		private int[] Reverse
		{
			get
			{
			if (_reverse == null)
			{
					if (_enhancedDOM != null)
					{
					_reverse = _enhancedDOM.getReverseMapping(_namesArray, _urisArray, _typesArray);
					}
			}
			return _reverse;
			}
		}

		private short[] NSMapping
		{
			get
			{
			if (_NSmapping == null)
			{
					if (_enhancedDOM != null)
					{
					_NSmapping = _enhancedDOM.getNamespaceMapping(_namespaceArray);
					}
			}
			return _NSmapping;
			}
		}

		private short[] NSReverse
		{
			get
			{
			if (_NSreverse == null)
			{
					if (_enhancedDOM != null)
					{
					_NSreverse = _enhancedDOM.getReverseNamespaceMapping(_namespaceArray);
					}
			}
			return _NSreverse;
			}
		}

		/// <summary>
		/// Returns singleton iterator containg the document root 
		/// </summary>
		public DTMAxisIterator Iterator
		{
			get
			{
				return _dom.Iterator;
			}
		}

		public string StringValue
		{
			get
			{
				return _dom.StringValue;
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public org.apache.xml.dtm.DTMAxisIterator getChildren(final int node)
		public DTMAxisIterator getChildren(int node)
		{
			if (_enhancedDOM != null)
			{
				return _enhancedDOM.getChildren(node);
			}
			else
			{
				DTMAxisIterator iterator = _dom.getChildren(node);
				return iterator.setStartNode(node);
			}
		}

		public StripFilter Filter
		{
			set
			{
			_filter = value;
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public org.apache.xml.dtm.DTMAxisIterator getTypedChildren(final int type)
		public DTMAxisIterator getTypedChildren(int type)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int[] reverse = getReverse();
			int[] reverse = Reverse;

			if (_enhancedDOM != null)
			{
				return _enhancedDOM.getTypedChildren(reverse[type]);
			}
			else
			{
				return _dom.getTypedChildren(type);
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public org.apache.xml.dtm.DTMAxisIterator getNamespaceAxisIterator(final int axis, final int ns)
		public DTMAxisIterator getNamespaceAxisIterator(int axis, int ns)
		{
			return _dom.getNamespaceAxisIterator(axis, NSReverse[ns]);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public org.apache.xml.dtm.DTMAxisIterator getAxisIterator(final int axis)
		public DTMAxisIterator getAxisIterator(int axis)
		{
			if (_enhancedDOM != null)
			{
				return _enhancedDOM.getAxisIterator(axis);
			}
			else
			{
				return _dom.getAxisIterator(axis);
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public org.apache.xml.dtm.DTMAxisIterator getTypedAxisIterator(final int axis, final int type)
		public DTMAxisIterator getTypedAxisIterator(int axis, int type)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int[] reverse = getReverse();
			int[] reverse = Reverse;
			if (_enhancedDOM != null)
			{
				return _enhancedDOM.getTypedAxisIterator(axis, reverse[type]);
			}
			else
			{
				return _dom.getTypedAxisIterator(axis, type);
			}
		}

		public int MultiDOMMask
		{
			get
			{
			return _multiDOMMask;
			}
			set
			{
			_multiDOMMask = value;
			}
		}


		public DTMAxisIterator getNthDescendant(int type, int n, bool includeself)
		{
			return _dom.getNthDescendant(Reverse[type], n, includeself);
		}

		public DTMAxisIterator getNodeValueIterator(DTMAxisIterator iterator, int type, string value, bool op)
		{
			return _dom.getNodeValueIterator(iterator, type, value, op);
		}

		public DTMAxisIterator orderNodes(DTMAxisIterator source, int node)
		{
			return _dom.orderNodes(source, node);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public int getExpandedTypeID(final int node)
		public int getExpandedTypeID(int node)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final short[] mapping = getMapping();
			short[] mapping = Mapping;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int type;
			int type;
			if (_enhancedDOM != null)
			{
				type = mapping[_enhancedDOM.getExpandedTypeID2(node)];
			}
			else
			{
				if (null != mapping)
				{
					type = mapping[_dom.getExpandedTypeID(node)];
				}
				else
				{
					type = _dom.getExpandedTypeID(node);
				}
			}
			return type;
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public int getNamespaceType(final int node)
		public int getNamespaceType(int node)
		{
			return NSMapping[_dom.getNSType(node)];
		}

		public int getNSType(int node)
		{
		return _dom.getNSType(node);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public int getParent(final int node)
		public int getParent(int node)
		{
			return _dom.getParent(node);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public int getAttributeNode(final int type, final int element)
		public int getAttributeNode(int type, int element)
		{
		return _dom.getAttributeNode(Reverse[type], element);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public String getNodeName(final int node)
		public string getNodeName(int node)
		{
			if (node == org.apache.xml.dtm.DTM_Fields.NULL)
			{
				return "";
			}
			return _dom.getNodeName(node);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public String getNodeNameX(final int node)
		public string getNodeNameX(int node)
		{
			if (node == org.apache.xml.dtm.DTM_Fields.NULL)
			{
				return "";
			}
			return _dom.getNodeNameX(node);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public String getNamespaceName(final int node)
		public string getNamespaceName(int node)
		{
			if (node == org.apache.xml.dtm.DTM_Fields.NULL)
			{
				return "";
			}
			return _dom.getNamespaceName(node);
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public String getStringValueX(final int node)
		public string getStringValueX(int node)
		{
			if (_enhancedDOM != null)
			{
				return _enhancedDOM.getStringValueX(node);
			}
			else
			{
				if (node == org.apache.xml.dtm.DTM_Fields.NULL)
				{
					return "";
				}
				return _dom.getStringValueX(node);
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void copy(final int node, org.apache.xml.serializer.SerializationHandler handler) throws org.apache.xalan.xsltc.TransletException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
		public void copy(int node, SerializationHandler handler)
		{
			_dom.copy(node, handler);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void copy(org.apache.xml.dtm.DTMAxisIterator nodes,org.apache.xml.serializer.SerializationHandler handler) throws org.apache.xalan.xsltc.TransletException
		public void copy(DTMAxisIterator nodes, SerializationHandler handler)
		{
		_dom.copy(nodes, handler);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public String shallowCopy(final int node, org.apache.xml.serializer.SerializationHandler handler) throws org.apache.xalan.xsltc.TransletException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
		public string shallowCopy(int node, SerializationHandler handler)
		{
			if (_enhancedDOM != null)
			{
				return _enhancedDOM.shallowCopy(node, handler);
			}
			else
			{
				return _dom.shallowCopy(node, handler);
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public boolean lessThan(final int node1, final int node2)
		public bool lessThan(int node1, int node2)
		{
			return _dom.lessThan(node1, node2);
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void characters(final int textNode, org.apache.xml.serializer.SerializationHandler handler) throws org.apache.xalan.xsltc.TransletException
//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
		public void characters(int textNode, SerializationHandler handler)
		{
			if (_enhancedDOM != null)
			{
				_enhancedDOM.characters(textNode, handler);
			}
			else
			{
				_dom.characters(textNode, handler);
			}
		}

		public Node makeNode(int index)
		{
			return _dom.makeNode(index);
		}

		public Node makeNode(DTMAxisIterator iter)
		{
			return _dom.makeNode(iter);
		}

		public NodeList makeNodeList(int index)
		{
			return _dom.makeNodeList(index);
		}

		public NodeList makeNodeList(DTMAxisIterator iter)
		{
			return _dom.makeNodeList(iter);
		}

		public string getLanguage(int node)
		{
			return _dom.getLanguage(node);
		}

		public int Size
		{
			get
			{
				return _dom.Size;
			}
		}

		public string DocumentURI
		{
			set
			{
				if (_enhancedDOM != null)
				{
					_enhancedDOM.DocumentURI = value;
				}
			}
			get
			{
				if (_enhancedDOM != null)
				{
					return _enhancedDOM.DocumentURI;
				}
				else
				{
					return "";
				}
			}
		}


		public string getDocumentURI(int node)
		{
			return _dom.getDocumentURI(node);
		}

		public int Document
		{
			get
			{
				return _dom.Document;
			}
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public boolean isElement(final int node)
		public bool isElement(int node)
		{
			return (_dom.isElement(node));
		}

//JAVA TO C# CONVERTER WARNING: 'final' parameters are not available in .NET:
//ORIGINAL LINE: public boolean isAttribute(final int node)
		public bool isAttribute(int node)
		{
			return (_dom.isAttribute(node));
		}

		public int getNodeIdent(int nodeHandle)
		{
			return _dom.getNodeIdent(nodeHandle);
		}

		public int getNodeHandle(int nodeId)
		{
			return _dom.getNodeHandle(nodeId);
		}

		/// <summary>
		/// Return a instance of a DOM class to be used as an RTF
		/// </summary>
		public DOM getResultTreeFrag(int initSize, int rtfType)
		{
			if (_enhancedDOM != null)
			{
				return _enhancedDOM.getResultTreeFrag(initSize, rtfType);
			}
			else
			{
				return _dom.getResultTreeFrag(initSize, rtfType);
			}
		}

		/// <summary>
		/// Return a instance of a DOM class to be used as an RTF
		/// </summary>
		public DOM getResultTreeFrag(int initSize, int rtfType, bool addToManager)
		{
			if (_enhancedDOM != null)
			{
				return _enhancedDOM.getResultTreeFrag(initSize, rtfType, addToManager);
			}
			else
			{
			return _dom.getResultTreeFrag(initSize, rtfType, addToManager);
			}
		}


		/// <summary>
		/// Returns a SerializationHandler class wrapped in a SAX adapter.
		/// </summary>
		public SerializationHandler OutputDomBuilder
		{
			get
			{
				return _dom.OutputDomBuilder;
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public String lookupNamespace(int node, String prefix) throws org.apache.xalan.xsltc.TransletException
		public string lookupNamespace(int node, string prefix)
		{
		return _dom.lookupNamespace(node, prefix);
		}

		public string getUnparsedEntityURI(string entity)
		{
			return _dom.getUnparsedEntityURI(entity);
		}

		public Hashtable ElementsWithIDs
		{
			get
			{
				return _dom.ElementsWithIDs;
			}
		}
	}

}