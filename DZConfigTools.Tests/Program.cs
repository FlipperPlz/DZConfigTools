// See https://aka.ms/new-console-template for more information

using DZConfigTools.Core.Models;

using (var file = File.OpenRead(@"C:\Users\developer\Desktop\MinimalTestMod\config.cpp")) {
    var f = ParamFile.OpenStream(file);
    if (f.IsSuccess) {
        Console.WriteLine(f.Value.WriteToStream().ToArray().Length);
        Console.WriteLine("Monster Dong");
    }
    else {
        Console.WriteLine(string.Join("\n", f.Errors));
    }
}
