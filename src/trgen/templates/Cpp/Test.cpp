// Template generated code from trgen <version>

#include \<iostream>
#include \<iomanip>
#include \<string>
#include \<chrono>
#include \<atomic>
#include \<vector>
#include "ANTLRInputStream.h"
#include "ErrorListener.h"
<tool_grammar_tuples:{x | #include "<x.GeneratedIncludeFileName>"
} >

std::string formatDuration(uint64_t duration) {
    std::stringstream oss;
    // duration is in microseconds units.
    long tseconds = duration / 1000000;
    long minutes = tseconds / 60;
    long seconds = tseconds % 60;
    long microseconds = duration % 1000000;
    oss \<\< std::setfill('0')
        \<\< minutes
        \<\< ":"
        \<\< std::setw(2)
        \<\< seconds
        \<\< "."
        \<\< std::setw(6)
        \<\< microseconds;
    return oss.str();
}

std::string formatDurationSeconds(uint64_t duration) {
    std::stringstream oss;
    // duration is in microseconds units.
    long tseconds = duration / 1000000;
    long minutes = tseconds / 60;
    long seconds = tseconds % 60;
    long microseconds = duration % 1000000;
    double s = minutes * 60.0 + seconds + (microseconds / 1000000.0);
    oss \<\< s;
    return oss.str();
}

bool show_tree = false;
bool show_tokens = false;
std::vector\<std::string> inputs;
std::vector\<bool> is_fns;
int error_code = 0;
int string_instance = 0;
std::string prefix;

void DoParse(antlr4::CharStream* str, std::string input_name, int row_number)
{
    antlr4::Lexer* lexer = new <lexer_name>(str);
    if (show_tokens)
    {
        for (int i = 0; ; ++i)
        {
            auto token = lexer->nextToken();
            std::cout \<\< token->toString() \<\< std::endl;
            if (token->getType() == antlr4::IntStream::EOF)
                break;
        }
        lexer->reset();
    }
    auto tokens = new antlr4::CommonTokenStream(lexer);
    auto* parser = new <parser_name>(tokens);
    auto listener_lexer = new ErrorListener();
    auto listener_parser = new ErrorListener();
    lexer->removeErrorListeners();
    parser->removeErrorListeners();
    lexer->addErrorListener(listener_lexer);
    parser->addErrorListener(listener_parser);
    auto before = std::chrono::steady_clock::now();
    auto* tree = parser-><start_symbol>();
    auto after = std::chrono::steady_clock::now();
    auto duration = std::chrono::duration_cast\<std::chrono::microseconds>(after - before);
    std::string result;
    if (listener_parser->had_error || listener_lexer->had_error)
    {
        result = "fail";
        error_code = 1;
    }
    else
    {
        result = "success";
    }
    if (show_tree)
    {
        std::cout \<\< tree->toStringTree(parser) \<\< std::endl;
    }
    std::cerr \<\< prefix \<\< "Cpp " \<\< row_number \<\< " " \<\< input_name \<\< " " \<\< result \<\< " " \<\< formatDurationSeconds(duration.count()) \<\< std::endl;
}


void ParseStdin()
{
    antlr4::CharStream* str = nullptr;
    str = new antlr4::ANTLRInputStream(std::cin);
    DoParse(str, "stdin", 0);
}

void ParseString(std::string input, int row_number)
{
    antlr4::CharStream* str = nullptr;
    str = new antlr4::ANTLRInputStream(input);
    DoParse(str, "string" + string_instance++, row_number);
}

void ParseFilename(std::string input, int row_number)
{
    antlr4::CharStream* str = nullptr;
    std::fstream fs(input);
    str = new antlr4::ANTLRInputStream(fs);
    DoParse(str, input, row_number);
}

int TryParse(std::vector\<std::string>& args)
{
    for (int i = 0; i \< args.size(); ++i)
    {
        if (args[i] == "-tokens")
        {
            show_tokens = true;
            continue;
        }
        else if (args[i] == "-tree")
        {
            show_tree = true;
            continue;
        }
        else if (args[i] == "-prefix")
        {
            prefix = args[++i] + " ";
        }
        else if (args[i] == "-input")
        {
            ++i;
            inputs.push_back(args[i]);
            is_fns.push_back(false);
        }
        else
        {
            inputs.push_back(args[i]);
            is_fns.push_back(true);
        }
    }
    if (inputs.size() == 0)
    {
        ParseStdin();
    }
    else
    {
        auto before = std::chrono::steady_clock::now();
        for (int f = 0; f \< inputs.size(); ++f)
        {
            if (is_fns[f])
                ParseFilename(inputs[f], f);
            else
                ParseString(inputs[f], f);
        }
        auto after = std::chrono::steady_clock::now();
        auto duration = std::chrono::duration_cast\<std::chrono::microseconds>(after - before);
        std::cerr \<\< "Total Time: " \<\< formatDurationSeconds(duration.count()) \<\< std::endl;
    }
    return error_code;
}

int main(int argc, const char * argv[])
{
    std::vector \<std::string> args;
    for (int i = 1; i \< argc; ++i)
    {
        args.push_back(argv[i]);
    }   
    return TryParse(args);
}

