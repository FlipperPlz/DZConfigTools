using System.Text;
using Antlr4.Runtime.Misc;
using DZConfigTools.Core.Generated;
using DZConfigTools.Core.IO;

namespace DZConfigTools.Core.Models.Statements; 

public class RapDeleteStatement : IRapStatement, IRapDeserializable<ParamFileParser.DeleteStatementContext> {
    private string Target { get; set; } = string.Empty;

    public void WriteBinarized(BinaryWriter writer) {
        writer.Write((byte) 4);
        writer.WriteAsciiZ(Target);
    }

    public string ToParseTree() => new StringBuilder("delete ").Append(Target).Append(';').ToString();

    public IRapDeserializable<ParamFileParser.DeleteStatementContext> ReadBinarized(BinaryReader reader) {
        if (reader.ReadByte() != 4) throw new Exception("Expected delete statement.");
        Target = reader.ReadAsciiZ();
        return this;
    }

    public IRapDeserializable<ParamFileParser.DeleteStatementContext> ReadParseTree(ParamFileParser.DeleteStatementContext ctx) {
        if (ctx.identifier() is not { } identifier) throw new Exception("Nothing was given to delete.");
        Target = ctx.Start.InputStream.GetText(new Interval(identifier.Start.StartIndex, identifier.Stop.StopIndex));
        return this;
    }
}