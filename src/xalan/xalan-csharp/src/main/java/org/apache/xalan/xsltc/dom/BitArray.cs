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
 * $Id: BitArray.java 478667 2006-11-23 20:50:36Z minchau $
 */

namespace org.apache.xalan.xsltc.dom
{

	using DTMAxisIterator = org.apache.xml.dtm.DTMAxisIterator;


	/// <summary>
	/// @author Morten Jorgensen
	/// </summary>
	public class BitArray : Externalizable
	{
		internal const long serialVersionUID = -4876019880708377663L;

		private int[] _bits;
		private int _bitSize;
		private int _intSize;
		private int _mask;

		// This table is used to prevent expensive shift operations
		// (These operations are inexpensive on CPUs but very expensive on JVMs.)
		private static readonly int[] _masks = new int[] {unchecked((int)0x80000000), 0x40000000, 0x20000000, 0x10000000, 0x08000000, 0x04000000, 0x02000000, 0x01000000, 0x00800000, 0x00400000, 0x00200000, 0x00100000, 0x00080000, 0x00040000, 0x00020000, 0x00010000, 0x00008000, 0x00004000, 0x00002000, 0x00001000, 0x00000800, 0x00000400, 0x00000200, 0x00000100, 0x00000080, 0x00000040, 0x00000020, 0x00000010, 0x00000008, 0x00000004, 0x00000002, 0x00000001};

		private const bool DEBUG_ASSERTIONS = false;

		/// <summary>
		/// Constructor. Defines the initial size of the bit array (in bits).
		/// </summary>
		public BitArray() : this(32)
		{
		}

		public BitArray(int size)
		{
			if (size < 32)
			{
				size = 32;
			}
			_bitSize = size;
			_intSize = ((int)((uint)_bitSize >> 5)) + 1;
			_bits = new int[_intSize + 1];
		}

		public BitArray(int size, int[] bits)
		{
		if (size < 32)
		{
			size = 32;
		}
		_bitSize = size;
		_intSize = ((int)((uint)_bitSize >> 5)) + 1;
		_bits = bits;
		}

		/// <summary>
		/// Set the mask for this bit array. The upper 8 bits of this mask
		/// indicate the DOM in which the nodes in this array belong.
		/// </summary>
		public virtual int Mask
		{
			set
			{
			_mask = value;
			}
			get
			{
			return (_mask);
			}
		}


		/// <summary>
		/// Returns the size of this bit array (in bits).
		/// </summary>
		public int size()
		{
		return (_bitSize);
		}

		/// <summary>
		/// Returns true if the given bit is set
		/// </summary>
		public bool getBit(int bit)
		{
			if (DEBUG_ASSERTIONS)
			{
				if (bit >= _bitSize)
				{
					throw new Exception("Programmer's assertion in  BitArray.getBit");
				}
			}

			return ((_bits[(int)((uint)bit >> 5)] & _masks[bit % 32]) != 0);
		}

		/// <summary>
		/// Returns the next set bit from a given position
		/// </summary>
		public int getNextBit(int startBit)
		{
			for (int i = ((int)((uint)startBit >> 5)) ; i <= _intSize; i++)
			{
				int bits = _bits[i];
				if (bits != 0)
				{
					for (int b = (startBit % 32); b < 32; b++)
					{
						if ((bits & _masks[b]) != 0)
						{
							return ((i << 5) + b);
						}
					}
				}
				startBit = 0;
			}
			return (DTMAxisIterator.END);
		}

		/// <summary>
		/// This method returns the Nth bit that is set in the bit array. The
		/// current position is cached in the following 4 variables and will
		/// help speed up a sequence of next() call in an index iterator. This
		/// method is a mess, but it is fast and it works, so don't change it.
		/// </summary>
		private int _pos = int.MaxValue;
		private int _node = 0;
		private int _int = 0;
		private int _bit = 0;

