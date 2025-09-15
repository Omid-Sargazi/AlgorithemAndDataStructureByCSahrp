// See https://aka.ms/new-console-template for more information
using CSharpExamples.Example1;
using CSharpExamples.LeetCode;

Console.WriteLine("Hello, World!");
// await Cancelation.Run();

var nums = new int[] { 4, 5, 6, 7, 0, 1, 2 };
Console.WriteLine(MinimumRotatedSortedArray.Run(nums));