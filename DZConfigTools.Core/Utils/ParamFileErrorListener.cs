using Antlr4.Runtime;

namespace DZConfigTools.Core.Utils; 

public class ParamFileErrorListener : BaseErrorListener {
    public readonly List<string> SyntaxErrors = new();
    
    public override void SyntaxError
    (
        TextWriter output,
        IRecognizer recognizer,
        IToken offendingSymbol,
        int line, 
        int charPositionInLine,
        string msg,
        RecognitionException e
    )
    {
        SyntaxErrors.Add($"[Ln{line}:Col{charPositionInLine}] {msg}");
        base.SyntaxError(output, recognizer, offendingSymbol, line, charPositionInLine, msg, e);
    }
}