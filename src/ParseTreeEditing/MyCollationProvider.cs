﻿namespace ParseTreeEditing
{
    using org.eclipse.wst.xml.xpath2.api;
    using System.Collections.Generic;

    public class MyCollationProvider : CollationProvider
    {
        public class StringCmp : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return x.CompareTo(y);
            }
        }

        public IComparer<string> getCollation(string name)
        {
            return new StringCmp();
        }

        public string DefaultCollation { get; }
    }
}
