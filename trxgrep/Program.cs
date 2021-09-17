namespace Trash
{
    using System;
    using System.Collections.Generic;
    using CommandLine;
    using CommandLine.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                new Program().MainInternal(args);
            }
            catch (Exception e)
            {
                System.Console.Error.WriteLine(e.ToString());
                System.Environment.Exit(1);
            }
        }

        void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
        {
            HelpText helpText = null;
            if (errs.IsVersion())  //check if error is version request
                helpText = HelpText.AutoBuild(result);
            else
            {
                helpText = HelpText.AutoBuild(result, h =>
                {
                    h.AdditionalNewLineAfterOption = false;
                    h.Heading = "trxgrep";
                    h.Copyright = "Copyright (c) 2021 Ken Domino"; //change copyright text
                    h.AddPreOptionsText(new CXGrep().Help());
                    return HelpText.DefaultParsingErrorsHandler(result, h);
                }, e => e);
            }
            Console.Error.WriteLine(helpText);
        }

        public void MainInternal(string[] args)
        {
            //foreach (var arg in args)
            //    System.Console.Error.WriteLine("arg " + arg);
            var config = new Config();
            var result = new CommandLine.Parser().ParseArguments<Config>(args);
            bool stop = false;
            result.WithNotParsed(
                errs =>
                {
                    DisplayHelp(result, errs);
                    stop = true;
                });
            if (stop) return;
            result.WithParsed(o =>
            {
                var ty = typeof(Config);
                foreach (var prop in ty.GetProperties())
                {
                    if (prop.GetValue(o, null) != null)
                    {
                        prop.SetValue(config, prop.GetValue(o, null));
                    }
                }
                if (o.Expr != null) config.Expr = o.Expr;
            });
            new CXGrep().Execute(config);
        }
    }
}
