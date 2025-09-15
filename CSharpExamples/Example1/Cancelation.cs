namespace CSharpExamples.Example1
{
    public class Cancelation
    {
        public async static Task Run()
        {
            using var cts = new CancellationTokenSource();

            cts.Cancel();
            var task = DoWorkAsync(cts.Token);

            await Task.Delay(500);

            await task;
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
    }
}