using System.Text;
using DZConfigTools.Core.Factories;
using DZConfigTools.Core.Generated;
using DZConfigTools.Core.IO;
using DZConfigTools.Core.Models.Statements;

namespace DZConfigTools.Core.Models.Declarations; 

public class RapClassDeclaration : IRapStatement, IRapDeserializable<ParamFileParser.ClassDeclarationContext> {
    public string Classname { get; set; } = string.Empty;
    public string? ParentClassname { get; set; } = null;
    public List<IRapStatement> Statements { get; set; } = new();

    public uint BinaryOffset { get; set; } = 0;
    public long BinaryOffsetPosition { get; set; } = 0;
    
    public void WriteBinarized(BinaryWriter writer) {
        writer.Write((byte) 0);
        writer.WriteAsciiZ(Classname);
        BinaryOffsetPosition = writer.BaseStream.Position;
        writer.Write((uint) BinaryOffset);
    }

    public string ToParseTree() {
        var builder = new StringBuilder("class ").Append(Classname);
        if (ParentClassname is not null) builder.Append(" : ").Append(ParentClassname);
        builder.Append(" {\n");
        Statements.ForEach(s => builder.Append(s.ToParseTree()).Append('\n'));
        return builder.Append("};").ToString();
    }

    public IRapDeserializable<ParamFileParser.ClassDeclarationContext> ReadBinarized(BinaryReader reader) {
        if ( reader.ReadByte() != 0) throw new Exception($"Expected class.");
        Classname = reader.ReadAsciiZ();
        BinaryOffsetPosition = reader.BaseStream.Position;
        BinaryOffset = reader.ReadUInt32();
        return this;
    }

    public IRapDeserializable<ParamFileParser.ClassDeclarationContext> ReadParseTree(ParamFileParser.ClassDeclarationContext ctx) {
        if (ctx.classname is not { } classname) throw new Exception();
        Classname = classname.GetText();
        if (ctx.superclass is { } superclass) ParentClassname = superclass.GetText();
        if (ctx.statement() is { } statements) Statements.AddRange(statements.Select(RapStatementFactory.Create));
        return this;
    }
}