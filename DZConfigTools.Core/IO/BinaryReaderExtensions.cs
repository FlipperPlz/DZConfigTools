using System.Text;

namespace DZConfigTools.Core.IO; 

public static class BinaryReaderExtensions {
    public static int ReadCompressedInteger(this BinaryReader reader) {
        var value = 0;
        for (var i = 0;; ++i) {
            var v = reader.ReadByte();
            value |= v & 0x7F << (7 * i);
            if((v & 0x80) == 0) break;
        }

        return value;
    }
    
    public static string ReadAsciiZ(this BinaryReader reader) {
        var builder = new StringBuilder();
        char c;
        while ((c = (char)reader.ReadByte()) != '\0') builder.Append(c);
        return builder.ToString();
    }
}