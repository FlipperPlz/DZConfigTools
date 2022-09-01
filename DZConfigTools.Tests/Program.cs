// See https://aka.ms/new-console-template for more information

using DZConfigTools.Core.Models;

var f = ParamFile.OpenFile(@"C:\Users\developer\Desktop\config.cpp");
if (f.IsSuccess) {
    f.Value.WriteToFile(@"C:\Users\developer\Desktop\testing\fullconfig.cpp", false);
    f.Value.WriteToFile(@"C:\Users\developer\Desktop\testing\fullconfig.bin", false);
}
