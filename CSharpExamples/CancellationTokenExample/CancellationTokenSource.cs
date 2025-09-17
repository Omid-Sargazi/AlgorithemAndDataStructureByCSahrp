using System;
using System.Threading;

namespace CSharpExamples.CancellationTokenExample
{
    public class CancellationTokenSource : IDisposable
    {
        public static async Task Run()
        {
            using var cts = new System.Threading.CancellationTokenSource();


            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            try
            {
                await PrintNumbersAsync(numbers, cts.Token);
            }
            catch (OperationCanceledException)
            {
                
                Console.WriteLine("Task was cancelled.");
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public static async Task PrintNumbersAsync(List<int> nums, CancellationToken cancellationToken)
        {
            foreach (var n in nums)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Console.WriteLine($"Number is: {n}");
                await Task.Delay(500,cancellationToken);
            }
        }
        

    }
}