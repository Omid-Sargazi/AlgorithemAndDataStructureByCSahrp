namespace CSharpExamples.LeetCode
{
    public class ContainerMostWater
    {
        public static int Run(int[] arr)
        {
            int maxArea = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    int heighMin = Math.Min(arr[i], arr[j]);
                    int width = j - i;
                    int area = width * heighMin;
                    maxArea = Math.Max(maxArea, area);
                }
            }

            return maxArea;

        }


        public static int TwoPointers(int[] arr)
        {
            int n = arr.Length - 1;
            int left = 0;
            int right = n;
            int maxArea = 0;

            while (left < right)
            {
                int width = right - left;
                int height = Math.Min(arr[left], arr[right]);
                int area = width * height;

                if (area > maxArea)
                {
                    maxArea = area;
                }

                if (arr[left] < arr[right])
                    left = left + 1;
                else
                {
                    right = right - 1;
                }
            }

            return maxArea;
        }
    }
}