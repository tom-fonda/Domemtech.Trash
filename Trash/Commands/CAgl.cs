﻿namespace Trash.Commands
{
    using Algorithms;
    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;
    using LanguageServer;
    using Microsoft.Msagl.Drawing;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using Workspaces;


    class CAgl
    {
        public void Help()
        {
            System.Console.WriteLine(@"agl
Read a tree from stdin and open a Windows Form that displays the graph.

Example:
    . | agl
");
        }

        public Graph CreateGraph(IParseTree[] trees, IList<string> parserRules)
        {
            var graph = new Graph();
            foreach (var tree in trees)
            {
                if (tree != null)
                {
                    if (tree.ChildCount == 0)
                        graph.AddNode(tree.GetHashCode().ToString());
                    else
                        GraphEdges(graph, tree, tree.GetHashCode());
                    FormatNodes(graph, tree, parserRules, tree.GetHashCode());
                }
            }
            return graph;
        }

        private void GraphEdges(Graph graph, ITree tree, int base_hash_code)
        {
            for (var i = tree.ChildCount - 1; i > -1; i--)
            {
                var child = tree.GetChild(i);
                graph.AddEdge((base_hash_code + tree.GetHashCode()).ToString(),
                    (base_hash_code + child.GetHashCode()).ToString());

                GraphEdges(graph, child, base_hash_code);
            }
        }

        private void FormatNodes(Graph graph, ITree tree, IList<string> parserRules, int base_hash_code)
        {
            var node = graph.FindNode((base_hash_code + tree.GetHashCode()).ToString());
            if (node != null)
            {
                node.LabelText = Trees.GetNodeText(tree, parserRules);

                var ruleFailedAndMatchedNothing = false;

                if (tree is ParserRuleContext context)
                    ruleFailedAndMatchedNothing =
                       // ReSharper disable once ComplexConditionExpression
                       context.exception != null &&
                       context.Stop != null
                       && context.Stop.TokenIndex < context.Start.TokenIndex;

                if (tree is IErrorNode || ruleFailedAndMatchedNothing)
                    node.Label.FontColor = Color.Red;
                else
                    node.Label.FontColor = Color.Black;

                node.Attr.Color = Color.Black;

                //if (BackgroundColor.HasValue)
                //    node.Attr.FillColor = BackgroundColor.Value;

                node.Attr.Color = Color.Black;

                node.UserData = tree;
            }

            for (int i = 0; i < tree.ChildCount; i++)
                FormatNodes(graph, tree.GetChild(i), parserRules, base_hash_code);
        }

        public void Execute(Repl repl, ReplParser.AglContext tree, bool piped)
        {
            MyTuple<IParseTree[], Parser, Document, string> tuple = repl.input_output_stack.Pop();
            var lines = tuple.Item4;
            var doc = repl.stack.Peek();
            var pr = ParsingResultsFactory.Create(doc);
            var lexer = pr.Lexer;
            var parser = pr.Parser;
            var serializeOptions = new JsonSerializerOptions();
            serializeOptions.Converters.Add(new AntlrJson.ParseTreeConverter());
            serializeOptions.WriteIndented = false;
            var nodes = JsonSerializer.Deserialize<IParseTree[]>(lines, serializeOptions);
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = CreateGraph(nodes, parser.RuleNames.ToList());
            graph.LayoutAlgorithmSettings = new Microsoft.Msagl.Layout.Layered.SugiyamaLayoutSettings();
            viewer.Graph = graph;
            form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            form.Controls.Add(viewer);
            form.ResumeLayout();
            form.ShowDialog();
        }
    }
}