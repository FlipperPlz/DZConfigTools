using DZConfigTools.Core.Generated;
using DZConfigTools.Core.Models.Values;

namespace DZConfigTools.Core.Factories; 

public static class RapLiteralFactory {
    public static IRapArrayEntry Create(ParamFileParser.LiteralOrArrayContext ctx) {
        if (ctx.literalArray() is { } array) return (IRapArrayEntry) new RapArray().ReadParseTree(array);
        if (ctx.literal() is { } literal) return (IRapArrayEntry) Create(literal);
        throw new Exception();
    }
    
    public static IRapLiteral Create(ParamFileParser.LiteralContext ctx) {
        if (ctx.literalString() is { } @string) return (IRapLiteral) new RapString().ReadParseTree(@string);
        if (ctx.literalFloat() is { } @float) return (IRapLiteral) new RapFloat().ReadParseTree(@float);
        if (ctx.literalInteger() is { } @int) return (IRapLiteral) new RapInteger().ReadParseTree(@int);
        throw new Exception();
    }
}