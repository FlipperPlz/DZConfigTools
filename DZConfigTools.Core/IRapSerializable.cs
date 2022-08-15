using System.Text;

namespace DZConfigTools.Core;

public interface IRapSerializable {
    public void WriteBinarized(BinaryWriter writer);
    public string ToParseTree();
}