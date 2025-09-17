namespace CSharpExamples.Trees.HeepSort
{
    public class HeapSort
    {
        public static void Run(int[] arr)
        {
            Console.WriteLine($"Before Heaping:{string.Join(",", arr)}");
            // Heapify(arr,0,arr.Length);
            BuildHeap(arr);
            Console.WriteLine($"After Heaping:{string.Join(",", arr)}");
        }

        private static void BuildHeap(int[] arr)
        {
            int n = arr.Length;
            for (int i = n - 1; i >= 0; i--)
            {
                Heapify(arr, i, n);
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
}