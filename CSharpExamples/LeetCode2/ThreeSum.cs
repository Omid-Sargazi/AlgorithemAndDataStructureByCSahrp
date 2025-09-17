using System.IO.Pipelines;
using System.Security.AccessControl;

namespace CSharpExamples.LeetCode2
{
    public class ThreeSum2
    {
        public IList<IList<int>> result = new List<IList<int>>();
        public IList<IList<int>> RunThreeSum2(int[] nums)
        {
            if (nums == null || nums.Length < 3)
            {
                return result;
            }

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                int left = i + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];

                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });
                        left++;
                        right--;

                        while (left < right && nums[left] == nums[left - 1])
                        {
                            left++;
                        }
                        while (left < right && nums[right] == nums[right + 1])
                        {
                            right--;
                        }
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