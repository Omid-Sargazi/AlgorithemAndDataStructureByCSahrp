namespace Algorithems.Sorting
{
    public class Sortings
    {
        public static void Bubble(int[] arr)
        {
            for (int start = arr.Length - 1; start >= 0; start--)
            {
                bool swapped = false;
                for (int j = 0; j < start; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }

            Console.WriteLine($"{string.Join(",", arr)}");
        }

        public static void Selection(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
                }
            }

            Console.WriteLine($"{string.Join(",", arr)}");
        }

        public static void Insertion(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int j = i - 1;
                int current = arr[i];
                while (j >= 0 && arr[j] > current)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = current;
            }

            Console.WriteLine($"{string.Join(",", arr)}");
        }

        public static int[] QuickSort(int[] arr, int lo, int hi)
        {
            if (lo <= hi)
            {
                var pi = Partition(arr, lo, hi);
                QuickSort(arr, lo, pi - 1);
                QuickSort(arr, pi + 1, hi);
            }
            return arr;
        }

        private static int Partition(int[] arr, int lo, int hi)
        {
            int pivot = arr[hi];
            int i = lo - 1;
            for (int j = lo; j < hi; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    (arr[j], arr[i]) = (arr[i], arr[j]);
                }
            }
            (arr[i + 1], arr[hi]) = (arr[hi], arr[i + 1]);

            return i + 1;
        }

        public static int[] RunQuickSort(int[] arr)
        {
            var res = QuickSort(arr, 0, arr.Length - 1);
            return res;
        }


        public static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return arr;
            int n = arr.Length;
            int mid = n / 2;
            int[] left = new int[mid];
            int[] right = new int[n - mid];

            Array.Copy(arr, 0, left, 0, mid);
            Array.Copy(arr, mid, right, 0, right.Length);
            // Console.WriteLine($"Left: {string.Join(",", left)}");
            // Console.WriteLine($"Right: {string.Join(",", right)}");

            MergeSort(left);
            MergeSort(right);
            var res = Merge(arr, left, right);
            Console.WriteLine($"Merged: {string.Join(",", res)}");
            return res;
        }

        private static int[] Merge(int[] result, int[] left, int[] right)
        {
            int p1 = 0, p2 = 0, p3 = 0;
            int n1 = left.Length, n2 = right.Length;

            while (p1 < n1 && p2 < n2)
            {
                if (left[p1] < right[p2])
                {
                    result[p3] = left[p1];
                    p1++;
                }
                else
                {
                    result[p3] = right[p2];
                    p2++;
                }
                p3++;
            }

            while (p1 < n1)
            {
                result[p3] = left[p1];
                p3++;
                p1++;
            }
            while (p2 < n2)
            {
                result[p3] = right[p2];
                p3++;
                p2++;
            }

            return result;
        }

        public static void RunMergeSort(int[] arr)
        {
             Console.WriteLine($"Original array: {string.Join(",", arr)}");
            var res = MergeSort(arr);
            Console.WriteLine($"Final sorted array: {string.Join(",", res)}");
        }
        
    }
}