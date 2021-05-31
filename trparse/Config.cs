using System.Collections.Generic;
using CommandLine;

namespace Trash
{
    public class Config
    {
		[Value(0)]
	    public IEnumerable<string> Files { get; set; }

        [Option('i', "input", Required = false)]
        public string Input { get; set; }

        [Option('t', "type", Required = false)]
        public string Type { get; set; }
    }
}
