// Template generated code from trgen <version>

import java.io.FileNotFoundException;
import java.io.IOException;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.tree.ParseTree;
import java.time.Instant;
import java.time.Duration;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class Test {

	static boolean shunt_output = false;
	static boolean show_profile = false;
    static boolean show_tree = false;
    static boolean show_tokens = false;
    static boolean show_trace = false;
	static int error_code = 0;
	static java.nio.charset.Charset charset = null;
    static int string_instance = 0;
    static String prefix = "";
	static boolean quiet = false;

    public static void main(String[] args) throws  FileNotFoundException, IOException
    {
        List\<Boolean> is_fns = new ArrayList\<Boolean>();
        List\<String> inputs = new ArrayList\<String>();
        for (int i = 0; i \< args.length; ++i)
        {
			if (args[i].Equals("-profile"))
			{
				show_profile = true;
			}
			else if (args[i].equals("-tokens"))
            {
                show_tokens = true;
            }
            else if (args[i].equals("-tree"))
            {
                show_tree = true;
            }
            else if (args[i].equals("-prefix"))
            {
                prefix = args[++i] + " ";
            }
            else if (args[i].equals("-input")) {
                inputs.add(args[++i]);
                is_fns.add(false);
            }
			else if (args[i].equals("-shunt"))
			{
				shunt_output = true;
			}
            else if (args[i].equals("-encoding"))
            {
                charset = java.nio.charset.Charset.forName(args[++i]);
            }
			else if (args[i].equals("-x"))
			{
				for (; ; )
				{
					var line = System.Console.In.ReadLine();
					line = line?.Trim();
					if (line == null || line == "")
					{
						break;
					}
					inputs.Add(line);
					is_fns.Add(true);
				}
			}
			else if (args[i].equals("-q"))
			{
				quiet = true;
			}
            else if (args[i].equals("-trace"))
            {
                show_trace = true;
                continue;
            }
            else {
                inputs.add(args[i]);
                is_fns.add(true);
            }
        }
        CharStream str = null;
        if (inputs.size() == 0)
        {
            ParseStdin();
        }
        else
        {
            Instant start = Instant.now();
            for (int f = 0; f \< inputs.size(); ++f)
            {
                if (is_fns.get(f))
                    ParseFilename(inputs.get(f), f);
                else
                    ParseString(inputs.get(f), f);
            }
            Instant finish = Instant.now();
            long timeElapsed = Duration.between(start, finish).toMillis();
            System.err.println("Total Time: " + (timeElapsed * 1.0) / 1000.0);
        }
        java.lang.System.exit(error_code);
    }

    static void ParseStdin()throws IOException {
        CharStream str = CharStreams.fromStream(System.in);
        DoParse(str, "stdin", 0);
    }

    static void ParseString(String input, int row_number) throws IOException {
        var str = CharStreams.fromString(input);
        DoParse(str, "string" + string_instance++, row_number);
    }

    static void ParseFilename(String input, int row_number) throws IOException
    {
        CharStream str = null;
        if (charset == null)
            str = CharStreams.fromFileName(input);
        else
            str = CharStreams.fromFileName(input, charset);
        DoParse(str, input, row_number);
    }

    static void DoParse(CharStream str, String input_name, int row_number) {
        <lexer_name> lexer = new <lexer_name>(str);
        if (show_tokens)
        {
            StringBuilder new_s = new StringBuilder();
            for (int i = 0; ; ++i)
            {
                var ro_token = lexer.nextToken();
                var token = (CommonToken)ro_token;
                token.setTokenIndex(i);
                new_s.append(token.toString());
                new_s.append(System.getProperty("line.separator"));
                if (token.getType() == IntStream.EOF)
                    break;
            }
            System.out.println(new_s.toString());
            lexer.reset();
        }
        var tokens = new CommonTokenStream(lexer);
        <parser_name> parser = new <parser_name>(tokens);
		output = shunt_output ? new StreamWriter(input_name + ".errors") : System.Console.Out;
        ErrorListener listener_lexer = new ErrorListener(quiet, output);
        ErrorListener listener_parser = new ErrorListener(quiet, output);
        parser.removeErrorListeners();
        lexer.removeErrorListeners();
        parser.addErrorListener(listener_parser);
        lexer.addErrorListener(listener_lexer);
        if (show_trace)
        {
            parser.setTrace(true);
//            ParserATNSimulator.trace_atn_sim = true;
        }
        Instant start = Instant.now();
        ParseTree tree = parser.<start_symbol>();
        Instant finish = Instant.now();
        long timeElapsed = Duration.between(start, finish).toMillis();
        String result = "";
        if (listener_parser.had_error || listener_lexer.had_error)
        {
            result = "fail";
            error_code = 1;
        }
        else
            result = "success";
        if (show_tree)
        {
			if (shunt_output)
			{
				System.out.println(tree.toStringTree(parser));
			} else
			{
				System.out.println(tree.toStringTree(parser));
			}
        }
		if (!quiet)
		{
			System.err.println(prefix + "Java " + row_number + " " + input_name + " " + result + " " + (timeElapsed * 1.0) / 1000.0);
		}
		if (shunt_output) output.close();
    }
}
