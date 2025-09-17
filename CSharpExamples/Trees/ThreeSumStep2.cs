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
            for (int i = 0; i < n-2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
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
                        while (left < right && nums[left] == nums[left - 1]) left++;
                        while (left < right && nums[right] == nums[right + 1]) right--;
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