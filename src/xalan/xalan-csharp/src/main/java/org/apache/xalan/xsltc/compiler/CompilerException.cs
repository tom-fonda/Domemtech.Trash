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
 * $Id: CompilerException.java 468650 2006-10-28 07:03:30Z minchau $
 */

namespace org.apache.xalan.xsltc.compiler
{
	/// <summary>
	/// @author Morten Jorgensen
	/// </summary>
	public sealed class CompilerException : Exception
	{
		internal const long serialVersionUID = 1732939618562742663L;

		private string _msg;

		public CompilerException() : base()
		{
		}

		public CompilerException(Exception e) : base(e.ToString())
		{
		_msg = e.ToString();
		}

		public CompilerException(string message) : base(message)
		{
		_msg = message;
		}

		public string Message
		{
			get
			{
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final int col = _msg.indexOf(':');
			int col = _msg.IndexOf(':');
    
			if (col > -1)
			{
				return (_msg.Substring(col));
			}
			else
			{
				return (_msg);
			}
			}
		}
	}

}