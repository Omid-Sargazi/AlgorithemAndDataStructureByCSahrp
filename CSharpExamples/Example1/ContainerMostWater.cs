namespace CSharpExamples.Example1
{
    public class ContainerMostWater2
    {
        public static int Run(int[] arr)
        {
            int n = arr.Length - 1;
            int left = 0;
            int right = n;
            int maxArea = 0;

            while (left < right)
            {
                int width = right - left;
                int hieght = Math.Min(arr[left], arr[right]);
                int area = width * hieght;

                if (area > maxArea)
                    maxArea = area;
                if (arr[left] < arr[hieght])
                    left++;
                else
                {
                    right--;
                }
            }

            return maxArea;
        }
    }
}