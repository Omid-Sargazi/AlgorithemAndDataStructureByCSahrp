namespace CSharpExamples.Example1
{
    public class TwoSumSortedArray
    {
        public static List<int> Run(int[] arr, int target)
        {
            var result = new List<int>();
            int left = 0;
            int right = arr.Length - 1;
            while (left < right)
            {
                int sum = arr[left] + arr[right];
                if (sum == target)
                {
                    result.Add(left);
                    result.Add(right);
                    left++;
                    right--;
                }
                else if (sum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return result;
        }
    }
}