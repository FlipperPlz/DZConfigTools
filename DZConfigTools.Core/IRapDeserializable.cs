using Antlr4.Runtime;

namespace DZConfigTools.Core;

public interface IRapDeserializable<in T> : IRapSerializable where T : ParserRuleContext {
    public IRapDeserializable<T> ReadBinarized(BinaryReader reader);
    public IRapDeserializable<T> ReadParseTree(T ctx);
}