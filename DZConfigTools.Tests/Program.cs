// See https://aka.ms/new-console-template for more information

using DZConfigTools.Core.Models;
var f = ParamFile.OpenFile(@"C:\Users\developer\Desktop\config.bin");
if (f.IsSuccess) {
    Console.WriteLine(f.Value.WriteToStream().ToArray().Length);
    Console.WriteLine("Monster Dong");
}
else {
    Console.WriteLine(string.Join("\n", f.Errors));
}