using System.Text;
using Antlr4.Runtime.Misc;
using DZConfigTools.Core.Generated;
using DZConfigTools.Core.IO;

namespace DZConfigTools.Core.Models.Values; 

public class RapString : IRapDeserializable<ParamFileParser.LiteralStringContext>, IRapLiteral, IRapArrayEntry {
    private string Value { get; set; } = string.Empty;
    public static implicit operator RapString(string s) => new() { Value = s };
    public static implicit operator string(RapString s) => s.Value;
    public void WriteBinarized(BinaryWriter writer) => writer.WriteAsciiZ(Value);
    public string ToParseTree() => new StringBuilder().Append('"').Append(Value).Append('"').ToString();

    public IRapDeserializable<ParamFileParser.LiteralStringContext> ReadBinarized(BinaryReader reader) {
        Value = reader.ReadAsciiZ(); 
        return this;
    }

    public IRapDeserializable<ParamFileParser.LiteralStringContext> ReadParseTree(ParamFileParser.LiteralStringContext ctx) {
        Value = ctx.Start.InputStream.GetText(new Interval(ctx.Start.StartIndex, ctx.Stop.StopIndex)).TrimStart('"').TrimEnd('"');
        return this;
    }
}