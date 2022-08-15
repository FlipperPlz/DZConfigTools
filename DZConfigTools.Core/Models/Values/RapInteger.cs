using Antlr4.Runtime.Misc;
using DZConfigTools.Core.Generated;

namespace DZConfigTools.Core.Models.Values; 

public class RapInteger : IRapDeserializable<ParamFileParser.LiteralIntegerContext>, IRapLiteral, IRapArrayEntry {
    private int Value { get; set; } = 0;
    public static implicit operator RapInteger (int s) => new() { Value = s };
    public static implicit operator int (RapInteger s) => s.Value;
    public void WriteBinarized(BinaryWriter writer) => writer.Write(Value);
    public string ToParseTree() => Value.ToString();
    public IRapDeserializable<ParamFileParser.LiteralIntegerContext> ReadParseTree(ParamFileParser.LiteralIntegerContext ctx) { Value = int.Parse(ctx.Start.InputStream.GetText(new Interval(ctx.Start.StartIndex, ctx.Stop.StopIndex))); return this; }
    public IRapDeserializable<ParamFileParser.LiteralIntegerContext> ReadBinarized(BinaryReader reader) { Value = reader.ReadInt32(); return this; }
}