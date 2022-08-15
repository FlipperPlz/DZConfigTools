// See https://aka.ms/new-console-template for more information

using DZConfigTools.Core.Models;

var f = ParamFile.OpenFile(@"C:\Program Files (x86)\Steam\steamapps\common\DayZ Tools\Bin\CfgConvert\fullconfig.bin");
f.WriteToFile(@"C:\Users\developer\Desktop\testing\fullconfig.cpp", false);
f.WriteToFile(@"C:\Users\developer\Desktop\testing\fullconfig.bin", true);
