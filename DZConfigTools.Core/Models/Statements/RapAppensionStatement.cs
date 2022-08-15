using System.Text;
using Antlr4.Runtime.Misc;
using DZConfigTools.Core.Generated;
using DZConfigTools.Core.IO;
using DZConfigTools.Core.Models.Values;

namespace DZConfigTools.Core.Models.Statements; 

public class RapAppensionStatement : IRapStatement, IRapDeserializable<ParamFileParser.ArrayAppensionContext> {
    private string Target { get; set; } = string.Empty;
    private RapArray Array { get; set; } = new();
    
    public void WriteBinarized(BinaryWriter writer) {
        writer.Write((byte) 5);
        writer.Write((int) 1);
        writer.WriteAsciiZ(Target);
        Array.WriteBinarized(writer);
    }

    public string ToParseTree() => new StringBuilder(Target).Append("[] += ").Append(Array.ToParseTree()).Append(';').ToString();

    public IRapDeserializable<ParamFileParser.ArrayAppensionContext> ReadBinarized(BinaryReader reader) {
        if (reader.ReadByte() != 5) throw new Exception("Expected array appension.");
        if (reader.ReadInt32() != 1) throw new Exception("Expected array appension. (1)");
        Target = reader.ReadAsciiZ();
        Array.ReadBinarized(reader);
        return this;
    }

    public IRapDeserializable<ParamFileParser.ArrayAppensionContext> ReadParseTree(ParamFileParser.ArrayAppensionContext ctx) {
        if (ctx.arrayName() is not { } arrayNameCtx) throw new Exception();
        if (ctx.literalArray() is not { } literalArrayCtx) throw new Exception();
        Target = ctx.Start.InputStream.GetText(new Interval(arrayNameCtx.Start.StartIndex, arrayNameCtx.Stop.StopIndex));
        Array.ReadParseTree(literalArrayCtx);
        return this;
    }
}