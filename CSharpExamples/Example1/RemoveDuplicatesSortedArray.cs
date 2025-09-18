namespace CSharpExamples.Example1
{
    public class RemoveDuplicatesSortedArray
    {
        public static int Run(int[] arr)
        {
            int i = 0;
            for (int j = 1; j < arr.Length; j++)
            {
                if (arr[i] != arr[j])
                {
                    i++;
                    arr[i] = arr[j];
                }
            }
            return i+1;
        }
    }
}