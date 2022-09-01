using Antlr4.Runtime.Misc;
using DZConfigTools.Core.Generated;

namespace DZConfigTools.Core.Models.Values; 

public class RapFloat : IRapDeserializable<ParamFileParser.LiteralFloatContext>, IRapLiteral, IRapArrayEntry {
    public float Value { get; set; } = 0.0f;
    public static implicit operator RapFloat (float s) => new() { Value = s };
    public static implicit operator float (RapFloat s) => s.Value;
    public void WriteBinarized(BinaryWriter writer) => writer.Write(Value);
    public string ToParseTree() => Value.ToString("G");
    public IRapDeserializable<ParamFileParser.LiteralFloatContext> ReadParseTree(ParamFileParser.LiteralFloatContext ctx) { Value = float.Parse(ctx.Start.InputStream.GetText(new Interval(ctx.Start.StartIndex, ctx.Stop.StopIndex))); return this; }
    public IRapDeserializable<ParamFileParser.LiteralFloatContext> ReadBinarized(BinaryReader reader) { Value = reader.ReadSingle(); return this; }
}