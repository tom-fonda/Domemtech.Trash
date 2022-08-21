﻿/// <summary>
///*****************************************************************************
/// Copyright (c) 2005, 2009 Andrea Bittau, University College London, and others
/// All rights reserved. This program and the accompanying materials
/// are made available under the terms of the Eclipse Public License 2.0
/// which accompanies this distribution, and is available at
/// https://www.eclipse.org/legal/epl-2.0/
/// 
/// SPDX-License-Identifier: EPL-2.0
/// 
/// Contributors:
///     Andrea Bittau - initial API and implementation from the PsychoPath XPath 2.0 
/// ******************************************************************************
/// </summary>

namespace org.eclipse.wst.xml.xpath2.processor.@internal
{

	/// <summary>
	/// Error caused by static element name.
	/// </summary>
	public class StaticElemNameError : StaticNameError
	{

		/// 
		private const long serialVersionUID = 1871575671871755673L;

		/// <summary>
		/// Constructor for static element name error
		/// </summary>
		/// <param name="reason">
		///            is the reason for the error. </param>
		public StaticElemNameError(string reason) : base(reason)
		{
		}
	}

}