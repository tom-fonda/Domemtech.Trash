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
 * $Id: XResources_ja_JP_HI.java 468655 2006-10-28 07:12:06Z minchau $
 */
namespace org.apache.xml.utils.res
{

	//
	//  LangResources_en.properties
	//

	/// <summary>
	/// The Japanese (Hiragana) resource bundle.
	/// @xsl.usage internal
	/// </summary>
	public class XResources_ja_JP_HI : XResourceBundle
	{

	  /// <summary>
	  /// Get the association table for this resource.
	  /// 
	  /// </summary>
	  /// <returns> the association table for this resource. </returns>
	  public override object[][] Contents
	  {
		  get
		  {
			return new object[][]
			{
				new object[] {"ui_language", "ja"},
				new object[] {"help_language", "ja"},
				new object[] {"language", "ja"},
				new object[] {"alphabet", new CharArrayWrapper(new char[]{0x3044, 0x308d, 0x306f, 0x306b, 0x307b, 0x3078, 0x3068, 0x3061, 0x308a, 0x306c, 0x308b, 0x3092, 0x308f, 0x304b, 0x3088, 0x305f, 0x308c, 0x305d, 0x3064, 0x306d, 0x306a, 0x3089, 0x3080, 0x3046, 0x3090, 0x306e, 0x304a, 0x304f, 0x3084, 0x307e, 0x3051, 0x3075, 0x3053, 0x3048, 0x3066, 0x3042, 0x3055, 0x304d, 0x3086, 0x3081, 0x307f, 0x3057, 0x3091, 0x3072, 0x3082, 0x305b, 0x3059})},
				new object[] {"tradAlphabet", new CharArrayWrapper(new char[]{'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'})},
				new object[] {"orientation", "LeftToRight"},
				new object[] {"numbering", "multiplicative-additive"},
				new object[] {"multiplierOrder", "follows"},
				new object[] {"numberGroups", new IntArrayWrapper(new int[]{1})},
				new object[] {"multiplier", new LongArrayWrapper(new long[]{long.MaxValue, long.MaxValue, 100000000, 10000, 1000, 100, 10})},
				new object[] {"multiplierChar", new CharArrayWrapper(new char[]{0x4EAC, 0x5146, 0x5104, 0x4E07, 0x5343, 0x767e, 0x5341})},
				new object[] {"zero", new CharArrayWrapper(new char[0])},
				new object[] {"digits", new CharArrayWrapper(new char[]{0x4E00, 0x4E8C, 0x4E09, 0x56DB, 0x4E94, 0x516D, 0x4E03, 0x516B, 0x4E5D})},
				new object[] {"tables", new StringArrayWrapper(new string[]{"digits"})}
			};
		  }
	  }
	}

}