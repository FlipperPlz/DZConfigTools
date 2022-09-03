using Antlr4.Runtime;
using Ardalis.Result;
using DZConfigTools.Core.Factories;
using DZConfigTools.Core.Generated;
using DZConfigTools.Core.IO;
using DZConfigTools.Core.Models.Declarations;
using DZConfigTools.Core.Models.Statements;
using DZConfigTools.Core.Utils;

namespace DZConfigTools.Core.Models; 

public class ParamFile : IRapDeserializable<ParamFileParser.ComputationalStartContext> {
    public List<IRapStatement> Statements { get; set; } = new();
    
    public void WriteBinarized(BinaryWriter writer) {
        writer.Write(new byte[] {0x00, (byte) 'r', (byte) 'a', (byte) 'P'});
        writer.Write((uint) 0);
        writer.Write((uint) 8);
        var enumOffsetPosition = writer.BaseStream.Position;
        writer.Write((uint) 999999); //Write Enum offset. will be changed later
        
        W_WriteParentClasses(writer);
        W_WriteChildClasses(writer);
        var enumOffset = (uint) writer.BaseStream.Position;
        writer.BaseStream.Position = enumOffsetPosition;
        writer.Write(BitConverter.GetBytes(enumOffset), 0, 4);
        writer.BaseStream.Position = enumOffset;
        
        writer.Write((uint) 0);
    }

    private void W_WriteParentClasses(BinaryWriter writer) {
        writer.WriteAsciiZ();
        writer.WriteCompressedInt(Statements.Count);
        foreach (var statement in Statements) statement.WriteBinarized(writer);
    }

    private void W_WriteChildClasses(BinaryWriter writer) {
        foreach (var rapStatement in Statements.Where(s => s is RapClassDeclaration)) {
            W_SaveChildClasses(writer, (RapClassDeclaration)rapStatement);
        }
    }

    private void W_SaveChildClasses(BinaryWriter writer, RapClassDeclaration globalClazz) {
        globalClazz.BinaryOffset = (uint) writer.BaseStream.Position;
        writer.BaseStream.Position = globalClazz.BinaryOffsetPosition;
        writer.Write(BitConverter.GetBytes(globalClazz.BinaryOffset), 0, 4);
        writer.BaseStream.Position = globalClazz.BinaryOffset;
        writer.WriteAsciiZ(globalClazz.ParentClassname ?? string.Empty);
        writer.WriteCompressedInt(globalClazz.Statements.Count);
        globalClazz.Statements.Where(s => s is RapExternalClassStatement).ToList().ForEach(s => s.WriteBinarized(writer));
        globalClazz.Statements.Where(s => s is RapClassDeclaration).ToList().ForEach(s => s.WriteBinarized(writer));
        globalClazz.Statements.Where(s => s is RapDeleteStatement).ToList().ForEach(s => s.WriteBinarized(writer));
        globalClazz.Statements.Where(s => s is RapVariableDeclaration).ToList().ForEach(s => s.WriteBinarized(writer));
        globalClazz.Statements.Where(s => s is RapArrayDeclaration).ToList().ForEach(s => s.WriteBinarized(writer));
        globalClazz.Statements.Where(s => s is RapAppensionStatement).ToList().ForEach(s => s.WriteBinarized(writer));
        globalClazz.Statements.Where(s => s is RapClassDeclaration).ToList().ForEach(s => W_SaveChildClasses(writer, (RapClassDeclaration)s));
    }

    public string ToParseTree() => string.Join('\n', Statements.Select(s => s.ToParseTree()));

    public IRapDeserializable<ParamFileParser.ComputationalStartContext> ReadBinarized(BinaryReader reader) {
        var bits = reader.ReadBytes(4);
        if (!(bits[0] == '\0' && bits[1] == 'r' && bits[2] == 'a' && bits[3] == 'P')) throw new Exception("Invalid header.");
        if(reader.ReadUInt32() != 0 || reader.ReadUInt32() != 8) throw new Exception("Expected bytes 0 and 8.");
        var enumOffset = reader.ReadUInt32();
        if (!R_ReadParentClasses(reader)) Console.WriteLine("No parent classes were found.");
        if (!R_ReadChildClass(reader)) Console.WriteLine("No child classes were found.");
        //TODO: Read Enums
        return this;
    }

    private bool R_ReadParentClasses(BinaryReader reader) {
        reader.ReadAsciiZ();
        var parentEntryCount = reader.ReadCompressedInteger();

        for (var i = 0; i < parentEntryCount; ++i) {
            switch (reader.PeekChar()) {
                case 0:
                    Statements.Add((IRapStatement) new RapClassDeclaration().ReadBinarized(reader));
                    break;
                case 1:
                    Statements.Add((IRapStatement) new RapVariableDeclaration().ReadBinarized(reader));
                    break;
                case 2:
                    Statements.Add((IRapStatement) new RapArrayDeclaration().ReadBinarized(reader));
                    break;
                case 3:
                    Statements.Add((IRapStatement) new RapExternalClassStatement().ReadBinarized(reader));
                    break;
                case 4:
                    Statements.Add((IRapStatement) new RapDeleteStatement().ReadBinarized(reader));
                    break;
                case 5:
                    Statements.Add((IRapStatement) new RapAppensionStatement().ReadBinarized(reader));
                    break;
                default: throw new NotSupportedException();
            }
        }
        return parentEntryCount > 0;
    }

