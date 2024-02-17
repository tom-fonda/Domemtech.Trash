﻿namespace ParseTreeEditing.UnvParseTreeDOM
{
    using org.w3c.dom;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class UnvParseTreeElement : UnvParseTreeNode, Element
    {
        public UnvParseTreeElement()
        {
            this.NodeType = NodeConstants.ELEMENT_NODE;
        }
        public UnvParseTreeElement(UnvParseTreeElement orig) : base(orig)
        {
            this.NodeType = NodeConstants.ELEMENT_NODE;
        }

        public virtual void EnterRule(IMyParseTreeListener listener)
        {
        }

        public virtual void ExitRule(IMyParseTreeListener listener)
        {
        }

        public object getAttributeNS(string sCHEMA_INSTANCE, string nIL_ATTRIBUTE)
        {
            return null;
        }

        public string Prefix { get; set; }
        public TypeInfo SchemaTypeInfo { get; set; }
        public string lookupNamespaceURI(string prefix)
        {
            throw new NotImplementedException();
        }

        public bool isDefaultNamespace(object elementNamespaceUri)
        {
            throw new NotImplementedException();
        }

        public static string Reconstruct(Node tree)
        {
            Stack<Node> stack = new Stack<Node>();
            stack.Push(tree);
            StringBuilder sb = new StringBuilder();
            while (stack.Any())
            {
                var n = stack.Pop();
                if (n is UnvParseTreeAttr a)
                {
                    if (a.LocalName == "Line") continue;
                    else if (a.LocalName == "Column") continue;
                    else sb.Append(a.StringValue);
                }
                else if (n is UnvParseTreeText t)
                {
                    sb.Append(t.NodeValue);
                }
                else if (n is UnvParseTreeElement e)
                {
                    for (int i = n.ChildNodes.Length - 1; i >= 0; i--)
                    {
                        stack.Push(n.ChildNodes.item(i));
                    }
                }
            }
            return sb.ToString();
        }

        public string GetText()
        {
            return Reconstruct(this);
        }

        public bool IsTerminal()
        {
            for (int i = 0; i < this.ChildNodes.Length; ++i)
            {
                if (this.ChildNodes.item(i) is UnvParseTreeText) return true;
                if (this.ChildNodes.item(i) is UnvParseTreeAttr) continue;
                if (this.ChildNodes.item(i) is UnvParseTreeElement) return false;
                if (this.ChildNodes.item(i) is UnvParseTreeDocument) return false;
                throw new NotImplementedException();
            }
            return false;
        }

        public int GetLine()
        {
            if (!this.AllChildren.Any()) return -1;
            var line = this.AllChildren.Where(c =>
            {
                var a = c as UnvParseTreeAttr;
                if (a == null) return false;
                var o = a.Name as string;
                if (o == null) return false;
                return o == "Line";
            }).Select(c =>
            {
                var t = (c as UnvParseTreeAttr).Value as string;
                return Int32.Parse(t);
            }).First();
            return line;
        }

        public int GetColumn()
        {
            if (!this.AllChildren.Any()) return -1;
            var col = this.AllChildren.Where(c =>
            {
                var a = c as UnvParseTreeAttr;
                if (a == null) return false;
                var o = a.Name as string;
                if (o == null) return false;
                return o == "Column";
            }).Select(c =>
            {
                var t = (c as UnvParseTreeAttr).Value as string;
                return Int32.Parse(t);
            }).First();
            return col;
        }
    }
}
