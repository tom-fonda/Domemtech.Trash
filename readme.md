# Trash

[![Build](https://github.com/kaby76/Domemtech.Trash/workflows/CI/badge.svg)](https://github.com/kaby76/Domemtech.Trash/actions?query=workflow%3ACI)

Trash is a collection of ~40 command-line tools to analyze and transform
Antlr parse trees and grammars. The toolkit can: generate a parser
application for an Antlr4 grammar for any target and any OS; analyze the
grammar for common problems; automate changes applied to a grammar scraped
from a specification; transform parse trees for transpilating
and proprocessing source code. With the [Antlr toolkit](https://www.antlr.org/)
and the [collection of Antlr grammars](https://github.com/antlr/grammars-v4),
one can write programming language tools quickly and easily.

The toolkit is designed around a JSON representation of
parse trees and command-line tools that read, modify, and write
those tree via standard input and output. Complex refactorings can be
achieved by chaining different commands together.

Each app in `Trash` is implemented as a [Dotnet Tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools) console application, and can be used on Windows, Linux, or Mac.
No prerequisites are required other than installing the
[NET SDK](https://dotnet.microsoft.com/), and the toolchains
for any other targets you want to use.

The toolkit uses [Antlr](https://www.antlr.org/) and
[XPath2](https://en.wikipedia.org/wiki/XPath).
The code is implemented in C#.

An application of the toolkit was used to scrape and refactor the Dart2
grammar from spec. See [this script](https://github.com/kaby76/ScrapeDartSpec/blob/master/refactor.sh).

## Install
### Requirements
[Install Dotnet 6.0.x](https://dotnet.microsoft.com/en-us/download)

### Linux or Cywin/MSYS2
Copy this script and execute it in a Bash shell.
```
#
for i in tranalyze trcombine trconvert trdelabel trdelete trdot trfold trfoldlit trformat trgen trgroup trinsert tritext trjson trkleene trmove trparse trperf trpiggy trprint trrename trreplace trrr trrup trsort trsplit trsponge trst trstrip trtext trtokens trtree trull trunfold trungroup trwdog trxgrep trxml trxml2
do
    dotnet tool install -g $i
done
```
### Windows or Linux Powershell
Copy this script and execute it in a Powershell shell.
```
$apps = @('tranalyze','trcombine','trconvert','trdelabel','trdelete','trdot','trfold','trfoldlit','trformat','trgen','trgroup','trinsert','tritext','trjson','trkleene','trmove','trparse','trperf','trpiggy','trprint','trrename','trreplace','trrr','trrup','trsort','trsplit','trsponge','trst','trstrip','trtext','trtokens','trtree','trull','trunfold','trungroup','trwdog','trxgrep','trxml','trxml2')
foreach ($i in $apps) {
	dotnet tool install -g $i
}
```
## Uninstall
### Linux or Cywin/MSYS2
Copy this script and execute it in a Bash shell.
```
#
for i in tranalyze trcombine trconvert trdelabel trdelete trdot trfold trfoldlit trformat trgen trgroup trinsert tritext trjson trkleene trmove trparse trperf trpiggy trprint trrename trreplace trrr trrup trsort trsplit trsponge trst trstrip trtext trtokens trtree trull trunfold trungroup trwdog trxgrep trxml trxml2
do
    dotnet tool uninstall -g $i
done
```
### Windows or Linux Powershell
Copy this script and execute it in a Powershell shell.
```
$apps = @('tranalyze','trcombine','trconvert','trdelabel','trdelete','trdot','trfold','trfoldlit','trformat','trgen','trgroup','trinsert','tritext','trjson','trkleene','trmove','trparse','trperf','trpiggy','trprint','trrename','trreplace','trrr','trrup','trsort','trsplit','trsponge','trst','trstrip','trtext','trtokens','trtree','trull','trunfold','trungroup','trwdog','trxgrep','trxml','trxml2')
foreach ($i in $apps) {
	dotnet tool uninstall -g $i
}
```
## List of commands

1) <a href="src/tranalyze/readme.md">tranalyze</a> -- Analyze a grammar
1) <a href="src/trcombine/readme.md">trcombine</a> -- Combine a split Antlr4 grammar
1) <a href="src/trconvert/readme.md">trconvert</a> -- Convert a grammar from one for to another
1) <a href="src/trdelabel/readme.md">trdelabel</a> -- Remove labels from an Antlr4 grammar
1) <a href="src/trdelete/readme.md">trdelete</a> -- Delete nodes in a parse tree
1) <a href="src/trdot/readme.md">trdot</a> -- Print a parse tree in Graphvis Dot format
1) <a href="src/trenum/readme.md">trenum</a> -- 1) <a href="src/trfirst/readme.md">trfirst</a> -- Outputs first sets of a grammar
1) <a href="src/trfold/readme.md">trfold</a> -- Perform fold transform on a grammar
1) <a href="src/trfoldlit/readme.md">trfoldlit</a> -- Perform fold transform on grammar with literals
1) <a href="src/trformat/readme.md">trformat</a> -- Format a grammar
1) <a href="src/trgen/readme.md">trgen</a> -- Generate an Antlr4 parser for a given target language
1) <a href="src/trgen2/readme.md">trgen2</a> -- Generate files from template and XML doc list.
1) <a href="src/trgroup/readme.md">trgroup</a> -- Perform a group transform on a grammar
1) <a href="src/trinsert/readme.md">trinsert</a> -- Insert string into points in a parse tree
1) <a href="src/tritext/readme.md">tritext</a> -- Get strings from a PDF file
1) <a href="src/trjson/readme.md">trjson</a> -- Print a parse tree in JSON structured format
1) <a href="src/trkleene/readme.md">trkleene</a> -- Perform a Kleene transform of a grammar
1) <a href="src/trmove/readme.md">trmove</a> -- Move nodes in a parse tree
1) <a href="src/trparse/readme.md">trparse</a> -- Parse a grammar or use generated parse to parse input
1) <a href="src/trperf/readme.md">trperf</a> -- Perform performance analysis of an Antlr grammar parse
1) <a href="src/trpiggy/readme.md">trpiggy</a> -- Perform a parse tree rewrite
1) <a href="src/trprint/readme.md">trprint</a> -- Print a parse tree, including off-token characters
1) <a href="src/trrename/readme.md">trrename</a> -- Rename symbols in a grammar
1) <a href="src/trreplace/readme.md">trreplace</a> -- Replace nodes in a parse tree with text
1) <a href="src/trrr/readme.md">trrr</a> -- (No description.)
1) <a href="src/trrup/readme.md">trrup</a> -- Remove useless parentheses in a grammar
1) <a href="src/trsem/readme.md">trsem</a> -- Read static semantics and generate code
1) <a href="src/trsort/readme.md">trsort</a> -- Sort rules in a grammar
1) <a href="src/trsplit/readme.md">trsplit</a> -- Split a combined Antlr4 grammar
1) <a href="src/trsponge/readme.md">trsponge</a> -- Extract parsing results output of Trash command into files
1) <a href="src/trst/readme.md">trst</a> -- Print a parse tree in Antlr4 ToStringTree()
1) <a href="src/trstrip/readme.md">trstrip</a> -- Strip a grammar of all actions, labels, etc.
1) <a href="src/trtext/readme.md">trtext</a> -- Print a parse tree with a specific interval
1) <a href="src/trthompson/readme.md">trthompson</a> -- (No description.)
1) <a href="src/trtokens/readme.md">trtokens</a> -- Print tokens in a parse tree
1) <a href="src/trtree/readme.md">trtree</a> -- Print a parse tree in a human-readable format
1) <a href="src/trull/readme.md">trull</a> -- Transform a grammar with upper- and lowercase string literals
1) <a href="src/trunfold/readme.md">trunfold</a> -- Perform an unfold transform on a grammar
1) <a href="src/trungroup/readme.md">trungroup</a> -- Perform an ungroup transform on a grammar
1) <a href="src/trwdog/readme.md">trwdog</a> -- Kill a program that runs too long
1) <a href="src/trxgrep/readme.md">trxgrep</a> -- "Grep" for nodes in a parse tree using XPath
1) <a href="src/trxml/readme.md">trxml</a> -- Print a parse tree in XML structured format
1) <a href="src/trxml2/readme.md">trxml2</a> -- Print an enumeration of all paths in a parse tree to leaves

