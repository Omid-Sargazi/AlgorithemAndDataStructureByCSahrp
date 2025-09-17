using System.Reflection;

namespace CSharpExamples.Trees
{
    public class ThreeSumStep2
    {
        public static void ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            Console.WriteLine("Sorted array:" + string.Join(",", nums));

            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                int left = i + 1;
                int right = n - 1;

                while (left < right)
                {
                   int sum = nums[i] + nums[left] + nums[right];
                Console.WriteLine($"Fix nums[{i}]={nums[i]},left={left},right={right}");

                if (sum == 0)
                {
                    Console.WriteLine($"✅ Found triplet: [{nums[i]}, {nums[left]}, {nums[right]}]");
                    left++;
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
        }

        public static void Run(int[] arr)
        {
            ThreeSum(arr);
        }

        
    }
}