    private bool R_ReadChildClass(BinaryReader reader) {
        var funcCtx = Statements.Where(s => s is RapClassDeclaration).ToList();
        funcCtx.ForEach(c => R_LoadChildClasses(reader, (RapClassDeclaration) c));
        return funcCtx.Count > 0;
    }

    private static void R_LoadChildClasses(BinaryReader reader, RapClassDeclaration child) {
        reader.BaseStream.Position = child.BinaryOffset;
        var parent = reader.ReadAsciiZ();
        child.ParentClassname = (parent == string.Empty) ? null : parent;
        var entryCount = reader.ReadCompressedInteger();
        for (var i = 0; i < entryCount; ++i) R_AddEntryToClass(reader, child);

        child.Statements.Where(s => s is RapClassDeclaration).ToList().ForEach(c => R_LoadChildClasses(reader, (RapClassDeclaration) c));

    }

    private static void R_AddEntryToClass(BinaryReader reader, RapClassDeclaration child) {
        var entryType = reader.PeekChar();
        switch (entryType) {
            case 0:
                child.Statements.Add((IRapStatement) new RapClassDeclaration().ReadBinarized(reader));
                return;
            case 1:
                child.Statements.Add((IRapStatement) new RapVariableDeclaration().ReadBinarized(reader));
                return;
            case 2:
                child.Statements.Add((IRapStatement) new RapArrayDeclaration().ReadBinarized(reader));
                return;
            case 3:
                child.Statements.Add((IRapStatement) new RapExternalClassStatement().ReadBinarized(reader));
                return;
            case 4:
                child.Statements.Add((IRapStatement) new RapDeleteStatement().ReadBinarized(reader));
                return;
            case 5:
                child.Statements.Add((IRapStatement) new RapAppensionStatement().ReadBinarized(reader));
                return;
            default: throw new Exception();
        }
    }

    public void WriteToFile(string filePath, bool binarized = true) {
        WriteToStream(binarized).WriteTo(File.OpenWrite(filePath));
    }

    public MemoryStream WriteToStream(bool binarized = true) {
        var fs = new MemoryStream();
        var writer = new BinaryWriter(fs);
        if(binarized) WriteBinarized(writer);
        else foreach (var c in ToParseTree()) writer.Write(c);
        return fs;
    }

    public static Result<ParamFile> OpenStream(Stream stream) {
        var memStream = new MemoryStream();
        stream.CopyTo(memStream);
        memStream.Seek(0, SeekOrigin.Begin);
        using (var reader = new BinaryReader(memStream)) {
            var bits = reader.ReadBytes(4);
            reader.BaseStream.Position -= 4;

            if (bits[0] == '\0' && bits[1] == 'r' && bits[2] == 'a' && bits[3] == 'P') {
                return (ParamFile)new ParamFile().ReadBinarized(reader);
            }

            reader.BaseStream.Seek(0, SeekOrigin.Begin);
            reader.Close();
        }
        return ParseParamFile(stream);

    }

    public static Result<ParamFile> OpenFile(string filePath) {
        return OpenStream(File.OpenRead(filePath));
    }

    private static Result<ParamFile> ParseBinarizedParamFile(Stream stream) {
        try {
            using var reader = new BinaryReader(stream);
            return (ParamFile) new ParamFile().ReadBinarized(reader);
        }
        catch {
            return Result<ParamFile>.Error("There was an error reading a binarized paramfile");
        }
    }

    private static Result<ParamFile> ParseParamFile(Stream stream) {
        try {
            var lexer = new ParamFileLexer(CharStreams.fromStream(stream));
            var tokens = new CommonTokenStream(lexer);
            var parser = new ParamFileParser(tokens);
            var errorListener = new ParamFileErrorListener();
            
            parser.RemoveErrorListeners();
            parser.AddErrorListener(errorListener);
            
            var computationalStart = parser.computationalStart();
            
            if (errorListener.SyntaxErrors.Count != 0) {
                return Result<ParamFile>.Error(errorListener.SyntaxErrors.ToArray());
            }

            return (ParamFile) new ParamFile().ReadParseTree(computationalStart);
        } catch (Exception e) {
            return Result<ParamFile>.Error(e.Message);
        }
    }

    public IRapDeserializable<ParamFileParser.ComputationalStartContext> ReadParseTree(ParamFileParser.ComputationalStartContext ctx) {
        if (ctx.statement() is { } statements) Statements.AddRange(statements.Select(RapStatementFactory.Create));
        return this;
    }
}