namespace PerfPlayground
{
    public sealed class StopwatchMetrics {
    public T Measure<T>(ILogger log, string name, Func<T> work) {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        var result = work();
        sw.Stop();
        log.LogInformation("{Name} took {Ms} ms", name, sw.ElapsedMilliseconds);
        return result;
    }
    public async Task<T> MeasureAsync<T>(ILogger log, string name, Func<Task<T>> work) {
        var sw = System.Diagnostics.Stopwatch.StartNew();
        var result = await work();
        sw.Stop();
        log.LogInformation("{Name} took {Ms} ms", name, sw.ElapsedMilliseconds);
        return result;
    }
}
}