		public int getBitNumber(int pos)
		{

		// Return last node if position we're looking for is the same
		if (pos == _pos)
		{
			return (_node);
		}

		// Start from beginning of position we're looking for is before
		// the point where we left off the last time.
		if (pos < _pos)
		{
			_int = _bit = _pos = 0;
		}

		// Scan through the bit array - skip integers that have no bits set
		for (; _int <= _intSize; _int++)
		{
			int bits = _bits[_int];
			if (bits != 0)
			{ // Any bits set?
			for (; _bit < 32; _bit++)
			{
				if ((bits & _masks[_bit]) != 0)
				{
				if (++_pos == pos)
				{
					_node = ((_int << 5) + _bit) - 1;
					return (_node);
				}
				}
			}
			_bit = 0;
			}
		}
		return (0);
		}

		/// <summary>
		/// Returns the integer array in which the bit array is contained
		/// </summary>
		public int[] data()
		{
		return (_bits);
		}

		internal int _first = int.MaxValue; // The index where first set bit is
		internal int _last = int.MinValue; // The _INTEGER INDEX_ where last set bit is

		/// <summary>
		/// Sets a given bit
		/// </summary>
		public int Bit
		{
			set
			{
				if (DEBUG_ASSERTIONS)
				{
					if (value >= _bitSize)
					{
						throw new Exception("Programmer's assertion in  BitArray.getBit");
					}
				}
    
				if (value >= _bitSize)
				{
					return;
				}
	//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
	//ORIGINAL LINE: final int i = (value >>> 5);
				int i = ((int)((uint)value >> 5));
				if (i < _first)
				{
					_first = i;
				}
				if (i > _last)
				{
					_last = i;
				}
				_bits[i] |= _masks[value % 32];
			}
		}

		/// <summary>
		/// Merge two bit arrays. This currently only works for nodes from
		/// a single DOM (because there is only one _mask per array).
		/// </summary>
		public BitArray merge(BitArray other)
		{
		// Take other array's bits if we have node set
		if (_last == -1)
		{
			_bits = other._bits;
		}
		// Only merge if other array has any bits set
		else if (other._last != -1)
		{
			int start = (_first < other._first) ? _first : other._first;
			int stop = (_last > other._last) ? _last : other._last;

			// Merge these bits into other array if other array is larger
			if (other._intSize > _intSize)
			{
			if (stop > _intSize)
			{
				stop = _intSize;
			}
			for (int i = start; i <= stop; i++)
			{
				other._bits[i] |= _bits[i];
			}
			_bits = other._bits;
			}
			// Merge other bits into this array if this arrai is large/equal.
			else
			{
			if (stop > other._intSize)
			{
				stop = other._intSize;
			}
			for (int i = start; i <= stop; i++)
			{
				_bits[i] |= other._bits[i];
			}
			}
		}
		return (this);
		}

		/// <summary>
		/// Resizes the bit array - try to avoid using this method!!!
		/// </summary>
		public void resize(int newSize)
		{
		if (newSize > _bitSize)
		{
			_intSize = ((int)((uint)newSize >> 5)) + 1;
//JAVA TO C# CONVERTER WARNING: The original Java variable was marked 'final':
//ORIGINAL LINE: final int[] newBits = new int[_intSize + 1];
			int[] newBits = new int[_intSize + 1];
			Array.Copy(_bits, 0, newBits, 0, ((int)((uint)_bitSize >> 5)) + 1);
			_bits = newBits;
			_bitSize = newSize;
		}
		}

		public virtual BitArray cloneArray()
		{
		return (new BitArray(_intSize, _bits));
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void writeExternal(java.io.ObjectOutput out) throws java.io.IOException
		public virtual void writeExternal(ObjectOutput @out)
		{
		@out.writeInt(_bitSize);
		@out.writeInt(_mask);
		@out.writeObject(_bits);
		@out.flush();
		}

		/// <summary>
		/// Read the whole tree from a file (serialized)
		/// </summary>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: public void readExternal(java.io.ObjectInput in) throws IOException, ClassNotFoundException
		public virtual void readExternal(ObjectInput @in)
		{
		_bitSize = @in.readInt();
		_intSize = ((int)((uint)_bitSize >> 5)) + 1;
		_mask = @in.readInt();
		_bits = (int[])@in.readObject();
		}

	}

}