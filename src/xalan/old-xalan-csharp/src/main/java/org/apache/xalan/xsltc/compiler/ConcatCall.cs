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
 * $Id: ConcatCall.java 468650 2006-10-28 07:03:30Z minchau $
 */

namespace org.apache.xalan.xsltc.compiler
{

	using ConstantPoolGen = org.apache.bcel.generic.ConstantPoolGen;
	using INVOKESPECIAL = org.apache.bcel.generic.INVOKESPECIAL;
	using INVOKEVIRTUAL = org.apache.bcel.generic.INVOKEVIRTUAL;
	using Instruction = org.apache.bcel.generic.Instruction;
	using InstructionList = org.apache.bcel.generic.InstructionList;
	using NEW = org.apache.bcel.generic.NEW;
	using PUSH = org.apache.bcel.generic.PUSH;
	using ClassGenerator = org.apache.xalan.xsltc.compiler.util.ClassGenerator;
	using MethodGenerator = org.apache.xalan.xsltc.compiler.util.MethodGenerator;
	using Type = org.apache.xalan.xsltc.compiler.util.Type;
	using TypeCheckError = org.apache.xalan.xsltc.compiler.util.TypeCheckError;

	/// <summary>
	/// @author Jacek Ambroziak
	/// @author Santiago Pericas-Geertsen
	/// </summary>
	internal sealed class ConcatCall : FunctionCall
	{
		public ConcatCall(QName fname, ArrayList arguments) : base(fname, arguments)
		{
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public org.apache.xalan.xsltc.compiler.util.Type typeCheck(SymbolTable stable) throws org.apache.xalan.xsltc.compiler.util.TypeCheckError
		public override Type typeCheck(SymbolTable stable)
		{
		for (int i = 0; i < argumentCount(); i++)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Expression exp = argument(i);
			Expression exp = argument(i);
			if (!exp.typeCheck(stable).identicalTo(Type.String))
			{
			setArgument(i, new CastExpr(exp, Type.String));
			}
		}
		return _type = Type.String;
		}

		/// <summary>
		/// translate leaves a String on the stack </summary>
		public override void translate(ClassGenerator classGen, MethodGenerator methodGen)
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.ConstantPoolGen cpg = classGen.getConstantPool();
		ConstantPoolGen cpg = classGen.ConstantPool;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.InstructionList il = methodGen.getInstructionList();
		InstructionList il = methodGen.InstructionList;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int nArgs = argumentCount();
		int nArgs = argumentCount();

		switch (nArgs)
		{
		case 0:
			il.append(new PUSH(cpg, Constants_Fields.EMPTYSTRING));
			break;

		case 1:
			argument().translate(classGen, methodGen);
			break;

		default:
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int initBuffer = cpg.addMethodref(Constants_Fields.STRING_BUFFER_CLASS, "<init>", "()V");
			int initBuffer = cpg.addMethodref(Constants_Fields.STRING_BUFFER_CLASS, "<init>", "()V");
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.Instruction append = new org.apache.bcel.generic.INVOKEVIRTUAL(cpg.addMethodref(Constants_Fields.STRING_BUFFER_CLASS, "append", "("+Constants_Fields.STRING_SIG+")" +Constants_Fields.STRING_BUFFER_SIG));
			Instruction append = new INVOKEVIRTUAL(cpg.addMethodref(Constants_Fields.STRING_BUFFER_CLASS, "append", "(" + Constants_Fields.STRING_SIG + ")" + Constants_Fields.STRING_BUFFER_SIG));

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int toString = cpg.addMethodref(Constants_Fields.STRING_BUFFER_CLASS, "toString", "()"+Constants_Fields.STRING_SIG);
			int toString = cpg.addMethodref(Constants_Fields.STRING_BUFFER_CLASS, "toString", "()" + Constants_Fields.STRING_SIG);

			il.append(new NEW(cpg.addClass(Constants_Fields.STRING_BUFFER_CLASS)));
			il.append(DUP);
			il.append(new INVOKESPECIAL(initBuffer));
			for (int i = 0; i < nArgs; i++)
			{
			argument(i).translate(classGen, methodGen);
			il.append(append);
			}
			il.append(new INVOKEVIRTUAL(toString));
		break;
		}
		}
	}

}