// See https://aka.ms/new-console-template for more information
using CSharpExamples.Example1;
using CSharpExamples.LeetCode;
using CSharpExamples.Trees;
using CSharpExamples.Trees.HeepSort;

Console.WriteLine("Hello, World!");
// await Cancelation.Run();

var nums = new int[] { 4, 5, 6, 7, 0, 1, 2,3 };
// Console.WriteLine(MinimumRotatedSortedArray.Run(nums));
// Console.WriteLine(SearchRotatedSortedArray.Run(nums, 0));
// BinaryTree.RunTreeNode();

int[] arr1 = new int[] { 1, 2, 3 };
int[] arr2 = new int[] { 1, 3, -1 };
int[] arr3 = new int[] { -1,0,1,2,-1,-4};
// HeapSort.Run(arr2);

// var result = SumThree.RunSumTree(arr3);

// Console.WriteLine($"Result:{string.Join(" | ", result.Select(r => string.Join(",", r)))}");

ThreeSumStep2.Run(arr3);