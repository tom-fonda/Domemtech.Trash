// Template generated code from trgen 0.19.0

using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ErrorListener<S> : ConsoleErrorListener<S>
{
    public bool had_error;
    bool _quiet;

    public ErrorListener(bool quiet = false)
    {
        _quiet = quiet;
    }

    public override void SyntaxError(TextWriter output, IRecognizer recognizer, S offendingSymbol, int line,
        int col, string msg, RecognitionException e)
    {
        had_error = true;
		if (!_quiet) base.SyntaxError(output, recognizer, offendingSymbol, line, col, msg, e);
    }
}
