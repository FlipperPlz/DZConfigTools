using System.Text;
using DZConfigTools.Core.Factories;
using DZConfigTools.Core.Generated;
using DZConfigTools.Core.IO;
using DZConfigTools.Core.Models.Statements;
using DZConfigTools.Core.Models.Values;

namespace DZConfigTools.Core.Models.Declarations; 

public class RapVariableDeclaration : IRapStatement, IRapDeserializable<ParamFileParser.TokenDeclarationContext> {
    private string VariableName { get; set; } = string.Empty;
    private IRapLiteral VariableValue { get; set; } = new RapString();

    public void WriteBinarized(BinaryWriter writer) {
        writer.Write((byte) 1);
        switch (VariableValue) {
            case RapString @string:
                writer.Write((byte) 0);
                writer.WriteAsciiZ(VariableName);
                @string.WriteBinarized(writer);
                break;
            case RapFloat @float:
                writer.Write((byte) 1);
                writer.WriteAsciiZ(VariableName);
                @float.WriteBinarized(writer);
                break;
            case RapInteger @int:
                writer.Write((byte) 2);
                writer.WriteAsciiZ(VariableName);
                @int.WriteBinarized(writer);
                break;
            default: throw new NotSupportedException();
        }
    }

    public string ToParseTree() => new StringBuilder(VariableName).Append(" = ").Append(VariableValue.ToParseTree()).Append(';').ToString();

    public IRapDeserializable<ParamFileParser.TokenDeclarationContext> ReadBinarized(BinaryReader reader) {
        if (reader.ReadByte() != 1) throw new Exception("Expected token.");
        var valType = reader.ReadByte();
        VariableName = reader.ReadAsciiZ();
        switch (valType) {
            case 0:
                VariableValue = (IRapLiteral) new RapString().ReadBinarized(reader);
                return this;
            case 1:
                VariableValue = (IRapLiteral) new RapFloat().ReadBinarized(reader);
                return this;
            case 2:
                VariableValue = (IRapLiteral) new RapInteger().ReadBinarized(reader);
                return this;
            default: throw new Exception();
        }
    }

    public IRapDeserializable<ParamFileParser.TokenDeclarationContext> ReadParseTree(ParamFileParser.TokenDeclarationContext ctx) {
        if (ctx.identifier() is not { } identifier) throw new Exception();
        if (ctx.value is not { } value) throw new Exception();
        VariableName = ctx.identifier().GetText();
        VariableValue = RapLiteralFactory.Create(value);
        return this;
    }
}