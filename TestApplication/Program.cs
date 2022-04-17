// See https://aka.ms/new-console-template for more information
using TextFilter;

Console.WriteLine($"File Filter Demonstration.");
Console.WriteLine($"Please type path.");

var filePath = Console.ReadLine();

var output = new FileTextFilter(filePath).Filter();
Console.WriteLine(output);
Console.ReadLine();
