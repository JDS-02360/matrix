/*

TODO:
    Implement multiplication - DONE
    Implement addition - DONE
    Split output matrix on arrays (m1[0], m1[1]) - DONE
    Write exceptions to log file - DONE
    Add zeroes to beginning of numbers, up to the longest number of digits in the column - DONE
        05 21 048
        37 09 110
        02 70 006
    Get input matrices from user

*/

using System.Text;

int[][] m1 = [
    [0, 1, 3],
    [4, 2, 5],
    [9, 6, 1]
];

int[][] m2 = [
    [8, 3, 4],
    [2, 5, 0],
    [1, 6, 7]
];

// Replace with wherever you want log.txt to go
string path = "./log.txt";

void ExceptionLog(Exception e)
{
    using (StreamWriter streamWriter = new(path, true))
    {
        streamWriter.WriteLine(e);
    }
}

int[][] MatrixMultiply(int[][] m1, int[][] m2)
{
    int[][] output = new int[m1.Length][];

    try
    {
        for (int idx = 0; idx < output.Length; idx++)
        {
            output[idx] = new int[m1[idx].Length];
        }

        int rowIdx = 0;
        
        foreach (int[] row in m1)
        {
            int colIdx = 0;
            
            foreach (int num in row)
            {
                int sum = 0;
                
                for (int idx = 0; idx < m1[0].Length; idx++)
                {
                    sum += m1[rowIdx][idx] * m2[idx][colIdx];
                }

                output[rowIdx][colIdx] = sum;

                colIdx++;
            }

            rowIdx++;
        }
    }
    catch (Exception e)
    {
        ExceptionLog(e);
    }

    return output;
}

int[][] MatrixAdd(int[][] m1, int[][] m2)
{
    int[][] output = new int[m1.Length][];

    try
    {
        for (int idx = 0; idx < output.Length; idx++)
        {
            output[idx] = new int[m1[idx].Length];
        }

        for (int i = 0; i < m1.Length; i++)
        {
            for (int j = 0; j < m1[i].Length; j++)
            {
                output[i][j] = m1[i][j] + m2[i][j];
            }
        }
    }
    catch (Exception e)
    {
        ExceptionLog(e);
    }

    return output;
}

void MatrixWrite(int[][] m)
{
    try
    {
        string[][] output = new string[m.Length][];
        string[][] columns = new string[m.Length][];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = new string[m[i].Length];
            columns[i] = new string[m[i].Length];
        }

        for (int i = 0; i < m.Length; i++)
        {
            for (int j = 0; j < m[i].Length; j++)
            {
                output[i][j] = m[i][j].ToString();
            }
        }

        for (int i = 0; i < output.Length; i++)
        {
            for (int j = 0; j < output[i].Length; j++)
            {
                for (int k = 0; k < output.Length; k++)
                {
                    columns[k][j] = output[j][k];
                }
            }
        }

        string[] longest = new string[columns.Length];

        /*
        
        Get longest string in column and store in variable so that I can check if string is shorter than it
        If so, append 0 to the beginning of it, and check again

        */

        for (int i = 0; i < columns.Length; i++)
        {
            for (int j = 0; j < columns[i].Length; j++)
            {
                longest[i] = columns[i].OrderByDescending(s => s.Length).First();
            }
        }

        for (int i = 0; i < columns.Length; i++)
        {
            for (int j = 0; j < columns[i].Length; j++)
            {
                StringBuilder stringBuilder = new(columns[i][j]);

                while (columns[i][j].Length < longest[i].Length)
                {
                    columns[i][j] = stringBuilder.Insert(0, "0").ToString();
                }
            }
        }

        for (int i = 0; i < columns.Length; i++)
        {
            for (int j = 0; j < columns[i].Length; j++)
            {
                for (int k = 0; k < columns.Length; k++)
                {
                    output[k][j] = columns[j][k];
                }
            }
        }

        foreach (string[] row in output)
        {
            foreach (string str in row)
            {
                Console.Write($"{str} ");
            }

            Console.WriteLine();
        }

        // So that there is a gap between output matrices
        Console.WriteLine();
    }
    catch (Exception e)
    {
        ExceptionLog(e);
    }
}

int[][] m3 = MatrixMultiply(m1, m2);
int[][] m4 = MatrixAdd(m1, m2);

MatrixWrite(m3);
MatrixWrite(m4);
