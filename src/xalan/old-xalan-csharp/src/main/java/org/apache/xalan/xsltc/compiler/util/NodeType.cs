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
 * $Id: NodeType.java 468649 2006-10-28 07:00:55Z minchau $
 */

namespace org.apache.xalan.xsltc.compiler.util
{

	using BranchHandle = org.apache.bcel.generic.BranchHandle;
	using CHECKCAST = org.apache.bcel.generic.CHECKCAST;
	using ConstantPoolGen = org.apache.bcel.generic.ConstantPoolGen;
	using GETFIELD = org.apache.bcel.generic.GETFIELD;
	using GOTO = org.apache.bcel.generic.GOTO;
	using IFEQ = org.apache.bcel.generic.IFEQ;
	using ILOAD = org.apache.bcel.generic.ILOAD;
	using INVOKEINTERFACE = org.apache.bcel.generic.INVOKEINTERFACE;
	using INVOKESPECIAL = org.apache.bcel.generic.INVOKESPECIAL;
	using ISTORE = org.apache.bcel.generic.ISTORE;
	using Instruction = org.apache.bcel.generic.Instruction;
	using InstructionList = org.apache.bcel.generic.InstructionList;
	using NEW = org.apache.bcel.generic.NEW;
	using PUSH = org.apache.bcel.generic.PUSH;

	/// <summary>
	/// @author Jacek Ambroziak
	/// @author Santiago Pericas-Geertsen
	/// </summary>
	public sealed class NodeType : Type
	{
		private readonly int _type;

		protected internal NodeType() : this(org.apache.xalan.xsltc.compiler.NodeTest_Fields.ANODE)
		{
		}

		protected internal NodeType(int type)
		{
		_type = type;
		}

		public int Type
		{
			get
			{
			return _type;
			}
		}

		public override String ToString()
		{
		return "node-type";
		}

		public override bool identicalTo(Type other)
		{
		return other is NodeType;
		}

		public override int GetHashCode()
		{
		return _type;
		}

		public override String toSignature()
		{
		return "I";
		}

		public override org.apache.bcel.generic.Type toJCType()
		{
		return org.apache.bcel.generic.Type.INT;
		}

		/// <summary>
		/// Translates a node into an object of internal type <code>type</code>.
		/// The translation to int is undefined since nodes are always converted
		/// to reals in arithmetic expressions.
		/// 
		/// @see	org.apache.xalan.xsltc.compiler.util.Type#translateTo
		/// </summary>
		public override void translateTo(ClassGenerator classGen, MethodGenerator methodGen, Type type)
		{
		if (type == Type.String)
		{
			translateTo(classGen, methodGen, (StringType) type);
		}
		else if (type == Type.Boolean)
		{
			translateTo(classGen, methodGen, (BooleanType) type);
		}
		else if (type == Type.Real)
		{
			translateTo(classGen, methodGen, (RealType) type);
		}
		else if (type == Type.NodeSet)
		{
			translateTo(classGen, methodGen, (NodeSetType) type);
		}
		else if (type == Type.Reference)
		{
			translateTo(classGen, methodGen, (ReferenceType) type);
		}
		else if (type == Type.Object)
		{
			translateTo(classGen, methodGen, (ObjectType) type);
		}
		else
		{
			ErrorMsg err = new ErrorMsg(ErrorMsg.DATA_CONVERSION_ERR, ToString(), type.ToString());
			classGen.Parser.reportError(org.apache.xalan.xsltc.compiler.Constants_Fields.FATAL, err);
		}
		}

		/// <summary>
		/// Expects a node on the stack and pushes its string value. 
		/// 
		/// @see	org.apache.xalan.xsltc.compiler.util.Type#translateTo
		/// </summary>
		public void translateTo(ClassGenerator classGen, MethodGenerator methodGen, StringType type)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.ConstantPoolGen cpg = classGen.getConstantPool();
		ConstantPoolGen cpg = classGen.ConstantPool;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.InstructionList il = methodGen.getInstructionList();
		InstructionList il = methodGen.InstructionList;

