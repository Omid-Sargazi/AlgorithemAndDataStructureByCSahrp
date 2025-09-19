namespace Algorithems.LeetCode
{
    public class Yeilds
    {
        public static IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
        }

        public static List<int> GetData()
        {
            var List = new List<int>();
            for (int i = 0; i < 1_000_0; i++)
            {
                List.Add(i);
            }

            return List;
        }

        public static IEnumerable<int> GetDataWithYeild()
        {
            for (int i = 0; i < 1_000_0; i++)
                yield return i;
        }
    }
}