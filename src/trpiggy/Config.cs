﻿using CommandLine;
using System.Collections.Generic;

namespace Trash
{
    public class Config
    {
        [Value(0, Min = 1)]
        public IEnumerable<string> TemplateFile { get; set; }

        [Option('f', "file", Required = false, HelpText = "Read parse tree data from file instead of stdin.")]
        public string TreeFile { get; set; }

        [Option('v', "verbose", Required = false)]
        public bool Verbose { get; set; }
    }
}