		switch (_type)
		{
		case org.apache.xalan.xsltc.compiler.NodeTest_Fields.ROOT:
		case org.apache.xalan.xsltc.compiler.NodeTest_Fields.ELEMENT:
			il.append(methodGen.loadDOM());
			il.append(SWAP); // dom ref must be below node index
			int index = cpg.addInterfaceMethodref(org.apache.xalan.xsltc.compiler.Constants_Fields.DOM_INTF, org.apache.xalan.xsltc.compiler.Constants_Fields.GET_ELEMENT_VALUE, org.apache.xalan.xsltc.compiler.Constants_Fields.GET_ELEMENT_VALUE_SIG);
			il.append(new INVOKEINTERFACE(index, 2));
			break;

		case org.apache.xalan.xsltc.compiler.NodeTest_Fields.ANODE:
		case org.apache.xalan.xsltc.compiler.NodeTest_Fields.COMMENT:
		case org.apache.xalan.xsltc.compiler.NodeTest_Fields.ATTRIBUTE:
		case org.apache.xalan.xsltc.compiler.NodeTest_Fields.PI:
			il.append(methodGen.loadDOM());
			il.append(SWAP); // dom ref must be below node index
			index = cpg.addInterfaceMethodref(org.apache.xalan.xsltc.compiler.Constants_Fields.DOM_INTF, org.apache.xalan.xsltc.compiler.Constants_Fields.GET_NODE_VALUE, org.apache.xalan.xsltc.compiler.Constants_Fields.GET_NODE_VALUE_SIG);
			il.append(new INVOKEINTERFACE(index, 2));
			break;

		default:
			ErrorMsg err = new ErrorMsg(ErrorMsg.DATA_CONVERSION_ERR, ToString(), type.ToString());
			classGen.Parser.reportError(org.apache.xalan.xsltc.compiler.Constants_Fields.FATAL, err);
			break;
		}
		}

