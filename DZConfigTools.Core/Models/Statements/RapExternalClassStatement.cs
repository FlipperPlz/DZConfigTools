using System.Text;
using Antlr4.Runtime.Misc;
using DZConfigTools.Core.Generated;
using DZConfigTools.Core.IO;
using DZConfigTools.Core.Models.Statements;

namespace DZConfigTools.Core.Models.Statements; 

public class RapExternalClassStatement : IRapStatement, IRapDeserializable<ParamFileParser.ExternalClassDeclarationContext> {
    public string Classname { get; set; } = string.Empty;
    
    public void WriteBinarized(BinaryWriter writer) {
        writer.Write((byte) 3);
        writer.WriteAsciiZ(Classname);
    }

    public string ToParseTree() => new StringBuilder("class ").Append(Classname).Append(';').ToString();

    public IRapDeserializable<ParamFileParser.ExternalClassDeclarationContext> ReadBinarized(BinaryReader reader) {
        if (reader.ReadByte() != 4) throw new Exception("Expected external class.");
        Classname = reader.ReadAsciiZ();
        return this;
    }

    public IRapDeserializable<ParamFileParser.ExternalClassDeclarationContext> ReadParseTree(ParamFileParser.ExternalClassDeclarationContext ctx) {
        if (ctx.classname is not { } classname) throw new Exception();
        Classname = ctx.Start.InputStream.GetText(new Interval(classname.Start.StartIndex, classname.Stop.StopIndex));
        return this;
    }
}