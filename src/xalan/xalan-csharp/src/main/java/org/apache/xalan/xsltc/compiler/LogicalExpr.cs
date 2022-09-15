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
 * $Id: LogicalExpr.java 468650 2006-10-28 07:03:30Z minchau $
 */

namespace org.apache.xalan.xsltc.compiler
{
	using GOTO = org.apache.bcel.generic.GOTO;
	using InstructionHandle = org.apache.bcel.generic.InstructionHandle;
	using InstructionList = org.apache.bcel.generic.InstructionList;
	using ClassGenerator = org.apache.xalan.xsltc.compiler.util.ClassGenerator;
	using MethodGenerator = org.apache.xalan.xsltc.compiler.util.MethodGenerator;
	using MethodType = org.apache.xalan.xsltc.compiler.util.MethodType;
	using Type = org.apache.xalan.xsltc.compiler.util.Type;
	using TypeCheckError = org.apache.xalan.xsltc.compiler.util.TypeCheckError;

	/// <summary>
	/// @author Jacek Ambroziak
	/// @author Santiago Pericas-Geertsen
	/// @author Morten Jorgensen
	/// </summary>
	internal sealed class LogicalExpr : Expression
	{

		public const int OR = 0;
		public const int AND = 1;

		private readonly int _op; // operator
		private Expression _left; // first operand
		private Expression _right; // second operand

		private static readonly string[] Ops = new string[] {"or", "and"};

		/// <summary>
		/// Creates a new logical expression - either OR or AND. Note that the
		/// left- and right-hand side expressions can also be logical expressions,
		/// thus creating logical trees representing structures such as
		/// (a and (b or c) and d), etc...
		/// </summary>
		public LogicalExpr(int op, Expression left, Expression right)
		{
		_op = op;
		(_left = left).setParent(this);
		(_right = right).setParent(this);
		}

		/// <summary>
		/// Returns true if this expressions contains a call to position(). This is
		/// needed for context changes in node steps containing multiple predicates.
		/// </summary>
		public override bool hasPositionCall()
		{
		return (_left.hasPositionCall() || _right.hasPositionCall());
		}

		/// <summary>
		/// Returns true if this expressions contains a call to last()
		/// </summary>
		public override bool hasLastCall()
		{
				return (_left.hasLastCall() || _right.hasLastCall());
		}

		/// <summary>
		/// Returns an object representing the compile-time evaluation 
		/// of an expression. We are only using this for function-available
		/// and element-available at this time.
		/// </summary>
		public override object evaluateAtCompileTime()
		{
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Object leftb = _left.evaluateAtCompileTime();
		object leftb = _left.evaluateAtCompileTime();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final Object rightb = _right.evaluateAtCompileTime();
		object rightb = _right.evaluateAtCompileTime();

		// Return null if we can't evaluate at compile time
		if (leftb == null || rightb == null)
		{
			return null;
		}

		if (_op == AND)
		{
			return (leftb == true && rightb == true) ? true : false;
		}
		else
		{
			return (leftb == true || rightb == true) ? true : false;
		}
		}

		/// <summary>
		/// Returns this logical expression's operator - OR or AND represented
		/// by 0 and 1 respectively.
		/// </summary>
		public int Op
		{
			get
			{
			return (_op);
			}
		}

		/// <summary>
		/// Override the SyntaxTreeNode.setParser() method to make sure that the
		/// parser is set for sub-expressions
		/// </summary>
		public override Parser Parser
		{
			set
			{
			base.Parser = value;
			_left.Parser = value;
			_right.Parser = value;
			}
		}

		/// <summary>
		/// Returns a string describing this expression
		/// </summary>
		public override string ToString()
		{
		return Ops[_op] + '(' + _left + ", " + _right + ')';
		}

		/// <summary>
		/// Type-check this expression, and possibly child expressions.
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public org.apache.xalan.xsltc.compiler.util.Type typeCheck(SymbolTable stable) throws org.apache.xalan.xsltc.compiler.util.TypeCheckError
		public override Type typeCheck(SymbolTable stable)
		{
		// Get the left and right operand types
		Type tleft = _left.typeCheck(stable);
		Type tright = _right.typeCheck(stable);

		// Check if the operator supports the two operand types
		MethodType wantType = new MethodType(Type.Void, tleft, tright);
		MethodType haveType = lookupPrimop(stable, Ops[_op], wantType);

		// Yes, the operation is supported
		if (haveType != null)
		{
			// Check if left-hand side operand must be type casted
			Type arg1 = (Type)haveType.argsType()[0];
			if (!arg1.identicalTo(tleft))
			{
			_left = new CastExpr(_left, arg1);
			}
			// Check if right-hand side operand must be type casted
			Type arg2 = (Type) haveType.argsType()[1];
			if (!arg2.identicalTo(tright))
			{
			_right = new CastExpr(_right, arg1);
			}
			// Return the result type for the operator we will use
			return _type = haveType.resultType();
		}
		throw new TypeCheckError(this);
		}

		/// <summary>
		/// Compile the expression - leave boolean expression on stack
		/// </summary>
		public override void translate(ClassGenerator classGen, MethodGenerator methodGen)
		{
		translateDesynthesized(classGen, methodGen);
		synthesize(classGen, methodGen);
		}

		/// <summary>
		/// Compile expression and update true/false-lists
		/// </summary>
		public override void translateDesynthesized(ClassGenerator classGen, MethodGenerator methodGen)
		{

//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final org.apache.bcel.generic.InstructionList il = methodGen.getInstructionList();
		InstructionList il = methodGen.getInstructionList();
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final SyntaxTreeNode parent = getParent();
		SyntaxTreeNode parent = Parent;

		// Compile AND-expression
		if (_op == AND)
		{

			// Translate left hand side - must be true
			_left.translateDesynthesized(classGen, methodGen);

			// Need this for chaining any OR-expression children
			InstructionHandle middle = il.append(NOP);

			// Translate left right side - must be true
			_right.translateDesynthesized(classGen, methodGen);

			// Need this for chaining any OR-expression children
			InstructionHandle after = il.append(NOP);

			// Append child expression false-lists to our false-list
			_falseList.append(_right._falseList.append(_left._falseList));

			// Special case for OR-expression as a left child of AND.
			// The true-list of OR must point to second clause of AND.
			if ((_left is LogicalExpr) && (((LogicalExpr)_left).Op == OR))
			{
			_left.backPatchTrueList(middle);
			}
			else if (_left is NotCall)
			{
			_left.backPatchTrueList(middle);
			}
			else
			{
			_trueList.append(_left._trueList);
			}

			// Special case for OR-expression as a right child of AND
			// The true-list of OR must point to true-list of AND.
			if ((_right is LogicalExpr) && (((LogicalExpr)_right).Op == OR))
			{
			_right.backPatchTrueList(after);
			}
			else if (_right is NotCall)
			{
			_right.backPatchTrueList(after);
			}
			else
			{
			_trueList.append(_right._trueList);
			}
		}
		// Compile OR-expression
		else
		{
			// Translate left-hand side expression and produce true/false list
			_left.translateDesynthesized(classGen, methodGen);

			// This GOTO is used to skip over the code for the last test
			// in the case where the the first test succeeds
			InstructionHandle ih = il.append(new GOTO(null));

			// Translate right-hand side expression and produce true/false list
			_right.translateDesynthesized(classGen, methodGen);

			_left._trueList.backPatch(ih);
			_left._falseList.backPatch(ih.getNext());

			_falseList.append(_right._falseList);
			_trueList.add(ih).append(_right._trueList);
		}
		}
	}

}