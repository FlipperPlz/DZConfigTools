//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.10.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /Users/ryannkelly/Desktop/PlayerDataBot/DZConfigTools/DZConfigTools.Core/Generated/ParamFileParser.g4 by ANTLR 4.10.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace DZConfigTools.Core.Generated;
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="ParamFileParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.10.1")]
[System.CLSCompliant(false)]
public interface IParamFileParserListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.computationalStart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterComputationalStart([NotNull] ParamFileParser.ComputationalStartContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.computationalStart"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitComputationalStart([NotNull] ParamFileParser.ComputationalStartContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStatement([NotNull] ParamFileParser.StatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStatement([NotNull] ParamFileParser.StatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.arrayAppension"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayAppension([NotNull] ParamFileParser.ArrayAppensionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.arrayAppension"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayAppension([NotNull] ParamFileParser.ArrayAppensionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.arrayTruncation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayTruncation([NotNull] ParamFileParser.ArrayTruncationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.arrayTruncation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayTruncation([NotNull] ParamFileParser.ArrayTruncationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.deleteStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeleteStatement([NotNull] ParamFileParser.DeleteStatementContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.deleteStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeleteStatement([NotNull] ParamFileParser.DeleteStatementContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.externalClassDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExternalClassDeclaration([NotNull] ParamFileParser.ExternalClassDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.externalClassDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExternalClassDeclaration([NotNull] ParamFileParser.ExternalClassDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.classDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterClassDeclaration([NotNull] ParamFileParser.ClassDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.classDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitClassDeclaration([NotNull] ParamFileParser.ClassDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.arrayDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayDeclaration([NotNull] ParamFileParser.ArrayDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.arrayDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayDeclaration([NotNull] ParamFileParser.ArrayDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.tokenDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTokenDeclaration([NotNull] ParamFileParser.TokenDeclarationContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.tokenDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTokenDeclaration([NotNull] ParamFileParser.TokenDeclarationContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.literalArray"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteralArray([NotNull] ParamFileParser.LiteralArrayContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.literalArray"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteralArray([NotNull] ParamFileParser.LiteralArrayContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.literalString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteralString([NotNull] ParamFileParser.LiteralStringContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.literalString"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteralString([NotNull] ParamFileParser.LiteralStringContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.literalInteger"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteralInteger([NotNull] ParamFileParser.LiteralIntegerContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.literalInteger"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteralInteger([NotNull] ParamFileParser.LiteralIntegerContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.literalFloat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteralFloat([NotNull] ParamFileParser.LiteralFloatContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.literalFloat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteralFloat([NotNull] ParamFileParser.LiteralFloatContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.literalOrArray"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteralOrArray([NotNull] ParamFileParser.LiteralOrArrayContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.literalOrArray"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteralOrArray([NotNull] ParamFileParser.LiteralOrArrayContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteral([NotNull] ParamFileParser.LiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteral([NotNull] ParamFileParser.LiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.arrayName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArrayName([NotNull] ParamFileParser.ArrayNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.arrayName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArrayName([NotNull] ParamFileParser.ArrayNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="ParamFileParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifier([NotNull] ParamFileParser.IdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="ParamFileParser.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifier([NotNull] ParamFileParser.IdentifierContext context);
}
