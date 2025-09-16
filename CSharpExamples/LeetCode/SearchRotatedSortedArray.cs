namespace CSharpExamples.LeetCode
{
    public class SearchRotatedSortedArray
    {
        public static int Run(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Length - 1;

            
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] == target) return mid;
                if (arr[mid] >= arr[left])
                {
                    if (target >= arr[left] && target < arr[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    if (target > arr[mid] && target <= arr[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

            }

            return -1;
        }
    }
}