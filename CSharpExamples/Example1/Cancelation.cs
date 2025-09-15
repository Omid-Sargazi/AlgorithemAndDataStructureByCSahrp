using System.Runtime.InteropServices;

namespace CSharpExamples.Example1
{
    public class Cancelation
    {
        public async static Task Run()
        {
            using var cts = new CancellationTokenSource();
            // cts.CancelAfter(TimeSpan.FromSeconds(3));


            // cts.Cancel();
            // var task = DoWorkAsync(cts.Token);

            // await Task.Delay(500);

            // await task;

            var nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var task = PrintNumbersAsync(nums, cts.Token);
            Console.WriteLine("Press enter to cancel...");
            _ = Task.Run(() =>
            {
                Console.ReadKey();
                cts.Cancel();
            });

            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                
                Console.WriteLine("Task was cancelled.");
            }



        }


        public static async Task DoWorkAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                Console.WriteLine("Working...");
                await Task.Delay(1000);
            }

            Console.WriteLine("Calcelled");
        }

        public static async Task PrintNumbersAsync(List<int> nums, CancellationToken ct)
        {
            foreach (var n in nums)
            {
                ct.ThrowIfCancellationRequested();
                Console.WriteLine(n);
                await Task.Delay(1000, ct);
            }
        }
        
    }
}