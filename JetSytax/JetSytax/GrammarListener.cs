//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Grammar.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="GrammarParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IGrammarListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProg([NotNull] GrammarParser.ProgContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.prog"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProg([NotNull] GrammarParser.ProgContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.content"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterContent([NotNull] GrammarParser.ContentContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.content"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitContent([NotNull] GrammarParser.ContentContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterElement([NotNull] GrammarParser.ElementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.element"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitElement([NotNull] GrammarParser.ElementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.attribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAttribute([NotNull] GrammarParser.AttributeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.attribute"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAttribute([NotNull] GrammarParser.AttributeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="GrammarParser.chardata"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterChardata([NotNull] GrammarParser.ChardataContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="GrammarParser.chardata"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitChardata([NotNull] GrammarParser.ChardataContext context);
}
