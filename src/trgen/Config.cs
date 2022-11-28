﻿using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Trash
{
    public class Config
    {
        [Value(0)]
        public IEnumerable<string> Files { get; set; }

        [Option('x', "profile", Required = false, HelpText = "Add in Antlr profiling code.")]
        public bool? profile { get; set; }

        [Option('s', "start-rule", Required = false, HelpText = "Start rule name.")]
        public string start_rule { get; set; }

        [Option('g', "grammar-name", Required = false, HelpText = "Grammar for parse.")]
        public string grammar_name { get; set; }

        [Option('t', "target", Required = false, HelpText = "The target language for the project.")]
        public string target
        {
            get { return _backing_target; }
            set
            {
                _backing_target = value;
                this.output_directory = "Generated-" + value + "/";
            }
        }

        [Option("antlr-tool-path", Required = false)]
        public string antlr_tool_path { get; set; }

        [Option('o', "output-directory", Required = false, HelpText = "The output directory for the project.")]
        public string output_directory { get; set; }

        [Option('p', "package", Required = false)]
        public string name_space { get; set; }

        [Option("template-sources-directory", Required = false)]
        public string template_sources_directory { get { return _backing_template_sources_directory; } set { _backing_template_sources_directory = Path.GetFullPath(value); } }

        [Option("skip-pattern", Required = false, HelpText = "Replacement for skip-list. R.E. on what to do, what not to do, of the grammars in the poms.")]
        public string skip_pattern { get; set; }

        [Option("todo-pattern", Required = false, HelpText = "Replacement for todo-list. R.E. on what to do, what not to do, of the grammars in the poms.")]
        public string todo_pattern { get; set; }

        [Option('v', "verbose", Required = false)]
        public bool Verbose { get; set; }



        private string _backing_template_sources_directory;
        private string _backing_target;
        public IEnumerable<string> antlr_tool_args { get; set; }
        public OSType? env_type { get; set; }
        public bool? flatten { get; set; }
        public LineTranslationType? line_translation { get; set; }
        public bool? maven { get; set; }
        public PathSepType? path_sep { get; set; }
        public string tool_grammar_files_pattern { get; set; }
        public int? watchdog_timeout { get; set; }
        public string SetupFfn = ".trgen.rc";
        public string root_directory;

        public Config()
        {
            // Get default from OS, or just default.
            line_translation = Command.GetLineTranslationType();
            env_type = Command.GetEnvType();
            path_sep = Command.GetPathSep();
            antlr_tool_path = Command.GetAntlrToolPath();
            target = "CSharp";
            tool_grammar_files_pattern = "^(?!.*(/Generated|/Generated-[^/]|/target|/examples)).+g4$";
            output_directory = "Generated-" + target + "/";
            flatten = false;
            watchdog_timeout = 60;
            var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (System.IO.File.Exists(home + Path.DirectorySeparatorChar + SetupFfn))
            {
                var jsonString = System.IO.File.ReadAllText(home + Path.DirectorySeparatorChar + SetupFfn);
                var o = JsonSerializer.Deserialize<Config>(jsonString);
                var ty = typeof(Config);
                foreach (var prop in ty.GetProperties())
                {
                    if (prop.GetValue(o, null) != null)
                    {
                        prop.SetValue(this, prop.GetValue(o, null));
                    }
                }
            }
            if (target == "Go")
            {
                name_space = "parser";
            }
            else
            {
                name_space = null;
            }
            output_directory = "Generated-" + target + "/";
            string cd = Environment.CurrentDirectory.Replace('\\', '/') + "/";
            this.root_directory = cd;
            if (this.maven == null) maven = File.Exists(cd + Path.DirectorySeparatorChar + @"pom.xml");
        }

        public Config(Config copy)
        {
            var ty = typeof(Config);
            foreach (var prop in ty.GetProperties())
            {
                if (prop.GetValue(copy, null) != null)
                {
                    prop.SetValue(this, prop.GetValue(copy, null));
                }
            }
        }
    }
}
