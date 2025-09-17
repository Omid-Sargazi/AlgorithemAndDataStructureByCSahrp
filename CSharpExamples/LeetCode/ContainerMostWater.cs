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
    }
}