using System.Collections.Generic;
using CommandLine;

namespace Trash
{
    public class Config
    {
        [Option('e', "no-prs", Required = false, HelpText = "No parsing result sets.")]
        public bool NoParsingResultSets { get; set; }

        [Option('f', "file", Required = false)]
        public string File { get; set; }

        [Option("fmt", Required = false)]
        public bool Format { get; set; }

        [Option('v', "verbose", Required =false)]
        public bool Verbose { get; set; }

        [Value(0, Min = 1)]
        public IEnumerable<string> Expr { get; set; }
    }
}
