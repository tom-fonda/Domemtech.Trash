﻿using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace Trash
{

    public partial class Program
    {
        int return_value = 0;

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

        public static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
        {
            HelpText helpText = null;
            if (errs.IsVersion())  //check if error is version request
                helpText = HelpText.AutoBuild(result);
            else
            {
                helpText = HelpText.AutoBuild(result, h =>
                {
                    h.AdditionalNewLineAfterOption = false;
                    h.Heading = "trgen2";
                    h.Copyright = "Copyright (c) 2021 Ken Domino";
                    h.AddPreOptionsText(new CGen().Help());
                    return HelpText.DefaultParsingErrorsHandler(result, h);
                }, e => e);
            }
            Console.Error.WriteLine(helpText);
        }

        private class MyError : Error
        {
            public MyError() : base(ErrorType.InvalidAttributeConfigurationError, true) { }
        }

        public void MainInternal(string[] args)
        {
            var cgen = new CGen();
            var config = new Config();

            // Get default from OS, or just default.
            config.output_directory = "Generated/";

            // Get any defaults from ~/.trgen.rc
            var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (System.IO.File.Exists(home + Path.DirectorySeparatorChar + cgen.SetupFfn))
            {
                var jsonString = System.IO.File.ReadAllText(home + Path.DirectorySeparatorChar + cgen.SetupFfn);
                var o = JsonSerializer.Deserialize<Config>(jsonString);
                var ty = typeof(Config);
                foreach (var prop in ty.GetProperties())
                {
                    if (prop.GetValue(o, null) != null)
                    {
                        prop.SetValue(config, prop.GetValue(o, null));
                    }
                }
                if (o.all_source_pattern != null) config.all_source_pattern = config.all_source_pattern;
                else config.all_source_pattern =
                    "^(?!.*(" +
                     (cgen.ignore_string != null ? cgen.ignore_string + "|" : "")
                     + "ignore/|Generated/|target/|examples/|.git/|.gitignore|/)).+"
                     + "$";
            }

            // Parse options, stop if we see a bogus option, or something like --help.
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
                if (o.all_source_pattern != null) config.all_source_pattern = config.all_source_pattern;
                else config.all_source_pattern =
                    "^(?!.*("
                     + "Generated/|.git/|.gitignore)).+"
                     + "$";
            });
            if (stop) return;

            return_value = cgen.Execute(config);
        }
    }
}