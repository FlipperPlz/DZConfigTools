using System.Text;
using Antlr4.Runtime.Misc;
using DZConfigTools.Core.Generated;
using DZConfigTools.Core.IO;
using DZConfigTools.Core.Models.Statements;
using DZConfigTools.Core.Models.Values;

namespace DZConfigTools.Core.Models.Declarations; 

public class RapArrayDeclaration :  IRapStatement, IRapDeserializable<ParamFileParser.ArrayDeclarationContext> {
    private string ArrayName { get; set; } = string.Empty;
    private RapArray ArrayValue { get; set; } = new();
    
    public void WriteBinarized(BinaryWriter writer) {
        writer.Write((byte) 2);
        writer.WriteAsciiZ(ArrayName);
        ArrayValue.WriteBinarized(writer);
    }

    public string ToParseTree() => new StringBuilder(ArrayName).Append("[] = ").Append(ArrayValue.ToParseTree()).Append(';').ToString();

    public IRapDeserializable<ParamFileParser.ArrayDeclarationContext> ReadBinarized(BinaryReader reader) {
        if (reader.ReadByte() != 2) throw new Exception("Expected external class.");
        ArrayName = reader.ReadAsciiZ();
        ArrayValue.ReadBinarized(reader);
        return this;
    }

    public IRapDeserializable<ParamFileParser.ArrayDeclarationContext> ReadParseTree(ParamFileParser.ArrayDeclarationContext ctx) {
        if (ctx.arrayName() is not { } arrayNameCtx) throw new Exception();
        if (ctx.literalArray() is not { } literalArrayCtx) throw new Exception();
        var name = arrayNameCtx.identifier() ?? throw new Exception();
        ArrayName = ctx.Start.InputStream.GetText(new Interval(name.Start.StartIndex, name.Stop.StopIndex));
        ArrayValue.ReadParseTree(literalArrayCtx);
        return this;
    }
}