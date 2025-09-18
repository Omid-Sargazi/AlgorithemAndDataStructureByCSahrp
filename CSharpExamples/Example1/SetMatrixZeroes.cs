namespace CSharpExamples.Example1
{
    public class SetMatrixZeroes
    {
        public static void Run(int[][] matrix)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;

            HashSet<int> rowsToZero = new HashSet<int>();
            HashSet<int> colsToZero = new HashSet<int>();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rowsToZero.Add(i);
                        colsToZero.Add(j);
                    }
                }
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (rowsToZero.Contains(i) || colsToZero.Contains(j))
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }
    }

}