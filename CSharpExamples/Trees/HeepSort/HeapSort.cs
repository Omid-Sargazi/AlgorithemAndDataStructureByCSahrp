using System.IO.Pipelines;
using System.Security.Cryptography.X509Certificates;

namespace CSharpExamples.Trees.HeepSort
{
    public class HeapSort
    {
        public static void Run(int[] arr)
        {
            Console.WriteLine($"Before Heaping:{string.Join(",", arr)}");
            // Heapify(arr,0,arr.Length);
            BuildHeap(arr);
            SortHeap(arr);
            Console.WriteLine($"After Heaping:{string.Join(",", arr)}");
        }

        private static void BuildHeap(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, i, n);
            }
        }

        private static void SortHeap(int[] arr)
        {
            int n = arr.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                (arr[0], arr[i]) = (arr[i], arr[0]);
                Heapify(arr, 0, i);
            }
        }


        public static void Heapify(int[] arr, int i, int n)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                (arr[largest], arr[i]) = (arr[i], arr[largest]);
                Heapify(arr, largest, n);
            }

        }
    }


    public class SumThree
    {
       public static IList<IList<int>> result = new List<IList<int>>();
        public static IList<IList<int>> RunSumTree(int[] nums)
        {
            if (nums.Length < 3 && nums == null) return new List<IList<int>>();
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int left = i + 1, right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });
                        left++;
                        right--;

                        while (left < right && nums[left] == nums[left - 1])
                            left++;
                        while (left < right && nums[right] == nums[right + 1])
                            right--;
                    }
                    else if (sum < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return result;
        }
    }
}