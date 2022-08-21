//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Iso14977Parser.g4 by ANTLR 4.10.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace LanguageServer {
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="Iso14977Parser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public interface IIso14977ParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.letter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLetter([NotNull] Iso14977Parser.LetterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.letter"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLetter([NotNull] Iso14977Parser.LetterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.decimal_digit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDecimal_digit([NotNull] Iso14977Parser.Decimal_digitContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.decimal_digit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDecimal_digit([NotNull] Iso14977Parser.Decimal_digitContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.concatenate_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterConcatenate_symbol([NotNull] Iso14977Parser.Concatenate_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.concatenate_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitConcatenate_symbol([NotNull] Iso14977Parser.Concatenate_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.defining_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDefining_symbol([NotNull] Iso14977Parser.Defining_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.defining_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDefining_symbol([NotNull] Iso14977Parser.Defining_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.definition_separator_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDefinition_separator_symbol([NotNull] Iso14977Parser.Definition_separator_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.definition_separator_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDefinition_separator_symbol([NotNull] Iso14977Parser.Definition_separator_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.end_comment_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnd_comment_symbol([NotNull] Iso14977Parser.End_comment_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.end_comment_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnd_comment_symbol([NotNull] Iso14977Parser.End_comment_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.end_group_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnd_group_symbol([NotNull] Iso14977Parser.End_group_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.end_group_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnd_group_symbol([NotNull] Iso14977Parser.End_group_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.end_option_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnd_option_symbol([NotNull] Iso14977Parser.End_option_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.end_option_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnd_option_symbol([NotNull] Iso14977Parser.End_option_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.end_repeat_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEnd_repeat_symbol([NotNull] Iso14977Parser.End_repeat_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.end_repeat_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEnd_repeat_symbol([NotNull] Iso14977Parser.End_repeat_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.except_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExcept_symbol([NotNull] Iso14977Parser.Except_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.except_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExcept_symbol([NotNull] Iso14977Parser.Except_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.first_quote_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFirst_quote_symbol([NotNull] Iso14977Parser.First_quote_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.first_quote_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFirst_quote_symbol([NotNull] Iso14977Parser.First_quote_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.repetition_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRepetition_symbol([NotNull] Iso14977Parser.Repetition_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.repetition_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRepetition_symbol([NotNull] Iso14977Parser.Repetition_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.second_quote_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSecond_quote_symbol([NotNull] Iso14977Parser.Second_quote_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.second_quote_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSecond_quote_symbol([NotNull] Iso14977Parser.Second_quote_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.special_sequence_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSpecial_sequence_symbol([NotNull] Iso14977Parser.Special_sequence_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.special_sequence_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSpecial_sequence_symbol([NotNull] Iso14977Parser.Special_sequence_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.start_comment_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStart_comment_symbol([NotNull] Iso14977Parser.Start_comment_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.start_comment_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStart_comment_symbol([NotNull] Iso14977Parser.Start_comment_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.start_group_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStart_group_symbol([NotNull] Iso14977Parser.Start_group_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.start_group_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStart_group_symbol([NotNull] Iso14977Parser.Start_group_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.start_option_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStart_option_symbol([NotNull] Iso14977Parser.Start_option_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.start_option_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStart_option_symbol([NotNull] Iso14977Parser.Start_option_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.start_repeat_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStart_repeat_symbol([NotNull] Iso14977Parser.Start_repeat_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.start_repeat_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStart_repeat_symbol([NotNull] Iso14977Parser.Start_repeat_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.terminator_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTerminator_symbol([NotNull] Iso14977Parser.Terminator_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.terminator_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTerminator_symbol([NotNull] Iso14977Parser.Terminator_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.other_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOther_character([NotNull] Iso14977Parser.Other_characterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.other_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOther_character([NotNull] Iso14977Parser.Other_characterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.space_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSpace_character([NotNull] Iso14977Parser.Space_characterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.space_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSpace_character([NotNull] Iso14977Parser.Space_characterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.horizontal_tabulation_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterHorizontal_tabulation_character([NotNull] Iso14977Parser.Horizontal_tabulation_characterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.horizontal_tabulation_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitHorizontal_tabulation_character([NotNull] Iso14977Parser.Horizontal_tabulation_characterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.new_line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNew_line([NotNull] Iso14977Parser.New_lineContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.new_line"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNew_line([NotNull] Iso14977Parser.New_lineContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.vertical_tabulation_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterVertical_tabulation_character([NotNull] Iso14977Parser.Vertical_tabulation_characterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.vertical_tabulation_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitVertical_tabulation_character([NotNull] Iso14977Parser.Vertical_tabulation_characterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.form_feed"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterForm_feed([NotNull] Iso14977Parser.Form_feedContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.form_feed"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitForm_feed([NotNull] Iso14977Parser.Form_feedContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.terminal_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTerminal_character([NotNull] Iso14977Parser.Terminal_characterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.terminal_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTerminal_character([NotNull] Iso14977Parser.Terminal_characterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.gap_free_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGap_free_symbol([NotNull] Iso14977Parser.Gap_free_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.gap_free_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGap_free_symbol([NotNull] Iso14977Parser.Gap_free_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.terminal_string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTerminal_string([NotNull] Iso14977Parser.Terminal_stringContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.terminal_string"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTerminal_string([NotNull] Iso14977Parser.Terminal_stringContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.first_terminal_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFirst_terminal_character([NotNull] Iso14977Parser.First_terminal_characterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.first_terminal_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFirst_terminal_character([NotNull] Iso14977Parser.First_terminal_characterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.second_terminal_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSecond_terminal_character([NotNull] Iso14977Parser.Second_terminal_characterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.second_terminal_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSecond_terminal_character([NotNull] Iso14977Parser.Second_terminal_characterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.gap_separator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGap_separator([NotNull] Iso14977Parser.Gap_separatorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.gap_separator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGap_separator([NotNull] Iso14977Parser.Gap_separatorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.syntax1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSyntax1([NotNull] Iso14977Parser.Syntax1Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.syntax1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSyntax1([NotNull] Iso14977Parser.Syntax1Context context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.commentless_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterCommentless_symbol([NotNull] Iso14977Parser.Commentless_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.commentless_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitCommentless_symbol([NotNull] Iso14977Parser.Commentless_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.integer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInteger([NotNull] Iso14977Parser.IntegerContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.integer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInteger([NotNull] Iso14977Parser.IntegerContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.meta_identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMeta_identifier([NotNull] Iso14977Parser.Meta_identifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.meta_identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMeta_identifier([NotNull] Iso14977Parser.Meta_identifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.meta_identifier_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMeta_identifier_character([NotNull] Iso14977Parser.Meta_identifier_characterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.meta_identifier_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMeta_identifier_character([NotNull] Iso14977Parser.Meta_identifier_characterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.special_sequence"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSpecial_sequence([NotNull] Iso14977Parser.Special_sequenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.special_sequence"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSpecial_sequence([NotNull] Iso14977Parser.Special_sequenceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.special_sequence_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSpecial_sequence_character([NotNull] Iso14977Parser.Special_sequence_characterContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.special_sequence_character"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSpecial_sequence_character([NotNull] Iso14977Parser.Special_sequence_characterContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.comment_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComment_symbol([NotNull] Iso14977Parser.Comment_symbolContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.comment_symbol"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComment_symbol([NotNull] Iso14977Parser.Comment_symbolContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.bracketed_textual_comment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBracketed_textual_comment([NotNull] Iso14977Parser.Bracketed_textual_commentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.bracketed_textual_comment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBracketed_textual_comment([NotNull] Iso14977Parser.Bracketed_textual_commentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.syntax2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSyntax2([NotNull] Iso14977Parser.Syntax2Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.syntax2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSyntax2([NotNull] Iso14977Parser.Syntax2Context context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.syntax3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSyntax3([NotNull] Iso14977Parser.Syntax3Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.syntax3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSyntax3([NotNull] Iso14977Parser.Syntax3Context context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.syntax_rule"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSyntax_rule([NotNull] Iso14977Parser.Syntax_ruleContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.syntax_rule"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSyntax_rule([NotNull] Iso14977Parser.Syntax_ruleContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.definitions_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDefinitions_list([NotNull] Iso14977Parser.Definitions_listContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.definitions_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDefinitions_list([NotNull] Iso14977Parser.Definitions_listContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.single_definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSingle_definition([NotNull] Iso14977Parser.Single_definitionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.single_definition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSingle_definition([NotNull] Iso14977Parser.Single_definitionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.syntactic_term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSyntactic_term([NotNull] Iso14977Parser.Syntactic_termContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.syntactic_term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSyntactic_term([NotNull] Iso14977Parser.Syntactic_termContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.syntactic_exception"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSyntactic_exception([NotNull] Iso14977Parser.Syntactic_exceptionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.syntactic_exception"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSyntactic_exception([NotNull] Iso14977Parser.Syntactic_exceptionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.syntactic_factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSyntactic_factor([NotNull] Iso14977Parser.Syntactic_factorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.syntactic_factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSyntactic_factor([NotNull] Iso14977Parser.Syntactic_factorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.syntactic_primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSyntactic_primary([NotNull] Iso14977Parser.Syntactic_primaryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.syntactic_primary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSyntactic_primary([NotNull] Iso14977Parser.Syntactic_primaryContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.optional_sequence"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOptional_sequence([NotNull] Iso14977Parser.Optional_sequenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.optional_sequence"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOptional_sequence([NotNull] Iso14977Parser.Optional_sequenceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.repeated_sequence"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRepeated_sequence([NotNull] Iso14977Parser.Repeated_sequenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.repeated_sequence"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRepeated_sequence([NotNull] Iso14977Parser.Repeated_sequenceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.grouped_sequence"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterGrouped_sequence([NotNull] Iso14977Parser.Grouped_sequenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.grouped_sequence"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitGrouped_sequence([NotNull] Iso14977Parser.Grouped_sequenceContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="Iso14977Parser.empty_sequence"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEmpty_sequence([NotNull] Iso14977Parser.Empty_sequenceContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Iso14977Parser.empty_sequence"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEmpty_sequence([NotNull] Iso14977Parser.Empty_sequenceContext context);
}
} // namespace LanguageServer
