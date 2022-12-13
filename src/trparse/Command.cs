﻿using System;
using System.IO;
using System.Linq;

namespace Trash
{
    class Command
    {
        public string Help()
        {
            using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("trparse.readme.md"))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public void Execute(Config config)
        {
            int exit_code = 0;

            // There are two ways to do this. One is a
            // bootstrapped method using LanguageServer, the
            // other is by using the generated code, with the loading
            // and running of the parser. We need to determine which way.
            // If Generated/exists, and it's a CSharp program that compiles,
            // use that to parse the input.
            //
            // If Generated/ does not exist, then parse as Antlr4.
            // If Type=="gen", then parse using Generated/.
            // If Type=="antlr2", then parse using Antlr2.
            // Etc.

            string path = config.ParserLocation != null ? config.ParserLocation
                : Environment.CurrentDirectory + Path.DirectorySeparatorChar;
            if (!Directory.Exists(path))
                throw new Exception("Path of parser does not exist.");
            path = Path.GetFullPath(path);
            path = path.Replace("\\", "/");
            if (!path.EndsWith("/")) path = path + "/";
            var fp = new TrashGlobbing.Glob(path)
                .RegexContents("(Generated-CSharp/)?bin/.*(?!ref)/" + config.Dll + ".dll$")
                .Where(f => f is FileInfo && !f.Attributes.HasFlag(FileAttributes.Directory))
                .Select(f => f.FullName.Replace('\\', '/'))
                .ToList();
            var exists = fp.Count == 1;
            if (config.ParserLocation != null && !exists)
            {
                System.Console.Error.WriteLine("Parser doesn't exist");
                System.Console.Error.WriteLine("fp " + String.Join(" ", fp));
                var is_generated_cs = new TrashGlobbing.Glob(path)
                    .RegexContents("(Generated-CSharp/)*.cs")
                    .Where(f => f is FileInfo && !f.Attributes.HasFlag(FileAttributes.Directory))
                    .Select(f => f.FullName.Replace('\\', '/'))
                    .ToList();
                System.Console.Error.WriteLine("is_generated_cs = " + String.Join(" ", is_generated_cs));
                var is_generated_java = new TrashGlobbing.Glob(path)
                    .RegexContents("(Generated-Java/)*.java")
                    .Where(f => f is FileInfo && !f.Attributes.HasFlag(FileAttributes.Directory))
                    .Select(f => f.FullName.Replace('\\', '/'))
                    .ToList();
                System.Console.Error.WriteLine("is_generated_java = " + String.Join(" ", is_generated_java));
                if (is_generated_cs.Count > 0 && is_generated_java.Count == 0)
                {
                    throw new Exception("-p specified, but the parser doesn't exist. Did you do a 'dotnet build'?");
                } else if (is_generated_cs.Count == 0 && is_generated_java.Count > 0)
                {
                    throw new Exception("-p specified, but the parser is a java program. Trparse doesn't work with that.");
                } else if (is_generated_java.Count > 0 && is_generated_cs.Count > 0)
                {
                    throw new Exception("-p specified, but the parser is a mix of C# and Java. Trparse works with only a C# target parser."); ;
                }
                else if (is_generated_java.Count == 0 && is_generated_cs.Count == 0)
                {
                    throw new Exception("-p specified, but I don't see any C# or Java. Trparse works with only a C# target parser, and it must be built."); ;
                }
                throw new Exception("-p specified, but the parser doesn't exist.");
            }
            string full_path = null;
            if (exists)
            {
                full_path = fp.First();
                exists = File.Exists(full_path);
            }

            if (config.Type != null && config.Type != "gen" || !exists)
            {
                //Dictionary<string, Document> list = new Dictionary<string, Document>();
                //var serializeOptions = new JsonSerializerOptions();
                //serializeOptions.Converters.Add(new AntlrJson.ParseTreeConverter());
                //serializeOptions.WriteIndented = true;
                //var results = new List<ParsingResultSet>();
                //foreach (var file in config.Files)
                //{
                //    Document doc = Docs.Class1.ReadDoc(file);
                //    list.Add(file, doc);
                //    Docs.Class1.ParseDoc(doc, 10, config.Type);
                //    var pr = ParsingResultsFactory.Create(doc);
                //    IParseTree pt = pr.ParseTree;
                //    if (!config.Quiet && config.Verbose) System.Console.Error.WriteLine(LanguageServer.TreeOutput.OutputTree(pt, pr.Lexer, pr.Parser, pr.TokStream as CommonTokenStream));
                //    var rel_path = Path.GetRelativePath(Environment.CurrentDirectory, doc.FullPath);
                //    var tuple = new ParsingResultSet()
                //    {
                //        Text = doc.Code,
                //        FileName = rel_path,
                //        Nodes = new AntlrTreeEditing.AntlrTree { pt },
                //        Lexer = pr.Lexer,
                //        Parser = pr.Parser,
                //        StartSymbol = "",
                //        MetaStartSymbol = ""
                //    };
                //    results.Add(tuple);
                //    if (exit_code == 0 & pr.NumberOfErrors > 0) exit_code = 1;
                //}
                //Environment.ExitCode = exit_code;
                //if (config.NoParsingResultSets) return;
                //string js1 = JsonSerializer.Serialize(results.ToArray(), serializeOptions);
                //System.Console.WriteLine(js1);
            }
            else
            {
                var grun = new Grun(config);
                Environment.ExitCode = grun.Run();
            }
        }
    }
}
