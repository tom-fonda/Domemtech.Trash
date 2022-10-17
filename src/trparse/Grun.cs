﻿namespace Trash
{
    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.Json;
    using Document = Workspaces.Document;
    using Workspace = Workspaces.Workspace;

    public class Grun
    {
        Config config;

        public Grun(Config co)
        {
            config = co;
        }

        public List<Document> Grammars { get; set; }

        public List<Document> ImportGrammars { get; set; }

        public List<Document> SupportCode { get; set; }

        private static string JoinArguments(IEnumerable<string> arguments)
        {
            if (arguments == null)
                throw new ArgumentNullException("arguments");

            StringBuilder builder = new StringBuilder();
            foreach (string argument in arguments)
            {
                if (builder.Length > 0)
                    builder.Append(' ');

                if (argument.IndexOfAny(new[] { '"', ' ' }) < 0)
                {
                    builder.Append(argument);
                    continue;
                }

                // escape a backslash appearing before a quote
                string arg = argument.Replace("\\\"", "\\\\\"");
                // escape double quotes
                arg = arg.Replace("\"", "\\\"");

                // wrap the argument in outer quotes
                builder.Append('"').Append(arg).Append('"');
            }

            return builder.ToString();
        }

        private void HandleOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            System.Console.WriteLine(e.Data);
        }

        public void ReadWorkspace(string csproj)
        {
        }

        public void CreateMsbuildWorkspace(Workspace workspace)
        {
        }

        public int Run()
        {
            int result = 0;
            try
            {
                var data = new List<AntlrJson.ParsingResultSet>();
                string txt = config.Input;
                if (config.Input == null && (config.Files == null || config.Files.Count() == 0))
                {
                    string lines = null;
                    for (; ; )
                    {
                        lines = System.Console.In.ReadToEnd();
                        if (lines != null && lines != "") break;
                    }
                    txt = lines;
                    result = Doit(txt, data);
                }
                else if (config.Input != null)
                {
                    txt = config.Input;
                    result = Doit(txt, data);
                }
                else if (config.Files != null)
                {
                    foreach (var file in config.Files)
                    {
                        try
                        {
                            txt = File.ReadAllText(file);
                        }
                        catch
                        {
                            txt = file;
                        }
                        result = result == 0 ? Doit(txt, data) : result;
                    }
                }
                if (config.NoParsingResultSets) return result;
                var serializeOptions = new JsonSerializerOptions();
                serializeOptions.Converters.Add(new AntlrJson.ParseTreeConverter());
                serializeOptions.WriteIndented = true;
                string js1 = JsonSerializer.Serialize(data.ToArray(), serializeOptions);
                System.Console.WriteLine(js1);
            }
            catch (Exception e)
            {
                result = 1; 
            }
            finally
            {
            }
            return result;
        }

        int Doit(string txt, List<AntlrJson.ParsingResultSet> data)
        {
            string path = config.ParserLocation != null ? config.ParserLocation
                : Environment.CurrentDirectory + Path.DirectorySeparatorChar;
            path = path.Replace("\\", "/");
            if (!path.EndsWith("/")) path = path + "/";
            var full_path = path + "Generated/bin/Debug/net6.0/";
            var exists = File.Exists(full_path + "Test.dll");
            if (!exists) full_path = path + "bin/Debug/net6.0/";
            full_path = Path.GetFullPath(full_path);
            Assembly asm1 = Assembly.LoadFile(full_path + "Antlr4.Runtime.Standard.dll");
            Assembly asm = Assembly.LoadFile(full_path + "Test.dll");
            var xxxxxx = asm1.GetTypes();
            Type[] types = asm.GetTypes();
            Type type = asm.GetType("Program");

            MethodInfo methodInfo = type.GetMethod("SetupParse2");
            object[] parm1 = new object[] { txt };
            var res = methodInfo.Invoke(null, parm1);

            MethodInfo methodInfo2 = type.GetMethod("Parse2");
            object[] parm2 = new object[] { };
            DateTime before = DateTime.Now;
            var res2 = methodInfo2.Invoke(null, parm2);
            DateTime after = DateTime.Now;

            MethodInfo methodInfo3 = type.GetMethod("AnyErrors");
            object[] parm3 = new object[] { };
            var res3 = methodInfo3.Invoke(null, parm3);

            var parser = type.GetProperty("Parser").GetValue(null, new object[0]) as Antlr4.Runtime.Parser;
            var lexer = type.GetProperty("Lexer").GetValue(null, new object[0]) as Antlr4.Runtime.Lexer;

            var tokstream = type.GetProperty("TokenStream").GetValue(null, new object[0]) as ITokenStream;
            var commontokstream = tokstream as CommonTokenStream;
            var r5 = type.GetProperty("Input").GetValue(null, new object[0]);
            var tree = res as IParseTree;
            var t2 = tree as ParserRuleContext;
            System.Console.Error.WriteLine("Time to parse: " + (after - before));
            System.Console.Error.WriteLine("# tokens per sec = " + tokstream.Size / (after - before).TotalSeconds);
            if (config.Verbose) System.Console.Error.WriteLine(LanguageServer.TreeOutput.OutputTree(tree, lexer, parser, commontokstream));
            var tuple = new AntlrJson.ParsingResultSet() { Text = (r5 as string), FileName = "stdin", Stream = tokstream as ITokenStream, Nodes = new IParseTree[] { t2 }, Parser = parser, Lexer = lexer };
            data.Add(tuple);
            return (bool)res3 ? 1 : 0;
        }
    }
}
