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
 * $Id: InternalError.java 1225426 2011-12-29 04:13:08Z mrglavas $
 */

namespace org.apache.xalan.xsltc.compiler.util
{

	/// <summary>
	/// Marks a class of errors in which XSLTC has reached some incorrect internal
	/// state from which it cannot recover.
	/// </summary>
	public class InternalError : Exception
	{
		/// <summary>
		/// Construct an <code>InternalError</code> with the specified error message. </summary>
		/// <param name="msg"> the error message </param>
		public InternalError(string msg) : base(msg)
		{
		}
	}

}