## Examples

### Parse a grammar, create a parser for the grammar, build, and test
```
git clone https://github.com/antlr/grammars-v4
cd grammars-v4/python/python
trparse *.g4 | trxgrep ' //grammarDecl' | trtext
# Output:
# PythonLexer.g4:lexer grammar PythonLexer;
# PythonParser.g4:parser grammar PythonParser;
trgen
cd Generated
dotnet build
cat - <<EOF | trparse | trxgrep ' //test' | trtext
x == y
x == y if z == b else a == u
lambda: a
lambda x, y: a
EOF
# Output:
# a
# lambda x, y: a
# a
# lambda: a
# a == u
# x == y if z == b else a == u
# x == y
```
### Display parse tree
```
trparse -i "a == b" | trtree
```
`trtree` is only one of several ways to view parse tree data.
Other programs for different output are
[trjson](https://github.com/kaby76/Domemtech.Trash/tree/main/trjson) for [JSON output](https://github.com/kaby76/Domemtech.Trash/blob/main/_tests/trconvert/antlr2/ada.g4.json),
[trxml](https://github.com/kaby76/Domemtech.Trash/tree/main/trxml) for [XML output](https://github.com/kaby76/Domemtech.Trash/blob/main/_tests/trconvert/antlr2/ada.g4.xml),
[trst](https://github.com/kaby76/Domemtech.Trash/tree/main/trst) for [Antlr runtime ToStringTree output](https://github.com/kaby76/Domemtech.Trash/blob/main/_tests/trconvert/antlr2/ada.g4.st),
[trdot](https://github.com/kaby76/Domemtech.Trash/tree/main/trdot),
[trprint](https://github.com/kaby76/Domemtech.Trash/tree/main/trprint) for input text for the parse,
and
[tragl](https://github.com/kaby76/Domemtech.Trash/tree/main/tragl).

### Convert grammars to Antlr4
```
trparse ada.g2 | trconvert | trprint | less
```
This command parses an [old Antlr2 grammar](https://github.com/kaby76/Domemtech.Trash/blob/main/_tests/trconvert/antlr2/ada.g2)
using [trparse](https://github.com/kaby76/Domemtech.Trash/tree/main/trparse),
converts the parse tree data to Antlr4 syntax using
 [trconvert](https://github.com/kaby76/Domemtech.Trash/tree/main/trconvert)
 and
finally [prints out the converted parse tree data, ada.g4](https://github.com/kaby76/Domemtech.Trash/blob/main/_tests/trconvert/antlr2/ada.g4)
using
[trprint](https://github.com/kaby76/Domemtech.Trash/tree/main/trprint). Other
grammar that can be converted are Antlr3, Bison, and ISO EBNF. In order to
use the grammar to parse data, you will need to convert it to an Antlr4 grammar.

### Generate an Arithmetic parser application
```
mkdir foobar; cd foobar; trgen
```
This command creates a parser application for the C# target.
If executed in an empty directory, which is done in the example
shown above, [trgen](https://github.com/kaby76/Domemtech.Trash/tree/main/trgen)
creates an application using the Arithmetic grammar.
If executed in a directory containing
a Antlr Maven plugin (`pom.xml`), `trgen` will create a program according
to the information specified in the `pom.xml` file. Either way, it creates a directory
`Generated/`, and places the source code there.

`trgen` has many options to generate a parser from any Antlr4 grammar, for any target.
But, if a parser is generated for the C# target, built using the NET SDK, then `trparse`
can execute the generated parser, and can be used with all the other tools in Trash. _NB:
In order to use the generate parser application, you must first build it:

    dotnet restore Generated/Test.csproj
    dotnet build Generated/Test.csproj

### Run the generated parser application

    trparse -i "1+2+3" | trtree

After using `trgen` to generate a parser program in C#, shown previously,
and after building the program, you can run the parser using `trparse`. This program 
looks for the generated parser in directory `Generated/`. If it exists,
it will run the parser application in the directory. You can pass
as command-line arguments an input string or input file. If no command-line
arguments are supplied, the program will read stdin. The output of `trparse`, as
with most tools of Trash, is parse tree data.

### Find nodes in the parse tree using XPath

    mkdir empty; cd empty; trgen; dotnet build Generated/Test.csproj; \
        trparse -i "1+2+3" | trxgrep " //SCIENTIFIC_NUMBER" | trst

With this command, a directory is created, the Arithmetic grammar generated, build,
and then run using [trparse](https://github.com/kaby76/Domemtech.Trash/tree/main/trparse).
The `trparse` tool unifies all parsing, whether it's parsing a grammar or parsing input
using a generated parser application. The output from the `trparse` tool is a parse
tree which you can search. [Trxgrep](https://github.com/kaby76/Domemtech.Trash/tree/main/trxgrep)
is the generalized search program for parse trees. `Trxgrep` uses XPath expressions to
precisely identify nodes in the parse tree.

XPath was added to Antlr4, but `Trash` takes the idea
further with the addition of an XPath2 engine ported from the
[Eclipse Web toolkit](https://git.eclipse.org/r/admin/repos/sourceediting%2Fwebtools.sourceediting).
XPath is a well-defined language that should be
used more often in compiler construction.

### Rename a symbol in a grammar, generate a parser for new grammar

    trparse Arithmetic.g4 | trrename "//parserRuleSpec//labeledAlt//RULE_REF[text() = 'expression']" "xxx" | trtext > new-source.g4
    trparse Arithmetic.g4 | trrename -r "expression,expression_;atom,atom_;scientific,scientific_" | trprint

In these two examples, the Arithmetic grammar is parsed.
[trrename](https://github.com/kaby76/Domemtech.Trash/tree/main/trrename) reads the parse tree data and
modifies it by renaming the `expression` symbol two ways: first by XPath expression identifying the LHS terminal
symbol of the `expression` symbol, and the second by assumption that the tree is an Antlr4 parse tree,
then renaming a semi-colon-separated list of paired renames. The resulting code is reconstructed and saved.
`trrename` does not rename symbols in actions, nor does it rename identifiers corresponding to the
grammar symbols in any support source code (but it could if the tool is extended).

### Count method declarations in a Java source file

    git clone https://github.com/antlr/grammars-v4.git; \
        cd grammars-v4/java/java9; \
        trgen; dotnet build Generated/Test.csproj;\
        trparse examples/AllInOne8.java | trxgrep " //methodDeclaration" | trst | wc

This command clones the Antlr4 grammars-v4 repo, generates a parser for the Java9 grammar,
then runs the parser on [examples/AllInOne8.java](https://github.com/antlr/grammars-v4/blob/master/java/java9/examples/AllInOne8.java).
The parse tree is then piped to `trxgrep` to find all parse tree nodes that are
a `methodDeclaration` type, converts it to a simple string, and counts the result using
`wc`.

### Strip a grammar of all non-essential CFG

    trparse Java9.g4 | trstrip | trtext > Essential-Java9.g4

### Split a grammar

Since Antlr2, one can written a combined parser/lexer in one file,
or a split parser/lexer in two files.
While it's not hard to split or combine
a grammar, it's tedious. For automating transformations, it's
necessary because Antlr4 requires the grammars to be split
when super classes are needed for different targets.

    trcombine ArithmeticLexer.g4 ArithmeticParser.g4 | trprint > Arithmetic.g4

This command calls [trcombine](https://github.com/kaby76/Domemtech.Trash/tree/main/trcombine)
which parses two split grammar files
[ArithmeticLexer.g4](https://github.com/kaby76/Domemtech.Trash/blob/main/_tests/combine/ArithmeticLexer.g4)
and
[ArithmeticParser.g4](https://github.com/kaby76/Domemtech.Trash/blob/main/_tests/combine/ArithmeticParser.g4),
and creates a [combined grammar](https://github.com/kaby76/Domemtech.Trash/blob/main/_tests/combine/Arithmetic.g4)
for the two.

    trparse Arithmetic.g4 | trsplit | trsponge -o true

This command calls [trsplit](https://github.com/kaby76/Domemtech.Trash/tree/main/trsplit)
which splits the grammar into two parse tree results, one that defines
ArithmeticLexer.g4 and the other that defines ArithmeticParser.g4.
The tool [trsponge](https://github.com/kaby76/Domemtech.Trash/tree/main/trsponge)
is similar to the [tee](https://en.wikipedia.org/wiki/Tee_(command)) in
Linux: the parse tree data is split and placed in files.

## Parsing Result Sets -- the data passed between commands

A *parsing result set* is a JSON serialization of an array of:

* A set of parse tree nodes.
* Parser information related to the parse tree nodes.
* Lexer information related to the parse tree nodes.
* The name of the input corresponding to the parse tree nodes.
* The input text corresponding to the parse tree nodes.

Most commands in Trash read and/or write parsing result sets.

## Supported grammars

| Grammars | File suffix |
| ---- | ---- |
| Antlr4 | .g4 |
| Antlr3 | .g3 |
| Antlr2 | .g2 |
| Bison | .y |
| LBNF | .cf |
| W3C EBNF | .ebnf |
| ISO 14977 | .iso14977, .iso |

## Analysis

### Recursion

* [Has direct/indirect recursion](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/analysis.md#has-directindirect-recursion)

## Refactoring

Trash provides a number of transformations that can help to make grammars cleaner (reformatting),
more readable (reducing the length of the RHS of a rule),
and more efficient (reducing the number of non-terminals) for Antlr.

Some of these refactorings are very specific for Antlr due to the way
the parser works, e.g., converting a prioritized chain of productions recognizing
an arithmetic expression to a recursive alternate form.
The refactorings implemented are:

### Raw tree editing

* [Delete parse tree node](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#delete-parse-tree-node)

### Reordering

* [Move start rule to top](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#move-start-rule)
* [Reorder parser rules](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#reorder-parser-rules)
* [Sort modes](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#sort-modes)

### Changing rules

* [Remove useless parentheses](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#remove-useless-parentheses)
* [Remove useless parser rules](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#remove-useless-productions)
* [Rename lexer or parser symbol](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#rename)
* [Unfold](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#Unfold)
* [Group alts](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#group-alts)
* [Ungroup alts](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#ungroup-alts)
* [Upper and lower case string literals](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#upper-and-lower-case-string-literals)
* [Fold](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#Fold)
* Replace direct left recursion with right recursion
* [Replace direct left/right recursion with Kleene operator](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#Kleene)
* Replace indirect left recursion with right recursion
* Replace parser rule symbols that conflict with Antlr keywords
* [Replace string literals in parser with lexer symbols](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#replace-literals-in-parser-with-lexer-token-symbols)
* Replace string literals in parser with lexer symbols, with lexer rule create
* [Delabel removes the annoying and mostly useless labeling in an Antlr grammar](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#delabel)

### Splitting and combining

* [Split combined grammars](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#splitting-and-combining-grammars)
* [Combine splitted grammars](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/refactoring.md#splitting-and-combining-grammars)

## Conversion

* [Antlr3 import](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/Import.md#antlr3)
* [Antlr2 import](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/Import.md#antlr2)
* [Bison import](https://github.com/kaby76/Domemtech.Trash/blob/main/doc/Import.md#bison)

---------

The source code for the extension is open source, free of charge, and free of ads. For the latest developments on the extension,
check out my [blog](http://codinggorilla.com).

# Building

    git clone https://github.com/kaby76/Domemtech.Trash
    cd Domemtech.Trash
    make clean; make; make install
    
You must have the NET SDK installed to build and run.

# Current release

## 0.17.0 ("pre-alpha" -- still prototyping)

* Add GitHub Action building and testing.
* Add trperf -- performance measurements of an Antlr program.
* Add trpiggy -- parse tree rewriter.
* Reorganize source code.
* Merge Domemtech.TrashBase into Trash in order to simplify life.
* Fix bugs.
* Add cross-document xpath searching.
* Add some grammar checking scripts in tests.

# Prior Releases

# Roadmap/Goals

Trash is a long-term project (already going on 3 years).
I'm envisioning for the "first" release to support:

* grep utility that finds data in parse trees
* print a parse tree in various formats
* sponge (converts parse tree data into files)
* be able to specify analyses and refactorings via high-level specifications
    * basic refactorings (insert, delete, rename, reorder, split, combine, fold, unfold)
    * piggy -- a parse tree rewriter
* basic analyses (indirect and direct recursion, infinite recursion, LL(1), LR(1), LALR(1), SLR(1), LR(0), etc)
* grammar extraction from pdfs and text
* extract context-free grammars directly from source code via machine learning
* reading and conversion of ABNF, Antlr2/3/4, Bison, Coco/R, ISO14977, JavaCC, Lark, LBNF, Pegen, Peg.js, Pest, Rex, W3C EBNF, XText

If you have any questions, email me at ken.domino <at> gmail.com
