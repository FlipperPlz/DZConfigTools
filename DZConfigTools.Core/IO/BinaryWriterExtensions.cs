namespace DZConfigTools.Core.IO; 

public static class BinaryWriterExtensions {
    public static void WriteCompressedInt(this BinaryWriter writer, int data) {
        do {
            var current = data % 0x80;
            data = (int) Math.Floor((decimal) (data / 0x80));
            if (data is not 0) current = current | 0x80; 
            writer.Write((byte) current);
        } while (data > 0x7F);

        if (data is not 0) {
            writer.Write((byte) data);
        }
    }
    
    public static void WriteAsciiZ(this BinaryWriter writer, string text = "") {
        writer.Write(text.ToCharArray());
        writer.Write(char.MinValue);
    }
}