// See https://aka.ms/new-console-template for more information
using Algorithems.Sorting;

Console.WriteLine("Hello, World!");
var arr = new int[] { 1, 2, 37, 8, 70, -70, -90, 12, 0, 0 };
// Sortings.Bubble(arr);
// Sortings.Selection(arr);
// Sortings.Insertion(arr);
// Sortings.QuickSort(arr,0,arr.Length -1);
var res = Sortings.RunQuickSort(arr);
Console.WriteLine($"{string.Join(",", res)}");