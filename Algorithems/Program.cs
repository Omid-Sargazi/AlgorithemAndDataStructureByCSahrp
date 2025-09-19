// See https://aka.ms/new-console-template for more information
using Algorithems.LeetCode;
using Algorithems.Sorting;

Console.WriteLine("Hello, World!");
var arr = new int[] { 1, 2, 37, 8, 70, -70, -90, 12, 0, 0 };

var arr2 = new int[] { 1, 2, 3 };
// Sortings.Bubble(arr);
// Sortings.Selection(arr);
// Sortings.Insertion(arr);
// Sortings.QuickSort(arr,0,arr.Length -1);
// var res = Sortings.RunQuickSort(arr);
// Console.WriteLine($"{string.Join(",", res)}");

// Sortings.RunMergeSort(arr);

// Sortings.RunHeapify(arr);
// var nums = new int[] { 4, 5, 6, 7, 0, 1, 2,3 };

// Console.WriteLine(MinimumRotatedSortedArray.Run(nums,0));

Action SayHello = (() => Console.WriteLine("Hello"));

Func<int, string> sayHello = ((int n) => $"Hello");
Console.WriteLine(sayHello(1));

Func<int, int, string> add = (a, b) => $"Sum{a + b}";
string res = add(5, 3);
Console.WriteLine(res);