		/// <summary>
		/// Translates a node into a synthesized boolean.
		/// If the expression is "@attr", 
		/// then "true" is pushed iff "attr" is an attribute of the current node.
		/// If the expression is ".", the result is always "true".	
		/// 
		/// @see	org.apache.xalan.xsltc.compiler.util.Type#translateTo
		/// </summary>
		public void translateTo(ClassGenerator classGen, MethodGenerator methodGen, BooleanType type)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.InstructionList il = methodGen.getInstructionList();
		InstructionList il = methodGen.InstructionList;
		FlowList falsel = translateToDesynthesized(classGen, methodGen, type);
		il.append(ICONST_1);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.BranchHandle truec = il.append(new org.apache.bcel.generic.GOTO(null));
		BranchHandle truec = il.append(new GOTO(null));
		falsel.backPatch(il.append(ICONST_0));
		truec.Target = il.append(NOP);
		}

		/// <summary>
		/// Expects a node on the stack and pushes a real.
		/// First the node is converted to string, and from string to real.
		/// 
		/// @see	org.apache.xalan.xsltc.compiler.util.Type#translateTo
		/// </summary>
		public void translateTo(ClassGenerator classGen, MethodGenerator methodGen, RealType type)
		{
		translateTo(classGen, methodGen, Type.String);
		Type.String.translateTo(classGen, methodGen, Type.Real);
		}

		/// <summary>
		/// Expects a node on the stack and pushes a singleton node-set. Singleton
		/// iterators are already started after construction.
		/// 
		/// @see	org.apache.xalan.xsltc.compiler.util.Type#translateTo
		/// </summary>
		public void translateTo(ClassGenerator classGen, MethodGenerator methodGen, NodeSetType type)
		{
		ConstantPoolGen cpg = classGen.ConstantPool;
		InstructionList il = methodGen.InstructionList;

		// Create a new instance of SingletonIterator
		il.append(new NEW(cpg.addClass(org.apache.xalan.xsltc.compiler.Constants_Fields.SINGLETON_ITERATOR)));
		il.append(DUP_X1);
		il.append(SWAP);
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int init = cpg.addMethodref(org.apache.xalan.xsltc.compiler.Constants_Fields.SINGLETON_ITERATOR, "<init>", "(" + org.apache.xalan.xsltc.compiler.Constants_Fields.NODE_SIG +")V");
		int init = cpg.addMethodref(org.apache.xalan.xsltc.compiler.Constants_Fields.SINGLETON_ITERATOR, "<init>", "(" + org.apache.xalan.xsltc.compiler.Constants_Fields.NODE_SIG + ")V");
		il.append(new INVOKESPECIAL(init));
		}

		/// <summary>
		/// Subsume Node into ObjectType.
		/// 
		/// @see	org.apache.xalan.xsltc.compiler.util.Type#translateTo
		/// </summary>
		public void translateTo(ClassGenerator classGen, MethodGenerator methodGen, ObjectType type)
		{
			methodGen.InstructionList.append(NOP);
		}

		/// <summary>
		/// Translates a node into a non-synthesized boolean. It does not push a 
		/// 0 or a 1 but instead returns branchhandle list to be appended to the 
		/// false list.
		/// 
		/// @see	org.apache.xalan.xsltc.compiler.util.Type#translateToDesynthesized
		/// </summary>
		public override FlowList translateToDesynthesized(ClassGenerator classGen, MethodGenerator methodGen, BooleanType type)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.InstructionList il = methodGen.getInstructionList();
		InstructionList il = methodGen.InstructionList;
		return new FlowList(il.append(new IFEQ(null)));
		}

		/// <summary>
		/// Expects a node on the stack and pushes a boxed node. Boxed nodes
		/// are represented by an instance of <code>org.apache.xalan.xsltc.dom.Node</code>.
		/// 
		/// @see	org.apache.xalan.xsltc.compiler.util.Type#translateTo
		/// </summary>
		public void translateTo(ClassGenerator classGen, MethodGenerator methodGen, ReferenceType type)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.ConstantPoolGen cpg = classGen.getConstantPool();
		ConstantPoolGen cpg = classGen.ConstantPool;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.InstructionList il = methodGen.getInstructionList();
		InstructionList il = methodGen.InstructionList;
		il.append(new NEW(cpg.addClass(org.apache.xalan.xsltc.compiler.Constants_Fields.RUNTIME_NODE_CLASS)));
		il.append(DUP_X1);
		il.append(SWAP);
		il.append(new PUSH(cpg, _type));
		il.append(new INVOKESPECIAL(cpg.addMethodref(org.apache.xalan.xsltc.compiler.Constants_Fields.RUNTIME_NODE_CLASS, "<init>", "(II)V")));
		}

		/// <summary>
		/// Translates a node into the Java type denoted by <code>clazz</code>. 
		/// Expects a node on the stack and pushes an object of the appropriate
		/// type after coercion.
		/// </summary>
		public override void translateTo(ClassGenerator classGen, MethodGenerator methodGen, Type clazz)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.ConstantPoolGen cpg = classGen.getConstantPool();
		ConstantPoolGen cpg = classGen.ConstantPool;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.InstructionList il = methodGen.getInstructionList();
		InstructionList il = methodGen.InstructionList;

			string className = clazz.Name;
			if (className.Equals("java.lang.String"))
			{
			   translateTo(classGen, methodGen, Type.String);
			   return;
			}

		il.append(methodGen.loadDOM());
		il.append(SWAP); // dom ref must be below node index

			if (className.Equals("org.w3c.dom.Node") || className.Equals("java.lang.Object"))
			{
			int index = cpg.addInterfaceMethodref(org.apache.xalan.xsltc.compiler.Constants_Fields.DOM_INTF, org.apache.xalan.xsltc.compiler.Constants_Fields.MAKE_NODE, org.apache.xalan.xsltc.compiler.Constants_Fields.MAKE_NODE_SIG);
			il.append(new INVOKEINTERFACE(index, 2));
			}
		else if (className.Equals("org.w3c.dom.NodeList"))
		{
			int index = cpg.addInterfaceMethodref(org.apache.xalan.xsltc.compiler.Constants_Fields.DOM_INTF, org.apache.xalan.xsltc.compiler.Constants_Fields.MAKE_NODE_LIST, org.apache.xalan.xsltc.compiler.Constants_Fields.MAKE_NODE_LIST_SIG);
			il.append(new INVOKEINTERFACE(index, 2));
		}
		else
		{
			ErrorMsg err = new ErrorMsg(ErrorMsg.DATA_CONVERSION_ERR, ToString(), className);
			classGen.Parser.reportError(org.apache.xalan.xsltc.compiler.Constants_Fields.FATAL, err);
		}
		}

		/// <summary>
		/// Translates an object of this type to its boxed representation.
		/// </summary>
		public override void translateBox(ClassGenerator classGen, MethodGenerator methodGen)
		{
		translateTo(classGen, methodGen, Type.Reference);
		}

		/// <summary>
		/// Translates an object of this type to its unboxed representation.
		/// </summary>
		public override void translateUnBox(ClassGenerator classGen, MethodGenerator methodGen)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.ConstantPoolGen cpg = classGen.getConstantPool();
		ConstantPoolGen cpg = classGen.ConstantPool;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.InstructionList il = methodGen.getInstructionList();
		InstructionList il = methodGen.InstructionList;
		il.append(new CHECKCAST(cpg.addClass(org.apache.xalan.xsltc.compiler.Constants_Fields.RUNTIME_NODE_CLASS)));
		il.append(new GETFIELD(cpg.addFieldref(org.apache.xalan.xsltc.compiler.Constants_Fields.RUNTIME_NODE_CLASS, org.apache.xalan.xsltc.compiler.Constants_Fields.NODE_FIELD, org.apache.xalan.xsltc.compiler.Constants_Fields.NODE_FIELD_SIG)));
		}

		/// <summary>
		/// Returns the class name of an internal type's external representation.
		/// </summary>
		public override String ClassName
		{
			get
			{
			return (org.apache.xalan.xsltc.compiler.Constants_Fields.RUNTIME_NODE_CLASS);
			}
		}

		public override Instruction LOAD(int slot)
		{
		return new ILOAD(slot);
		}

		public override Instruction STORE(int slot)
		{
		return new ISTORE(slot);
		}
	}


}